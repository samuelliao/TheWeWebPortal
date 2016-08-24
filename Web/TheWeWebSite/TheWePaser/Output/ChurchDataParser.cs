using NPOI.XSSF.UserModel;
using System;
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
                WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(0);
                for (int rowCnt = 1; rowCnt < WORKSHEET.LastRowNum; rowCnt++)
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

                    for (int cellCnt = 2; cellCnt < WORKSHEET.GetRow(rowCnt).LastCellNum; cellCnt++)
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

                    result.Add(lst);
                }
            }
            return result;
        }

        public bool WriteBackChurch(List<List<DbSearchObject>> lst)
        {
            bool result = true;
            foreach(List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result & GenDbCon.InsertDataInToTable("Church", Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                }catch(Exception ex)
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
                if (IsDataSetEmpty(ds))
                {
                    return InsertData(true, name, string.Empty);
                }
                else
                {
                    return ds.Tables[0].Rows[0]["Id"].ToString();
                }
            }catch(Exception ex)
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
                if (IsDataSetEmpty(ds))
                {
                    return InsertData(false, name, countryId);
                }
                else
                {
                    return ds.Tables[0].Rows[0]["Id"].ToString();
                }
            }
            catch(Exception ex)
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
                if(!isCountry) lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, cid));
                if (GenDbCon.InsertDataInToTable((isCountry ? "Country" : "Area"), Util.SqlQueryInsertInstanceConverter(lst), Util.SqlQueryInsertValueConverter(lst)))
                {
                    DataSet ds = GenDbCon.GetDataFromTable("Id", (isCountry ? "Country" : "Area"), Util.SqlQueryConditionConverter(lst));
                    if (IsDataSetEmpty(ds))
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
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public bool IsDataSetEmpty(DataSet ds)
        {
            if (ds == null) return true;
            else if (ds.Tables.Count == 0) return true;
            else if (ds.Tables[0].Rows.Count == 0) return true;
            else return false;
        }
    }

}
