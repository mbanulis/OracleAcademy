using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    interface ISerializer
    {
        //string ReadFileConfiguration(string path);
        void SaveEmployeeData(object obj);
        List <Employee> LoadEmployeedata();
    }
}
