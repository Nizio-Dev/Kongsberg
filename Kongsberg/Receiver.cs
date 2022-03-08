using Kongsberg.Enum;


namespace Kongsberg;


public class Receiver
{
    public int Id { get; }


    public Receiver(int id)
    {
        Id = id;
    }


    public void OnSensorDataObtained(object source, SensorDataObtainedEventArgs eventArgs)
    {
        Sensor sensor = (Sensor)source;
        var data = eventArgs;
        
        var classifiedAs = Classifier.Classify(data.Value, sensor.MinValue, sensor.MaxValue);

        lock (Console.Out)
        {
            if(classifiedAs == ClassifierStates.Alarm)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if(classifiedAs == ClassifierStates.Warning)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

            Console.WriteLine($"${sensor.EncoderType}, {sensor.Id}, {sensor.Type, 8}, " +
                $"{data.Value, 5}, {classifiedAs, 7}");

            Console.ResetColor();
        }
    }
}
