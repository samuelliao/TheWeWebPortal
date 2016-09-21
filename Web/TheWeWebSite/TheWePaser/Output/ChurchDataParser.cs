using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWeLib;
using TheWeLib.DbControl;

namespace TheWeParser.Output
{
    class ChurchDataParser
    {
        GeneralDbDAO GenDbCon;
        Utility Util;
        XSSFWorkbook WORKBOOK;
        XSSFSheet WORKSHEET;

        public ChurchDataParser(string dbConnStr)
        {
            GenDbCon = new GeneralDbDAO(dbConnStr);
            Util = new Utility();
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

        public List<List<DbSearchObject>> GetChurchDbList()
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            if (WORKBOOK != null)
            {
                for (int sheetCnt = 0; sheetCnt < WORKBOOK.NumberOfSheets; sheetCnt++)
                {
                    WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(sheetCnt);
                    for (int rowCnt = 1; rowCnt <= WORKSHEET.LastRowNum; rowCnt++)
                    {
                        List<DbSearchObject> lst = new List<DbSearchObject>();
                        if (WORKSHEET.GetRow(rowCnt) == null) continue;
                        if (WORKSHEET.GetRow(rowCnt).GetCell(0) == null || WORKSHEET.GetRow(rowCnt).GetCell(1) == null) continue;

                        // Country
                        string countryid = GetCountryId(WORKSHEET.GetRow(rowCnt).GetCell(0).StringCellValue);
                        if (string.IsNullOrEmpty(countryid)) continue;
                        lst.Add(new DbSearchObject(GetAttrName(0), AtrrTypeItem.String, AttrSymbolItem.Equal, countryid));

                        // Area
                        string areaId = GetAreaId(countryid, WORKSHEET.GetRow(rowCnt).GetCell(1).StringCellValue);
                        if (string.IsNullOrEmpty(areaId)) continue;
                        lst.Add(new DbSearchObject(GetAttrName(1), AtrrTypeItem.String, AttrSymbolItem.Equal, areaId));

                        for (int cellCnt = 2; cellCnt < 10; cellCnt++)
                        {
                            var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                            if (cell != null)
                            {
                                lst.Add(new DbSearchObject(GetAttrName(cellCnt)
                                    , (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? AtrrTypeItem.Integer : AtrrTypeItem.String)
                                    , AttrSymbolItem.Equal
                                    , (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue)));
                            }
                        }
                        string remark = string.Empty;
                        for (int cellCnt = 19; cellCnt <= WORKSHEET.GetRow(rowCnt).LastCellNum; cellCnt++)
                        {
                            var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                            if (cell != null)
                            {
                                string tmp = (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue);
                                if (!string.IsNullOrEmpty(tmp))
                                {
                                    if (cellCnt >= 25)
                                    {
                                        remark += tmp + "\r\n";
                                    }
                                    else
                                    {
                                        remark += WORKSHEET.GetRow(0).GetCell(cellCnt).StringCellValue + ":" + tmp + "\r\n";
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(remark))
                        {
                            lst.Add(new DbSearchObject("Remark"
                                    , AtrrTypeItem.String
                                    , AttrSymbolItem.Equal
                                    , remark));
                        }
                        result.Add(lst);
                    }
                }
            }
            return result;
        }

        public List<List<DbSearchObject>> GetChurchServiceTime()
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            if (WORKBOOK != null)
            {
                for (int sheetCnt = 0; sheetCnt < WORKBOOK.NumberOfSheets; sheetCnt++)
                {
                    WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(sheetCnt);
                    for (int rowCnt = 1; rowCnt <= WORKSHEET.LastRowNum; rowCnt++)
                    {
                        List<DbSearchObject> lst = new List<DbSearchObject>();
                        if (WORKSHEET.GetRow(rowCnt) == null) continue;
                        if (WORKSHEET.GetRow(rowCnt).GetCell(0) == null || WORKSHEET.GetRow(rowCnt).GetCell(1) == null) continue;

                        string countryid = GetCountryId(WORKSHEET.GetRow(rowCnt).GetCell(0).StringCellValue);
                        string areaId = GetAreaId(countryid, WORKSHEET.GetRow(rowCnt).GetCell(1).StringCellValue);
                        //string name = WORKSHEET.GetRow(rowCnt).GetCell(2).StringCellValue;
                        string churchId = GetChurchId(countryid, areaId, WORKSHEET.GetRow(rowCnt).GetCell(2).StringCellValue);
                        if (string.IsNullOrEmpty(churchId)) continue;
                        //if (name == "藍點灣海洋教堂") {
                        //    string str = "";
                        //}
                        for (int cellCnt = 10; cellCnt <= 18; cellCnt++)
                        {
                            var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                            if (cell != null)
                            {
                                lst = new List<DbSearchObject>();
                                lst.Add(new DbSearchObject("ChurchId"
                                    , AtrrTypeItem.String
                                    , AttrSymbolItem.Equal
                                    , churchId));
                                string time = (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue);
                                if (time.Contains("~"))
                                {
                                    lst.Add(new DbSearchObject("StartTime"
                                        , AtrrTypeItem.DateTime
                                        , AttrSymbolItem.Equal
                                        , time.Split('~')[0]));
                                    lst.Add(new DbSearchObject("EndTime"
                                        , (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? AtrrTypeItem.Integer : AtrrTypeItem.String)
                                        , AttrSymbolItem.Equal
                                        , time.Split('~')[1]));
                                }
                                else
                                {
                                    if (cell.DateCellValue.ToString("HH:mm:ss") == "00:00:00")
                                    {
                                        // Pass this church
                                        cellCnt = 19;
                                        continue;
                                    }
                                    lst.Add(new DbSearchObject("StartTime"
                                        , AtrrTypeItem.DateTime
                                        , AttrSymbolItem.Equal
                                        //, (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue)));
                                        , cell.DateCellValue.ToString("HH:mm:ss")));
                                }
                                result.Add(lst);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool WriteBackChurch(List<List<DbSearchObject>> lst)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result & GenDbCon.InsertDataInToTable("Church", Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }
            return result;
        }

        public bool WriteBackChurchServiceTime(List<List<DbSearchObject>> lst)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result & GenDbCon.InsertDataInToTable("ChurchBookingTime", Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }
            return result;
        }

        private string GetAttrName(int index)
        {
            string result = string.Empty;
            switch (index)
            {
                case 0:
                    result = "CountryId";
                    break;
                case 1:
                    result = "AreaId";
                    break;
                case 2:
                    result = "Name";
                    break;
                case 3:
                    result = "CnName";
                    break;
                case 4:
                    result = "EngName";
                    break;
                case 5:
                    result = "JpName";
                    break;
                case 6:
                    result = "Capacities";
                    break;
                case 7:
                    result = "RedCarpetLong";
                    break;
                case 8:
                    result = "RedCarpetCategory";
                    break;
                case 9:
                    result = "PatioHeight";
                    break;
                default:
                    break;
            }
            return result;
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
        public string GetChurchId(string countryId, string areaId, string name)
        {
            try
            {
                string sql = "Select Id From Church Where Name like N'%" + name + "%' And CountryId='" + countryId + "' And AreaId = '" + areaId + "'";
                DataSet ds = GenDbCon.GetDataFromTable(sql);
                if (Util.IsDataSetEmpty(ds))
                {
                    //return InsertData(false, name, countryId);
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
                    if (Util.IsDataSetEmpty(ds))
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

        public void SetAllServiceItem()
        {
            DataSet chDs = GetChurchId();
            DataSet siDs = GetExistServiceItem();
            
            if (Util.IsDataSetEmpty(chDs) && Util.IsDataSetEmpty(siDs)) return;
            List<List<DbSearchObject>> dbls = new List<List<DbSearchObject>>();
            foreach (DataRow dr in siDs.Tables[0].Rows)
            {
                dbls.Add(OthItemInfoDbObject(dr["Sn"].ToString().Substring(0, 2), dr, string.Empty));
            }

            foreach (DataRow dr in chDs.Tables[0].Rows)
            {
                if (siDs.Tables[0].Select("SupplierId = '" + dr["Id"].ToString() + "'").Length > 0) continue;
                foreach(List<DbSearchObject> item in dbls)
                {
                    item[item.FindIndex(x => x.AttrName == "SupplierId")].AttrValue = dr["Id"].ToString();
                    WriteBackInfo(MsSqlTable.ServiceItem, item);
                }
            }
        }

        private List<DbSearchObject> OthItemInfoDbObject(string sn, DataRow dr, string churchId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , sn
                ));
            lst.Add(new DbSearchObject(
                "IsGeneral"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , "1"
                ));
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dr["Name"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Price"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dr["Price"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dr["Cost"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dr["Description"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "CategoryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dr["CategoryId"].ToString()
                ));
            string typeId = dr["Type"].ToString();
            if (!string.IsNullOrEmpty(typeId))
            {
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , typeId
                    ));
            }

            lst.Add(new DbSearchObject(
                "SupplierId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , churchId
                ));

            lst.Add(new DbSearchObject(
                "IsStore"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , "0"
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
            "CreatedateTime"
            , AtrrTypeItem.DateTime
            , AttrSymbolItem.Equal
            , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            ));
            return lst;
        }

        private List<DbSearchObject> AccInfoDbObject(string acc)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Account"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , acc
                ));
            lst.Add(new DbSearchObject(
                "AccInfo"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , Util.GetMD5(acc)
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
            return lst;
        }

        public DataSet GetChurchId()
        {
            try
            {
                string sql = "Select * From Church Where IsDelete = 0";
                return GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetExistServiceItem()
        {
            try
            {
                string sql = "Select * From Serviceitem Where IsDelete = 0 And IsStore = 0";
                return GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool WriteBackInfo(MsSqlTable table, List<DbSearchObject> lst)
        {
            try
            {
                return GenDbCon.InsertDataInToTable(
                        Util.MsSqlTableConverter(table)
                        , Util.SqlQueryInsertInstanceConverter(lst)
                        , Util.SqlQueryInsertValueConverter(lst));
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        private bool WriteBackInfo(MsSqlTable table, List<DbSearchObject> lst, string id)
        {
            try
            {
                return GenDbCon.UpdateDataIntoTable(
                        Util.MsSqlTableConverter(table)
                        , Util.SqlQueryUpdateConverter(lst)
                        , " Where Id = '" + id + "'");
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public void ResetAccountAndPassword()
        {
            try
            {
                string sql = "Select * From Employee Where IsDelete = 0";
                DataSet ds =  GenDbCon.GetDataFromTable(sql);
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["Account"].ToString() == "admin") continue;
                    WriteBackInfo(MsSqlTable.Employee, AccInfoDbObject(dr["Account"].ToString().ToLower()), dr["Id"].ToString());
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
