using kongsberg.Sensors;
using Xunit;

namespace kongsberg.Tests;

public class SensorTests
{
    [Fact]
    public void Ctor_StandardSensor_CreatesProperInstance()
    {
        var testName = "TestSensor";
        var testType = "Fixed";
        var testFreq = 1;
        var testMin = 0;
        var testMax = 255;
        var sensor = new Sensor(testName, testType, testFreq, testMin, testMax);

        Assert.NotNull(sensor);
        Assert.Equal(sensor.Name, testName);
        Assert.Equal(sensor.Type, testType);
        Assert.Equal(sensor.Frequency, testFreq);
        Assert.Equal(sensor.MinValue, testMin);
        Assert.Equal(sensor.MaxValue, testMax);
    }


}
