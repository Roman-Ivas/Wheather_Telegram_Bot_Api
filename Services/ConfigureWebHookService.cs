using Microsoft.Extensions.Options;

namespace WheatherTelegramBotApi.Services
{
    public class ConfigureWebHookService : IHostedService
    {
        private readonly ILogger<ConfigureWebHookService> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly BotConfiguration botConfiguration;

        public ConfigureWebHookService(
            ILogger<ConfigureWebHookService> logger,
            IServiceProvider serviceProvider,
            IOptions<BotConfiguration> options)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.botConfiguration = options.Value;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
