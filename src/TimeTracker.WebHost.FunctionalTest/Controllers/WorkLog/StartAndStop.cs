using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Application.WorkLogs.Commands.StartWorkLog;
using TimeTracker.Application.WorkLogs.Commands.StopWorkLog;
using TimeTracker.WebHost.FunctionalTest.Common;
using Xunit;

namespace TimeTracker.WebHost.FunctionalTests.Controllers.Worklog
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenStartLogCommand_ReturnStartLogResult()
        {
            // Arrange
            var now = DateTime.Now;
            var command = new StartLogCommand
            {
                Identifier = "ENG-1",
                Start = now
            };

            //Act
            var requestContent = Utilities.GetRequestContent(command);
            var response = await _client.PostAsync("api/issue/startlog", requestContent);
            var result = await Utilities.GetResponseContent<StartLogResult>(response);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("ENG-1", result.Identifier);
            Assert.Equal(now, result.Start);
        }

        [Fact]
        public async Task GivenStopLogCommand_ReturnStopLogResult()
        {
            // Arrange
            var start = DateTime.Parse("04/05/2020 20:00:00");
            var end = DateTime.Parse("04/05/2020 23:00:00");
            var duration = (end - start).TotalMinutes;
            var command = new StopLogCommand
            {
                Identifier = "JS-2",
                End = end
            };


            //Act
            var requestContent = Utilities.GetRequestContent(command);
            var response = await _client.PostAsync("api/issue/stoplog", requestContent);
            var result = await Utilities.GetResponseContent<StopLogCommandResult>(response);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(duration,result.Duration);
            Assert.Equal(start,result.Start);
            Assert.Equal(end,result.End);
        }
    }
}