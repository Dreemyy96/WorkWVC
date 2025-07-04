namespace WorkingWithVisualStudio.Models
{
    public interface IRepository
    {
        public IEnumerable<Product> Products { get; }
        void AddProducts(Product p);
    }
}
