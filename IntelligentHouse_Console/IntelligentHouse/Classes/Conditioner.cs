using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class Conditioner : ClimatControl
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
        public Conditioner()
        { }
        public Conditioner(string deviceName, bool deviceState, int maxDeviceTemperature, int minDeviceTemperature, int temperature, EnumSeasons seasons)
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
            return "Устройство типа Кондиционер: ".ToUpper() + DeviceName + ";" + "\n" +
                  "Cостояние: " + temp + ";" + "\n" +
                  "Режим эксплуатации: " + Seasons + ";" + "\n" +
                  "Максимальная температура устройства: " + MaxDeviceTemperature + "\n" +
                  "Минимальная температура устройства: " + MinDeviceTemperature + "\n" +
                  "Установленная температура: " + Temperature + ";" + "\n";

        }
    }
}
