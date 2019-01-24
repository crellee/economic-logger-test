using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Models.Interfaces
{
    public interface IProjectRepository
    {
         IEnumerable<Project> SelectAll();
         Project  SelectById(int id);
         IEnumerable<Project> Find(string searchText);
    }
}