using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestCounter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.WebApi.Controllers
{
    [Route("api/Statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {

        private readonly IRequestCountStatsService requestCountStatsService;

        public StatisticsController(IRequestCountStatsService service)
        {
            this.requestCountStatsService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stats = this.requestCountStatsService.GetStatistics();
            return Ok(stats.Counts);
        }
    }
}
