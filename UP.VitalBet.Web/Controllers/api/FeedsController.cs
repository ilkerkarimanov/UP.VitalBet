using System;
using System.Threading.Tasks;
using System.Web.Http;
using UP.VitalBet.App.Cqs.Commands.Feed;
using UP.VitalBet.Core;
using UP.VitalBet.Core.Cqs.Command;
using UP.VitalBet.Core.Cqs.Query;
using UP.VitalBet.Controllers;
using UP.VitalBet.Web.Hubs;

namespace UP.VitalBet.Web.Controllers.api
{

    public class FeedsController : BaseController
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IBroadcaster _broadcaster;

        public FeedsController(IQueryProcessor queryProcessor,
            ICommandDispatcher commandDispatcher,
            IBroadcaster broadcaster)
        {
            _queryProcessor = queryProcessor;
            _commandDispatcher = commandDispatcher;
            _broadcaster = broadcaster;
        }

        [HttpPost]
        [Route("~/api/feeds/import")]
        public async Task<IHttpActionResult> Index()
        {
            try
            {
                var command = new ImportFeedCommand();
                var result = await _commandDispatcher.DispatchAsync<ImportFeedCommand, Result>(command);
                return ToResult(result);
            }
            catch (Failure reqEx)
            {
                return ErrorResult(reqEx);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

    }
}
