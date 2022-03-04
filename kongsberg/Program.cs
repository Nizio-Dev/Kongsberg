using kongsberg;
using Newtonsoft.Json.Linq;


JObject configOne = JObject.Parse(File.ReadAllText(@"../../../../simulationConfig1.json"));
JObject configTwo = JObject.Parse(File.ReadAllText(@"../../../../simulationConfig2.json"));

SensorSimulator simulationFirst = new SensorSimulator(configOne);
SensorSimulator simulationSecond = new SensorSimulator(configTwo);

simulationFirst.DeactivateReceiver(0);
simulationFirst.DeactivateReceiver(1);

simulationSecond.DeactivateReceiver(0);
simulationSecond.DeactivateReceiver(1);

simulationSecond.ActivateReceiver(1);

simulationFirst.RunAsync();
simulationSecond.RunAsync();

Console.WriteLine("Not blocked");
//simulationFirst.Stop();
//simulationSecond.Stop();

Console.ReadKey();