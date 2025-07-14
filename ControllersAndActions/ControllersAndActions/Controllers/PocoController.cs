using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ControllersAndActions.Controllers
{
	public class PocoController
	{
		[ControllerContext]
        public ControllerContext ControllerContext { get; set; }
        public IActionResult Index()
		{
			return new ViewResult(){
				ViewName = "Result",
				ViewData = new ViewDataDictionary( new EmptyModelMetadataProvider(), new ModelStateDictionary()) 
					{ Model = $"This is a POCO controller"}
			};
		}
		public IActionResult Headers()
		{
			return new ViewResult()
			{
				ViewName = "DictionaryResult",
				ViewData = new ViewDataDictionary(
					new EmptyModelMetadataProvider(),
					new ModelStateDictionary())
				{
					Model = ControllerContext.HttpContext.Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
				}
			};
		}
	}
}
