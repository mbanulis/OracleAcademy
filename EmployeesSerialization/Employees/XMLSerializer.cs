using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Employees
{
    class XMLSerializer: ISerializer
    {
        //protected static string path = "EmployeeInfo.dat";
       // static XmlSerializer xmlFormat = new XmlSerializer();
        public void SaveEmployeeData(object obj)
        {
           // using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
             //   binForm.Serialize(fs, obj);
          //  }
        }
        public List<Employee> LoadEmployeedata()
        {
           List<Employee> deserializedEmp= null;
           // using (FileStream fs = File.OpenRead(path))
          //  {
              //  deserializedEmp = (List<Employee>)binForm.Deserialize(fs);
          //  }
            return deserializedEmp;
        }
    }
}
