using IdentityMS.Business.Response.Enums;
using IdentityMS.WebApi.Response.Enums;
using IdentityMS.WebApi.Response.Generic;
using IdentityMS.WebApi.Response.NonGeneric;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IdentityMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseIdentityMSController : ControllerBase
    {
        [NonAction]
        public JssResult Succesed()
        {
            return new JssResult(HttpStatusCode.OK, IdentityMSResultCodes.Successed);
        }

        [NonAction]
        public JssResult<T> Succesed<T>(T value)
        {
            return new JssResult<T>(HttpStatusCode.OK, IdentityMSResultCodes.Successed, value);
        }

        [NonAction]
        public JssResult Failed(Enum code)
        {
            if (code is IdentityMSErrorCodes.EntityNotFound)
            {
                return new JssResult(HttpStatusCode.NotFound, code);
            }

            return new JssResult(HttpStatusCode.BadRequest, code);
        }

        [NonAction]
        public JssResult<T> Failed<T>(Enum code)
        {
            if (code is IdentityMSErrorCodes.EntityNotFound)
            {
                return new JssResult<T>(HttpStatusCode.NotFound, code);
            }

            return new JssResult<T>(HttpStatusCode.BadRequest, code);
        }
    }
}
