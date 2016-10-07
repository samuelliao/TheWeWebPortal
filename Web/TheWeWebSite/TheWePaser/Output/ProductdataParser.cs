using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using TheWeLib;
using TheWeLib.DbControl;

namespace TheWeParser.Output
{
    class ProductdataParser
    {
        GeneralDbDAO GenDbCon;
        Utility Util;
        XSSFWorkbook WORKBOOK;
        XSSFSheet WORKSHEET;
        List<List<DbSearchObject>> ProductLvPrice;
        List<List<DbSearchObject>> ProductInfo;
        List<List<DbSearchObject>> ProductForStore;

        public ProductdataParser(string dbConnStr)
        {
            GenDbCon = new GeneralDbDAO(dbConnStr);
            Util = new Utility();
            ProductForStore = new List<List<DbSearchObject>>();
            ProductInfo = new List<List<DbSearchObject>>();
            ProductLvPrice = new List<List<DbSearchObject>>();
        }

        public bool FileReader(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        WORKBOOK = new XSSFWorkbook(fs);
                    }
                    return WORKBOOK != null;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else return false;
        }

        public void GetProductDbList()
        {
            DataSet pds = null;
            DataSet chDs = null;
            DataSet storePrice = null;
            string productid = "";
            string productName = "";
            string churchName = "";
            List<DbSearchObject> lst;
            if (WORKBOOK != null)
            {
                for (int sheetCnt = 0; sheetCnt < WORKBOOK.NumberOfSheets; sheetCnt++)
                {
                    WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(sheetCnt);
                    for (int rowCnt = 1; rowCnt <= WORKSHEET.LastRowNum; rowCnt++)
                    {
                        lst = new List<DbSearchObject>();
                        if (WORKSHEET.GetRow(rowCnt) == null) continue;
                        if (WORKSHEET.GetRow(rowCnt).GetCell(0) == null) continue;

                        productName = WORKSHEET.GetRow(rowCnt).GetCell(0).StringCellValue.Trim();
                        churchName = WORKSHEET.GetRow(rowCnt).GetCell(1).StringCellValue.Trim();
                        chDs = GetChurch(churchName);
                        if (Util.IsDataSetEmpty(chDs))
                        {
                            continue;
                        }
                        foreach (DataRow dr in chDs.Tables[0].Rows)
                        {
                            pds = GetProduct(productName, dr["Id"].ToString());
                            if (Util.IsDataSetEmpty(pds)) continue;
                            else break;
                        }
                        if (Util.IsDataSetEmpty(pds))
                        {
                            continue;
                        }

                        productid = pds.Tables[0].Rows[0]["Id"].ToString();
                        if (string.IsNullOrEmpty(productid))
                        {
                            continue;
                        }

                        lst.Add(new DbSearchObject("Id", AtrrTypeItem.String, AttrSymbolItem.Equal, productid));
                        lst.Add(new DbSearchObject("Cost", AtrrTypeItem.String, AttrSymbolItem.Equal, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(2).NumericCellValue.ToString()).ToString("#0.00")));
                        lst.Add(new DbSearchObject("CostCurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, "470E9113-4E57-43B6-A2B3-622904493945"));
                        lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                        lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                        ProductInfo.Add(lst);

                        ProductForStore.Add(SetDbObject(pds, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(3).NumericCellValue.ToString()).ToString("#0.00"), Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(4).NumericCellValue.ToString()).ToString("#0.00")));

                        storePrice = StoreLVPrice(productid);
                        if (Util.IsDataSetEmpty(storePrice)) continue;
                        foreach (DataRow dr in storePrice.Tables[0].Rows)
                        {
                            lst = new List<DbSearchObject>();
                            lst.Add(new DbSearchObject("Id", AtrrTypeItem.String, AttrSymbolItem.Equal, dr["Id"].ToString()));
                            lst.Add(new DbSearchObject("Currency", AtrrTypeItem.String, AttrSymbolItem.Equal, "470E9113-4E57-43B6-A2B3-622904493945"));
                            lst.Add(new DbSearchObject("Price", AtrrTypeItem.String, AttrSymbolItem.Equal, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(3).NumericCellValue.ToString()).ToString("#0.00")));
                            lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                            lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                            ProductLvPrice.Add(lst);
                        }
                    }
                }
            }
        }

        public bool WriteBack()
        {
            bool result = true;
            result = result & WriteBackProductInfo();
            result = result & WriteBackProductStroeLvPrice();
            result = result & WriteBackProductForStore();
            return result;
        }

        private bool WriteBackProductInfo()
        {
            bool result = true;
            foreach (List<DbSearchObject> item in ProductInfo)
            {
                try
                {
                    result = result & GenDbCon.UpdateDataIntoTable("ProductSet", Util.SqlQueryUpdateConverter(item), " Where Id = '" + item.Find(x => x.AttrName == "Id").AttrValue + "'");
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }
            return result;
        }
        private bool WriteBackProductStroeLvPrice()
        {
            bool result = true;
            foreach (List<DbSearchObject> item in ProductLvPrice)
            {
                try
                {
                    result = result & GenDbCon.UpdateDataIntoTable("StoreLvSetPrice", Util.SqlQueryUpdateConverter(item), " Where Id = '" + item.Find(x => x.AttrName == "Id").AttrValue + "'");
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }
            return result;
        }
        private bool WriteBackProductForStore()
        {
            bool result = true;
            foreach (List<DbSearchObject> item in ProductForStore)
            {
                try
                {
                    result = result & GenDbCon.InsertDataInToTable("ProductSet", Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }

            return result;
        }


        private DataSet StoreLVPrice(string setId)
        {
            try
            {
                string sql = "Select * From StoreLvSetPrice Where SetId = '" + setId + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return null;
                }
                else
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<DbSearchObject> SetDbObject(DataSet ds, string cost, string price)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            #region TextBox
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , cost
                ));
            lst.Add(new DbSearchObject(
            "Price"
            , AtrrTypeItem.Integer
            , AttrSymbolItem.Equal
            , price
            ));

            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Name"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "CnName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["CnName"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "JpName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["JpName"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "EngName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["EngName"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "BridalMakeup"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["BridalMakeup"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "GroomMakeup"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["GroomMakeup"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Corsage"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Corsage"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "WeddingFilmingTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["WeddingFilmingTime"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "FilmingLocation"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["FilmingLocation"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Decoration"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Decoration"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Moves"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Decoration"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "PhotosNum"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["PhotosNum"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Performence"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Performence"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "RoomId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["RoomId"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "StayNight"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["StayNight"].ToString()
                ));
            #endregion
            #region DropDownList
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["CountryId"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "AreaId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["AreaId"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "ChurchId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["ChurchId"].ToString()
                ));
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["WeddingCategory"].ToString()))
            {
                lst.Add(new DbSearchObject(
                    "WeddingCategory"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ds.Tables[0].Rows[0]["WeddingCategory"].ToString()
                    ));
            }
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Category"].ToString()))
            {
                lst.Add(new DbSearchObject(
                "Category"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Category"].ToString()
                ));
            }
            lst.Add(new DbSearchObject(
                "Staff"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Staff"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "CostCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "470E9113-4E57-43B6-A2B3-622904493945"
                ));
            lst.Add(new DbSearchObject(
                "PriceCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "A22C53A8-DD4D-4DD8-BD12-1D6512B89D95"
                ));
            #endregion
            #region CheckBox
            lst.Add(new DbSearchObject(
                "Breakfast"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Breakfast"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Certificate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Certificate"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "ChurchCost"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["ChurchCost"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Dinner"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Dinner"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "DressIroning"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["DressIroning"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "IsLegal"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["IsLegal"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Lounge"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Lounge"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Lunch"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Lunch"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Kickoff"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Kickoff"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Pastor"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Pastor"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "SignPen"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["SignPen"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "RingPillow"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["RingPillow"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Rehearsal"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Rehearsal"].ToString()
                ));
            #endregion
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "24C25A04-4C6C-44CD-961B-83C4BF129A3D"
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "00000000-0000-0000-0000-000000000001"
                ));
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            lst.Add(new DbSearchObject(
            "CreatedateAccId"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , "00000000-0000-0000-0000-000000000001"
            ));
            lst.Add(new DbSearchObject(
                "BaseId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ds.Tables[0].Rows[0]["Id"].ToString()
                ));
            return lst;
        }



        private string GetProductId(string name)
        {
            try
            {
                string sql = "Select Id From Country Where Name like N'%" + name + "%'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return string.Empty;
                }
                else
                {
                    return ds.Tables[0].Rows[0]["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private DataSet GetProduct(string name, string churchId)
        {
            try
            {
                string sql = "Select * From ProductSet Where Name like N'%" + name + "%' And ChurchId = '"+ churchId + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return null;
                }
                else
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private DataSet GetChurch(string name)
        {
            try
            {
                string sql = "Select * From Church Where Name like N'%" + name + "%'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return null;
                }
                else
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void FixProductPriceTable()
        {
            string resultIds = string.Empty;
            DataSet SetDs = GetDataFromDb("Select Distinct(Id) From ProductSet Where StoreId= 'B7E99B67-EE4B-4FE0-AAA7-F2BC24A9E45A'");
            DataSet PriceDs = GetDataFromDb("select * From StoreLvSetPrice Order by SetId, StoreLv");
            if (Util.IsDataSetEmpty(SetDs) || Util.IsDataSetEmpty(PriceDs)) return;
            List<DbSearchObject> lst = new List<DbSearchObject>();
            DataRow[] findout;
            foreach (DataRow dr in SetDs.Tables[0].Rows)
            {
                findout = PriceDs.Tables[0].Select("SetId = '" + dr["Id"].ToString() + "'");
                if (findout.Length >= 2) continue;
                lst = new List<DbSearchObject>();
                resultIds += "'" + dr["Id"].ToString() + "',";
                lst.Add(new DbSearchObject("SetId", AtrrTypeItem.String, AttrSymbolItem.Equal, dr["Id"].ToString()));
                lst.Add(new DbSearchObject("StoreLv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "2"));
                lst.Add(new DbSearchObject("Currency", AtrrTypeItem.String, AttrSymbolItem.Equal, findout[0]["Currency"].ToString()));
                lst.Add(new DbSearchObject("Price", AtrrTypeItem.String, AttrSymbolItem.Equal, findout[0]["Price"].ToString()));
                lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                lst.Add(new DbSearchObject("CreatedateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                lst.Add(new DbSearchObject("CreatedateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                ProductLvPrice.Add(lst);
            }
            WriteBackProductLvPrice();
            resultIds = resultIds.Remove(resultIds.Length - 1);
        }

        public void FixServiceItemLocationInfo()
        {
            string resultIds = string.Empty;
            DataSet ds1 = GetDataFromDb("Select DISTINCT * From ServiceItem Where  SupplierId is not null And CountryId is null and AreaId is null");
            DataSet ds2 = GetDataFromDb("Select * From Church"); ;
            if (Util.IsDataSetEmpty(ds1) || Util.IsDataSetEmpty(ds2)) return;
            List<List<DbSearchObject>> lsts = new List<List<DbSearchObject>>(); 
            List<DbSearchObject> lst = new List<DbSearchObject>();
            DataRow[] findout;
            foreach(DataRow dr in ds1.Tables[0].Rows)
            {
                findout = ds2.Tables[0].Select("Id = '" + dr["SupplierId"].ToString() + "'");
                if (findout.Length >= 2 || findout.Length == 0) continue;
                lst = new List<DbSearchObject>();
                resultIds += "'" + dr["Id"].ToString() + "',";
                lst.Add(new DbSearchObject("Id", AtrrTypeItem.String, AttrSymbolItem.Equal, dr["Id"].ToString()));
                lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, findout[0]["CountryId"].ToString()));
                lst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, findout[0]["AreaId"].ToString()));
                lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                lsts.Add(lst);
            }
            WriteBackDb(lsts, false, "ServiceItem");
            resultIds = resultIds.Remove(resultIds.Length - 1);
        }

        private bool WriteBackDb(List<List<DbSearchObject>> lst, bool isCreate, string tableName)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    if (isCreate)
                    {
                        result = result & GenDbCon.InsertDataInToTable(tableName, Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                    }
                    else
                    {
                        string id = item.Find(x => x.AttrName == "Id").AttrValue;
                        if (string.IsNullOrEmpty(id)) continue;
                        result = result & GenDbCon.UpdateDataIntoTable(tableName, Util.SqlQueryUpdateConverter(item), " Where Id = '" + id + "'");
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }

            return result;
        }

        private bool WriteBackProductLvPrice()
        {
            bool result = true;
            foreach (List<DbSearchObject> item in ProductLvPrice)
            {
                try
                {
                    result = result & GenDbCon.InsertDataInToTable("StoreLvSetPrice", Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }

            return result;
        }

        private DataSet GetDataFromDb(string sql)
        {
            try
            {
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return null;
                }
                else
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
