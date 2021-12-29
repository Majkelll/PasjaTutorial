using System;

namespace PasjaTutorial.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}