using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    [Serializable]
   public abstract class Device
    {
       
        public string DeviceName { get; set; }
        public bool DeviceState { get; set; }
        public Device()
        { }
        public Device(string deviceName, bool deviceState)
        {
            this.DeviceName = deviceName;
            this.DeviceState = deviceState;
        }
        public abstract string ToString();
    }
}