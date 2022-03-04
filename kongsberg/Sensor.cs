namespace kongsberg.Sensors;

public class SensorDataObtainedEventArgs : EventArgs
{
    public int Value { get; set;}
}

public class Sensor
{   

    public event EventHandler<SensorDataObtainedEventArgs>? SensorDataObtained;

    public int Id { get; }
    public string Type { get; } = "Unknown";
    public string EncoderType { get; } = "Unknown";
    public int Frequency { get; } = 1;
    public int MinValue { get; }
    public int MaxValue { get; }
    public bool IsRunning { get; private set; } = false;

    private Random _random = new Random();
    private const int _second = 1000;

    public Sensor(int id, string type, string encoderType, 
        int frequency, int minValue, int maxValue)
    {
        Id = id;
        Type = type;
        EncoderType = encoderType;
        Frequency = frequency;
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public int Generate()
    {
        return _random.Next(MinValue, MaxValue);
    }
    
    public async Task RunAsync()
    {
        IsRunning = true;
        await Task.Run(() =>
        {
            while (IsRunning)
            {
                var generatedData = Generate();
                SensorDataObtained?.Invoke(this, new SensorDataObtainedEventArgs{Value = generatedData});
                Thread.Sleep((int)((1.0f/Frequency)*_second));
            }
        }); 
    }

    public void Stop()
    {
        IsRunning = false;
    }

}

