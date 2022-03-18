namespace iotEndpoint.DTOs
{
    public class MeasurementDTO
    {
        public int ID { get; set; } = 0;
        public int SensorID { get; set; } = 0;
        public float? Value { get; set; }
        public DateTime? DateTime { get; set; }

    }
}
