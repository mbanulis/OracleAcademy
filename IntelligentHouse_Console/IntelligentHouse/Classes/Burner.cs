using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    class Burner : Device, ISwitcher, IRegime
    {
        private Mode burnermode;
        public Mode Burnermode
        {
            get
            {
                return burnermode;
            }
            set
            {
                burnermode = value;
            }
        }

        private int burnerRadius;
        public int BurnerRadius
        {
            get
            {
                return burnerRadius;
            }
            set
            {
                if (burnerRadius > 5 && burnerRadius < 20)
                {
                    burnerRadius = value;
                }

            }
        }

        public Burner()
        { }
        public Burner(string deviceName, bool deviceState, Mode burnermode, int burnerRadius)
            : base(deviceName, deviceState)
        {
            this.BurnerRadius = burnerRadius;
            this.Burnermode = burnermode;
        }
        public void SetMaximumMode()
        {
            if (DeviceState == true)
                Burnermode = Mode.maximum;
            else
                throw new Exception("Для выбора режима включите комфорку");
        }
        public void SetNormalMode()
        {
            if (DeviceState == true)
                Burnermode = Mode.normal;
            else
                throw new Exception("Для выбора режима включите комфорку");
        }
        public void SetMinimumMode()
        {
            if (DeviceState == true)
                Burnermode = Mode.minimum;
            else
                throw new Exception("Для выбора режима включите комфорку");

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
            return "Комфорка: " + "\n" +
                "Режим комфорки: " + Burnermode + ";"
                + "\n" + "Cостояние: " + temp + ";";
        }
    }
}
