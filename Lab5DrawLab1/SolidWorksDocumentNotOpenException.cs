using System;

namespace Lab5DrawLab1
{
    public class SolidWorksDocumentNotOpenException : Exception
    {
        public SolidWorksDocumentNotOpenException() : base("The document was not open")
        {
        }

        public SolidWorksDocumentNotOpenException(string message) : base(message)
        {
        }
    }
}
