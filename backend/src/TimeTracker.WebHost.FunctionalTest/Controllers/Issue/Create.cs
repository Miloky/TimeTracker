using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Application.Issues.Commands.CreateIssue;
using TimeTracker.WebHost.FunctionalTest.Common;
using Xunit;

namespace TimeTracker.WebHost.FunctionalTests.Controllers.Issue
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateIssueCommand_ReturnNewIssueId()
        {
            // Arrange 
            var command1 = new CreateIssueCommand
            {
                Title = "Harry Potter & the philosopher's stone",
                Prefix = "ENG",
                Description = "Read the book"
            };
            var command2 = new CreateIssueCommand
            {
                Title = "A Game of Thrones",
                Prefix = "ENG",
                Description = "Read the book"
            };

            // Act
            var content1 = Utilities.GetRequestContent(command1);
            var response1 = await _client.PostAsync("api/issue/new", content1);
            var result1 = await response1.Content.ReadAsStringAsync();

            var content2 = Utilities.GetRequestContent(command2);
            var response2 = await _client.PostAsync("api/issue/new", content2);
            var result2 = await response2.Content.ReadAsStringAsync();


            //Assert
            response1.EnsureSuccessStatusCode();
            response2.EnsureSuccessStatusCode();
            Assert.Equal("ENG-3",result1);
            Assert.Equal("ENG-4",result2);
        }
    }
}