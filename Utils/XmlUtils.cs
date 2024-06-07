using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace DECXML_Maximillian_Leonard.Utils
{
    public class XmlUtils
    {
        public static void WriteXML(string fileName, string childName)
        {
            string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string finalPath = Path.Combine(rootDirectoryPath, "xml", $"{fileName}.xml");

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            con.Open();
            string strSQL = $"SELECT * FROM {fileName}";
            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet(fileName);
            dt.Fill(ds, childName);
            ds.WriteXml(finalPath);
            con.Close();
        }

        public static string ReadXML(string xmlName)
        {
            string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string xmlPath = Path.Combine(rootDirectoryPath, "xml", $"{xmlName}.xml");

            string xmlString = File.ReadAllText(xmlPath);

            return xmlString;
        }

        public static string CapitalizeLetter(string word)
        {
            return Regex.Replace(word, "^[a-z]", c => c.Value.ToUpper());
        }
    }
}