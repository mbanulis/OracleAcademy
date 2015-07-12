using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string path = "options.ini";
            string tmp = ReadFileConfiguration(path);

            ISerializer obj;
            if(tmp == "BIN")
            {
                obj = new BinarySerializer();
                Menu menu = new Menu(obj);
                menu.DisplayMenu();
            }
            else if (tmp=="XML")
            {
                obj = new XMLSerializer();
                Menu menu = new Menu(obj);
                menu.DisplayMenu();
            }

           
           
  
            //string a = ReaderConfiguration.ReadFile();
            //Console.WriteLine(a);
           
          

            
        }

        public static string ReadFileConfiguration(string path) //Проблемка
        {
            try
            {
                string s;
                using (StreamReader sr = new StreamReader(path))
                {
                    s = sr.ReadToEnd();
                }
                return s;
            }
            catch (Exception e)
            {
                return "Exception: " + e.Message;
            }
        }
        
    }
}
