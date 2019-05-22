using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaPogodowa
{
    class Program
    {
        static void Main(string[] args)
        {
            Sensor sensor = new Sensor();
            try
            {
                sensor.Name = "NazwaDo16Znakow";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(sensor.Name);
            try
            {
                sensor.Name = "WiecejNiz16ZnakowByNieDzialalo";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Random rnd = new Random();
            Console.WriteLine(sensor.Name);
            sensores.PressureSensor PressSensor = new sensores.PressureSensor();
            PressSensor.PressureValue = rnd.Next(900,1030);
            sensores.HumiditySensor HumPressSensor = new sensores.HumiditySensor();
            HumPressSensor.HumidityValue = rnd.Next(30, 90);
            HumPressSensor.PressureValue = rnd.Next(900, 1030);
            sensores.TemperatureSensor TempSensor = new sensores.TemperatureSensor();
            TempSensor.TemperatureUnit = "Celcius";
            TempSensor.TemperatureValue = rnd.Next(-20, 40);

            stations.WeatherStation StacjaPogodowa = new stations.WeatherStation();
            StacjaPogodowa.SerializationPeriod = 10000;
            StacjaPogodowa.AddSensor(PressSensor);
            StacjaPogodowa.AddSensor(HumPressSensor);
            StacjaPogodowa.AddSensor(TempSensor);
            StacjaPogodowa.startTimer();

            //przykladowe sensory
            sensores.TemperatureSensor TempSensor1 = new sensores.TemperatureSensor();
            TempSensor1.TemperatureValue = rnd.Next(-20, 40);
            TempSensor1.TemperatureUnit = "Celcius";
            sensores.HumiditySensor HumPressSensor1= new sensores.HumiditySensor();
            HumPressSensor1.HumidityValue = rnd.Next(30, 90);
            HumPressSensor1.PressureValue = rnd.Next(900, 1030);
            sensores.PressureSensor PressSensor1 = new sensores.PressureSensor();
            PressSensor1.PressureValue = rnd.Next(900, 1030);
            StacjaPogodowa.AddSensor(TempSensor1);
            StacjaPogodowa.AddSensor(HumPressSensor1);
            StacjaPogodowa.AddSensor(PressSensor1);
            StacjaPogodowa.ReadMeasurement();
            Func<Sensor, bool> samplePredicate = x => ((ITemperature)x).TemperatureValue > 30;
            Func<Sensor, bool> whichEleents = x => x is ITemperature;
            List<Sensor> mySensores = StacjaPogodowa.GetSpecificSensorTypesFullfillingGivenPredicate(whichEleents, samplePredicate);
            foreach (Sensor sensor1 in mySensores)
            {
                Console.WriteLine(sensor1);
            }

            Console.WriteLine("Naciśnij 'q' i enter by wyjść.");
            while (Console.Read() != 'q') ;
        }
    }
}