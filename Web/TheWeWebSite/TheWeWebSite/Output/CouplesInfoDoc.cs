using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TheWeLib;

namespace TheWeWebSite.Output
{
    public class CouplesInfoDoc
    {
        XSSFWorkbook WORKBOOK;
        XSSFSheet WORKSHEET;
        public string CreateCouplesInfoDoc(string lang
            , string sn, string weddingDate, string churchName
            , string bridalName, string bridalEngName, string bridalPhone
            , string groomName, string groomEngName, string groomPhone
            , string orderTyp, string religiousType, string isLegal)
        {
            string folderPath = SysProperty.ImgRootFolderpath + @"\docTemplate";
            string filePath = folderPath + @"\Template\CouplesInfo." + lang + ".xlsx";
            if (!File.Exists(filePath))
            {
                filePath = folderPath + @"\Template\CouplesInfo.zh-TW.xlsx";
            }
            if (File.Exists(filePath))
            {
                ReadXlsxDoc(filePath);
                if (WORKBOOK != null)
                {
                    WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(0);
                    filePath = folderPath + @"/" + sn + "_CouplesInfo.xlsx";
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    for (int rowCnt = 0; rowCnt < 24; rowCnt++)
                    {
                        if (WORKSHEET.GetRow(rowCnt) == null) continue;
                        for (int cellCnt = 0; cellCnt < 8; cellCnt++)
                        {
                            var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                            if (cell != null)
                            {
                                if (cell.StringCellValue.Contains("Pattern"))
                                {
                                    cell.SetCellValue(ReplacePattern
                                        (cell.StringCellValue, weddingDate, churchName
                                        , bridalName, bridalEngName, bridalPhone
                                        , groomName, groomEngName, groomPhone
                                        , orderTyp, religiousType, isLegal));
                                }
                            }
                        }
                    }
                    XSSFFormulaEvaluator.EvaluateAllFormulaCells(WORKBOOK);
                    using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        WORKBOOK.Write(fs);
                    }
                    return filePath;
                }
            }
            return string.Empty;
        }

        private void ReadXlsxDoc(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    WORKBOOK = new XSSFWorkbook(fs);
                }
            }
        }

        private string ReplacePattern(
            string str, string weddingDate, string churchName
            , string bridalName, string bridalEngName, string bridalPhone
            , string groomName, string groomEngName, string groomPhone
            , string orderType, string religiousType, string isLegal)
        {
            if (string.IsNullOrEmpty(str)) return str;
            str = str.Replace("ChurchNamePattern", churchName);
            str = str.Replace("WeddingDatePattern", weddingDate);
            str = str.Replace("BridalNamePattern", bridalName);
            str = str.Replace("BridalEngNamePattern", bridalEngName);
            str = str.Replace("BridalPhonePattern", bridalPhone);
            str = str.Replace("GroomNamePattern", groomName);
            str = str.Replace("GroomEngNamePattern", groomEngName);
            str = str.Replace("GroomPhonePattern", groomPhone);
            str = str.Replace("OrderTypePattern", orderType);

            str = str.Replace("ReligiousCeremonyPattern", religiousType);
            str = str.Replace("LegalPattern", isLegal);
            return str;
        }
    }
}