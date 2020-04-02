using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TimeTracker.Application.Projects.Commands.CreateProject;
using TimeTracker.WebHost.FunctionalTest.Common;
using Xunit;

namespace TimeTracker.WebHost.FunctionalTest.Controllers.Project
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httClient;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _httClient = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateProjectCommand_ReturnsNewProjectId()
        {
            var command = new CreateProjectCommand
            {
                Name = "TEST DATA"
            };

            var content = Utilities.GetRequestContent(command);
            var response = await _httClient.PostAsync("api/projects/new", content);
            response.EnsureSuccessStatusCode();
            var responseObject = await Utilities.GetResponseContent<JObject>(response);
            var projectId = responseObject.Value<int>("id");
            Assert.Single(responseObject);
            Assert.NotEqual(0, projectId);
            Assert.Equal(3, projectId);
        }
    }
}