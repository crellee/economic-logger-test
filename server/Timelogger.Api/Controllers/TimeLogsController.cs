using System;
using Microsoft.AspNetCore.Mvc;
using Timelogger.Entities;
using Timelogger.Models.Interfaces;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class TimeLogsController : Controller
    {
        private readonly ITimeLogRepository _repository;
		public TimeLogsController(ITimeLogRepository repository)
		{
			_repository = repository;
		}

        [HttpPost]
        public IActionResult Post([FromBody] TimeLog timeLog) 
        {
            timeLog = _repository.Create(timeLog);
            if(timeLog == null)
            {
                return BadRequest();
            }
            return Ok(timeLog);
        }
    }
}