
namespace Assignment2
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Product(string name, double price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name}, {Price} RS, {Quantity}, {Type}";
        }
    }
}