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

        public void GetMainProductDbList()
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
                        churchName = WORKSHEET.GetRow(rowCnt).GetCell(7).StringCellValue.Trim();
                        chDs = GetChurch(churchName, WORKSHEET.GetRow(rowCnt).GetCell(6).StringCellValue.Trim());
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

                        ProductForStore.Add(SetDbObject(pds, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(3).NumericCellValue.ToString()).ToString("#0.00"), Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(4).NumericCellValue.ToString()).ToString("#0.00"), false, false, ""));

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

        public void GetProductDbList()
        {
            DataSet pds = null;
            DataSet chDs = null;
            DataSet storePrice = null;
            string productid = "";
            string productName = "";
            string churchName = "";
            bool isJP = false;
            //string currencyId = "470E9113-4E57-43B6-A2B3-622904493945"; // JPY
            //string currencyId = "FD570380-B2DA-45EA-B27B-FBB7A497BAB2"; // usd
            string currencyId = "96decc41-c9a8-4a63-acc5-6600568a9567"; // gbp
            //string currencyId = "F4C8B4A8-2DDB-4200-8BA0-447555201219"; // EUR
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
                        if (string.IsNullOrEmpty(WORKSHEET.GetRow(rowCnt).GetCell(0).StringCellValue)) continue;

                        productName = WORKSHEET.GetRow(rowCnt).GetCell(0).StringCellValue.Trim();
                        churchName = WORKSHEET.GetRow(rowCnt).GetCell(6).StringCellValue.Trim();
                        string countryid = GetCountryId(WORKSHEET.GetRow(rowCnt).GetCell(4).StringCellValue);
                        string areaId = GetAreaId(countryid, WORKSHEET.GetRow(rowCnt).GetCell(5).StringCellValue);
                        string churchLoc = WORKSHEET.GetRow(rowCnt).GetCell(1) != null ? WORKSHEET.GetRow(rowCnt).GetCell(1).StringCellValue : string.Empty;
                        chDs = GetChurch(countryid, areaId, churchName, (isJP ? churchLoc : ""));
                        if (Util.IsDataSetEmpty(chDs))
                        {
                            continue;
                        }
                        foreach (DataRow dr in chDs.Tables[0].Rows)
                        {
                            pds = GetProduct(productName, dr["Id"].ToString());
                            if (Util.IsDataSetEmpty(pds))
                            {
                                WriteBackDb(SetProductData(WORKSHEET.GetRow(rowCnt) as XSSFRow, dr["CountryId"].ToString(), dr["AreaId"].ToString(), dr["Id"].ToString(), isJP, currencyId), true, "ProductSet");
                                pds = GetProduct(productName, dr["Id"].ToString());
                                if (Util.IsDataSetEmpty(pds))
                                {
                                    continue;
                                }
                                else break;
                            }
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
                        lst.Add(new DbSearchObject("Cost", AtrrTypeItem.String, AttrSymbolItem.Equal, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(19).NumericCellValue.ToString()).ToString("#0.00")));
                        //lst.Add(new DbSearchObject("CostCurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, "470E9113-4E57-43B6-A2B3-622904493945"));
                        lst.Add(new DbSearchObject("CostCurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, currencyId)); //USD
                        //lst.Add(new DbSearchObject("CostCurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, "FD570380-B2DA-45EA-B27B-FBB7A497BAB2")); //USD
                        //lst.Add(new DbSearchObject("CostCurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, "470E9113-4E57-43B6-A2B3-622904493945"));//JPN
                        lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                        lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                        ProductInfo.Add(lst);

                        ProductForStore.Add(SetDbObject(pds, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(33).NumericCellValue.ToString()).ToString("#0.00"), Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(35).NumericCellValue.ToString()).ToString("#0.00"), true, true, currencyId));
                        ProductForStore.Add(SetDbObject(pds, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(33).NumericCellValue.ToString()).ToString("#0.00"), Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(35).NumericCellValue.ToString()).ToString("#0.00"), false, false, currencyId));

                        for (int cnt = 1; cnt <= 2; cnt++)
                        {
                            ProductLvPrice.Add(StoreLvPriceDbObject(productid, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(33).NumericCellValue.ToString()).ToString("#0.00"), cnt.ToString()));
                        }
                        //storePrice = StoreLVPrice(productid);
                        //if (Util.IsDataSetEmpty(storePrice)) continue;
                        //foreach (DataRow dr in storePrice.Tables[0].Rows)
                        //{
                        //    lst = new List<DbSearchObject>();
                        //    lst.Add(new DbSearchObject("Id", AtrrTypeItem.String, AttrSymbolItem.Equal, dr["Id"].ToString()));
                        //    lst.Add(new DbSearchObject("Currency", AtrrTypeItem.String, AttrSymbolItem.Equal, "FD570380-B2DA-45EA-B27B-FBB7A497BAB2"));
                        //    lst.Add(new DbSearchObject("Price", AtrrTypeItem.String, AttrSymbolItem.Equal, Util.ParseMoney(WORKSHEET.GetRow(rowCnt).GetCell(33).NumericCellValue.ToString()).ToString("#0.00")));
                        //    lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                        //    lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                        //    ProductLvPrice.Add(lst);
                        //}
                    }
                }
            }
        }

        public bool WriteBack()
        {
            bool result = true;
            //result = result & WriteBackProductInfo(isJP);
            result = result & WriteBackProductStroeLvPrice(true);
            result = result & WriteBackProductForStore();
            return result;
        }

        private bool WriteBackProductInfo(bool isJP)
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
        private bool WriteBackProductStroeLvPrice(bool isInsert)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in ProductLvPrice)
            {
                try
                {
                    if (isInsert)
                    {
                        result = result & GenDbCon.InsertDataInToTable("StoreLvSetPrice", Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                    }
                    else
                    {
                        result = result & GenDbCon.UpdateDataIntoTable("StoreLvSetPrice", Util.SqlQueryUpdateConverter(item), " Where Id = '" + item.Find(x => x.AttrName == "Id").AttrValue + "'");
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

        private List<DbSearchObject> SetDbObject(DataSet ds, string cost, string price, bool isTWD, bool isTW, string currency)
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
            , (isTW ? price : "0")
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
                //, currency
                , "FD570380-B2DA-45EA-B27B-FBB7A497BAB2"
                //, "470E9113-4E57-43B6-A2B3-622904493945"
                ));
            lst.Add(new DbSearchObject(
                "PriceCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (isTWD ? "A22C53A8-DD4D-4DD8-BD12-1D6512B89D95" : "07AE6782-CB3E-4F9D-ACC3-225A77B36550")
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
                , (isTW ? "24C25A04-4C6C-44CD-961B-83C4BF129A3D" : "B106FD82-C7E3-4028-9C6C-032F0B47EC98")
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

        private List<DbSearchObject> StoreLvPriceDbObject(string setId, string price, string lvCnt)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "StoreLv"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , lvCnt
                ));
            lst.Add(new DbSearchObject(
                "Price"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , price
                ));
            lst.Add(new DbSearchObject(
                "Currency"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "FD570380-B2DA-45EA-B27B-FBB7A497BAB2"
                //, "470E9113-4E57-43B6-A2B3-622904493945"
                ));
            lst.Add(new DbSearchObject(
                "SetId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , setId
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
                string sql = "Select * From ProductSet Where Name like N'%" + name + "%' And ChurchId = '" + churchId + "'";
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
        private DataSet GetChurch(string name, string locName)
        {
            try
            {
                string sql = "Select * From Church Where Name = N'" + name + "' and locationName = N'" + locName + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return null;// InsertData(true, name, string.Empty);
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

        public string GetCountryId(string name)
        {
            try
            {
                string sql = "Select Id From Country Where Name like N'%" + name + "%'";                
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return InsertData(true, name, string.Empty);
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

        public string GetAreaId(string countryId, string name)
        {
            try
            {
                string sql = "Select Id From Area Where Name like N'%" + name + "%' And CountryId='" + countryId + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return InsertData(false, name, countryId);
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
        public DataSet GetChurch(string countryId, string areaId, string name, string locationName)
        {
            try
            {
                string sql = "Select * From Church Where Name = N'" + name + "' And CountryId='" + countryId + "' And AreaId = '" + areaId + "'";
                if (!string.IsNullOrEmpty(locationName)) sql += sql + " And locationName='" + locationName + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    //return InsertData(false, name, countryId);
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
                string sql = "Select * From Church Where Name = N'" + name + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return null;// InsertData(true, name, string.Empty);
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

        public string InsertData(bool isCountry, string name, string cid)
        {
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, name));
                lst.Add(new DbSearchObject("CreatedateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                if (!isCountry) lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, cid));
                if (GenDbCon.InsertDataInToTable((isCountry ? "Country" : "Area"), Util.SqlQueryInsertInstanceConverter(lst), Util.SqlQueryInsertValueConverter(lst)))
                {
                    DataSet ds = GenDbCon.GetDataFromTable("Id", (isCountry ? "Country" : "Area"), Util.SqlQueryConditionConverter(lst));
                    if (!Util.IsDataSetEmpty(ds))
                    {
                        return ds.Tables[0].Rows[0]["Id"].ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
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
            foreach (DataRow dr in ds1.Tables[0].Rows)
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
        private bool WriteBackDb(List<DbSearchObject> lst, bool isCreate, string tableName)
        {
            bool result = true;
            try
            {
                if (isCreate)
                {
                    result = result & GenDbCon.InsertDataInToTable(tableName, Util.SqlQueryInsertInstanceConverter(lst), Util.SqlQueryInsertValueConverter(lst));
                }
                else
                {
                    string id = lst.Find(x => x.AttrName == "Id").AttrValue;
                    result = result & GenDbCon.UpdateDataIntoTable(tableName, Util.SqlQueryUpdateConverter(lst), " Where Id = '" + id + "'");
                }
            }
            catch (Exception ex)
            {
                result = false;
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

        private List<DbSearchObject> SetProductData(XSSFRow row, string countryId, string areaId, string churchId, bool isJP, string currencyId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            #region TextBox
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , row.GetCell(19).NumericCellValue.ToString()
                ));
            lst.Add(new DbSearchObject(
            "Price"
            , AtrrTypeItem.Integer
            , AttrSymbolItem.Equal
            , row.GetCell(33).NumericCellValue.ToString()
            ));

            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , row.GetCell(0).StringCellValue
                ));
            if (!isJP)
            {
                lst.Add(new DbSearchObject(
                    "EngName"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , (row.GetCell(1) == null ? string.Empty : row.GetCell(1).StringCellValue)
                    ));
            }
            lst.Add(new DbSearchObject(
                "BridalMakeup"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(7).CellType == NPOI.SS.UserModel.CellType.Numeric ? row.GetCell(7).NumericCellValue.ToString() : row.GetCell(7).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "GroomMakeup"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(8).CellType == NPOI.SS.UserModel.CellType.Numeric ? row.GetCell(8).NumericCellValue.ToString() : row.GetCell(8).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "Corsage"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(15) == null ? string.Empty : row.GetCell(15).StringCellValue.ToString())
                ));
            lst.Add(new DbSearchObject(
                "WeddingFilmingTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(9) == null ? string.Empty : row.GetCell(9).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "FilmingLocation"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(10) == null ? string.Empty : row.GetCell(10).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "Decoration"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(17) == null ? string.Empty : row.GetCell(17).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "Moves"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(11) == null ? string.Empty : row.GetCell(11).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "PhotosNum"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , row.GetCell(12).NumericCellValue.ToString()
                ));
            lst.Add(new DbSearchObject(
                "Performence"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(18) == null ? string.Empty : row.GetCell(18).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "RoomId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (row.GetCell(14) == null ? string.Empty : row.GetCell(14).StringCellValue)
                ));
            lst.Add(new DbSearchObject(
                "StayNight"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , (row.GetCell(13) == null ? "0" : (string.IsNullOrEmpty(row.GetCell(13).NumericCellValue.ToString()) ? "0" : row.GetCell(13).NumericCellValue.ToString()))
                ));
            #endregion
            #region DropDownList
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , countryId
                ));
            lst.Add(new DbSearchObject(
                "AreaId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , areaId
                ));
            lst.Add(new DbSearchObject(
                "ChurchId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , churchId
                ));
            string tmp = (row.GetCell(3) == null ? string.Empty : GetWeddingCategory(row.GetCell(3).StringCellValue));
            if (!string.IsNullOrEmpty(tmp))
            {
                lst.Add(new DbSearchObject(
                    "WeddingCategory"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tmp
                    ));
            }
            lst.Add(new DbSearchObject(
            "Category"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , (row.GetCell(2) == null ? string.Empty : GetCategory(row.GetCell(2).StringCellValue))
            ));
            lst.Add(new DbSearchObject(
                "Staff"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , "1"
                ));
            lst.Add(new DbSearchObject(
                "CostCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , currencyId
                //, "FD570380-B2DA-45EA-B27B-FBB7A497BAB2"
                //, "470E9113-4E57-43B6-A2B3-622904493945"
                ));
            lst.Add(new DbSearchObject(
                "PriceCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , currencyId
                //, "FD570380-B2DA-45EA-B27B-FBB7A497BAB2"
                //, "470E9113-4E57-43B6-A2B3-622904493945"
                ));
            #endregion
            #region CheckBox
            lst.Add(new DbSearchObject(
                "Breakfast"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , (row.GetCell(28) == null ? "0" : row.GetCell(28).StringCellValue == "Y" ? "1" : "0")
                ));
            lst.Add(new DbSearchObject(
                "Certificate"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(22) == null ? "0" : row.GetCell(22).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "ChurchCost"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(20) == null ? "0" : row.GetCell(20).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Dinner"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(30) == null ? "0" : row.GetCell(30).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "DressIroning"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(26) == null ? "0" : row.GetCell(26).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "IsLegal"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(32) == null ? "0" : row.GetCell(32).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Lounge"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(25) == null ? "0" : row.GetCell(25).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Lunch"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(29) == null ? "0" : row.GetCell(29).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Kickoff"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(27) == null ? "0" : row.GetCell(27).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Pastor"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(21) == null ? "0" : row.GetCell(21).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "SignPen"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(24) == null ? "0" : row.GetCell(24).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "RingPillow"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(23) == null ? "0" : row.GetCell(23).StringCellValue == "Y" ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Rehearsal"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , row.GetCell(31) == null ? "0" : row.GetCell(31).StringCellValue == "Y" ? "1" : "0"
                ));
            #endregion
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "B7E99B67-EE4B-4FE0-AAA7-F2BC24A9E45A"
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "00000000-0000-0000-0000-000000000001"
                ));
            lst.Add(new DbSearchObject(
            "CreatedateAccId"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , "00000000-0000-0000-0000-000000000001"
            ));
            return lst;
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

        private string GetWeddingCategory(string wc)
        {
            if (string.IsNullOrEmpty(wc)) return string.Empty;
            try
            {
                string sql = "Select * From [WeddingCategory] Where Name = N'" + wc + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return string.Empty;// InsertData(true, name, string.Empty);
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

        private string GetCategory(string wc)
        {
            if (string.IsNullOrEmpty(wc)) return string.Empty;
            try
            {
                string sql = "Select * From [ServiceItemCategory] where TypeLv = 0 AND Name = N'" + wc + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    return string.Empty;// InsertData(true, name, string.Empty);
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
    }
}
