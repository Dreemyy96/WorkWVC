using Microsoft.AspNetCore.Mvc;

namespace UsingViewComponents.Components
{
    public class PageSize : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = await client.GetAsync("http://apress.com");
            return View(responce.Content.Headers.ContentLength);
        }
    }
}
