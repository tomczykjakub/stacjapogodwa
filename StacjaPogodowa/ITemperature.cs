using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Interfejs ITemperature
namespace StacjaPogodowa
{
    interface ITemperature
    {
        double TemperatureValue { get; set; }
        string TemperatureUnit { get; set; }

    }
}