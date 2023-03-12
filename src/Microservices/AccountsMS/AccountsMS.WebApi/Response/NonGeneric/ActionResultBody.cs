namespace AccountsMS.WebApi.Response.NonGeneric
{
    public class ActionResultBody
    {
        public Enum Code { get; set; }
        public string Description { get; set; }

        public ActionResultBody(Enum code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
