using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Omniture.Shared.Validation
{
    public class UnprocessableEntityObjectResult : ObjectResult
    {
        public UnprocessableEntityObjectResult(ModelStateDictionary  modelstate )
            : base(new SerializableError(modelstate))
        {
            if (modelstate == null)
            {
                throw new ArgumentNullException(nameof(modelstate));
            }
            StatusCode = 422;
        }
    }
}
