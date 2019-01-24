using System;
using Timelogger.Entities;
using Timelogger.Models.Interfaces;

namespace Timelogger.Models
{
    public class TimeLogRepository : ITimeLogRepository
    {
        private readonly ApiContext _context;
        public TimeLogRepository(ApiContext context)
        {
            _context = context;
        }
        public TimeLog Create(TimeLog timeLog)
        {
            try 
            {
                timeLog.Date = DateTime.Now;
                _context.TimeLogs.Add(timeLog);
                _context.SaveChanges();
                return timeLog;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            } 
        }
    }
}