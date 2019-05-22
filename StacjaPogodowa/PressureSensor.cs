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
    class PressureSensor : Sensor, IPressure
    {
        [DataMember]
        public double PressureValue { get; set; }

        public override string ToString()
        {
            return "Ciśnienie wynosi: " + this.PressureValue;
        }
    }
}