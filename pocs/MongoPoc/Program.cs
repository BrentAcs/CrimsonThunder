// See https://aka.ms/new-console-template for more information

using CrimsonThunder.Common.Extensions;
using CrimsonThunder.Common.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;


var configuration = new ConfigurationBuilder()
   .AddJsonFile($"appsettings.json")
   .Build();
   
IHost host = Host.CreateDefaultBuilder(args)
   .ConfigureServices(services =>
   {
      services.AddHostedService<MongoService>();
      services.AddCrimsonThunderMongoCommon(configuration);
      
      services.AddScoped<ISamplePocoRepo, SamplePocoRepo>();
      
   })
   .Build();

   Utilities.RegisterKnownTypes<SamplePoco>();

host.Run();

public class MongoService : BackgroundService
{
   private readonly ILogger<MongoService> _logger;
   private readonly ISamplePocoRepo _repo;

   public MongoService(ILogger<MongoService> logger, ISamplePocoRepo repo)
   {
      _logger = logger;
      _repo = repo;
   }

   protected override async Task ExecuteAsync(CancellationToken stoppingToken)
   {
      Console.WriteLine("Service Starting...");

      var brent = new SamplePoco
      {
         Name = "Brent",
         Age = 50
      };
      
      await _repo.InsertOneAsync(brent, stoppingToken).ConfigureAwait(false);
      
      Console.WriteLine("Service Ending...");
   }
}

[BsonCollection("SamplePocos")]
public class SamplePoco : IMongoDocument
{
   public ObjectId Id { get; set; }
   public string Name { get; set; } = String.Empty;
   public string? Description { get; set; }
   public int Age { get; set; }
   
}

public interface ISamplePocoRepo : IMongoRepository<SamplePoco>
{
}

public class SamplePocoRepo : MongoRepository<SamplePoco>, ISamplePocoRepo
{
   public SamplePocoRepo(IMongoContext? mongoContext, ILogger<MongoRepository<SamplePoco>> logger) : base(mongoContext, logger)
   {
   }
}