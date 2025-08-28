using HiveMQtt.Client;
using HiveMQtt.MQTT5.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorSimulator
{
    public class Sensor
    {
        public string sensorName { get; set; }
        public bool isRunning { get; set; }
        public string sensorColor { get; set; }

        public Sensor(string sensorName) {
            this.sensorName = sensorName;
            sensorColor = "gray";
            isRunning = false;
        }

        private async Task PublishData(HiveMQClient client, string topic)
        {
            var msg = JsonSerializer.Serialize(
                new
                {   
                    sensorName,
                    sensorColor,
                    isRunning,
                });
            //Publish MQTT messages
           await client.PublishAsync(topic, msg, QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
        }

        public async Task RunCycle(HiveMQClient client, int offTime, int onTime, string topic)
        {
            while (true)
            {
                if(!isRunning)
                {
                    sensorColor = "gray";
                    Console.WriteLine($"{sensorName} OFF ({sensorColor})");
                    await PublishData(client, topic);
                    await Task.Delay(offTime * 1000);
                    isRunning = true;
                }
                else
                {
                    sensorColor = "green";
                    Console.WriteLine($"{sensorName} ON ({sensorColor})");
                    await PublishData(client, topic);
                    await Task.Delay(onTime * 1000);
                    sensorColor = "yellow";
                    Console.WriteLine($"{sensorName} ON ({sensorColor})");
                    await PublishData(client, topic);
                    await Task.Delay(onTime * 1000);
                    sensorColor = "red";
                    Console.WriteLine($"{sensorName} ON ({sensorColor})");
                    await PublishData(client, topic);
                    await Task.Delay(onTime * 1000);
                    isRunning = false;
                }
            }
        }
    }
}
