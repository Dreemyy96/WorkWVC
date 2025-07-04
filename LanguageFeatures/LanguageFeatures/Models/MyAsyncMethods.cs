namespace LanguageFeatures.Models
{
	public class MyAsyncMethods
	{
		public static async Task<long?> GetPageLengthAsync()
		{
			HttpClient client = new HttpClient();
			var httpTask = await client.GetAsync("http://apress.com");
			return httpTask.Content.Headers.ContentLength;
		}
	}
}
