using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.ReasonCodes;

namespace WebSimulator.Services
{
    public class HiveConnectionService: BackgroundService
    {   
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ConnectHive();
        }
        private async Task ConnectHive()
        {
            var options = new HiveMQClientOptions
            {
                Host = "d3d2aecf0c0045fa9b662493dd7e0f06.s1.eu.hivemq.cloud",
                Port = 8883,
                UseTLS = true,
                UserName = "alexjibe",
                Password = "Jibe123*",
            };
            var client = new HiveMQClient(options);
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

            client.OnMessageReceived += (sender, args) =>
            {
                string received_message = args.PublishMessage.PayloadAsString;
                Console.WriteLine(received_message);
            };
            await client.SubscribeAsync("sensors/sensor1").ConfigureAwait(false);
            await client.SubscribeAsync("sensors/sensor2").ConfigureAwait(false);
            await client.SubscribeAsync("sensors/sensor3").ConfigureAwait(false);
        }
    }
}
