using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Serilog;
using Omniture.Shared.Common;
using Omniture.Shared.Validation;


namespace Omniture.Shared.Configuration.Exception
{
    public static class ExceptionHandler
    {
        public static System.Action<IApplicationBuilder> HttpExceptionHandling(IWebHostEnvironment env)
        {
            return options =>
            {
                options.Run(
                async context =>
                {

                    context.Response.ContentType = context.Request.ContentType;
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex.Error.GetType() == typeof(ValidModelException))
                    {
                        var MaintanancetateDic = new ModelStateDictionary();
                        MaintanancetateDic.AddModelError("Message", ex.Error.Message);
                        context.Response.StatusCode = 422;
                        context.Response.ContentType= "application/json"; 
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        UnprocessableEntityObjectResult(MaintanancetateDic))).ConfigureAwait(false);
                    }
                    else
                    {
                        if (ex.Error.GetType() == typeof(ModelNotFoundException))
                            context.Response.StatusCode = 422;
                        else
                        {
                            Log.Error(ex.Error, "Exception");
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            message = env.EnvironmentName=="Development" ? ex.Error?.Message : "Error Processing your request, please retry after sometime"
                        })).ConfigureAwait(false);
                    }
                });
            };
        }
    }

}
