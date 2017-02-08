using System.Threading.Tasks;


namespace UP.VitalBet.Common.Cqs.Command
{
    public interface IAsyncCommandHandler
    { }

    public interface IAsyncCommandHandler<in TCommand, TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}