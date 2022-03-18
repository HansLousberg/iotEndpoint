using iotEndpoint.DAL;
using iotEndpoint.DTOs;
using iotEndpoint.Objects;

namespace iotEndpoint.Logic
{
    public class RulesEngine
    {
        public void ApplyRules(IList<MeasurementDTO> measurements, int deviceID)
        {
            var SortedList = SortBySensor(measurements);

            TriggerStore triggerStore = new();
            foreach (List<MeasurementDTO> sensorMeasurement in SortedList)
            {
                //sort measurements by time

                var triggers = triggerStore.GetApplicableTriggers(deviceID, sensorMeasurement[0].SensorID);
                foreach (var trigger in triggers)
                {
                    foreach (var measurement in measurements)
                    {
                        if (((measurement.Value >= trigger.TriggerPoint) && trigger.AboveInclusive) 
                            || (!(measurement.Value >= trigger.TriggerPoint) && !trigger.AboveInclusive))
                            UpdateActuator(trigger.ActuatorID, trigger.Message);
                    }
                }
                Console.WriteLine("1");
            }
        }

        private List<List<MeasurementDTO>> SortBySensor(IList<MeasurementDTO> measurements)
        {
            //assumption, atleast 1 measurement is in the list
            List<List<MeasurementDTO>> sortedList = new();
            foreach (MeasurementDTO measurement in measurements)
            {
                bool found = false;
                foreach (List<MeasurementDTO> sensorList in sortedList)
                {
                    if (sensorList[0].SensorID != measurement.SensorID)
                        continue;
                    sensorList.Add(measurement);
                    found = true;
                    break;
                }
                if (!found)
                {
                    var newList = new List<MeasurementDTO>();
                    newList.Add(measurement);
                    sortedList.Add(newList);
                }
            }
            return sortedList;
        }

        private void UpdateActuator(int actuatorID, string message)
        {
            ActuatorStore actuatorStore = new();
            Actuator actuator = actuatorStore.Retreive(actuatorID);
            actuator.SendMessage(message);
        }
    }


}
