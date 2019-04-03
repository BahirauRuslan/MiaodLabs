using System;

namespace Lab5DrawLab1
{
    public class SolidWorksNotRunningException : Exception
    {
        public SolidWorksNotRunningException() : base("Solidworks was not running")
        {
        }

        public SolidWorksNotRunningException(string message) : base(message)
        {
        }

        public SolidWorksNotRunningException(
            string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
