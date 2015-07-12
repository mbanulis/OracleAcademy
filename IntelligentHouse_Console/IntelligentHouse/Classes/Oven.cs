using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class Oven : Device, ISwitcher, ITemperature, IRegulator, IOpenClose
    {
        private int temperature;
        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= 0 && value <= 250)
                {
                    temperature = value;
                }
                else
                {
                    throw new OverflowException("Диапазон температуры духовки от 0 до 250");
                }
            }
        }
        private EnumOvenMode ovenmode;
        public EnumOvenMode Ovenmode
        {
            get
            {
                return ovenmode;
            }
            set
            {
                ovenmode = value;
            }
        }
        private bool ovenDoor;
        public bool OvenDoor
        {
            get
            {
                return ovenDoor;
            }
            set
            {
                ovenDoor = value;
            }
        }
        public Oven()
        { }
        public Oven(string deviceName, bool deviceState, EnumOvenMode ovenmode, int temperature, bool ovenDoor)
            : base(deviceName, deviceState)
        {
            this.Ovenmode = ovenmode;
            this.Temperature = temperature;
            this.OvenDoor = ovenDoor;
        }
        public void setFanGrillBottomHeat()
        {
            Ovenmode = EnumOvenMode.Fan_grill_bottomHeat;
        }
        public void SetRingHeatingElementFan()
        {
            Ovenmode = EnumOvenMode.RingHeatingElement_fan;
        }
        public void SetGrill()
        {
            Ovenmode = EnumOvenMode.grill;
        }
        public void SetTopHeatingBottomHeat()
        {
            Ovenmode = EnumOvenMode.topHeating_bottomHeat;
        }
        public void SetTopHeating()
        {
            Ovenmode = EnumOvenMode.topHeating;
        }
        public void SetBottomHeat()
        {
            Ovenmode = EnumOvenMode.bottomHeat;
        }
        public void SetTurboGrill()
        {
            Ovenmode = EnumOvenMode.turboGrill;
        }
        public void SwitchOn()
        {

            DeviceState = true;
        }
        public void SwitchOff()
        {
            DeviceState = false;
        }
        public void Increasing()
        {
            if (Temperature > 0 && Temperature <= 245)
                Temperature += 5;
            else
                throw new Exception();

        }
        public void Decreasing()
        {
            if (Temperature >= 5 && Temperature <= 250)
                Temperature -= 5;
            else
                throw new Exception();
        }
        public void Opened()
        {
            OvenDoor = true;
        }
        public void Closed()
        {
            OvenDoor = false;
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
            string tmp;
            if (OvenDoor)
            {
                tmp = "Открыт";
            }
            else
            {
                tmp = "Закрыт";
            }
            return
                   "Cостояние: " + temp + ";" + "\n" +
                   "Текущая температура в духовом шкафе: " + Temperature + ";" + "\n" +
                   "Режим приготовления: " + Ovenmode + ";" + "\n" +
                   "Cостояние дверцы духового шкафа: " + tmp;
        }
    }
}
