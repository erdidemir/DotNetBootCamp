namespace PosIntegration.Exception
{
    public class PosException : System.Exception
    {
        public PosException(string message) : base(message)
        {
        }

        public PosException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}