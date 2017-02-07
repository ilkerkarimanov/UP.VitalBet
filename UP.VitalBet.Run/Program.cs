using Microsoft.Practices.Unity;
using System.Diagnostics;
using UP.VitalBet.Core.Import;

namespace UP.VitalBet.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.Start();
            
                var stopwatch0 = new Stopwatch();
                stopwatch0.Start();
                var feedClient = Bootstrap.container.Resolve<IFeedClient>();
            var result = feedClient.RetrieveSportFeed().Result;
                stopwatch0.Stop();

                var _tracker = Bootstrap.container.Resolve<IFeedIndexer>();
                
                var stopwatch1 = new Stopwatch();
                stopwatch1.Start();

                _tracker.Index(result.Sports);
                stopwatch1.Stop();
            
        }
    }
}
