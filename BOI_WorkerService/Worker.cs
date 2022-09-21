using BOI_WorkerService.Models.ConfigurationModels;
using BOI_WorkerService.Services.SendEnqueuedEmail;
using MediatR;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace BOI_WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;
        private readonly ServiceConfigurationSettings _serviceConfigurtionSettings;


        public Worker(ILogger<Worker> logger, IMediator mediator,
                IOptions<ServiceConfigurationSettings> serviceConfigurtionSettings, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _mediator = mediator;
            _serviceProvider = serviceProvider;
            _serviceConfigurtionSettings = serviceConfigurtionSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {

                    using (var scope = _serviceProvider.CreateScope())
                    {
                       
                        if (_serviceConfigurtionSettings.ActivateEnqueueEmail)
                        {
                            // Read Enqueued email and send 
                            await scope.ServiceProvider.GetRequiredService<IMediator>().Send(new SendEnqueuedEmailCommand(), stoppingToken);
                        }

                    }
                    await Task.Delay(1000, stoppingToken);
                }
                catch (OperationCanceledException)
                {

                    return;
                }
            }
        }
    }
}