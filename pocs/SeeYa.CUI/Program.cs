// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeeYa.Core;

IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
   {
      services.AddHostedService<Worker>();
      services.AddScoped<IStoryRepo, TestStoryRepo>();
      services.AddScoped<IStoryNodeRepo, TestStoryNodeRepo>();
      services.AddScoped<IStoryRunner, StoryRunner>();
   })
   .Build();

host.Run();

public class Worker : BackgroundService, IObserver<StoryNode>
{
   private readonly IStoryRunner _runner;

   public Worker(IStoryRunner runner)
   {
      _runner = runner;
      _runner.Subscribe(this);
   }

   protected override Task ExecuteAsync(CancellationToken stoppingToken)
   {
      _runner.Start("100000000000000000000000");
      Console.WriteLine($"{nameof(Worker)} done!");
      
      return Task.CompletedTask;
   }

   public void OnCompleted() 
   {
      Console.WriteLine($"{nameof(Worker)} {nameof(OnCompleted)}");
   }

   public void OnError(Exception error)
   {
      Console.WriteLine($"{nameof(Worker)} {nameof(OnError)}");
   }

   public void OnNext(StoryNode value) 
   {
      Console.WriteLine($"{nameof(Worker)} {nameof(OnNext)}");
   }
}


