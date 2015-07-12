using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    [Serializable]
    class Lamp : Device, ISwitcher
    {
        public Lamp()
        { }
        public Lamp(string deviceName, bool deviceState)
            : base(deviceName, deviceState)
        { }
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
            return "Тип устройства: Лампа".ToUpper() + "<br />" + "Cостояние: " + temp;
        }

        public void SwitchOn()
        {
            DeviceState = true;
        }
        public void SwitchOff()
        {
            DeviceState = false;
        }
    }
}