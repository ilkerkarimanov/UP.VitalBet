using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{
    public abstract class IndexHandlerBase : IIndexHandler
    {
        protected IIndexHandler successor;

        public void SetSuccessor(IIndexHandler successor)
        {
            this.successor = successor;
        }

        public abstract void IndexRequest(Feed feed);
    }
}
