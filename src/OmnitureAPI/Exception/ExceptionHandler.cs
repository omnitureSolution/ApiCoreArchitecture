using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Serilog;
using VisionPlus.Shared.Common;
using VisionPlus.Shared.Validation;

namespace VisionPlusAPI.Exception
{
    public static class ExceptionHandler
    {
        public static System.Action<IApplicationBuilder> HttpExceptionHandling()
        {
            return options =>
            {
                options.Run(
                async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = context.Request.ContentType;
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex.Error.GetType() == typeof(ValidModelException))
                    {
                        var modelStateDic = new ModelStateDictionary();
                        modelStateDic.AddModelError("Message", ex.Error.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        UnprocessableEntityObjectResult(modelStateDic))).ConfigureAwait(false);
                    }
                    else
                    {
                        Log.Error(ex.Error, "Exception");
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            message = ex.Error?.Message
                        })).ConfigureAwait(false);
                    }
                });
            };
        }
    }

}
