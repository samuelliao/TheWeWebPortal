using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Novacode;
using TheWeLib;
using System.Data;

namespace TheWeWebSite.Output
{
    public class AdvisoryDoc
    {
        public string GenerateDoc(string sn, DateTime time
            , string bridalName, string bridalEngName, string bridalPhone, string bridalMsg, string bridalBday, string bridalWork, string bridalMail
            , string groomName, string groomEngName, string groomPhone, string groomMsg, string groomBday, string groomWork, string groomMail
            , string advisoryItem, string interestCountry, string weddingPlanning, List<DataRow> locLst
            , string filmDate, string weddingDate, string receptionDate, string howtoknow)
        {
            string folderPath = SysProperty.ImgRootFolderpath + @"\docTemplate";
            if (Directory.Exists(folderPath))
            {
                string filePath = folderPath + @"\Template\AdvisoryDoc.docx";
                if (File.Exists(filePath))
                {
                    using (DocX document = DocX.Load(filePath))
                    {
                        filePath = folderPath + @"/" + sn + "_Advisory.docx";
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        document.ReplaceText("BridalNamePattern", bridalName);
                        document.ReplaceText("BridalPhonePattern", bridalPhone);
                        document.ReplaceText("BridalEngNamePattern", bridalEngName);
                        document.ReplaceText("BridalBdayPattern", bridalBday);
                        document.ReplaceText("BridalWorkPattern", bridalWork);
                        document.ReplaceText("BridalMsgerPattern", bridalMsg);
                        document.ReplaceText("BridalMailPattern", bridalMail);

                        document.ReplaceText("GroomNamePattern", groomName);
                        document.ReplaceText("GroomPhonePattern", groomPhone);
                        document.ReplaceText("GroomEngNamePattern", groomEngName);
                        document.ReplaceText("GroomBdayPattern", groomBday);
                        document.ReplaceText("GroomWorkPattern", groomWork);
                        document.ReplaceText("GroomMsgerPattern", groomMsg);
                        document.ReplaceText("GroomMailPattern", groomMail);

                        document.ReplaceText("AdvisoryItemPattern", advisoryItem);
                        document.ReplaceText("InterestCountryPattern", interestCountry);
                        document.ReplaceText("WeddingPlanPattern", weddingPlanning);

                        document.ReplaceText("FilmDatePattern", filmDate);
                        document.ReplaceText("WeddingDatePattern", weddingDate);
                        document.ReplaceText("RecptionDatePattern", receptionDate);
                        document.ReplaceText("SourceInfoPattern", howtoknow);

                        document.ReplaceText("AdvisoryDatePattern", time.ToString("yyyy/MM/dd"));
                        int cnt = 10;
                        if (locLst.Count > 0)
                        {
                            foreach (var dr in locLst.Select(x => x["CountryId"]).Distinct())
                            {
                                string loc = LocationConverter(dr.ToString(), locLst);
                                Row row = document.Tables[0].InsertRow(document.Tables[0].Rows[9], cnt);
                                row.Cells[0].Paragraphs.First().Append(
                                    SysProperty.Util.OutputRelatedLangName(string.Empty
                                    , SysProperty.GetCountryById(dr.ToString())));
                                row.Cells[1].Paragraphs.First().Append(loc);
                                cnt++;
                            }
                        }
                        document.Tables[0].RemoveRow(9);
                        document.SaveAs(filePath);
                    }
                    return filePath;
                }
            }
            return string.Empty;
        }

        public string LocationConverter(string countryId, List<DataRow> lst)
        {
            string result = string.Empty;
            if (lst.Count > 0)
            {
                foreach(DataRow dr in lst.Where(x => x["CountryId"].ToString().Equals(countryId)))
                {
                    result += string.IsNullOrEmpty(result) ? string.Empty : ", ";
                    result += SysProperty.Util.OutputRelatedLangName(string.Empty, dr)+"("+ SysProperty.Util.OutputRelatedLangName
                            (string.Empty, SysProperty.GetAreaById(dr["AreaId"].ToString())) +")";
                }
            }
            return result;
        }
    }
}