using EntityFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Infrastructure.EF;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Repositories
{
    public class MatchRepository : RepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(VitalBetDbContext context)
            : base(context) { }

        public IEnumerable<Match> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ?
                dbContext.Matches.AsNoTracking().ToList() :
                dbContext.Matches.ToList();
        }

        public IEnumerable<Match> GetForTheNext24Hours(DateTime startDate)
        {
            var dateDuration = startDate.AddHours(24);
            var matches =  dbContext.Matches.AsNoTracking()
                .Where(x => x.StartDate >= startDate && x.StartDate <= dateDuration)
                .Where(x => x.Bets.Any(z => z.Odds.Any()))
                .OrderBy(x => x.StartDate).ToList();
            return matches;
        }

        public void InserAll(IEnumerable<Match> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Matches).InsertAll(
                entities,
                dbContext.Database.Connection,
                                    10000);

        }

        public void UpdateAll(IEnumerable<Match> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Matches).UpdateAll(
                entities,
                    x => x.ColumnsToUpdate(t => t.EventId, t => t.MatchType, t => t.Name, t => t.StartDate),
                    dbContext.Database.Connection,
                    10000);
        }
    }
}
