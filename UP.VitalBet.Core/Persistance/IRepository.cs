using System.Collections.Generic;

namespace UP.VitalBet.Core.Persistance
{
    public interface IRepository<T> where T : class
    {
        void InserAll(IEnumerable<T> entities);
        void UpdateAll(IEnumerable<T> entities);

        IEnumerable<T> GetAll(bool asNoTracking = false);
    }
}
