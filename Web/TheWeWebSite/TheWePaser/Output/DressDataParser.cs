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
    class DressDataParser
    {
        GeneralDbDAO GenDbCon;
        Utility Util;
        XSSFWorkbook WORKBOOK;
        XSSFSheet WORKSHEET;

        public DressDataParser(string dbConnStr)
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

        public List<List<DbSearchObject>> GetDressDbList()
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            string tmp = string.Empty;
            string attrName = string.Empty;
            string attrValue = string.Empty;
            MsSqlTable table = MsSqlTable.Nothing;
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

                        for (int cellCnt = 0; cellCnt <= WORKSHEET.GetRow(rowCnt).LastCellNum; cellCnt++)
                        {
                            // If cellCnt = 14, so shift to 19.
                            if (cellCnt >= 14)
                            {
                                cellCnt = 19;
                            }
                            else if (cellCnt > 24)
                            {
                                cellCnt = 36;
                            }

                            if (cellCnt == 20) continue;
                            var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                            if (cell != null)
                            {
                                attrName = GetAttrName(cellCnt);
                                if (string.IsNullOrEmpty(attrName)) continue;
                                table = GetAttrRelatedTable(cellCnt);
                                attrValue = (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue);
                                if (table == MsSqlTable.Nothing)
                                {
                                    if(cellCnt == 1)
                                    {
                                        attrValue = string.IsNullOrEmpty(attrValue) ? "0" : (attrValue == "女" ? "0" : "1");
                                    }
                                    else if (cellCnt == 19)
                                    {
                                        attrValue = string.IsNullOrEmpty(attrValue) ? "0" : "1";
                                    }
                                    else if (cellCnt >= 21 && cellCnt <= 23)
                                    {
                                        attrValue = string.IsNullOrEmpty(attrValue) ? "0" : (attrValue == "Y" ? "1" : "0");
                                    }
                                    else if (cellCnt == 13)
                                    {
                                        cellCnt++;
                                        if (WORKSHEET.GetRow(rowCnt).GetCell(cellCnt) != null)
                                        {
                                            tmp = (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue);
                                            if (!string.IsNullOrEmpty(tmp))
                                            {
                                                attrValue += (string.IsNullOrEmpty(attrName) ? string.Empty : ",") + tmp;
                                            }
                                        }
                                    }
                                    lst.Add(new DbSearchObject(attrName
                                        , (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? AtrrTypeItem.Integer : AtrrTypeItem.String)
                                        , AttrSymbolItem.Equal
                                        , attrValue));
                                }
                                else
                                {
                                    attrValue = GetObjectId(table, attrValue);
                                    if (string.IsNullOrEmpty(attrValue)) continue;
                                    lst.Add(new DbSearchObject(attrName
                                        , AtrrTypeItem.String
                                        , AttrSymbolItem.Equal
                                        , attrValue));
                                }
                            }
                        }
                        lst.Add(new DbSearchObject("StatusCode"
                                        , AtrrTypeItem.String
                                        , AttrSymbolItem.Equal
                                        , "BE87234E-50EA-480D-9C0C-1BF2645FADF1"));
                        lst.Add(new DbSearchObject("CreatedateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                        lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                        lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                        result.Add(lst);
                    }
                }
            }
            return result;
        }
        public void GetDressDbListAndWrite()
        {
            string tmp = string.Empty;
            string attrName = string.Empty;
            string attrValue = string.Empty;
            List<DbSearchObject> lst = new List<DbSearchObject>();
            MsSqlTable table = MsSqlTable.Nothing;
            if (WORKBOOK != null)
            {
                WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(0);
                for (int rowCnt = 1; rowCnt <= WORKSHEET.LastRowNum; rowCnt++)
                {
                    lst = new List<DbSearchObject>();
                    if (WORKSHEET.GetRow(rowCnt) == null) continue;
                    if (WORKSHEET.GetRow(rowCnt).GetCell(0) == null || WORKSHEET.GetRow(rowCnt).GetCell(1) == null) continue;

                    for (int cellCnt = 0; cellCnt <= WORKSHEET.GetRow(rowCnt).LastCellNum; cellCnt++)
                    {
                        // If cellCnt = 14, so shift to 19.
                        if (cellCnt == 20) continue;
                        if (cellCnt >= 14 && cellCnt < 19)
                        {
                            cellCnt = 19;
                        }
                        else if (cellCnt > 24 && cellCnt < 36)
                        {
                            if (WORKSHEET.LastRowNum >= 36)
                            {
                                cellCnt = 36;
                            }
                            else
                            {
                                cellCnt = WORKSHEET.LastRowNum + 1;
                                continue;
                            }
                        }
                        var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                        if (cell != null)
                        {
                            attrName = GetAttrName(cellCnt);
                            if (string.IsNullOrEmpty(attrName))
                            {
                                if (cellCnt == 0) cellCnt = WORKSHEET.LastRowNum + 1;
                                continue;
                            }
                            table = GetAttrRelatedTable(cellCnt);
                            attrValue = (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue);
                            if (table == MsSqlTable.Nothing)
                            {
                                if (cellCnt == 1)
                                {
                                    attrValue = string.IsNullOrEmpty(attrValue) ? "0" : (attrValue == "女" ? "0" : "1");
                                }
                                else if (cellCnt == 19)
                                {
                                    attrValue = string.IsNullOrEmpty(attrValue) ? "0" : "1";
                                }
                                else if (cellCnt >= 21 && cellCnt <= 23)
                                {
                                    attrValue = string.IsNullOrEmpty(attrValue) ? "0" : (attrValue == "Y" ? "1" : "0");
                                }
                                else if (cellCnt == 13)
                                {
                                    cellCnt++;
                                    if (WORKSHEET.GetRow(rowCnt).GetCell(cellCnt) != null)
                                    {
                                        tmp = (cell.CellType == NPOI.SS.UserModel.CellType.Numeric ? cell.NumericCellValue.ToString() : cell.StringCellValue);
                                        if (!string.IsNullOrEmpty(tmp))
                                        {
                                            attrValue += (string.IsNullOrEmpty(attrName) ? string.Empty : ",") + tmp;
                                        }
                                    }
                                }
                                lst.Add(new DbSearchObject(attrName
                                    , AtrrTypeItem.String
                                    , AttrSymbolItem.Equal
                                    , attrValue));
                            }
                            else
                            {
                                attrValue = GetObjectId(table, attrValue);
                                if (string.IsNullOrEmpty(attrValue)) continue;
                                lst.Add(new DbSearchObject(attrName
                                    , AtrrTypeItem.String
                                    , AttrSymbolItem.Equal
                                    , attrValue));
                            }
                        }
                    }
                    lst.Add(new DbSearchObject("StatusCode"
                                    , AtrrTypeItem.String
                                    , AttrSymbolItem.Equal
                                    , "BE87234E-50EA-480D-9C0C-1BF2645FADF1"));
                    lst.Add(new DbSearchObject("CreatedateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                    lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                    lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, "00000000-0000-0000-0000-000000000001"));
                    lst.Add(new DbSearchObject("StoreId", AtrrTypeItem.String, AttrSymbolItem.Equal, "24C25A04-4C6C-44CD-961B-83C4BF129A3D"));
                    WriteBackDress("Dress", lst);
                }
            }
        }

        public bool WriteBackDress(string tableName, List<List<DbSearchObject>> lst)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result & GenDbCon.InsertDataInToTable(tableName, Util.SqlQueryInsertInstanceConverter(item), Util.SqlQueryInsertValueConverter(item));
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }
            return result;
        }
        public bool WriteBackDress(string tableName, List<DbSearchObject> lst)
        {
            bool result = true;
            try
            {
                result = result & GenDbCon.InsertDataInToTable(tableName, Util.SqlQueryInsertInstanceConverter(lst), Util.SqlQueryInsertValueConverter(lst));
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        private string GetObjectId(MsSqlTable table, string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return string.Empty;
                string sql = "Select Id From " + Util.MsSqlTableConverter(table) + " Where Name like N'%" + name + "%'";
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

        private string GetAttrName(int cellCnt)
        {
            switch (cellCnt)
            {
                case 0:
                    return "Sn";
                case 1:
                    return "Gender";
                case 2:
                    return "Category";
                case 3:
                    return "Color";
                case 4:
                    return "Color2";
                case 5:
                    return "Material";
                case 6:
                    return "Neckline";
                case 7:
                    return "Type";
                case 8:
                    return "Trailing";
                case 9:
                    return "Shoulder";
                case 10:
                    return "Description";
                case 11:
                    return "Back";
                case 12:
                    return "Worn";
                case 13:
                    return "Fitting";
                case 14:
                    return "Fitting";
                case 16:
                    return "Veil";
                case 17:
                    return "Corsage";
                case 18:
                    return "Gloves";
                case 19:
                    return "BigSize";
                case 21:
                    return "OutPicture";
                case 22:
                    return "DomesticWedding";
                case 23:
                    return "AddPrice";
                case 24:
                    return "PlusItemPrice";
                case 36:
                    return "UseStatus";
                default:
                    return string.Empty;
            }
        }
        private MsSqlTable GetAttrRelatedTable(int cellCnt)
        {
            switch (cellCnt)
            {
                case 2:
                    return MsSqlTable.DressCategory;
                case 6:
                    return MsSqlTable.DressNeckline;
                case 7:
                    return MsSqlTable.DressType;
                case 8:
                    return MsSqlTable.DressTrailing;
                case 9:
                    return MsSqlTable.DressShoulder;
                case 11:
                    return MsSqlTable.DressBack;
                case 12:
                    return MsSqlTable.DressWorn;
                case 16:
                    return MsSqlTable.DressVeil;
                case 17:
                    return MsSqlTable.DressCorsage;
                case 18:
                    return MsSqlTable.DressGloves;
                case 36:
                    return MsSqlTable.DressUseStatus;
                default:
                    return MsSqlTable.Nothing;
            }
        }
    }
}
