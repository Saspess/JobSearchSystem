using IdentityMS.Business.Exceptions;
using IdentityMS.Business.Response.Enums.EnumExtensions;

namespace IdentityMS.Business.Response
{
    public abstract class ResultBase
    {
        public bool IsSuccess { get; set; }
        internal Enum Code { get; set; }
        internal string CustomErrorMessage { get; set; }

        public Enum ErrorCode
        {
            get
            {
                if (IsSuccess)
                {
                    throw new ResultException("You attempted to access the ErrorCode property for a successful result. A successful result has no ErrorCode.");
                }

                return Code;
            }
        }

        public string ErrorMessage
        {
            get
            {
                if (IsSuccess)
                {
                    throw new ResultException("You attempted to access the ErrorMessage property for a successful result. A successful result has no ErrorMessage.");
                }

                return GetDescription();
            }
        }

        protected ResultBase(bool isSuccess, Enum code = null, string customErrorMessage = null)
        {
            Code = code;
            IsSuccess = isSuccess;
            CustomErrorMessage = customErrorMessage;
        }

        private string GetDescription()
        {
            if (!string.IsNullOrEmpty(CustomErrorMessage))
            {
                return ErrorCode.GetDescription() + ". " + CustomErrorMessage;
            }

            return ErrorCode.GetDescription();
        }
    }
}
