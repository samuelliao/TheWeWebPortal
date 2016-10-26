using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DbBackupMgt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(Properties.Settings.Default.FolderPath))
            {
                string[] files = Directory.GetFiles(Properties.Settings.Default.FolderPath);
                DateTime fileModTime;
                DateTime compareTime = DateTime.Now.AddDays(Properties.Settings.Default.ExpireDay * (-1));
                foreach(string file in files)
                {
                    fileModTime = File.GetLastWriteTime(file);
                    if(DateTime.Compare(fileModTime, compareTime) < 0)
                    {
                        File.Delete(file);
                    }
                }
            }
        }
    }
}
