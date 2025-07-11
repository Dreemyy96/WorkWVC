using System.Text;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("Edge not suppoted", Encoding.UTF8);
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
}
