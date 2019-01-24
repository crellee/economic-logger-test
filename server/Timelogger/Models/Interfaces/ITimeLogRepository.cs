using Timelogger.Entities;

namespace Timelogger.Models.Interfaces
{
    public interface ITimeLogRepository
    {
         TimeLog Create(TimeLog timeLog);
    }
}