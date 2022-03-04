using Kongsberg;
using Xunit;

namespace kongsberg.Tests;

public class SensorTests
{
    [Fact]
    public void Ctor_StandardSensor_CreatesProperInstance()
    {
        var testId = 1;
        var testType = "TestSensor";
        var testEncoderType = "Fixed";
        var testFreq = 1;
        var testMin = 0;
        var testMax = 255;
        var sensor = new Sensor(testId, testType, testEncoderType, testFreq, testMin, testMax);

        Assert.NotNull(sensor);
        Assert.Equal(sensor.Id, testId);
        Assert.Equal(sensor.Type, testType);
        Assert.Equal(sensor.EncoderType, testEncoderType);
        Assert.Equal(sensor.Frequency, testFreq);
        Assert.Equal(sensor.MinValue, testMin);
        Assert.Equal(sensor.MaxValue, testMax);
    }

    

/*    // Testy wartoœci granicznych dla klasyfikacji
    [Fact]
    public void LogData_0To100Data0_GivesAlarm()
    {
        var sensor = new Sensor(1, "Sensor", "Fix", 0, 0, 100);

        var logOutput = sensor.Classify(0);

        Assert.Equal(ClassifierStates.Alarm, logOutput);
    }

    [Fact]
    public void LogData_0To100Data50_GivesNormal()
    {
        var sensor = new Sensor(1, "Sensor", "Fix", 0, 0, 100);

        var logOutput = sensor.Classify(50);

        Assert.Equal(ClassifierStates.Normal, logOutput);
    }

    [Fact]
    public void LogData_0To100Data77_GivesNormal()
    {
        var sensor = new Sensor(1, "Sensor", "Fix", 0, 0, 100);

        var logOutput = sensor.Classify(77);

        Assert.Equal(ClassifierStates.Warning, logOutput);
    }*/
}
