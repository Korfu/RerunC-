using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestCounter.Services;

namespace RequestCounter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/api/request-counter")]
    public class RequestCounterController : ControllerBase
    {
        private readonly IRequestCountStatsService _requestCountStatsService;

        private readonly ILogger<RequestCounterController> _logger;

        public RequestCounterController(ILogger<RequestCounterController> logger,
            IRequestCountStatsService requestCountStatsService)
        {
            _logger = logger;
            _requestCountStatsService = requestCountStatsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _requestCountStatsService.IncreaseCounter("GET");
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            _requestCountStatsService.IncreaseCounter("POST");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            _requestCountStatsService.IncreaseCounter("PUT");
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            _requestCountStatsService.IncreaseCounter("PATCH");
            return Ok();
        }
        

        [HttpDelete]
        public IActionResult Delete()
        {
            _requestCountStatsService.IncreaseCounter("DELETE");
            return Ok();
        }
    }
}