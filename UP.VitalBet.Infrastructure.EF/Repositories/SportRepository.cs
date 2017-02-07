using EntityFramework.Utilities;
using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Infrastructure.EF;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Repositories
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepository
    {
        public SportRepository(VitalBetDbContext context)
            : base(context)
        { }

        public IEnumerable<Sport> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ?
                dbContext.Sports.AsNoTracking().ToList() :
                dbContext.Sports.ToList();
        }

        public void InserAll(IEnumerable<Sport> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Sports).InsertAll(
                entities,
                dbContext.Database.Connection,
                10000);

        }

        public void UpdateAll(IEnumerable<Sport> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Sports).UpdateAll(
                entities,
                x => x.ColumnsToUpdate(t => t.Id, t => t.Name),
                dbContext.Database.Connection,
                10000);
        }
    }
}
