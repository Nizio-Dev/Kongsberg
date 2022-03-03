namespace kongsberg.Sensors;


enum ClassifierStates
{
    Normal,
    Warning,
    Alarm
}

public class Sensor
{   

    public int Id { get; }
    public string Type { get; } = "Unknown";
    public string EncoderType { get; } = "Unknown";
    public int Frequency { get; } = 1;
    public int MinValue { get; }
    public int MaxValue { get; }
    public bool IsRunning { get; private set; } = false;

    private Random _random = new Random();
    private const int _second = 1000;

    private const float _warningThreshold = 0.65F;
    private const float _alarmThreshold = 0.9F;

    private readonly int _middlePoint;
    private readonly int _distanceToMiddle;

    public Sensor(int id, string type, string encoderType, 
        int frequency, int minValue, int maxValue)
    {
        Id = id;
        Type = type;
        EncoderType = encoderType;
        Frequency = frequency;
        MinValue = minValue;
        MaxValue = maxValue;
        _middlePoint = (minValue + maxValue) / 2;
        _distanceToMiddle = maxValue-_middlePoint;
    }

    protected int Generate()
    {
        return _random.Next(MinValue, MaxValue);
    }
    
    private ClassifierStates Classify(int data) 
    {

        float distance;

        if(data < _middlePoint)
        {
            distance = _middlePoint - data;
        }
        else
        {
            distance = MaxValue - data;
        }

        return distance/_distanceToMiddle >= _alarmThreshold ? ClassifierStates.Alarm :
            distance/_distanceToMiddle >= _warningThreshold ? ClassifierStates.Warning :
            ClassifierStates.Normal;
    }

    public async Task RunAsync()
    {
        IsRunning = true;

        await Task.Run(() =>
        {
            while (IsRunning)
            {
                LogData();
                Thread.Sleep((int)((1.0f/Frequency)*_second));
            }
        }); 
    }

    public void Stop()
    {
        IsRunning = false;
    }

    private void LogData()
    {
        int generatedValue = Generate();
        ClassifierStates classifiedAs = Classify(generatedValue);

        if(classifiedAs == ClassifierStates.Alarm)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else if(classifiedAs == ClassifierStates.Warning)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        Console.WriteLine($"${EncoderType}, {Id}, {Type, 8}, {generatedValue, 6}, {classifiedAs, 7}");
        Console.ResetColor();
        

    }
}

