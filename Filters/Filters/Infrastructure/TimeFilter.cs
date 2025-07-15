using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private Stopwatch timer;
        private IFilterDiagnostics diagnostics;
        public TimeFilter(IFilterDiagnostics diag)
        {
            diagnostics = diag;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            diagnostics.AddMessage($@"Action time:{timer.Elapsed.TotalMicroseconds}");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            diagnostics.AddMessage($@"Result time:{timer.Elapsed.TotalMicroseconds}");
        }
    }
}
