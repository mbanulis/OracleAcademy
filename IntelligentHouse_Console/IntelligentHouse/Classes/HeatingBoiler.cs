using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class HeatingBoiler : ClimatControl
    {
        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value <= MaxDeviceTemperature && value >= MinDeviceTemperature)
                    temperature = value;
                else
                    throw new Exception("Устанавлимая температура выходит за пределы допустимой");

            }
        }
        public HeatingBoiler()
        { }
        public HeatingBoiler(string deviceName, bool deviceState, int maxDeviceTemperature, int minDeviceTemperature, int temperature, EnumSeasons seasons)
            : base(deviceName, deviceState, maxDeviceTemperature, minDeviceTemperature, temperature, seasons)
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
            return "Устройство типа Котел: ".ToUpper() + DeviceName + ";" + "\n" +
                    "Cостояние: " + temp + ";" + "\n" +
                    "Режим эксплуатации: " + Seasons + ";" + "\n" +
                    "Максимальная температура устройства: " + MaxDeviceTemperature + "\n" +
                    "Минимальная температура устройства: " + MinDeviceTemperature + "\n" +
                    "Установленная температура: " + Temperature + ";" + "\n";

        }
    }
}
