using System.ComponentModel;

namespace IdentityMS.Business.Response.Enums
{
    public enum IdentityMSErrorCodes
    {
        [Description("Entity was not found")]
        EntityNotFound = 1,

        [Description("Argument is null")]
        NullArgument = 2,

        [Description("Login failed")]
        LoginFailed = 3,

        [Description("User already exists")]
        UserExists = 4
    }
}
