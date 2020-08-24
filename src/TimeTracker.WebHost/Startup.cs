using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Application;
using TimeTracker.Persistence;

namespace TimeTracker.WebHost
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterApplicationLayer();
            services.RegisterPersistenceLayer(_configuration);
            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();
            app.UseEndpoints(opt => opt.MapDefaultControllerRoute());
        }
    }
}
