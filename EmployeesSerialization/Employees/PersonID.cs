using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public abstract class PersonID
    {
        
        private static int currentID;

        public int MyID { get; set; }
        static PersonID()
        {
            currentID = 0;
        }
        public PersonID()
         {
             this.MyID = GetNextID();
         }

        protected int GetNextID()
        {
            return ++currentID;
        }
    }
}
