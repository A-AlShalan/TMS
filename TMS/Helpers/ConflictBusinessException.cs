namespace TMS.Helpers
{
    public class ConflictBusinessException : Exception
    {
        public ConflictBusinessException(string message) : base(message)
        {
        }
    }
}