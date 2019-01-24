using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Models;
using Timelogger.Models.Interfaces;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
	{
		private readonly IProjectRepository _repository;
		public ProjectsController(IProjectRepository repository)
		{
			_repository = repository;
		}

		// GET api/projects
		[HttpGet]
		public IActionResult Get()
		{
			var projects = _repository.SelectAll();
			if(projects == null)
			{
				return BadRequest();
			}
			return Ok(projects);
        }

		// GET api/projects/5
		[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var project = _repository.SelectById(id);
			if (project == null)
			{
				return NotFound();
			}
			return Ok(project);
        }

		// [HttpGet("{searchText}")]
		[Route("[action]/{searchText}")]
		[HttpGet]
		public IActionResult Search(string searchText) 
		{
			var projects = _repository.Find(searchText);
			if(projects == null)
			{
				return BadRequest();
			}
			return Ok(projects);
		}
    }
}
