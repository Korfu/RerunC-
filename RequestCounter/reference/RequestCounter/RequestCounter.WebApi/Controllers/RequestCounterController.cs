using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestCounter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.WebApi.Controllers
{
    /// <summary>
    /// Route is introcued with TASK Create route to request counter
    /// </summary>
    [Route("api/request-counter")]
    [ApiController]
    public class RequestCounterController : ControllerBase
    {
        private readonly IRequestCountStatsService requestCountStatsService;

        public RequestCounterController(IRequestCountStatsService service)
        {
            this.requestCountStatsService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this.requestCountStatsService.IncreaseCounter("GET");
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            this.requestCountStatsService.IncreaseCounter("POST");
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            this.requestCountStatsService.IncreaseCounter("PATCH");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            this.requestCountStatsService.IncreaseCounter("PUT");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            this.requestCountStatsService.IncreaseCounter("DELETE");
            return Ok();
        }
    }
}
