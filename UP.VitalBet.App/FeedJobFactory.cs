using FluentScheduler;
using System;

namespace UP.VitalBet.App
{
    public class FeedJobFactory : IJobFactory
    {
        private readonly IServiceProvider _container;
        public FeedJobFactory(IServiceProvider container)
        {
            _container = container;
        }
        public IJob GetJobInstance<T>() where T : IJob
        {
            return (T) _container.GetService(typeof(T));
        }
    }
}
