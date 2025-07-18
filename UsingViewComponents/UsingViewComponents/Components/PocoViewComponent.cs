using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class PocoViewComponent 
    {
        private readonly ICityRepository _repository;
        public PocoViewComponent(ICityRepository rep)
        {
            _repository = rep;
        }
        public string Invoke() =>$"{_repository.Cities.Count()} cities, {_repository.Cities.Sum(c=>c.Population)} people";
    }
}
