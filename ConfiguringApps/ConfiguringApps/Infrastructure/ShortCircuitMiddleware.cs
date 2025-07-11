namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate _next;
        public ShortCircuitMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if ((context.Items["EdgeBrowser"]) as bool? == true)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
