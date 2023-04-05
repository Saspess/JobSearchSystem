namespace IdentityMS.WebApi.Response.NonGeneric
{
    public class ActionResultBody
    {
        public Enum Code { get; set; }
        public string Description { get; set; }

        public ActionResultBody(Enum code = null, string description = null)
        {
            Code = code;
            Description = description;
        }
    }
}
