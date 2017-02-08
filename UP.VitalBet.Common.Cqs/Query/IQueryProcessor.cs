using System.Threading.Tasks;

namespace UP.VitalBet.Common.Cqs.Query
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}