using System;
using System.Linq;
using System.Web.Http;
using UP.VitalBet.Common;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UP.VitalBet.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected virtual IHttpActionResult ErrorResult(string message)
        {
            return ErrorResult("request_error", message);
        }

        protected virtual IHttpActionResult ErrorResult(string error, string message)
        {
            return Content(System.Net.HttpStatusCode.BadRequest,
                            new
                            {
                                Status = "Failed",
                                Error = error,
                                Message = message
                            });
        }

        protected virtual IHttpActionResult ErrorResult(Failure ex) {
            if (ex.Errors != null && ex.Errors.Count() > 0)
            {
                var result = Result.Fail(ex.Errors.ToArray());
                return ToResult(result);
            }
            else
            {
                return ErrorResult(ex.Message);
            }
        }

        protected virtual IHttpActionResult ErrorResult(Exception ex)
        {
            return Content(System.Net.HttpStatusCode.BadRequest,
                            new
                            {
                                Status = "Failed",
                                Error = "server_error",
                                Message = "Internal server error"
                            });
        }

        protected virtual IHttpActionResult ErrorModelResult()
        {
            var errors = ModelState
                    .SelectMany(value => value.Value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToArray();

            var modelValidationResult = errors.Length == 0 ? Common.Result.Ok() : Common.Result.Fail(errors.ToArray());

            return modelValidationResult.Succeeded ?  OkResult() : Content (
                System.Net.HttpStatusCode.BadRequest,
                new
                {
                    Status = "Failed",
                    Error = "request_error",
                    Message = modelValidationResult.Errors
                });
        }

        protected virtual IHttpActionResult ToResult(Result result)
        {
            return result.Succeeded ? OkResult() :  Content(
                System.Net.HttpStatusCode.BadRequest,
                new
                {
                    Status = "Failed",
                    Error = "request_error",
                    Message = result.Errors
                });
        }

        protected virtual IHttpActionResult OkResult()
        {
            return Ok(
                new {
                Status = "Success"
            });
        }

        protected virtual IHttpActionResult OkResult(object value)
        {
            return Ok(value);
        }
        
    }
}
