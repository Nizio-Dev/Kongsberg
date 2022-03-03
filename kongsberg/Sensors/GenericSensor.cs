using kongsberg.Interfaces;

namespace kongsberg.Sensors;

public abstract class GenericSensor<T> : ISensor<T>
{   

    public Guid Id { get;} = Guid.NewGuid();
    public string Name { get; } = "Unknown";
    public string Type { get; } = "Unknown";
    public string EncoderType { get; } = "Fixed";
    public byte Frequency { get; } = 1;
    
    protected Random _random = new Random();


    public GenericSensor(string name, string type, byte frequency)
    {
        Name = name;
        Type = type;
        Frequency = frequency;
    }

    public abstract T Generate();

}

