using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using HomeApi.Contracts.Models.Home;
using Web_Api_Modul_34.Model;

namespace Web_Api_Modul_34.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;   
        }
        [HttpGet]
        [Route("inFo")]
        public IActionResult Info()
        {
            var pageResult = new StringBuilder();
            pageResult.Append($"Добро пожаловать Api вашего дома! {Environment.NewLine}");
            pageResult.Append($"Здемсь вы можете посмотреть основную конфигурацию. {Environment.NewLine}");
            pageResult.Append($" {Environment.NewLine}");
            pageResult.Append($"Колличество этажей : {_options.Value.FloorAmount}{Environment.NewLine}");
            pageResult.Append($"Стационарный телефон: {_options.Value.Telephone}{Environment.NewLine}");
            pageResult.Append($"Тип отопления:  {_options.Value.Heating}{Environment.NewLine}");
            pageResult.Append($"Напряжение электросети: {_options.Value.CurrentVolts}{Environment.NewLine}");
            pageResult.Append($"Подключен к газовой сети: {_options.Value.GasConnected}{Environment.NewLine}");
            pageResult.Append($"Жилая площадь:  {_options.Value.Area} м2{Environment.NewLine}");
            pageResult.Append($"Материал:  {_options.Value.Material}{Environment.NewLine}");
            pageResult.Append($"{Environment.NewLine}");
            pageResult.Append($"Адресс : {_options.Value.Address.Street} {_options.Value.Address.House}/{_options.Value.Address.Building}{Environment.NewLine}");

            return StatusCode(200, pageResult.ToString());
        }



        [HttpGet] // Для обслуживания Get-запросов
        [Route("infoMap")] // Настройка маршрута с помощью атрибутов
        public IActionResult InfoMap()
        {
            // Получим запрос, "смапив" конфигурацию на модель запроса
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            // Вернём ответ
            return StatusCode(200, infoResponse);
        }
    }
}
