namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate _next;
        public BrowserTypeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Items["EdgeBrowser"] = context.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("edge"));
            await _next.Invoke(context);
        }
    }
}
