using FluentScheduler;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using UP.VitalBet.Core;
using UP.VitalBet.Core.Configuration;

namespace UP.VitalBet.App
{
    public class FeedJob : IJob, IRegisteredObject
    {
        private readonly object _lock = new object();

        private bool _shuttingDown;
        private readonly IConfiguration _config;

        private const string feedApiConfigKey = "feedApiUrl";
        public FeedJob(IConfiguration config)
        {
            // Register this job with the hosting environment.
            // Allows for a more graceful stop of the job,
            //in the case of IIS shutting down.
            HostingEnvironment.RegisterObject(this);
            _config = config;
        }

        public async void Execute()
        {
            lock (_lock)
            {
                if (_shuttingDown)
                    return;

                // Do work, son!
                DoWork();
            }
        }

        private async void DoWork()
        {
            if (!_config.HasProperty(feedApiConfigKey)) throw new Failure("[feedApiUrl] config is null.");
            string url = _config.ReadProperty(feedApiConfigKey);
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var res = await httpClient.SendAsync(request);
            }
        }

        public void Stop(bool immediate)
        {
            // Locking here will wait for the lock in Execute to be released until this code can continue.
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }
    }
}
