namespace iotEndpoint.DTOs
{
    public class DeviceDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<SensorDTO> Sensors { get; set; } = new List<SensorDTO>();
    }
}
