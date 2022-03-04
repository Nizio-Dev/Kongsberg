using kongsberg.Sensors;
using Kongsberg;
using Newtonsoft.Json.Linq;

namespace kongsberg;

public class SensorSimulator
{   

    List<Sensor> Sensors { get; } = new List<Sensor>();
    List<Receiver> Receivers { get; } = new List<Receiver>();

    public SensorSimulator(JObject data)
    {
        foreach(var sensor in data["Sensors"]!)
        {
            Sensors.Add(new Sensor((int)sensor["ID"]!, (string)sensor["Type"]!, 
                (string)sensor["EncoderType"]!, (int)sensor["Frequency"]!, 
                (int)sensor["MinValue"]!, (int)sensor["MaxValue"]!));
        }


        foreach(var receiver in data["Receivers"]!)
        {
            var newReceiver = new Receiver((int)receiver["ID"]!);
            Receivers.Add(newReceiver);

            if ((bool)receiver["IsActive"]!)
            {
                foreach(var sensor in Sensors)
                {
                    sensor.SensorDataObtained += newReceiver.OnSensorDataObtained!;
                }
            }
            
        }
    }

    public void ActivateReceiver(int id)
    {
        foreach(var sensor in Sensors)
        {
            sensor.SensorDataObtained += Receivers[id].OnSensorDataObtained!;
        }
    }

    public void DeactivateReceiver(int id)
    {
        foreach(var sensor in Sensors)
        {
            sensor.SensorDataObtained -= Receivers[id].OnSensorDataObtained!;
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

