using iotEndpoint.DAL;
using iotEndpoint.DTOs;
using MQTTnet;

namespace iotEndpoint.Logic
{
    public class MeasurementManager
    {
        public void HandleNewMeasurements(IList<MeasurementDTO> measurements, int deviceID)
        {
            //validate if deviceID exists
            //validate if SensorID exists
            MeasurementStore measurementStore = new MeasurementStore();
            foreach (MeasurementDTO measurement in measurements)
            {
                measurementStore.Store(measurement, deviceID);
            }

            RulesEngine rulesEngine = new RulesEngine();
            rulesEngine.ApplyRules(measurements,deviceID);
        }

        


    }
}
