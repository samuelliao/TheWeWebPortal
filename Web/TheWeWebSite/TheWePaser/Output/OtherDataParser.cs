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
    public class OtherDataParser
    {
        GeneralDbDAO _genDbCon;
        Utility _util;
        XSSFWorkbook WORKBOOK;
        XSSFSheet WORKSHEET;
        List<List<DbSearchObject>> RESULT;

        public OtherDataParser(string dbConnStr)
        {
            _genDbCon = new GeneralDbDAO(dbConnStr);
            _util = new Utility();
            RESULT = new List<List<DbSearchObject>>();
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

        public void GetDataList()
        {
            string tmpStr = "";
            XSSFCell workCell;
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
                        if (WORKSHEET.GetRow(rowCnt).GetCell(1) == null) continue;

                        for (int cellCnt = 0; cellCnt <= 7; cellCnt++)
                        {
                            workCell = (XSSFCell)WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                            if (workCell == null) {
                                if (cellCnt == 7)
                                {
                                    lst.Add(new DbSearchObject(attrName(cellCnt), AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                                }
                                else
                                {
                                    lst.Add(new DbSearchObject(attrName(cellCnt), AtrrTypeItem.String, AttrSymbolItem.Equal, string.Empty));
                                }
                            }
                            else
                            {
                                tmpStr = workCell.CellType == NPOI.SS.UserModel.CellType.Numeric ? workCell.NumericCellValue.ToString() : workCell.StringCellValue;
                                tmpStr = tmpStr.Replace("\'", "");
                                if (cellCnt == 7)
                                {
                                    lst.Add(new DbSearchObject(attrName(cellCnt), AtrrTypeItem.Bit, AttrSymbolItem.Equal, string.IsNullOrEmpty(tmpStr) ? "1" : "0"));
                                }
                                else
                                {
                                    lst.Add(new DbSearchObject(attrName(cellCnt), AtrrTypeItem.String, AttrSymbolItem.Equal, tmpStr));
                                }
                            }
                        }
                        RESULT.Add(lst);
                    }
                }
            }
        }
        private string attrName(int index)
        {
            switch (index)
            {
                case 0:
                    return "doc";
                case 1:
                    return "ce_no";
                case 2:
                    return "ce_name";
                case 3:
                    return "ce_name1";
                case 4:
                    return "code";
                case 5:
                    return "standard";
                case 6:
                    return "unit";
                case 7:
                    return "disable";
                default:
                    return string.Empty;
            }
        }

        public bool writeBackData()
        {
            bool result = true;
            foreach (List<DbSearchObject> item in RESULT)
            {
                try
                {
                    result = result & _genDbCon.InsertDataInToTable("check_items", _util.SqlQueryInsertInstanceConverter(item), _util.SqlQueryInsertValueConverter(item));
                }
                catch (Exception ex)
                {
                    result = false;
                    continue;
                }
            }

            return result;
        }
    }
}
