using SensorSimulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Sensor sensor1 = new Sensor("pressure");
        Sensor sensor2 = new Sensor("temperature");
        Sensor sensor3 = new Sensor("light");
        Console.WriteLine(sensor1.sensorName);
        Console.WriteLine(sensor2.sensorName);
        Console.WriteLine(sensor3.sensorColor);
    }
}