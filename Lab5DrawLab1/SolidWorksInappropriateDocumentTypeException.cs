using System;

namespace Lab5DrawLab1
{
    public class SolidWorksInappropriateDocumentTypeException : Exception
    {
        public SolidWorksInappropriateDocumentTypeException() : base("Inappropriate document type")
        {
        }

        public SolidWorksInappropriateDocumentTypeException(string message) : base(message)
        {
        }
    }
}
