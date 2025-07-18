
namespace Cities.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly List<City> _cityList = new List<City>()
        {
            new City { Name = "London", Country = "UK", Population = 8539000},
            new City { Name = "New York", Country = "USA", Population = 8406000 },
            new City { Name = "San Jose", Country = "USA", Population = 998537 },
            new City { Name = "Paris", Country = "France", Population = 2244000 }
        };

        public IEnumerable<City> Cities => _cityList;

        public void AddCity(City city)
        {
            _cityList.Add(city);
        }
    }
}
