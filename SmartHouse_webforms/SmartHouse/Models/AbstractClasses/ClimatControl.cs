using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    [Serializable]
    abstract class ClimatControl: Device, ISwitcher, IModeSeason, ITemperature, IRegulator
    {
        public int MaxDeviceTemperature { get; set; }
        public int MinDeviceTemperature { get; set; }
        internal int temperature;
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
        private EnumSeasons seasons;
        public EnumSeasons Seasons
        {
            get
            {
                return seasons;
            }
            set
            {
                seasons = value;
            }
        }
        public ClimatControl()
        { }

        public ClimatControl(string deviceName, bool deviceState, int maxDeviceTemperature, int minDeviceTemperature, int temperature, EnumSeasons seasons)
            : base(deviceName, deviceState)
        {
            this.MaxDeviceTemperature = 40;
            this.MinDeviceTemperature = 0;
            this.Seasons = seasons;
            this.Temperature = temperature;

        }
        public void SetWinterMode()
        {
            Seasons = EnumSeasons.winter;
        }
        public void SetSummerMode()
        {
            Seasons = EnumSeasons.summer;
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
            if (Temperature < MaxDeviceTemperature - 1)
                Temperature++;
            else
                throw new Exception("Вы вышли за пределы допустимой температуры работы устройства");
        }
        public void Decreasing()
        {
            if (Temperature > MinDeviceTemperature + 1)
            {
                Temperature--;
            }
            else
            {
                throw new Exception("Вы вышли за пределы допустимой температуры работы устройства");
            }

        }
    }
}