using iotEndpoint.DAL;
using iotEndpoint.DTOs;

namespace iotEndpoint.Logic
{
    public class ActuatorManager
    {
        public ActuatorDTO Register(ActuatorDTO actutor)
        {
            ActuatorStore actuatorStore = new();
            return actuatorStore.Store(actutor);
        }
    }
}
