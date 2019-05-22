using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
//Sensor
[DataContract]
public class Sensor
{

    
    private String name;
    public String Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value.Length > 16) throw new Exception(value + " Jest dłuższe niż 16 znaków, spróbuj ponownie");
            name = value;
        }
    }
    private static int counter;

    static Sensor()
    {
        counter = 0;
    }


    public Sensor()
    {
        counter++;
        Name = "Sensor" + counter;
    }
}