namespace iotEndpoint.DTOs
{
    public class TriggerDTO
    {
        public int ID { get; set; } = 0;
        public int DeviceID { get; set; } = 0;
        public int ActuatorID { get; set; } = 0;
        public int SensorID { get; set; } = 0;
        public bool AboveInclusive { get; set; } = false;
        public float TriggerPoint { get; set; } = 0;
        public string Message { get; set; } = "";

    }
}
