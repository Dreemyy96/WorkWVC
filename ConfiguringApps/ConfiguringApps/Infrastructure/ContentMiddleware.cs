using System.Text;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate _requestDelegate;
        private UptimeService _uptime;

        public ContentMiddleware(RequestDelegate next, UptimeService uptime)
        {
            _requestDelegate = next;
            _uptime = uptime;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path.ToString().ToLower() == "/middleware")
            {
                await context.Response.WriteAsync("This is from the content middleware" + $"uptime: {_uptime.Uptime}ms", Encoding.UTF8);
            }
            else
            {
                await _requestDelegate.Invoke(context);
            }
        }
    }
}
