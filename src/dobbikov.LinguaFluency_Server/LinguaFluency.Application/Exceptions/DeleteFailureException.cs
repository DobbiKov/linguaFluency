using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Application.Exeptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
