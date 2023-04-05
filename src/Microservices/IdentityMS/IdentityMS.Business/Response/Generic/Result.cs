using IdentityMS.Business.Exceptions;
using IdentityMS.Business.Response.Enums.EnumExtensions;
using IdentityMS.Business.Response.NonGeneric;

namespace IdentityMS.Business.Response.Generic
{
    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!base.IsSuccess)
                {
                    throw new ResultException("You attempted to access the Value property for a failed result. A failed result has no Value YET. Code Description: " + base.ErrorCode.GetDescription());
                }

                return _value;
            }
        }

        protected Result(bool isSuccess, Enum code, string customErrorMessage = null)
            : base(isSuccess, code, customErrorMessage)
        {
            _value = default(T);
        }

        protected Result(bool isSuccess, T result) : base(isSuccess)
        {
            _value = result;
        }

        public static Result<T> Successed(T result)
        {
            return new Result<T>(true, result);
        }

        public static Result<T> Failed(Enum code, string customErrorMessage)
        {
            return new Result<T>(false, code, customErrorMessage);
        }
    }
}
