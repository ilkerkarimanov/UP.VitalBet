using EntityFramework.Utilities;
using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Infrastructure.EF;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Repositories
{
    public class OddRepository : RepositoryBase<Odd>, IOddRepository
    {
        public OddRepository(VitalBetDbContext context)
            : base(context) { }

        public IEnumerable<Odd> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ?
                dbContext.Odds.AsNoTracking().ToList() :
                dbContext.Odds.ToList();
        }


        public void InserAll(IEnumerable<Odd> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Odds).InsertAll(
                entities,
                dbContext.Database.Connection,
                10000);
        }

        public void UpdateAll(IEnumerable<Odd> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Odds).UpdateAll(
                entities,
                        x => x.ColumnsToUpdate(t => t.Name, t => t.Value, t => t.SpecialBetValue, t => t.BetId),
                        dbContext.Database.Connection,
                        10000);
        }
    }
}
