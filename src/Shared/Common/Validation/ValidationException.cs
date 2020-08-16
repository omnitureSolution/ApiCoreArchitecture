using System;

namespace Omniture.Shared.Common
{
    public class ValidModelException : Exception
    {
        public ValidModelException(string message)
            : base(message)
        {
        }

    }

    public class ModelNotFoundException : ValidModelException
    {
        public ModelNotFoundException(string message)
            : base(message)
        {
        }
    }
}
