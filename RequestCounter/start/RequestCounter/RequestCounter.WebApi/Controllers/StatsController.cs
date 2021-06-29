using Microsoft.AspNetCore.Mvc;
using RequestCounter.Services;

namespace RequestCounter.WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]/api/statistics")]
    public class StatsController : ControllerBase
    {
        private readonly IRequestCountStatsService _requestCountStatsService;

        public StatsController(IRequestCountStatsService requestCountStatsService)
        {
            _requestCountStatsService = requestCountStatsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _requestCountStatsService.GetStatistics();
            return Ok(result.Counts);
        }
    }
}