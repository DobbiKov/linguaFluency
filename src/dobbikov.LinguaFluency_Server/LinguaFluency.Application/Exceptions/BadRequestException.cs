using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Application.Exeptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
