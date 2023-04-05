namespace IdentityMS.Business.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException() { }

        public ServiceNotFoundException(string message) : base(message) { }
    }
}
