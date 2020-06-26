namespace MartianRobots.Console
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Threading;
    using System.Threading.Tasks;

    public class MartianRobotsSupportService : IHostedService
    {
        private readonly ILogger _logger;
        //private readonly IOptions<AppConfig> _appConfig;

        public MartianRobotsSupportService(ILogger logger) //, IOptions<AppConfig> appConfig)
        {
            this._logger = logger;
            //this._appConfig = appConfig;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
