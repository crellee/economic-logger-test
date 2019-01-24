using System;
using Xunit;
using Moq;
using Timelogger;
using Timelogger.Models.Interfaces;
using Timelogger.Models;
using Timelogger.Api.Controllers;


namespace Timelogger.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var MockITimeLogRepository = new Mock<ITimeLogRepository>();
            TimeLogsController controller = new TimeLogsController(MockITimeLogRepository.Object);

            Entities.TimeLog timeLogModel = new Entities.TimeLog()
            {
                TimeSpent = 4.32,
                Date = new DateTime(2000, 11, 11),
                ProjectId = 1
            };

            // //Act
            controller.Post(timeLogModel);

            //Assert
            MockITimeLogRepository.Verify(t => t.Create(timeLogModel));
        }
    }
}
