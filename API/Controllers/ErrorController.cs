using API.Errors;
using Microsoft.AspNetCore.Mvc;

//Incase of any request to the endpoint that is not handled by our api
namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult error(int code)
        {
            return (new ObjectResult(new ApiResponse(code)));

        }

    }
}