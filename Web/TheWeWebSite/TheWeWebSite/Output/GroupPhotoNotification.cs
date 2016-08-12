using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Novacode;
using TheWeLib;
using System.IO;

namespace TheWeWebSite.Output
{
    public class GroupPhotoNotification
    {
        public string CreateGroupPhoto(string lang, string sn, string bridalName, string groomName, string venue, DateTime weddingDate)
        {
            string folderPath = SysProperty.ImgRootFolderpath + @"\docTemplate";
            if (Directory.Exists(folderPath))
            {
                string filePath = folderPath + @"\Template\Photo." + lang + ".docx";
                if (!File.Exists(filePath))
                {
                    filePath = folderPath + @"\Template\Photo.zh-TW.docx";
                }

                if (File.Exists(filePath))
                {
                    using (DocX document = DocX.Load(filePath))
                    {
                        filePath = folderPath + @"/" + sn + "_Photo.docx";
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        document.ReplaceText("CoupleNamePattern", bridalName + " & " + groomName);                                                
                        document.ReplaceText("VenuePattern", venue);

                        if (weddingDate.CompareTo(new DateTime()) > 0)
                        {
                            document.ReplaceText("DatePattern",weddingDate.ToString("MM, dd, yyyy"));
                            document.ReplaceText("TimePattern:", weddingDate.ToString("HH:mm"));
                        }
                        else
                        {
                            document.ReplaceText("DatePattern", "MM, dd, yyyy");
                            document.ReplaceText("TimePattern", "HH:mm");
                        }
                        document.SaveAs(filePath);
                    }
                    return filePath;
                }
            }
            return string.Empty;
        }
    }
}