using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ViewResultDiagnostics : IActionFilter
    {
        private IFilterDiagnostics _filterDiagnostics;
        public ViewResultDiagnostics(IFilterDiagnostics filter)
        {
            _filterDiagnostics = filter;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ViewResult vr;
            if((vr = context.Result as ViewResult) != null)
            {
                _filterDiagnostics.AddMessage($"View name: {vr.ViewName}");
                _filterDiagnostics.AddMessage($@"Model type: {vr.ViewData.Model.GetType().Name}");
            }
        }
    }
}
