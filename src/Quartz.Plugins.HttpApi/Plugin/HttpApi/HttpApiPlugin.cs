using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Quartz.Logging;
using Quartz.Spi;

namespace Quartz.Plugin.HttpApi
{
    public class HttpApiPlugin : ISchedulerPlugin
    {
        private ILog log = LogProvider.GetLogger(typeof(HttpApiPlugin));

        private IHost? host;

        public string HostName { get; set; } = "127.0.0.1";
        public int? Port { get; set; }

        public Task Initialize(string pluginName, IScheduler scheduler, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            string baseAddress = $"http://{HostName ?? "localhost"}:{Port ?? 28682}/";

            //host = WebApp.Start<Startup>(url: baseAddress);
            host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .Build();

            await host.StartAsync(cancellationToken);

            log.InfoFormat("Quartz Web Console bound to address {0}", baseAddress);
        }

        public Task Shutdown(CancellationToken cancellationToken)
        {
            host?.Dispose();
            return Task.CompletedTask;
        }
    }
}