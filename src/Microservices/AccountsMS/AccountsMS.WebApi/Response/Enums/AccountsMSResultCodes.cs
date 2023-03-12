using System.ComponentModel;

namespace AccountsMS.WebApi.Response.Enums
{
    public enum AccountsMSResultCodes
    {
        [Description("Successed result")]
        Successed = 1,

        [Description("Failure result")]
        Failed = 2
    }
}
