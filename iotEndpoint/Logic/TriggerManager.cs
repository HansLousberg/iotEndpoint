using iotEndpoint.DAL;
using iotEndpoint.DTOs;

namespace iotEndpoint.Logic
{
    public class TriggerManager
    {
        public TriggerDTO CreateTrigger(TriggerDTO trigger)
        {
            TriggerStore triggerStore = new();
            triggerStore.Store(trigger);

            return trigger;
        }
    }
}
