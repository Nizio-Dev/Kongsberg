using kongsberg.Sensors;
using Newtonsoft.Json.Linq;

namespace kongsberg;

public class SensorSimulator
{   
    List<Sensor> Sensors { get; } = new List<Sensor>();

    public SensorSimulator()
    {
        Sensors.Add(new Sensor(1, "Speed", "FIX", 2, -10, 100));
        Sensors.Add(new Sensor(2, "Position", "FIX", 1, -10000, 10000));
        Sensors.Add(new Sensor(3, "Depth", "FIX", 10, 0, 255));
    }

    public SensorSimulator(JObject data)
    {
        foreach(var sensor in data["Sensors"]!)
        {
            Sensors.Add(new Sensor((int)sensor["ID"]!, (string)sensor["Type"]!, 
                (string)sensor["EncoderType"]!, (int)sensor["Frequency"]!, 
                (int)sensor["MinValue"]!, (int)sensor["MaxValue"]!));
        }
    }


    public Task RunAsync()
    {
        return Task.WhenAll(Sensors.Select(s => s.RunAsync()));
    }

    public void Stop()
    {
        Sensors.ForEach(s => s.Stop());
    }
}

