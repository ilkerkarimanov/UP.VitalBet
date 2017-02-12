using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{
    public interface IIndexHandler
    {
        void IndexRequest(Feed feed);
        void SetSuccessor(IIndexHandler successor);
    }
}