namespace ViewPagerEx.Models
{
    public class Product
    {
        string productId;
        string name;
        string description;
        double price;

        public string ProductId => productId;
        public string Name => name;
        public string Description => description + "\n";
        public double Price => price;

        public Product(string id, string na, string desc, double pr)
        {
            productId = id;
            name = na;
            description = desc;
            price = pr;
        }
    }
}
