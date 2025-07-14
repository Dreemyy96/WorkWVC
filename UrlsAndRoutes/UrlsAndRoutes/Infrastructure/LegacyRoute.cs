using System.Text;

namespace UrlsAndRoutes.Infrastructure
{
	public class LegacyRoute : IRouter
	{
		private string[] _urls;
        private IRouter _mvcRoute;
        public LegacyRoute(IServiceProvider services, params string[] targetUrls)
        {
            _urls = targetUrls; 
            /*mvcRoute = services.GetRequiredService<MvcRouteHandler>();*/
        }
        public Task RouteAsync(RouteContext ctx)
        {
            string requestedUrl = ctx.HttpContext.Request.Path.Value.TrimEnd('/');
            if(_urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                ctx.Handler = async ctx =>
                {
                    HttpResponse responce = ctx.Response;
                    byte[] bytes = Encoding.ASCII.GetBytes($"URL:{requestedUrl}");
                    await responce.Body.WriteAsync(bytes, 0, bytes.Length);
                };
            }
            return Task.CompletedTask;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
