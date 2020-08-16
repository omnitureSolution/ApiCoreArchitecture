using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Omniture.Db;
using Omniture.Shared.Common;
using Omniture.Shared.WebClient;

namespace SocietyCareAPI.Filters
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private readonly IUnitOfWork _uow = null;

        public TransactionFilter(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Filters.Any(t => t.GetType() == typeof(TransactionRequiredAttribute)))
            {
                if (context.Exception == null && context.ModelState.IsValid)
                {
                    _uow.Commit();
                }
                else
                {
                    _uow.Rollback();
                }
            }
            CreateHistory();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.Filters.Any(t => t.GetType() == typeof(TransactionRequiredAttribute)))
                return;
            _uow.Begin();
        }

        private void CreateHistory()
        {
            var data = _uow.HistoryChangeList();
            if (data.Any())
            {
                //var dt = HttpAPIClient.Post($"http://localhost:51952/api/History", "", data.ToJsonString());
            }
        }
    }

    public class TransactionRequiredAttribute : ActionFilterAttribute
    {
        public TransactionRequiredAttribute()
        {
        }

    }
}
