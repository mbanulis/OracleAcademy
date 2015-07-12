using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class Stove : Device, ISwitcher
    {
        private CookingSurfase myCookingSurfase;
        public CookingSurfase MyCookingSurfase
        {
            get
            {
                return myCookingSurfase;
            }
            set
            {
                myCookingSurfase = value;
            }

        }
        private Oven myOven;
        public Oven MyOven
        {
            get
            {
                return myOven;
            }
            set
            {
                myOven = value;
            }
        }
        public Stove()
        { }
        public Stove(CookingSurfase cs, Oven o)
        {
            this.myCookingSurfase = cs;
            this.MyOven = o;
        }
        public Stove(string deviceName, bool deviceState, CookingSurfase myCookingSurfase, Oven myOven)
            : base(deviceName, deviceState)
        {

            this.MyCookingSurfase = myCookingSurfase;
            this.MyOven = myOven;
        }
        public override string ToString()
        {
            string temp;
            if (DeviceState)
            {
                temp = "включено";
            }
            else
            {
                temp = "выключено";
            }
            return
                "Устройство типа Плита: ".ToUpper() + DeviceName + ";" + "\n" +
                    "Cостояние: " + temp + ";" + "\n\n" +
                 "Варочная поверхность: " + MyCookingSurfase.DeviceName + ";" + "\n" +
                 "Cостояние: " + MyCookingSurfase.DeviceState + ";" + "\n\n" +
                "Правая верхняя комфорка: " + "\n" +
                "Cостояние комфорки: " + MyCookingSurfase.UpperRightBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + MyCookingSurfase.UpperRightBurner.Burnermode + ";" + "\n\n" +
                "Левая верхняя комфорка: " + "\n" +
                "Cостояние комфорки: " + MyCookingSurfase.UpperLeftBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + MyCookingSurfase.UpperLeftBurner.Burnermode + ";" + "\n\n" +
                 "Левая нижняя комфорка: " + "\n" +
                "Cостояние комфорки: " + MyCookingSurfase.BottomLeftBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + MyCookingSurfase.UpperLeftBurner.Burnermode + ";" + "\n\n" +
                "Правая нижняя комфорка: " + "\n" +
                "Cостояние комфорки: " + MyCookingSurfase.BottomRightBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + MyCookingSurfase.BottomRightBurner.Burnermode + ";" + "\n\n" +
                "Духовой шкаф: " + myOven.DeviceName + ";" + "\n" +
                 "Cостояние: " + MyOven.DeviceState + ";" + "\n" +
                 "Текущая температура в духовом шкафе: " + MyOven.Temperature + ";" + "\n" +
                 "Состояние дверцы: " + MyOven.OvenDoor + ";" + "\n" +
                  "Режим духового шкафа: " + MyOven.Ovenmode + ";" + "\n";
        }
        public void SwitchOn()
        {
            DeviceState = true;
        }
        public void SwitchOff()
        {
            DeviceState = false;
        }
        public void SwitchOnCookingSurface()
        {
            MyCookingSurfase.SwitchOn();
        }
        public void SwitchOffCookingSurface()
        {
            MyCookingSurfase.SwitchOff();
        }
        public void SwitchOnUpperRightBurner()
        {
            myCookingSurfase.UpperRightBurner.SwitchOn();
        }
        public void SwitchOffUpperRightBurner()
        {
            myCookingSurfase.UpperRightBurner.SwitchOff();
        }
        public void SwitchOnUpperLeftBurner()
        {
            myCookingSurfase.UpperLeftBurner.SwitchOn();
        }
        public void SwitchOffUpperLeftBurner()
        {
            myCookingSurfase.UpperLeftBurner.SwitchOff();
        }
        public void SwitchOnBottomRightBurner()
        {
            myCookingSurfase.BottomRightBurner.SwitchOn();
        }
        public void SwitchOffBottomRightBurner()
        {
            myCookingSurfase.BottomRightBurner.SwitchOff();
        }
        public void SwitchOnBottomLeftBurner()
        {
            myCookingSurfase.BottomLeftBurner.SwitchOn();
        }
        public void SwitchOffBottomLeftBurner()
        {
            myCookingSurfase.BottomLeftBurner.SwitchOff();
        }
        public void SwitchOnBurner(Burner obj)
        {
            obj.SwitchOn();
        }
        public void SwitchOffBurner(Burner obj)
        {
            obj.SwitchOff();
        }

        public void SetMaximumModeURB()
        {
            myCookingSurfase.UpperRightBurner.SetMaximumMode();
        }
        public void SetNormalModeURB()
        {
            myCookingSurfase.UpperRightBurner.SetNormalMode();

        }
        public void SetMinimumModeURB()
        {
            myCookingSurfase.UpperRightBurner.SetMinimumMode();
        }
        public void SetMaximumModeULB()
        {
            myCookingSurfase.UpperLeftBurner.SetMaximumMode();
        }
        public void SetNormalModeULB()
        {
            myCookingSurfase.UpperLeftBurner.SetNormalMode();

        }
        public void SetMinimumModeULB()
        {
            myCookingSurfase.UpperLeftBurner.SetMinimumMode();
        }
        public void SetMaximumModeBLB()
        {
            myCookingSurfase.BottomLeftBurner.SetMaximumMode();
        }
        public void SetNormalModeBLB()
        {
            myCookingSurfase.BottomLeftBurner.SetNormalMode();
        }
        public void SetMinimumModeBLB()
        {
            myCookingSurfase.BottomLeftBurner.SetMinimumMode();
        }
        public void SetMaximumModeBRB()
        {
            myCookingSurfase.BottomRightBurner.SetMaximumMode();
        }
        public void SetNormalModeBRB()
        {
            myCookingSurfase.BottomRightBurner.SetNormalMode();
        }
        public void SetMinimumModeBRB()
        {
            myCookingSurfase.BottomRightBurner.SetMinimumMode();
        }
        public void OvenSwitchOn()
        {
            MyOven.SwitchOn();
        }
        public void OvenSwitchOff()
        {
            MyOven.SwitchOff();
        }
        public void OvenDoorOpened()
        {
            MyOven.OvenDoor = true;
        }
        public void OvenDoorClosed()
        {
            MyOven.OvenDoor = false;
        }
        public void OvensetFanGrillBottomHeat()
        {
            MyOven.Ovenmode = EnumOvenMode.Fan_grill_bottomHeat;
        }
        public void OvenSetRingHeatingElementFan()
        {
            MyOven.Ovenmode = EnumOvenMode.RingHeatingElement_fan;
        }
        public void OvenSetGrill()
        {
            MyOven.Ovenmode = EnumOvenMode.grill;
        }
        public void OvenSetTopHeatingBottomHeat()
        {
            MyOven.Ovenmode = EnumOvenMode.topHeating_bottomHeat;
        }
        public void OvenSetTopHeating()
        {
            MyOven.Ovenmode = EnumOvenMode.topHeating;
        }
        public void OvenSetBottomHeat()
        {
            MyOven.Ovenmode = EnumOvenMode.bottomHeat;
        }
        public void OvenSetTurboGrill()
        {
            MyOven.Ovenmode = EnumOvenMode.turboGrill;
        }
        public void OvenIncreaseTemp()
        {
            if (MyOven.Temperature > 0 && MyOven.Temperature <= 245)
                MyOven.Temperature += 5;
            else
                throw new Exception();

        }
        public void OvenDecreaseTemp()
        {
            if (MyOven.Temperature > 0 && MyOven.Temperature <= 245)
                MyOven.Temperature -= 5;
            else
                throw new Exception();
        }
        public void OvenSetTemp()
        {
            Console.WriteLine("Input Temperature for Oven");
            MyOven.Temperature = Int32.Parse(Console.ReadLine());

        }
    }
}
