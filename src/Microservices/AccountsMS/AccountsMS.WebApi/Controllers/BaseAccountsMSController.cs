using AccountsMS.Business.Response.Enums;
using AccountsMS.WebApi.Response.Enums;
using AccountsMS.WebApi.Response.Generic;
using AccountsMS.WebApi.Response.NonGeneric;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AccountsMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAccountsMSController : ControllerBase
    {
        [NonAction]
        public JssResult Succesed()
        {
            return new JssResult(HttpStatusCode.OK, AccountsMSResultCodes.Successed);
        }

        [NonAction]
        public JssResult<T> Succesed<T>(T value)
        {
            return new JssResult<T>(HttpStatusCode.OK, AccountsMSResultCodes.Successed, value);
        }

        [NonAction]
        public JssResult Failed(Enum code)
        {
            if (code is AccountsMSErrorCodes.EntityNotFound)
            {
                return new JssResult(HttpStatusCode.NotFound, code);
            }

            return new JssResult(HttpStatusCode.BadRequest, code);
        }

        [NonAction]
        public JssResult<T> Failed<T>(Enum code)
        {
            if (code is AccountsMSErrorCodes.EntityNotFound)
            {
                return new JssResult<T>(HttpStatusCode.NotFound, code);
            }

            return new JssResult<T>(HttpStatusCode.BadRequest, code);
        }
    }
}
