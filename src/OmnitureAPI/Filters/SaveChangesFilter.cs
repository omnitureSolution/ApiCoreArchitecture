using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Omniture.Db;

namespace SocietyCareAPI.Filters
{
    public class SaveChangesFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _uow;

        public SaveChangesFilter(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var result = await next();
            if (result.Exception == null || result.ExceptionHandled)
            {
                await _uow.SaveAsync();
            }
        }
    }
}
