using MQTTnet;

namespace iotEndpoint.Objects
{
    public class Actuator
    {
        public Actuator(int id, string name, string mqttChannel)
        {
            ID = id;
            Name = name;
            MqttChannel = mqttChannel;
        }

        public int ID { get; }
        public string Name { get; }
        public string MqttChannel { get; }

        public void SendMessage(string message)
        {

            var applicationMessage = new MqttApplicationMessageBuilder()
               .WithTopic(MqttChannel)
               .WithPayload(message)
               .Build();

            MQTTclient.mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

        }



    }
}
