using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
   
{
     [Serializable]
    public class Employee: Person
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public Employee()
        {

        }
        public Employee( double salary, string position, string name, string surname, int age):base (name,  surname, age) 
        {
            this.Salary = salary;
            this.Position = position;

        }
        public override string ToString()
        {
            return "Employee's ID: " + MyID + ";\n" + "Employee's Name: " + Name + ";\n" +
           "Employee's surname: " + Surname + ";\n" + "Employee's age: " + Age + ";\n" + "Employee's position: " +
           Position + ";\n" + "Employee's salary: " + Salary + ";\n";

        }
    }
   
}
