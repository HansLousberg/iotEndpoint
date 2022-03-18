using iotEndpoint.DTOs;
using iotEndpoint.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iotEndpoint.Controllers
{
    [Route("api/Actuators/{actuatorID}/[controller]")]
    [ApiController]
    public class TriggersController : ControllerBase
    {
        [HttpPost]
        public TriggerDTO Post(int actuatorID, [FromBody] TriggerDTO trigger)
        {
            trigger.ActuatorID = actuatorID;
            TriggerManager triggerManager = new();
            triggerManager.CreateTrigger(trigger);
            return trigger;
        }
    }
}
