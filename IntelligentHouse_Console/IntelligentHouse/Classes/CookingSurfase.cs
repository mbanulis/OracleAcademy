using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class CookingSurfase : Device, ISwitcher
    {
        private Burner upperLeftBurner;
        public Burner UpperLeftBurner
        {
            get
            {
                return upperLeftBurner;
            }
            set
            {
                upperLeftBurner = value;
            }
        }
        private Burner upperRightBurner;
        public Burner UpperRightBurner
        {
            get
            {
                return upperRightBurner;
            }
            set
            {
                upperRightBurner = value;
            }
        }
        private Burner bottomLeftBurner;
        public Burner BottomLeftBurner
        {
            get
            {
                return bottomLeftBurner;
            }
            set
            {
                bottomLeftBurner = value;
            }
        }
        private Burner bottomRightBurner;
        public Burner BottomRightBurner
        {
            get
            {
                return bottomRightBurner;
            }
            set
            {
                bottomRightBurner = value;
            }
        }
        public CookingSurfase()
        { }
        public CookingSurfase(string deviceName, bool deviceState, Burner upperLeftBurner, Burner upperRightBurner, Burner bottomLeftBurner, Burner bottomRightBurner)
            : base(deviceName, deviceState)
        {
            this.BottomLeftBurner = bottomLeftBurner;
            this.BottomRightBurner = bottomLeftBurner;
            this.UpperLeftBurner = upperLeftBurner;
            this.UpperRightBurner = upperRightBurner;
        }
        public void SwitchOn()
        {

            DeviceState = true;
        }
        public void SwitchOff()
        {
            DeviceState = false;
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
            return "Устройство: " + DeviceName + ";" + "\n" + "Cостояние: " + temp + ";" + "\n" +
                "Правая верхняя комфорка: " + "\n" +
                "Cостояние комфорки: " + UpperRightBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + UpperRightBurner.Burnermode + ";" + "\n\n" +
                "Левая верхняя комфорка: " + "\n" +
                "Cостояние комфорки: " + UpperLeftBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + UpperLeftBurner.Burnermode + ";" + "\n\n" +
                 "Левая нижняя комфорка: " + "\n" +
                "Cостояние комфорки: " + UpperLeftBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + UpperLeftBurner.Burnermode + ";" + "\n\n" +
                "Правая нижняя комфорка: " + "\n" +
                "Cостояние комфорки: " + BottomRightBurner.DeviceState + ";" + "\n" +
                "Режим комфорки: " + BottomRightBurner.Burnermode + ";" + "\n";
        }
    }
}
