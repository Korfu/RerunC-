using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RequestCounter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestCounterController : ControllerBase
    {
        

        private readonly ILogger<RequestCounterController> _logger;

        public RequestCounterController(ILogger<RequestCounterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        
        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok();
        }
        
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}