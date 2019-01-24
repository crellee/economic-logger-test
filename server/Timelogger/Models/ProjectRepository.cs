using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Timelogger.Entities;
using Timelogger.Models.Interfaces;

namespace Timelogger.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApiContext _context;
        public ProjectRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> SelectAll()
        {
            try 
            {
                var projects = _context.Projects;
                return projects;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Project SelectById(int id)
        {
            try 
            {
                var project = _context.Projects.Include(t => t.TimeLogs).FirstOrDefault(p => p.Id == id);
                return project;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<Project> Find(string searchText)
        {
            try 
            {
                var projects = _context.Projects.Where(p => p.Name.ToLower().Contains(searchText.ToLower()));
                return projects;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}