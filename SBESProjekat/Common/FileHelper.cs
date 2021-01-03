using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Common
{
    public class FileHelper
    {
        public static void WriteInTxt(string text)
        {
            string path = "..\\..\\..\\AuditEventFile.txt";
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(text);
            sw.Close();
            stream.Close();
        }
    }
}
