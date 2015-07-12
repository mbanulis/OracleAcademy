using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
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
            return "Устройство типа Лампа: ".ToUpper() + DeviceName + ";" + "\n" + "Cостояние: " + temp + ";" + "\n";
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
