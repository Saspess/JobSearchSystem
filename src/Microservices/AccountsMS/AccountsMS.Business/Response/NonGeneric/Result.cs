namespace AccountsMS.Business.Response.NonGeneric
{
    public class Result : ResultBase
    {
        public Result(bool isSuccess, Enum code, string customErrorMessage = null)
            : base(isSuccess, code, customErrorMessage) { }

        protected Result(bool isSuccess) : base(isSuccess) { }

        public static Result Successed()
        {
            return new Result(true);
        }

        public static Result Failed(Enum code, string customErrorMessage = null)
        {
            return new Result(false, code, customErrorMessage);
        }
    }
}
