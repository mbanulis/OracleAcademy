using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Menu
    {

        private ISerializer kindOfSerialization;

        public ISerializer KindOfSerialization
        {
            get { return kindOfSerialization; }
            set { kindOfSerialization = value;}
        }

        private List<Employee> allEmployees;

        public List<Employee> AllEmployees
        {
            get { return allEmployees; }
            set { allEmployees = KindOfSerialization.LoadEmployeedata(); }
        }

        public Menu(ISerializer kindOfSerialization)
       {
           this.KindOfSerialization = kindOfSerialization;
           this.AllEmployees = KindOfSerialization.LoadEmployeedata();
       }
        public void DisplayMenu()
        {
            while (true)
            {
               
                Console.WriteLine("Employee's databaase".ToUpper()+"\n");
                Console.WriteLine("1. Create new Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. Display Employee Information");
                Console.WriteLine("4. Display all Employees");
                Console.WriteLine("5. Exit");
                string tmp = Console.ReadLine();
                switch (tmp)
                {
                    case "1":
                        AllEmployees.Add(CreateEmployee());
                        break;
                    case "2":
                        DeleteEmployee();
                        break;
                    case "3":
                        DisplayEmployeeInformation();
                        break;
                    case "4":
                        DisplayAllEmployees();
                        break;
                    case "5":
                        KindOfSerialization.SaveEmployeeData(AllEmployees);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }

        }
        public Employee CreateEmployee()
        {
            Employee E1=new Employee();
            Console.WriteLine("Employee name: ");
            E1.Name = Console.ReadLine();
            Console.WriteLine("Employee surname: ");
            E1.Surname = Console.ReadLine();
            Console.WriteLine("Employee age: ");
            E1.Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Employee position: ");
            E1.Position = Console.ReadLine();
            Console.WriteLine("Employee salary: ");
            E1.Salary = Double.Parse(Console.ReadLine());
            return E1;
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("To delete Employee's record, enter Emloyee's ID");
            int tmp = Int32.Parse(Console.ReadLine());
            if (AllEmployees.Exists(x => x.MyID == tmp))
            {
                Employee e = AllEmployees.Find(x => x.MyID == tmp);
                AllEmployees.Remove(e);
            }
            else
            {
                Console.WriteLine("Employee with entered ID does not exist");
            }
        }
        public void DisplayEmployeeInformation()
        {
            Console.WriteLine("Enter Emloyee's ID to display Employee information");
            int tmp = Int32.Parse(Console.ReadLine());
            if(AllEmployees.Exists(x=>x.MyID==tmp))
            {
                Employee e = AllEmployees.Find(x => x.MyID == tmp);
                Console.WriteLine(e.ToString());
            }
            else
            {
                Console.WriteLine("Employee with entered ID does not exist");
            }
            
        }
        public void DisplayAllEmployees()
        { 
            foreach(Employee e in AllEmployees)
            {
                Console.WriteLine(e.ToString());
            }
        }
     
    }
}
