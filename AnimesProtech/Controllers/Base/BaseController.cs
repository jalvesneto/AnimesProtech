using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.WEBAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public JsonResult Success(object entity, int statusCode = 200)
        {
            var result = new JsonResult(entity);
            result.StatusCode = statusCode;

            return result;
        }

        [NonAction]
        public JsonResult Error(object entity, int statusCode = 500)
        {
            var result = new JsonResult(entity);
            result.StatusCode = statusCode;

            return result;
        }
    }
}
