namespace WorkerServicePoc;

public class TimedHostedService : IHostedService, IDisposable
{
   private readonly ILogger<TimedHostedService> _logger;
   private KernelConfig _kernelConfig;
   private Timer? _timer = null;
   private int _doWorkCount = 0;

   public TimedHostedService(ILogger<TimedHostedService> logger, IConfiguration configuration)
   {
      _logger = logger;

      _kernelConfig = configuration.GetSection("Backend:Kernel").Get<KernelConfig>();
   }

   public Task StartAsync(CancellationToken cancellationToken)
   {
      _logger.LogInformation("{service} Service running.", nameof(TimedHostedService));

      _timer = new Timer(DoWork, new TimedHostedServiceState(), TimeSpan.Zero, TimeSpan.FromSeconds(_kernelConfig.TickTimeout));

      return Task.CompletedTask;
   }

   public Task StopAsync(CancellationToken cancellationToken)
   {
      _logger.LogInformation("{service} Service is stopping.", nameof(TimedHostedService));

      _timer?.Change(Timeout.Infinite, 0);

      return Task.CompletedTask;
   }

   public void Dispose()
   {
      _timer?.Dispose();
   }

   private void DoWork(object? stateObject)
   {
      var count = Interlocked.Increment(ref _doWorkCount);

      // stateObject ??= new TimedHostedServiceState();
      var state = stateObject as TimedHostedServiceState;

      _logger.LogInformation("Do Work, count: {count}, state: '{state}'", count, state.Count);

      var stateCount = state.Count;
      Interlocked.Increment(ref stateCount);
      state.Count = stateCount;
   }
}

public class TimedHostedServiceState
{
   public int Count { get; set; }
}

public class KernelConfig
{
   public double TickTimeout { get; set; } = 1;
}
