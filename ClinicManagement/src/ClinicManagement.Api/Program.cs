using System;
using Autofac.Extensions.DependencyInjection;
using ClinicManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ClinicManagement.Api
{
  public class Program
  {
    public static async System.Threading.Tasks.Task Main(string[] args)
    {
      var builder = CreateHostBuilder(args);
      
      var serviceName = "ClinicManagement.Api";
      var serviceVersion = "1.0.0";
      
      builder.ConfigureServices(service =>
      {
        service.AddOpenTelemetryTracing(b =>
        {
          b
            .AddConsoleExporter()
            .AddSource(serviceName)
            .SetResourceBuilder(
              ResourceBuilder.CreateDefault()
                .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation();
        });
        service.AddOpenTelemetryMetrics(m =>
        {
          m
            .AddPrometheusExporter(options =>
            {
              options.StartHttpListener = true;
              // Use your endpoint and port here
              options.HttpListenerPrefixes = new string[] {$"http://localhost:{9090}/"};
              options.ScrapeResponseCacheDurationMilliseconds = 0;
            });
          });
      });

      var host = builder
                  .Build();
      

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var hostEnvironment = services.GetService<IWebHostEnvironment>();
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation($"Starting in environment {hostEnvironment.EnvironmentName}");
        try
        {
          var seedService = services.GetRequiredService<AppDbContextSeed>();
          await seedService.SeedAsync(new OfficeSettings().TestDate);
        }
        catch (Exception ex)
        {
          logger.LogError(ex, "An error occurred seeding the DB.");
        }
      }

      host.Run();
    }
   

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
          .UseServiceProviderFactory(new AutofacServiceProviderFactory())
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Startup>();
          });
      
  }
}
