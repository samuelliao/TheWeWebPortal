using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TheWeLib;
using NPOI.XSSF.Model; // InternalWorkbook
using NPOI.XSSF.UserModel; // HSSFWorkbook, HSSFSheet

namespace TheWeWebSite.Output
{
    public class ContractDoc
    {
        XSSFWorkbook WORKBOOK;
        XSSFSheet WORKSHEET;

        public string CreateContractDoc(string sn
            , string bridalName, string bridalEmail, string bridalPhone
            , string groomName, string groomEmail, string groomPhone
            , string ServiceName, string setName, string otherPrcie, string price, string expectDate)
        {
            string folderPath = SysProperty.ImgRootFolderpath + @"\docTemplate";
            string filePath = folderPath + @"\Template\Contract2016TW.xlsx";
            ReadXlsxDoc(filePath);
            if (WORKBOOK != null)
            {
                WORKSHEET = (XSSFSheet)WORKBOOK.GetSheetAt(0);
                filePath = folderPath + @"/" + sn + "_Contract.xlsx";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                for (int rowCnt = 3; rowCnt < 17; rowCnt++)
                {
                    if (WORKSHEET.GetRow(rowCnt) == null) continue;
                    for (int cellCnt = 0; cellCnt < 7; cellCnt++)
                    {
                        var cell = WORKSHEET.GetRow(rowCnt).GetCell(cellCnt);
                        if (cell != null)
                        {
                            if (cell.StringCellValue.Contains("Pattern"))
                            {
                                cell.SetCellValue(ReplacePattern(cell.StringCellValue
                                    , bridalName, bridalEmail, bridalPhone
                                    , groomName, groomEmail, groomPhone
                                    , ServiceName, setName, otherPrcie, price, expectDate));
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

        private string ReplacePattern(string str
            , string bridalName, string bridalEmail, string bridalPhone
            , string groomName, string groomEmail, string groomPhone
            , string ServiceName, string setName, string otherPrcie, string price, string expectDate)
        {
            if (string.IsNullOrEmpty(str)) return str;
            str = str.Replace("DateTimePattern", DateTime.Now.ToString("dd/MM/yyyy"));
            str = str.Replace("BridalEmailPattern", bridalEmail);
            str = str.Replace("BridalNamePattern", bridalName);
            str = str.Replace("BridalPhonePattern", bridalPhone);
            str = str.Replace("GroomEmailPattern", groomEmail);
            str = str.Replace("GroomNamePattern", groomName);
            str = str.Replace("GroomPhonePattern", groomPhone);

            str = str.Replace("SetNamePattern", setName);
            str = str.Replace("ExpectDatePattern", expectDate);
            str = str.Replace("SetPricePattern", price);
            str = str.Replace("OtherPricePattern", otherPrcie);
            str = str.Replace("ServicePattern", ServiceName);
            return str;
        }
    }
}