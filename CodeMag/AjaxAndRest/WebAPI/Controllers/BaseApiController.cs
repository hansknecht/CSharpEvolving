using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers {
    public class BaseApiController : ControllerBase {
        protected IActionResult HandleException(
            Exception exception, string msg) {
            IActionResult ret;

            ret = StatusCode(StatusCodes.Status500InternalServerError, new Exception(msg));

            return ret;
        }
    }
}