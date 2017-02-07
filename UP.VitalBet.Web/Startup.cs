using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using StructureMap;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using UP.VitalBet.Web.Hubs;
using UP.VitalBet.Web.DependencyResolution;
using FluentScheduler;
using UP.VitalBet.App;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(UP.VitalBet.Web.Startup))]

namespace UP.VitalBet.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            var container = IoC.GetConfiguredContainer();
            var resolver = DependencyResolver.Current.GetService<Microsoft.AspNet.SignalR.IDependencyResolver>();

            var hubConfiguration = new HubConfiguration
            {
                Resolver = resolver
            };
            app.MapSignalR(hubConfiguration);
            JobManager.JobFactory = container.GetInstance<IJobFactory>();
            JobManager.Initialize(new FeedJobScheduling());
        }
    }
}