using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Filters.Infrastructure
{
    public class DiagnosticsFilter : IAsyncResultFilter
    {
        private IFilterDiagnostics diagnostics;
        public DiagnosticsFilter(IFilterDiagnostics diag)
        {
            diagnostics = diag;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            foreach(string msg in diagnostics.Messages)
            {
                byte[] bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
                await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
