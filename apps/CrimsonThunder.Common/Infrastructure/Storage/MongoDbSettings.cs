﻿namespace CrimsonThunder.Common.Infrastructure.Storage;

public class MongoDbSettings : IMongoDbSettings
{
   public string ConnectionString { get; set; } = string.Empty;
   public string DatabaseName { get; set; } = string.Empty;
}
