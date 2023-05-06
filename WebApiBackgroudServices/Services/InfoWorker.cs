using WebApiBackgroudServices.Repository;

namespace WebApiBackgroudServices.Services
{
    public class InfoWorker : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly ILogger<InfoWorker> _logger;
        private int executionCount = 0;
        private ICommandRepository _commandRepository;

        public InfoWorker(ILogger<InfoWorker> logger, ICommandRepository commandRepository)
        {
            _logger = logger;
            _commandRepository = commandRepository;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"---------- PROCESS STARTED [{nameof(InfoWorker)}] ----------\n");

            _timer = new Timer(
                DoWork,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5)  
            );

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            Console.WriteLine($"\n{DateTime.Now:o} => {_commandRepository.GetMessage()}");

            _logger.LogInformation(
                $"--- Timed Hosted Service is working. [Count: {count} time(s)]\n"
            );
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"\n---------- PROCESS FINISHED [{nameof(InfoWorker)}] ----------");

            return Task.CompletedTask;
        }
    }
}