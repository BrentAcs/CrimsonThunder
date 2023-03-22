using CrimsonThunder.Common.Infrastructure.Storage;

namespace CrimsonThunder.Common.Extensions;

public static class ServiceCollectionExtensions
{
   public static IServiceCollection AddCrimsonThunderMongoCommon(this IServiceCollection services, IConfiguration configuration)
   {
      services
         .Configure<MongoDbSettings>( configuration.GetSection("MongoDb") ) 
         .AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value)
         .AddSingleton<IMongoContext, MongoContext>()
         
         // .AddScoped<IStarClusterRepo, StarStarClusterRepo>()
         // .AddScoped<IPlanetarySystemRepo, PlanetarySystemRepo>()
         // .AddScoped<IUserAppStateRepo, UserAppStateRepo>()
         //
         // .AddScoped<IMongoRepository, StarStarClusterRepo>()
         // .AddScoped<IMongoRepository, PlanetarySystemRepo>()
         // .AddScoped<IMongoRepository, UserAppStateRepo>()
         ;

      return services;
   }

}
