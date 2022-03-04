using Kongsberg.Enum.ClassifierStates;

namespace kongsberg.Classifier;


public static class Classifier
{

    private const float _warningThreshold = 0.50F;
    private const float _alarmThreshold = 0.8F;


    public static ClassifierStates Classify(int data, int minValue, int maxValue) 
    {

        float distance;

        var middlePoint = (minValue + maxValue) / 2;
        var distanceToMiddle = maxValue-middlePoint;

        if(data < middlePoint)
        {
            distance = middlePoint - data;
        }
        else
        {
            distance = data - middlePoint;
        }

        return distance/distanceToMiddle >= _alarmThreshold ? ClassifierStates.Alarm :
        distance/distanceToMiddle >= _warningThreshold ? ClassifierStates.Warning :
        ClassifierStates.Normal;
    }
}
