namespace kongsberg.Sensors;

public class DepthSensor : GenericSensor<Byte>
{

    public Byte MinValue { get; } = 0;
    public Byte MaxValue { get; } = 255;

    public DepthSensor(string name, string type, byte frequency) : base(name, type, frequency)
    {

    }

    public override sbyte Generate()
    {
        _random.
    }
}

