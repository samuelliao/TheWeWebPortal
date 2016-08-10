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
        public string CreateGroupPhoto(string sn, string bridalName, string groomName, string venue, DateTime weddingDate)
        {
            string folderPath = SysProperty.ImgRootFolderpath + @"\docTemplate";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = folderPath + @"\GroupPhotoShootingArrangement.docx";
            using (DocX document = DocX.Load(filePath))
            {
                filePath = folderPath + @"/"+sn+"_Photo.docx";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                document.ReplaceText("Bride and Groom: ", "Bride and Groom: " + bridalName + " & " + groomName);
                document.ReplaceText("Wedding Date:", "Wedding Date: " + weddingDate.ToString("MM, dd, yyyy"));
                document.ReplaceText("Wedding Venue: ", "Wedding Venue: " + venue);
                document.ReplaceText("Wedding Time:", "Wedding Time: " + weddingDate.ToString("HH:mm")); 
                document.SaveAs(filePath);
            }
            return filePath;

        }
    }
}