using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace lab9_ASP_MVC_Views.Models
{
    public class MyData
    {
        public List<List<string>> Values;
        public string[] tNames { get; set; }

        public MyData()
        {
            tNames = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/App_Data"));
            for (int i = 0; i < tNames.Length; i++)
            {
                tNames[i] = Path.GetFileNameWithoutExtension(tNames[i]);
            }
            Values=new List<List<string>>();
        }

        public List<List<string>> getData(string fileName)
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data");
            string[] arr;
            fileName = path + "\\" + fileName + ".csv";
            string[] data = File.ReadAllLines(fileName);
           
            for (int i = 0; i < data.Length; i++)
            {
                if (!String.IsNullOrEmpty(data[i]))
                {
                    arr = data[i].Split(';');
                    Values.Add(arr.ToList());
                }
            }
            return Values;
        }
    }
}