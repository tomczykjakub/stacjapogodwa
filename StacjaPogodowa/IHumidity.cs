using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Interfejs IHumidity
namespace StacjaPogodowa
{
    interface IHumidity
    {
        double HumidityValue { get; set; }
    }
}