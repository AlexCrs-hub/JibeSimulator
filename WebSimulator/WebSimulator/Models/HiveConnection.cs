using HiveMQtt.Client;
using HiveMQtt.Client.Options;

namespace WebSimulator.Models
{
    public class HiveConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public HiveConnection(string host, int port, string username, string password)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }

        public HiveMQClient CreateClient()
        {
            var options = new HiveMQClientOptions
            {
                Host = Host,
                Port = 8883,
                UseTLS = true,
                UserName = Username,
                Password = Password,
            };
            var client = new HiveMQClient(options);

            return client;
        }
    }
}
