namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine cartObj = _lineCollection.Where(p=>p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (cartObj == null)
            {
                _lineCollection.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                cartObj.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(l=>l.Product.ProductId == product.ProductId);
        }
        public virtual decimal ComputeTotalValue()=>_lineCollection.Sum(e=>e.Product.Price *  e.Quantity);
        public virtual void Clear()=>_lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
            set { _lineCollection = value.ToList(); }
        }
    }
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
