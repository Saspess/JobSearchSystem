using System.ComponentModel;

namespace IdentityMS.WebApi.Response.Enums
{
    public enum IdentityMSResultCodes
    {
        [Description("Successed result")]
        Successed = 1,

        [Description("Failure result")]
        Failed = 2
    }
}
