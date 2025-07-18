namespace Cities.Models
{
    public interface IRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City city);
    }
}
