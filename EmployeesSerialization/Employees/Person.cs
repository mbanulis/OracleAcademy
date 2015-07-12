using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
{
    [Serializable]
    public abstract class Person: PersonID
    {
       
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private DateTime date_of_birth;

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
       public Person()
       {}
      
        public Person( string name, string surname, int age):base()
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
    }
    
}
