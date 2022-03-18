using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;

namespace iotEndpoint
{
    public class MQTTclient
    {
        public static IMqttClient mqttClient { get; set; }
        public async Task Connect_Client()
        {
            var mqttFactory = new MqttFactory();

            mqttClient = mqttFactory.CreateMqttClient();
            // Use builder classes where possible in this project.
            var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("192.168.0.103").Build();

            // This will throw an exception if the server is not available.
            // The result from this message returns additional data which was sent 
            // from the server. Please refer to the MQTT protocol specification for details.
            var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            Console.WriteLine("The MQTT client is connected.");


        }
    }
}
