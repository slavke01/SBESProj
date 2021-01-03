using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml;

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


        public static void WriteInXML(string text)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = null;

            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

          
            string path = "..\\..\\..\\AuditEventLogCert.xml";
            using (StreamWriter fileWriter = new StreamWriter(path, true))
            {
                writer = XmlWriter.Create(fileWriter, settings);

                writer.WriteStartElement("AuditEvent");
                writer.WriteAttributeString("Log",text);
                writer.WriteEndElement();

                writer.Flush();
            }


        }
    }
}
