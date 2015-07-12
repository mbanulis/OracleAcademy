using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class Menu
    {

        public void MainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            string header = "Умный дом";
            string h2 = "Список доступных компонентов:";
            Console.WriteLine(header.ToUpper() + "\n" + "\n" + h2.ToUpper() + "\n");
            string[] c1 = new string[5] { "1. Лампа", "2. Плита", "3. Кондиционер", "4. Котел", "5. Кухонная вытяжка" };
            foreach (string c in c1)
            {
                Console.WriteLine(c);
            }
            string m = "Главное меню";
            Console.WriteLine("\n" + m.ToUpper() + "\n");
            string[] MainMenu = new string[4] { "1. Конфигурация", "2. Управление", "3. Отображение текущего состояния", "4. Выход из программы" };
            foreach (string a in MainMenu)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n" + "Введите команду" + "\n");
        }
        public string MenuForKonfiguration()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Меню конфигурации компонентов Умного дома".ToUpper() + "\n");
            Console.ResetColor();
            string[] menu = new string[4];
            menu[0] = "Создать компонент типа (Пример ввода: 'Создать компонент типа котел')";
            menu[1] = "Удалить компонент (Пример ввода: 'Удалить')";
            menu[2] = "Вернуться в предыдущее меню (Пример ввода: 'Вернуться')";
            foreach (string c in menu)
            {

                Console.WriteLine(c);
            }

            Console.WriteLine("\n" + "Введите команду" + "\n");
            string aa = Console.ReadLine();
            return aa;
        }
        public void MenuManagement()
        {
            Console.WriteLine("Meню Управление \n".ToUpper());
            Console.WriteLine("Возврат в Главное меню: введите 15");
        }
        public void CreateDevice(Dictionary<string, Device> obj, string choice)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Меню создания компонента Умного дома".ToUpper() + "\n");
            Console.ResetColor();
            Console.WriteLine("Введите имя устройства");
            string name = Console.ReadLine();
            if (choice == "лампа")
            {
                Lamp myLamp = new Lamp();
                myLamp.DeviceName = name;
                obj.Add(name, myLamp);
                Console.Clear();
                Console.WriteLine("Компонент  успешно создан \n".ToUpper());
                Console.WriteLine(myLamp.ToString());
                Console.ReadKey();
            }
            if (choice == "кондиционер")
            {
                Conditioner myConditioner = new Conditioner();
                myConditioner.DeviceName = name;
                SubMenuToCreateClimatobject(myConditioner);
                obj.Add(name, myConditioner);
                Console.Clear();
                Console.WriteLine("Компонент  успешно создан \n".ToUpper());
                Console.WriteLine(myConditioner.ToString());
                Console.ReadKey();
            }
            if (choice == "котел")
            {
                HeatingBoiler myBoiler = new HeatingBoiler();
                myBoiler.DeviceName = name;
                SubMenuToCreateClimatobject(myBoiler);
                obj.Add(name, myBoiler);
                Console.WriteLine("Компонент  успешно создан \n".ToUpper());
                Console.WriteLine(myBoiler.ToString());
                Console.ReadKey();

            }
            if (choice == "кухонная вытяжка")
            {
                KitchenVentilation myVentilation = new KitchenVentilation();
                myVentilation.DeviceName = name;
                obj.Add(name, myVentilation);
                Console.Clear();
                Console.WriteLine("Компонент  успешно создан \n".ToUpper());
                Console.WriteLine(myVentilation.ToString());
                Console.ReadKey();

            }
            if (choice == "плита")
            {
                Burner B1 = new Burner();
                Burner B2 = new Burner();
                Burner B3 = new Burner();
                Burner B4 = new Burner();
                CookingSurfase CS1 = new CookingSurfase("CS1", false, B1, B2, B3, B4);
                Oven O = new Oven();
                Stove myCooker = new Stove(CS1, O);
                myCooker.DeviceName = name;
                obj.Add(name, myCooker);
                Console.Clear();
                Console.WriteLine("Компонент  успешно создан \n".ToUpper());
                Console.WriteLine(myCooker.ToString());
                Console.ReadKey();
            }

        }

        public void SubMenuToCreateClimatobject(ClimatControl obj)
        {
            Console.WriteLine("\n\n" + "Первоначальная настройка устройства".ToUpper() + "\n");
            Console.WriteLine("Укажите режим работы устройства(зима/лето)");
            string mod = Console.ReadLine();
            if (mod.StartsWith("Зи") || mod.StartsWith("зи"))
            {
                ((ClimatControl)obj).Seasons = EnumSeasons.winter;
            }
            else
                ((ClimatControl)obj).Seasons = EnumSeasons.summer;
            Console.WriteLine("Укажите максимально возможную температуру для работы устройства");
            ((ClimatControl)obj).MaxDeviceTemperature = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Укажите минимально возможную температуру для работы устройства");
            ((ClimatControl)obj).MinDeviceTemperature = Int32.Parse(Console.ReadLine());
        }
        public void MenuForManagement(Dictionary<string, Device> d)
        {
            while (true)
            {
                DisplayObjectNames(d);
                Console.WriteLine("Введите имя устройства");
                Console.WriteLine("Вернуться в предыдущее меню: введите 0");
                string tmp = Console.ReadLine();
                if(tmp == "0")
                {
                    MenuToManageComponent(d);
                }
                else
                {
                    Device obj = null;
                    while(true)
                    {
                        if (d.ContainsKey(tmp))
                        {
                            obj = d[tmp];
                            Console.Clear();
                            DisplayObjectToString(obj);
                            string command1;
                            if (obj is Stove)
                            {
                                MenuToManageCooker((Stove)obj);
                            }
                            else
                            {
                                if (obj is ISwitcher)
                                {
                                    MenuSwitchDevice((ISwitcher)obj);
                                }

                                if (obj is IOpenClose)
                                {
                                    OpenerDevice((IOpenClose)obj);
                                }
                                if ((obj is ITemperature))
                                {
                                    Console.WriteLine("Установить температуру. Введите 5");
                                }
                                if (obj is IRegulator)
                                {
                                    Regulator((IRegulator)obj);
                                }
                                if (obj is IModeSeason)
                                {
                                    SetSeason((IModeSeason)obj);
                                }
                                if (obj is IRegime)
                                {
                                    SetRegime((IRegime)obj);
                                }
                                if (obj is Device)
                                {
                                    Console.WriteLine("Вернуться в предыдущее меню: введите 0");
                                }
                                command1 = Console.ReadLine();
                                if (command1 == "0")
                                {

                                    return;
                                }
                                else
                                {
                                    switch (command1)
                                    {
                                        case "1":
                                            ((ISwitcher)obj).SwitchOn();
                                            break;
                                        case "2":
                                            ((ISwitcher)obj).SwitchOff();
                                            break;
                                        case "3":
                                            ((IOpenClose)obj).Opened();
                                            break;
                                        case "4":
                                            ((IOpenClose)obj).Closed();
                                            break;
                                        case "5":
                                            if (obj.DeviceState == true)
                                                SetTemperature((ITemperature)obj);
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "6":
                                            if (obj.DeviceState == true)
                                                ((IRegulator)obj).Increasing();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "7":
                                            if (obj.DeviceState == true)
                                                ((IRegulator)obj).Decreasing();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "8":
                                            if (obj.DeviceState == true)
                                                ((IModeSeason)obj).SetSummerMode();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "9":
                                            if (obj.DeviceState == true)
                                                ((IModeSeason)obj).SetWinterMode();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "10":
                                            if (obj.DeviceState == true)
                                                ((IRegime)obj).SetMaximumMode();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "11":
                                            if (obj.DeviceState == true)
                                                ((IRegime)obj).SetMinimumMode();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "12":
                                            if (obj.DeviceState == true)
                                                ((IRegime)obj).SetNormalMode();
                                            else
                                            {
                                                Console.WriteLine("Для работы устройства необходимо его включить");
                                                Console.ReadKey();
                                            }
                                            break;

                                    }
                                }
                            }

                            }
                            

                    }
                }
            }
        }
                  
        public void MenuToManageComponent(Dictionary<string, Device> d)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n" + "Meню Управление \n".ToUpper());
                Console.WriteLine("Возврат в Главное меню: введите 0");
                Console.WriteLine("Управление устройством: введите 1");
                string m = Console.ReadLine();
                if (m == "1")
                {
                    Console.Clear();
                    MenuForManagement(d);
                }
                else if (m == "0")
                {
                    return;
                }
            }
               
        }
        public void DisplayObjectsAll(Dictionary<string, Device> obj)
        {
            Console.Clear();
            Console.WriteLine("\n" + "Текущее состояние устройств".ToUpper() + "\n\n");
            foreach (Device j in obj.Values)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(j.ToString());
            }
        }
        public void DisplayObjectNames(Dictionary<string, Device> obj)
        {
            Console.WriteLine("Список доступных компонент \n".ToUpper());
            foreach (Device i in obj.Values)
            {
                if (i is Lamp)
                    Console.WriteLine("Лампа: " + i.DeviceName);
                if (i is Conditioner)
                    Console.WriteLine("Кондиционер: " + i.DeviceName);
                if (i is HeatingBoiler)
                    Console.WriteLine("Котел: " + i.DeviceName);
                if (i is Stove)
                    Console.WriteLine("Плита: " + i.DeviceName);
                if (i is KitchenVentilation)
                    Console.WriteLine("Кухонная вытяжка: " + i.DeviceName);
            }
        }
        public void DisplayObjectToString(Device obj)
        {
            if (obj is Lamp)
                Console.WriteLine(obj.ToString());
            if (obj is Conditioner)
                Console.WriteLine(obj.ToString());
            if (obj is HeatingBoiler)
                Console.WriteLine(obj.ToString());
            if (obj is Stove)
                Console.WriteLine(((Stove)obj).ToString());
            if (obj is KitchenVentilation)
                Console.WriteLine(obj.ToString());
        }
        public void MenuToDisplayObjects(Dictionary<string, Device> obj)
        {
            while(true)
            {
            Console.ResetColor();
            Console.WriteLine("Меню отображение".ToUpper() + "\n");
            Console.WriteLine("Отобразить все компоненты: введите 1");
            Console.WriteLine("Вернуться в предыдущее меню: введите 0");
            string c = Console.ReadLine();
            if(c=="1")
            {
                Console.ForegroundColor = ConsoleColor.Green;
               DisplayObjectsAll(obj);
               
            }
            else if(c=="0")
            {
                return;
            }
                else
            {
                Console.WriteLine("Выберите правильную команду");
            }
            }
                
        }

        public void MenuToDeleteComponent(Dictionary<string, Device> obj)
        {
            Console.WriteLine("Введите Имя устройства, которое необходимо удалить");
            string s = Console.ReadLine();
            if (obj.ContainsKey(s))
            {
                obj.Remove(s);
                Console.WriteLine("\n Компонент удален".ToUpper());
            }
            else
                Console.WriteLine("Объект с таким именем не существует");
            Console.ReadKey();
        }
        public void MenuSwitchDevice(ISwitcher obj)
        {
            Console.WriteLine("Включить устройство. Введите 1");
            Console.WriteLine("Выключить устройство. Введите 2");
        }
        public void OpenerDevice(IOpenClose obj)
        {

            Console.WriteLine("Открыть дверцу. Введите 3");
            Console.WriteLine("Закрыть дверцу. Введите 4");


        }
        public void Regulator(IRegulator obj)
        {
            Console.WriteLine("Увеличить температуру устройства. Введите 6");
            Console.WriteLine("Снизить температуру устройства. Введите 7");

        }
        public void SetSeason(IModeSeason obj)
        {
            Console.WriteLine("Установить режим 'Лето'. Введите 8");
            Console.WriteLine("Установить режим 'Зима'. Введите 9");


        }
        public void SetRegime(IRegime obj)
        {
            Console.WriteLine("Установить режим 'Максимум'. Введите 10");
            Console.WriteLine("Установить режим 'Минимум'. Введите 11");
            Console.WriteLine("Установить режим 'Средний'. Введите 12");


        }
        public void SetTemperature(ITemperature obj)
        {

            Console.WriteLine("Установите температуру");
            int tmp = Int32.Parse(Console.ReadLine());
            ((ITemperature)obj).Temperature = tmp;

        }
        public void MenuToManageCooker(Stove obj)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Меню управления плитой".ToUpper() + "\n");
                Console.WriteLine("Варочная поверхность: введите 1");
                Console.WriteLine("Духовка: введите 2");
                Console.WriteLine("Вернуться в предыдущее меню: введите 0");
                string tmp = Console.ReadLine();
                switch (tmp)
                {
                    case "1":

                        for (int count = 0; ; count++)
                        {
                            string tmpBurner = null;
                            if (tmpBurner == "5")
                            {
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Управление варочной поверхностью".ToUpper()+"\n");
                                Console.WriteLine("Правая верхняя комфорка: введите 1");
                                Console.WriteLine("Правая нижняя комфорка: введите 2");
                                Console.WriteLine("Левая нижняя комфорка: введите 4");
                                Console.WriteLine("Левая верхняя комфорка: введите 3");
                                Console.WriteLine("Вернуться в предыдущее меню: введите 0");
                                tmpBurner = Console.ReadLine();
                                switch (tmpBurner)
                                {
                                    case "1":
                                        Console.Clear();
                                        BurnerMenu(obj.MyCookingSurfase.UpperRightBurner);
                                        break;
                                    case "2":
                                        Console.Clear();
                                        BurnerMenu(obj.MyCookingSurfase.BottomRightBurner);
                                        break;
                                    case "3":
                                        Console.Clear();
                                        BurnerMenu(obj.MyCookingSurfase.BottomLeftBurner);
                                        break;
                                    case "4":
                                        BurnerMenu(obj.MyCookingSurfase.UpperLeftBurner);
                                        break;
                                    case "0":
                                        return;
                                    default:
                                        Console.WriteLine("Введите правильную команду");
                                        break;
                                }
                            }
                        }
                        break;
                    case "2":
                        OvenMenu(obj);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Введите правильную команду");
                        break;

                }

            }
            
        }
        public static void BurnerMenu(Burner obj)
        {
            Console.Clear();
            string t = null;
            for (int count2 = 0; ; count2++)
            {
                if (t == "6")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + "Комфорка. Управление".ToUpper() + "\n");
                    Console.WriteLine("Включить комфорку - 1");
                    Console.WriteLine("Выключить комфорку- 2");
                    Console.WriteLine("Установить режим Максимум-3");
                    Console.WriteLine("Установить режим Минимум-4");
                    Console.WriteLine("Установить режим Нормал-5");
                    Console.WriteLine("Вернуться в предыдущее меню-6");
                    t = Console.ReadLine();

                    switch (t)
                    {
                        case "1":
                            obj.SwitchOn();
                            break;
                        case "2":
                            obj.SwitchOff();
                            break;
                        case "3":
                            if (obj.DeviceState == true)
                                obj.SetMaximumMode();
                            else
                                return;
                            break;
                        case "4":
                            if (obj.DeviceState == true)
                                obj.SetMinimumMode();
                            else
                                return;
                            break;
                        case "5":
                            if (obj.DeviceState == true)
                                obj.SetNormalMode();
                            else
                                return;
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine(obj.ToString());
                }
            }


        }

        public static void OvenMenu(Stove obj)
        {
            Console.Clear();
            string t = null;
            for (int count2 = 0; ; count2++)
            {
                if (t == "10")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + "Духовой шкаф. Управление".ToUpper() + "\n");
                    Console.WriteLine("Включить духовку: введите 1");
                    Console.WriteLine("Выключить духовку: введите 2");
                    Console.WriteLine("Установить температуру духового шкафа: введите 13");
                    Console.WriteLine("Открыть дверцу духового шкафа: введите 11");
                    Console.WriteLine("Закрыть дверцу духового шкафа: введите 12");
                    Console.WriteLine("Установить режим приготовления 'Вентилятор + гриль + нижний нагрев': введите 3");
                    Console.WriteLine("Установить режим приготовления 'Кольцевой нагревательный элемент + вентилятор': введите 4");
                    Console.WriteLine("Установить режим приготовления 'Верхний нагрев + нижний нагрев': введите 5");
                    Console.WriteLine("Установить режим приготовления 'Верхний нагрев': введите 6");
                    Console.WriteLine("Установить режим приготовления 'Нижний нагрев': введите 7");
                    Console.WriteLine("Установить режим приготовления 'Гриль': введите 8");
                    Console.WriteLine("Установить режим приготовления 'Tурбо-Гриль': введите 9");
                    Console.WriteLine("Вернуться в предыдущее меню: введите 10");
                    Console.WriteLine("Введите номер команды");
                    t = Console.ReadLine();
                    switch (t)
                    {
                        case "1":
                            obj.OvenSwitchOn();
                            break;
                        case "2":
                            obj.OvenSwitchOff();
                            break;
                        case "3":
                           if(obj.MyOven.DeviceState==true)
                                obj.OvensetFanGrillBottomHeat();
                           else
                           {
                               Console.WriteLine("Для работы устройства необходимо его включить");
                               Console.ReadKey();
                           }
                            break;
                        case "4":
                            if (obj.MyOven.DeviceState == true)
                                obj.OvenSetRingHeatingElementFan();
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "5":
                            if (obj.MyOven.DeviceState == true)
                                obj.OvenSetTopHeatingBottomHeat();
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "6":
                            if (obj.MyOven.DeviceState == true)
                                obj.OvenSetTopHeating();
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "7":
                            if (obj.MyOven.DeviceState == true)
                                obj.OvenSetBottomHeat();
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "8":
                            if (obj.MyOven.DeviceState == true)
                            obj.OvenSetGrill();
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "9":
                            if (obj.MyOven.DeviceState == true)
                                obj.OvenSetTurboGrill();
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "11":
                            obj.OvenDoorOpened();
                            break;
                        case "12":
                            obj.OvenDoorClosed();
                            break;
                        case "13":
                            if (obj.MyOven.DeviceState == true)
                            {
                                Console.WriteLine("Введите значение температуры");
                                int tt = Int32.Parse(Console.ReadLine());
                                obj.MyOven.Temperature = tt;
                            }
                            else
                            {
                                Console.WriteLine("Для работы устройства необходимо его включить");
                                Console.ReadKey();
                            }
                            break;
                        case "10":
                            break;
                        default:
                            Console.WriteLine("Введите правильную команду");
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Духовой шкаф. Состояние".ToUpper() + "\n");
                    Console.WriteLine(obj.MyOven.ToString());
                }
            }
        }

    }
    
}
