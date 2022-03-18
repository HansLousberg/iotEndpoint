using iotEndpoint.DTOs;
using iotEndpoint.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace iotEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        [HttpPost]
        public DeviceDTO Post([FromBody] DeviceDTO device)
        {
            DeviceManager deviceManager = new DeviceManager();
            return deviceManager.Register(device);

        }
    }
}
