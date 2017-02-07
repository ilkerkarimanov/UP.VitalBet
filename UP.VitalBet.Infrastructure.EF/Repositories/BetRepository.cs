using EntityFramework.Utilities;
using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Infrastructure.EF;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Repositories
{
    public class BetRepository : RepositoryBase<Bet>, IBetRepository
    {
        public BetRepository(VitalBetDbContext context)
            : base(context) { }

        public IEnumerable<Bet> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ?
                dbContext.Bets.AsNoTracking().ToList() :
                dbContext.Bets.ToList();
        }

        public void InserAll(IEnumerable<Bet> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Bets).InsertAll(
                entities, dbContext.Database.Connection, 10000);

        }

        public void UpdateAll(IEnumerable<Bet> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Bets).UpdateAll(
                entities,
                    x => x.ColumnsToUpdate(t => t.Name, t => t.IsLive, t => t.MatchId),
                    dbContext.Database.Connection,
                    10000);
        }
    }
}
