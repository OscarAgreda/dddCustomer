using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using DDDCustomer.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DDDCustomer.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var hostEnvironment = services.GetService<IWebHostEnvironment>();

                //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-7.0
                //  This line retrieves an instance of the ILoggerFactory service from the DI container managed by the IServiceCollection object named services. The GetRequiredService<T> method is used to get the service, and if the service cannot be found in the DI container, an exception is thrown.
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                // This line creates an instance of the logger for the Program class using the CreateLogger<T> method of the ILoggerFactory interface. The logger instance is stored in the logger variable.
                var logger = loggerFactory.CreateLogger<Program>();



                // This line logs an information-level message using the logger instance created in step 2. The message includes a string interpolation expression that includes the value of the EnvironmentName property of the hostEnvironment object, which is presumably an instance of the IHostEnvironment interface.
                logger.LogInformation($"Starting in environment {hostEnvironment.EnvironmentName}");
                //Microsoft.Extensions.Logging is a logging abstraction library for .NET applications that provides a common interface for logging across different log providers. It allows you to log messages at different log levels (such as trace, debug, information, warning, error, and critical) and to route those messages to different targets, such as console, file, database, or third-party logging services like Application Insights.
                // To use Microsoft.Extensions.Logging, you typically start by configuring a logger provider. This is done in the application startup code, such as the Configure method in an ASP.NET Core application's Startup class.
                try
                {
                    var catalogContext = services.GetRequiredService<AppDbContext>();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}