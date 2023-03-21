using Serilog;
using WorkerServicePoc;

IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
   {
      // services.AddHostedService<Worker>();
      services.AddHostedService<TimedHostedService>();
   })
   .UseSerilog((hostingContext, loggerConfiguration) =>
   {
      loggerConfiguration
         .ReadFrom.Configuration(hostingContext.Configuration)
         .Enrich.FromLogContext();
   })
   .Build();

host.Run();
