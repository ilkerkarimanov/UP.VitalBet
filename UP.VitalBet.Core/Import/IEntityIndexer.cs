using System.Collections.Generic;
using UP.VitalBet.Model;

namespace UP.VitalBet.Core.Import
{
    public interface IEntityIndexer<T>
    {
        void Index(IEnumerable<T> data);
    }

}
