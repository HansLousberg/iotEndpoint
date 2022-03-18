using iotEndpoint.DAL;
using iotEndpoint.DTOs;

namespace iotEndpoint.Logic
{
    public class DeviceManager
    {
        public DeviceDTO Register(DeviceDTO device)
        {
            DeviceStore deviceStore = new DeviceStore();
            deviceStore.Store(device);
            SensorStore sensorStore = new SensorStore();
            foreach(SensorDTO sensor in device.Sensors)
            {
                sensorStore.Store(sensor,device.ID);
            }
            
            return device;
        }
    }
}
