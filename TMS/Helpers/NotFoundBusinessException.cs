namespace TMS.Helpers
{
    public class NotFoundBusinessException : Exception
    {
        public NotFoundBusinessException(string message) : base(message)
        {

        }
    }
}