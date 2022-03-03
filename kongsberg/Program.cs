using kongsberg;
using Newtonsoft.Json.Linq;

bool optionChosen = false;

SensorSimulator simulation = new SensorSimulator();

while (!optionChosen)
{
Console.Write(@$"Choose configuration for the simulation:
1. Load sensors from a sensorConfig.json file.
2. Proceed with static sensors.
");

    switch (Console.ReadKey().KeyChar)
    {
        case '1':
            JObject sensorData = JObject.Parse(File.ReadAllText(@"../../../../sensorConfig.json"));
            simulation = new SensorSimulator(sensorData);
            optionChosen = true;
            break;
        
        case '2':
            optionChosen = true;
            break;
    }

    Console.Clear();
}

simulation.RunAsync();

Console.WriteLine("Not blocked");
//simulation.Stop();

Console.ReadKey();