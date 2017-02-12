using System.Collections.Generic;
using UP.VitalBet.Model;

namespace UP.VitalBet.Core.Import
{
    public interface IFeedIndexer
    {
        void Index(Feed data);
    }
}
