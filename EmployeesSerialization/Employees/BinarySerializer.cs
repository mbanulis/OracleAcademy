using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class BinarySerializer: ISerializer

    {
       protected static string path = "EmployeeInfo.dat";
       static BinaryFormatter binForm = new BinaryFormatter();

       public void SaveEmployeeData(object obj)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                binForm.Serialize(fs, obj);
            }
        }
        public List<Employee> LoadEmployeedata()
        {
            List<Employee> deserializedEmp;
            using (FileStream fs = File.OpenRead(path))
            {
                   deserializedEmp = (List<Employee>)binForm.Deserialize(fs);
            }
            return deserializedEmp;
        }
    }
}
