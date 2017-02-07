using UP.VitalBet.Infrastructure.EF;

namespace UP.VitalBet.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        private VitalBetDbContext _dbContext;

        protected VitalBetDbContext dbContext
        {
            get { return _dbContext; }
        }
        
        public RepositoryBase(VitalBetDbContext context)
        {
            _dbContext = context;
        }
        
    }
}
