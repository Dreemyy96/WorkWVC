using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private ConcurrentQueue<double> actionTimes = new ConcurrentQueue<double>();
        private ConcurrentQueue<double> resultTime = new ConcurrentQueue<double>();

        private IFilterDiagnostics diagnostics;
        public TimeFilter(IFilterDiagnostics diag)
        {
            diagnostics = diag;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            actionTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnostics.AddMessage($@"Action time:{timer.Elapsed.TotalMicroseconds} Average: {actionTimes.Average():F2}");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            diagnostics.AddMessage($@"Result time:{timer.Elapsed.TotalMicroseconds} Average: {actionTimes.Average():F2}");
        }
    }
}
