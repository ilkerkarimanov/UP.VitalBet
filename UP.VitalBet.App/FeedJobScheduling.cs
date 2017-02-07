using FluentScheduler;

namespace UP.VitalBet.App
{
    public class FeedJobScheduling : Registry
    {
        public FeedJobScheduling()
        {
            // Schedule an IJob to run at an interval
            Schedule<FeedJob>().ToRunNow().AndEvery(60).Seconds();
        }
    }
}
