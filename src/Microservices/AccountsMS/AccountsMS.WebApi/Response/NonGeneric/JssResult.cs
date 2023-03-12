using AccountsMS.Business.Responce.Enums.EnumExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace AccountsMS.WebApi.Response.NonGeneric
{
    public class JssResult : IConvertToActionResult
    {
        private readonly ActionResultBody _resultBody;

        internal HttpStatusCode HttpStatusCode { get; set; }
        internal string Description { get; set; }
        internal Enum Code { get; set; }

        public JssResult(HttpStatusCode httpStatusCode, Enum code)
        {
            Code = code;
            Description = code.GetDescription();
            HttpStatusCode = httpStatusCode;
            _resultBody = new ActionResultBody(Code, Description);
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
