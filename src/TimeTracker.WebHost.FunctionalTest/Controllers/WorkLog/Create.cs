using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Application.WorkLogs.Commands.StartWorkLog;
using TimeTracker.WebHost.FunctionalTest.Common;
using Xunit;

namespace TimeTracker.WebHost.FunctionalTests.Controllers.Worklog
{
    public class Create:IClassFixture<CustomWebApplicationFactory<Startup>>
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
            Assert.Equal(now,result.Start);
        }
    }
}