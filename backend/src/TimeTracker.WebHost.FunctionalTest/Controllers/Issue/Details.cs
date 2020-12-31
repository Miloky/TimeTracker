using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Application.Issues.Queries.IssueDetails;
using TimeTracker.WebHost.FunctionalTest.Common;
using Xunit;

namespace TimeTracker.WebHost.FunctionalTest
{
    public class Details : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Details(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenIssueDetailsQuery_ReturnsIssueDetails()
        {
            // Arrange
            var query = new IssueDetailsQuery
            {
                Identifier = "JS-2"
            };
            HttpContent httpContent = Utilities.GetRequestContent(query);

            //Act
            HttpResponseMessage httpResponseMessage = await _client.PostAsync("/api/issue/details", httpContent);
            IssueDetailsQueryResult queryResult = await Utilities.GetResponseContent<IssueDetailsQueryResult>(httpResponseMessage);

            //Assert
            httpResponseMessage.EnsureSuccessStatusCode();
            Assert.NotEmpty(queryResult.WorkLogs);
        }
    }
}
