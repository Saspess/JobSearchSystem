using IdentityMS.WebApi.Response.NonGeneric;

namespace IdentityMS.WebApi.Response.Generic
{
    public class ActionResultBody<T> : ActionResultBody
    {
        public T Value { get; set; }

        public ActionResultBody(Enum code = null, string description = null, T value = default(T)) : base(code, description)
        {
            Value = value;
        }
    }
}
