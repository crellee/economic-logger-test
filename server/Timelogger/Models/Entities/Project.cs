using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
    public class Project
    {
		public int Id { get; set; }
		public string Name { get; set; }
    public List<TimeLog> TimeLogs { get; set; }
    }
}
