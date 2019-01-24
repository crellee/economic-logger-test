using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timelogger.Entities
{
    public class TimeLog
    {
        public int Id { get; set; } 

        [Required]
        public double TimeSpent { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}