using iotEndpoint.DTOs;
using iotEndpoint.Logic;
using Microsoft.AspNetCore.Mvc;

namespace iotEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActuatorsController : ControllerBase
    {
        [HttpPost]
        public ActuatorDTO Post([FromBody] ActuatorDTO actuator)
        {
            ActuatorManager actuatorManager = new();
            return actuatorManager.Register(actuator);
            
        }
    }
}
