using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    [Serializable]
    class KitchenVentilation : Device, ISwitcher, IRegime
    {
        private Mode kitchenVentilationMode;
        public Mode KitchenVentilationdMode
        {
            get
            {
                return kitchenVentilationMode;
            }
            set
            {
                kitchenVentilationMode = value;
            }
        }
        public KitchenVentilation()
        { }
        public KitchenVentilation(string deviceName, bool deviceState, Mode kitchenVentilationMode)
            : base(deviceName, deviceState)
        {
            this.KitchenVentilationdMode = kitchenVentilationMode;
        }
        public void SwitchOn()
        {
            DeviceState = true;
        }
        public void SwitchOff()
        {
            DeviceState = false;
        }
        public void SetMaximumMode()
        {
            if (DeviceState == true)
                KitchenVentilationdMode = Mode.maximum;
            else
                throw new Exception("Для выбора режима включите вытяжку");
        }
        public void SetNormalMode()
        {
            if (DeviceState == true)
                KitchenVentilationdMode = Mode.normal;
            else
                throw new Exception("Для выбора режима включите вытяжку");
        }
        public void SetMinimumMode()
        {
            if (DeviceState == true)
                KitchenVentilationdMode = Mode.minimum;
            else
                throw new Exception("Для выбора режима включите вытяжку");
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
            return "Устройство типа Вытяжка: ".ToUpper() + "<br />" +
                "Cостояние: " + temp + "<br />" +
                "Режим: " + KitchenVentilationdMode;

        }
    }
}