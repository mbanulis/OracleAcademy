using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Device> smartDevices = new Dictionary<string, Device>();
            smartDevices.Add("L1", new Lamp("L1", false));
            smartDevices.Add("C1", new Conditioner("C1", false, 40, 0, 0, EnumSeasons.summer));
            Burner b1 = new Burner();
            Burner b2 = new Burner();
            Burner b3 = new Burner();
            Burner b4 = new Burner();
            CookingSurfase CookSurf = new CookingSurfase("CookSurf", false, b1, b2, b3, b4);
            Oven O1 = new Oven("Oven1", true, EnumOvenMode.bottomHeat, 0, true);
            smartDevices.Add("Cook1", new Stove("Cook1", false, CookSurf, O1));
            smartDevices.Add("H1", new HeatingBoiler("H1", false, 40, 0, 0, EnumSeasons.summer));
            smartDevices.Add("K1", new KitchenVentilation("K1", false, Mode.normal));

            Menu menu = new Menu();
            string command1;
            string command2;
            string[] C1;
            for (int count3 = 0; ; count3++)
            {
                menu.MainMenu();
                command1 = Console.ReadLine();
                Console.Clear();
                C1 = command1.Split(' ');
                if (C1[0] == "выход")
                {
                    Environment.Exit(0);
                }
                else
                {
                    switch (C1[0])
                    {
                        case "конфигурация":
                            for (int count = 0; ; count++)
                            {
                                command2 = menu.MenuForKonfiguration();
                                string[] C2 = command2.Split(' ');
                                if (C2[0] == "вернуться")
                                {
                                    menu.MainMenu();
                                    break;
                                }
                                else
                                {
                                    switch (C2[0])
                                    {
                                        case "создать":
                                            menu.CreateDevice(smartDevices, C2[3]);
                                            Console.Clear();
                                            menu.DisplayObjectsAll(smartDevices);
                                            Console.ReadKey();
                                            break;
                                        case "удалить":
                                            Console.Clear();
                                            menu.DisplayObjectNames(smartDevices);
                                            menu.MenuToDeleteComponent(smartDevices);
                                            menu.DisplayObjectsAll(smartDevices);
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                            }
                            break;
                        case "управление":
                            try
                            {
                                menu.MenuToManageComponent(smartDevices);
                            }
                            catch (OverflowException e)
                            {
                                Console.WriteLine("ОШИБКА: " + e.Message);
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("ОШИБКА: " + ex.Message);
                                Console.ReadKey();
                            }
                            break;
                        case "отображение":
                            menu.MenuToDisplayObjects(smartDevices);
                            break;
                    }
                }
            }
        }
    }
}
