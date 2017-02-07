using Microsoft.Practices.Unity;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Infrastructure.EF;
using UP.VitalBet.Infrastructure.Feed;
using UP.VitalBet.Infrastructure.Feed.Abstract;
using UP.VitalBet.Infrastructure.Index;
using UP.VitalBet.Infrastructure.Index.EntityIndexers;
using UP.VitalBet.Infrastructure.Repositories;
using UP.VitalBet.Model;

namespace UP.VitalBet.Run
{
    public class Bootstrap
    {
        public static UnityContainer container;
        public static void Start()
        {
            container = new UnityContainer();

            container.RegisterType<IFeedSerializer, FeedSerializer>();
            container.RegisterType<IFeedClient, FeedClient>();
            container.RegisterType<IEntityIndexer<Sport>, SportEntityIndexer>();
            container.RegisterType<IEntityIndexer<Event>, EventEntityIndexer>();
            container.RegisterType<IEntityIndexer<Match>, MatchEntityIndexer>();
            container.RegisterType<IEntityIndexer<Bet>, BetEntityIndexer>();
            container.RegisterType<IEntityIndexer<Odd>, OddEntityIndexer>();
            container.RegisterType<IFeedIndexer, FeedIndexer>();
            container.RegisterType<IMatchRepository, MatchRepository>();
            container.RegisterType<ISportRepository, SportRepository>();
            container.RegisterType<IEventRepository, EventRepository>();
            container.RegisterType<IBetRepository, BetRepository>();
            container.RegisterType<IOddRepository, OddRepository>();
            container.RegisterType<VitalBetDbContext>();
        
        }
    }
}
