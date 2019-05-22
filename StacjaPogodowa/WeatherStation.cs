﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Timers;
using StacjaPogodowa.sensores;

namespace StacjaPogodowa.stations
{
    [DataContract]
    [KnownType(typeof(PressureSensor))]
    [KnownType(typeof(TemperatureSensor))]
    [KnownType(typeof(HumiditySensor))]
    class WeatherStation
    {
        [DataMember]
        private List<Sensor> parts = new List<Sensor>();

        [DataMember]
        public double _serializationPeriod;
        [DataMember]
        public double SerializationPeriod
        {
            get
            {
                return _serializationPeriod;
            }

            set
            {
                if (value < 0) throw new Exception("Czas musi być większy od 0!");
                _serializationPeriod = value;
            }
        }

        private System.Timers.Timer aTimer;


        public WeatherStation()
        {
            this.SerializationPeriod = 5000;
            
        }

        ~WeatherStation()
        {
            aTimer.Stop();
        }

        public void AddSensor(Sensor sensor)
        {
            parts.Add(sensor);
        }

        public void ReadMeasurement()
        {
            foreach (Sensor sensor in parts)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(sensor);
                Console.WriteLine("\n--------------");
            }
        }


        public void startTimer()
        {
            this.aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(this.OnTimeEvent);
            aTimer.Interval = this.SerializationPeriod;
            aTimer.Enabled = true;

            prepareDirectory();
            aTimer.Start();
        }


        private void prepareDirectory()
        {
            string settings_dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "JSON SENSOR DATA");
            Directory.CreateDirectory(settings_dir);
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            SerialzieToJson();
        }

        private void SerialzieToJson()
        {

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(WeatherStation));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, this);
            msObj.Position = 0;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".json";
            var pathToJsons = string.Format("{0}\\{1}\\{2}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "JSON SENSOR DATA", fileName);
            using (FileStream fs = new FileStream(pathToJsons, FileMode.OpenOrCreate))
            {
                msObj.CopyTo(fs);
                fs.Flush();
            }


            // sample read
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();
            Console.WriteLine("JSON: " + json + " zapisano!");
            sr.Close();
            msObj.Close();
        }

        public List<Sensor> GetSpecificSensorTypesFullfillingGivenPredicate(Func<Sensor, bool> whichTypes, Func<Sensor, bool> predicate)
        {
            return parts.Where(whichTypes).Where(predicate).ToList();
        }


    }
}