using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    [Serializable]
    class Conditioner: ClimatControl
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
            return "Устройство: Кондиционер".ToUpper() +"<br />" +
                  "Cостояние: " + temp + "<br />" +
                  "Режим эксплуатации: " + Seasons + "<br />" +
                  "Максимальная температура устройства: " + MaxDeviceTemperature + "<br />" +
                  "Минимальная температура устройства: " + MinDeviceTemperature + "<br />" +
                  "Текущая температура: " + Temperature;

        }
    }
}