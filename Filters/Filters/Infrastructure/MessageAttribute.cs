using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Filters.Infrastructure
{
    public class MessageAttribute : ResultFilterAttribute
    {
        private string message;
        public MessageAttribute(string msg)
        {
            message = msg;
        }
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await PrintMessageAsync(context, $"<div>Before result:{message}</div>");
            await next();
            await PrintMessageAsync(context, $"<div>After result:{message}</div>");
        }
        private async Task PrintMessageAsync(FilterContext context, string msg)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
