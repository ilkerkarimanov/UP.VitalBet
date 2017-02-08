// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UP.VitalBet.Web.DependencyResolution
{
    using StructureMap.Graph;
    using System;
    using FluentScheduler;
    using UP.VitalBet.App;
    using UP.VitalBet.Core.Configuration;
    using UP.VitalBet.Core.Import;
    using UP.VitalBet.Core.Persistance;
    using UP.VitalBet.Infrastructure.EF;
    using UP.VitalBet.Infrastructure.Feed;
    using UP.VitalBet.Infrastructure.Feed.Abstract;
    using UP.VitalBet.Infrastructure.Index;
    using UP.VitalBet.Infrastructure.Index.EntityIndexers;
    using UP.VitalBet.Infrastructure.Repositories;
    using UP.VitalBet.Model;
    using UP.VitalBet.Web.Configurations;
    using Hubs;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.AspNet.SignalR.Infrastructure;
    using Common;
    using Common.Cqs.Command;
    using Common.Cqs.Query;

    public class DefaultRegistry : StructureMap.Configuration.DSL.Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            RegisterTypes();
        }

        private void RegisterTypes()
        {
            For<IServiceProvider>().Use<StructureMapServiceProvider>();
            DateTimeProvider.Init(() => DateTime.UtcNow);
            RegisterWebConfiguration();
            RegisterSignalR();
            RegisterEFPersistance();
            RegisterGraphTracker();
            RegisterFeedIntegration();
            RegisterFeedEngine();
            RegisterFeedJob();

        }

        private void RegisterWebConfiguration()
        {
            For<IConfiguration>().Use<WebConfiguration>();
        }

        private void RegisterEFPersistance()
        {
            For<IMatchRepository>().Use<MatchRepository>();
            For<ISportRepository>().Use<SportRepository>();
            For<IEventRepository>().Use<EventRepository>();
            For<IBetRepository>().Use<BetRepository>();
            For<IOddRepository>().Use<OddRepository>();
            For<VitalBetDbContext>().Use<VitalBetDbContext>();
        }

        private void RegisterGraphTracker()
        {
            For<IEntityIndexer<Sport>>().Use<SportEntityIndexer>();
            For<IEntityIndexer<Event>>().Use<EventEntityIndexer>();
            For<IEntityIndexer<Match>>().Use<MatchEntityIndexer>();
            For<IEntityIndexer<Bet>>().Use<BetEntityIndexer>();
            For<IEntityIndexer<Odd>>().Use<OddEntityIndexer>();
            For<IFeedIndexer>().Use<FeedIndexer>();
        }

        private void RegisterFeedEngine()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<App.Cqs.CommandHandlers.Feed.ImportFeedCommandHandler>();
                x.ConnectImplementationsToTypesClosing(typeof(IAsyncCommandHandler<,>));
                x.ConnectImplementationsToTypesClosing(typeof(IHandleQueryAsync<,>));
            });

            For<IFeedCrawler>().Use<FeedCrawler>();
            For<IQueryProcessor>().Use<QueryProcessor>();
            For<ICommandDispatcher>().Use<CommandDispatcher>();
        }

        private void RegisterSignalR()
        {
            For<IDependencyResolver>().Singleton().Use<StructureMapSignalRDependencyResolver>();

            For<IConnectionManager>().Use<ConnectionManager>();
            For<IBroadcaster>()
                .Singleton()
                .Use<Broadcaster>()
                .Ctor<IHubConnectionContext<dynamic>>()
                .Is(ctx => ctx.GetInstance<IDependencyResolver>()
                    .Resolve<IConnectionManager>()
                    .GetHubContext<BroadcasterHub>().Clients);
        }

        private void RegisterFeedIntegration()
        {
            For<IFeedSerializer>().Use<FeedSerializer>();
            For<IFeedClient>().Use<FeedClient>();
        }

        private void RegisterFeedJob()
        {
            For<IJob>().Use<FeedJob>();
            For<IJobFactory>().Use<FeedJobFactory>();
        }
        #endregion
    }
}