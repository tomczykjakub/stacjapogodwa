using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace StacjaPogodowa.sensores
{
    [DataContract]
    class TemperatureSensor : Sensor, ITemperature
    {

        [DataMember]
        public double TemperatureValue { get; set; }
        [DataMember]
        public string TemperatureUnit { get; set; }

        public override string ToString()
        {
            return "Temperatura wynosi: " + this.TemperatureValue + " " + this.TemperatureUnit;
        }
    }
}