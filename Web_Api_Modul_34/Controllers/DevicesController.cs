using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using HomeApi.Contracts.Models.Devices;
using Web_Api_Modul_34.Model;

namespace Web_Api_Modul_34.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Ad")]
        public IActionResult Ad([FromBody] AddDeviceRequest request)
        {
            if (request.CurrentVolts < 120)
            {
                ModelState.AddModelError("currentVolts", "Device in smoll 220 V not plug");
                return BadRequest(ModelState);
            }
            return StatusCode(200, $"устройство {request.Name} добавленно");
        }
        [HttpPost]
        [Route("Addd")]
        public IActionResult Add([FromBody] AddDeviceRequest request // Объект запроса
 )
        {
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }
    }
}
