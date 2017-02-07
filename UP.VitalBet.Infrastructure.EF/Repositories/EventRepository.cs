using EntityFramework.Utilities;
using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Infrastructure.EF;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(VitalBetDbContext context)
            : base(context) { }

        public IEnumerable<Event> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ?
                dbContext.Events.AsNoTracking().ToList() :
                dbContext.Events.ToList();
        }


        public void InserAll(IEnumerable<Event> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Events).InsertAll(
                entities,
                    dbContext.Database.Connection,
                    10000);
        }

        public void UpdateAll(IEnumerable<Event> entities)
        {
            EFBatchOperation.For(dbContext, dbContext.Events).UpdateAll(
                entities,
                x => x.ColumnsToUpdate(t => t.Name, t => t.SportId, t => t.IsCategory, t => t.CategoryId),
                dbContext.Database.Connection, 10000);
        }
    }
}
