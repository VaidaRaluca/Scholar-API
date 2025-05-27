namespace Scholar.Api.Exceptions
{
    public class ResourceMissingException : Exception
    {
        public ResourceMissingException(string message) : base(message)
        {
        }
    }
}
