using System.Collections.Generic;

namespace UP.VitalBet.Core.Import
{
    public interface IEntityIndexer<T>
    {
        void Index(IEnumerable<T> data);
    }

}
