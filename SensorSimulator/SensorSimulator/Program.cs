using HiveMQtt.MQTT5.ReasonCodes;
using SensorSimulator;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var host = "d3d2aecf0c0045fa9b662493dd7e0f06.s1.eu.hivemq.cloud";
        var port = 8883;
        var username = "alexjibe";
        var password = "Jibe123*";
        var connection = new HiveConnection(host, port, username, password);
        var client = connection.CreateClient();
        HiveMQtt.Client.Results.ConnectResult connectResult;
        try
        {
            connectResult = await client.ConnectAsync().ConfigureAwait(false);
            if (connectResult.ReasonCode == ConnAckReasonCode.Success)
            {
                Console.WriteLine($"Connect successful: {connectResult}");
            }
            else
            {
                Console.WriteLine($"Connect failed: {connectResult}");
                Environment.Exit(-1);
            }
        }
        catch (System.Net.Sockets.SocketException e)
        {
            Console.WriteLine($"Error connecting to the MQTT Broker with the following socket error: {e.Message}");
            Environment.Exit(-1);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error connecting to the MQTT Broker with the following message: {e.Message}");
            Environment.Exit(-1);
        }

        var sensor1 = new Sensor("pressure");
        var sensor2 = new Sensor("temperature");
        var sensor3 = new Sensor("light");
        await Task.WhenAll(
            sensor1.RunCycle(client, 2, 3, "sensors/sensor1"),
            sensor2.RunCycle(client, 3, 5, "sensors/sensor2"),
            sensor3.RunCycle(client, 2, 4, "sensors/sensor3")
            );
    }
}