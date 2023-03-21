using System.ComponentModel;

namespace AccountsMS.Business.Response.Enums
{
    public enum AccountsMSErrorCodes
    {
        [Description("Entity was not found")]
        EntityNotFound = 1,

        [Description("Argument is null")]
        NullArgument = 2
    }
}
