namespace AccountsMS.Business.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() { }

        public AlreadyExistsException(string message) : base(message) { }
}
}
