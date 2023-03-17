using AccountsMS.WebApi.Response.NonGeneric;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace AccountsMS.WebApi.Response.Generic
{
    public class JssResult<T> : JssResult, IConvertToActionResult
    {
        private readonly ActionResultBody<T> _resultBody;

        public JssResult(HttpStatusCode httpStatusCode, Enum code = null, T value = default(T)) : base(httpStatusCode, code)
        {
            _resultBody = new ActionResultBody<T>(Code, Description, value);
        }

        public IActionResult Convert()
        {
            ObjectResult objectResult = new ObjectResult(_resultBody)
            {
                StatusCode = (int)HttpStatusCode
            };

            return objectResult;
        }
    }
}
