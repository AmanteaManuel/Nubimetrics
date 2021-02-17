using System;
using System.Configuration;
using System.IO;
using System.Text;
using WebApi.Models;

namespace WebApi.Services
{
    public class CSVFilesServices
    {
        public static void WriteCSV(string text)
        {            
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine(text + ";");
            string csvpath = ConfigurationManager.AppSettings["PATH_CURRENCIES"].ToString();
            File.AppendAllText(csvpath, csvContent.ToString());

        }
    }
}