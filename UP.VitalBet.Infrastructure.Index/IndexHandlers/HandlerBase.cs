using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.IndexHandlers
{
    public abstract class IndexHandlerBase
    {
        protected IndexHandlerBase successor;

        public void SetSuccessor(IndexHandlerBase successor)
        {
            this.successor = successor;
        }

        public abstract void IndexRequest(FeedResult feed);
    }
}
