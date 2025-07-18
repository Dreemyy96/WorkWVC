using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private readonly ICityRepository _repository;
        public CitySummary(ICityRepository rep)
        {
            _repository = rep;
        }

        //public string Invoke() => $"{_repository.Cities.Count()} cities, {_repository.Cities.Sum(p=>p.Population)} people";
        //public IViewComponentResult Invoke() => View(new CityViewModel() { Population = _repository.Cities.Sum(p => p.Population), Cities = _repository.Cities.Count() });
        //public IViewComponentResult Invoke() => Content("This is a <h3><i>string<i><h3>");
        //public IViewComponentResult Invoke() => new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string<i><h3>"));
        //public IViewComponentResult Invoke()
        //{
        //    string target = RouteData.Values["id"] as string;
        //    var cities = _repository.Cities.Where(city => target == null || string.Compare(city.Country, target, true) == 0);
        //    return View(new CityViewModel() { Cities = cities.Count(), Population = cities.Sum(c=>c.Population) });
        //}
        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", _repository.Cities);
            }
            else
            {
                return View(new CityViewModel { Cities = _repository.Cities.Count(), Population = _repository.Cities.Sum(c => c.Population) });
            }
        }

    }
}
