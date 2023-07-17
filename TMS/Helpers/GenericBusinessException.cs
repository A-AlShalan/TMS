namespace TMS.Helpers
{

public class GenericBusinessException : Exception
    {
        public GenericBusinessException(string message) : base(message)
        {
        }
    }
}