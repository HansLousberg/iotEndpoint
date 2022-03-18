using iotEndpoint.DTOs;
using iotEndpoint.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iotEndpoint.Controllers
{
    [Route("api/Devices/{deviceID}/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {

        [HttpPost(Name = "PostMeasurement")]
        public List<MeasurementDTO> Post(int deviceID, [FromBody] List<MeasurementDTO> measurements)
        {
            foreach (MeasurementDTO measurement in measurements)
            {
                if(measurement.DateTime == null)
                {
                    measurement.DateTime = DateTime.UtcNow;
                }
            }
            MeasurementManager measurementManager = new MeasurementManager();
            measurementManager.HandleNewMeasurements(measurements, deviceID);
            return measurements;
        }
    }
}
