using HealthForge.AspNetDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace HealthForge.AspNetDemo
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup()
        {
            Configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();
            services.AddDbContext<BookContext>(options => options.UseSqlServer(Configuration["DATABASE_ADO_CONNECTION_STRING"]));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi();
            loggerFactory.AddConsole(minLevel: LogLevel.Information);
        }
    }
}
