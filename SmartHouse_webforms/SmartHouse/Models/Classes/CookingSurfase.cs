using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    [Serializable]
    class CookingSurfase: Device, ISwitcher
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
            this.BottomRightBurner = bottomRightBurner;
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
        public void SwitchOnUpperRightBurner()
        {
            UpperRightBurner.SwitchOn();
        }
        public void SwitchOffUpperRightBurner()
        {
          UpperRightBurner.SwitchOff();
        }
        public void SwitchOnUpperLeftBurner()
        {
            UpperLeftBurner.SwitchOn();
        }
        public void SwitchOffUpperLeftBurner()
        {
         UpperLeftBurner.SwitchOff();
        }
        public void SwitchOnBottomRightBurner()
        {
            BottomRightBurner.SwitchOn();
        }
        public void SwitchOffBottomRightBurner()
        {
          BottomRightBurner.SwitchOff();
        }
        public void SwitchOnBottomLeftBurner()
        {
            BottomLeftBurner.SwitchOn();
        }
        public void SwitchOffBottomLeftBurner()
        {
           BottomLeftBurner.SwitchOff();
        }
        public void SetMaximumModeURB()
        {
            UpperRightBurner.SetMaximumMode();
        }
        public void SetNormalModeURB()
        {
           UpperRightBurner.SetNormalMode();

        }
        public void SetMinimumModeURB()
        {
           UpperRightBurner.SetMinimumMode();
        }
        public void SetMaximumModeULB()
        {
           UpperLeftBurner.SetMaximumMode();
        }
        public void SetNormalModeULB()
        {
          UpperLeftBurner.SetNormalMode();

        }
        public void SetMinimumModeULB()
        {
           UpperLeftBurner.SetMinimumMode();
        }
        public void SetMaximumModeBLB()
        {
           BottomLeftBurner.SetMaximumMode();
        }
        public void SetNormalModeBLB()
        {
            BottomLeftBurner.SetNormalMode();
        }
        public void SetMinimumModeBLB()
        {
          BottomLeftBurner.SetMinimumMode();
        }
        public void SetMaximumModeBRB()
        {
           BottomRightBurner.SetMaximumMode();
        }
        public void SetNormalModeBRB()
        {
           BottomRightBurner.SetNormalMode();
        }
        public void SetMinimumModeBRB()
        {
           BottomRightBurner.SetMinimumMode();
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
            return "Устройство: Варочная поверхность ".ToUpper() + "<br />" + "Cостояние: " + temp + "<br />" +
                "Правая верхняя комфорка: " + UpperRightBurner.DeviceState + "<br />" +
                "Режим: " + UpperRightBurner.Burnermode + "<br />" +
                "Левая верхняя комфорка: " + UpperLeftBurner.DeviceState + "<br />" +
                "Режим: " + UpperLeftBurner.Burnermode + "<br />" +
                 "Левая нижняя комфорка: " + BottomLeftBurner.DeviceState + "<br />" +
                "Режим: " + BottomLeftBurner.Burnermode + "<br />" +
                "Правая нижняя комфорка: " + BottomRightBurner.DeviceState + "<br />" +
                "Режим: " + BottomRightBurner.Burnermode;
        }
    }
}