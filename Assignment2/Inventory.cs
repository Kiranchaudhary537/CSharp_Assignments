
namespace Assignment2
{
    class Inventory
    {
        private List<Product> products;

        public Inventory()
        {
            products = new List<Product>();
        }

        //method to add products
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        //print total product count
        public void PrintTotalProducts()
        {
            Console.WriteLine($"Total number of products: {products.Count}");
        }

        //print all products
        public void PrintAllProducts()
        {
            Console.WriteLine("List of all products:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            PrintTotalProducts();
            Console.WriteLine();
        }


        public void PrintProductsByType(string type)
        {
            foreach (var product in products)
            {
                if (product.Type == type)
                {
                    Console.WriteLine(product);
                }
            }
            Console.WriteLine();
        }

        public void RemoveProduct(string name)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name == name)
                {
                    products.RemoveAt(i);
                    break;
                }
            }
            PrintTotalProducts();
            Console.WriteLine();
        }

        public void UpdateProductQuantity(string name, int quantity)
        {
            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    product.Quantity += quantity;
                    Console.WriteLine(product);
                }
            }
            Console.WriteLine();
        }

        public double getPriceOfItem(string name)
        {
            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    return product.Price;
                }
            }
            return 0;
        }

        public double CalculateTotalPrice(List<(string, int)> itemsList)
        {
            double total = 0;
            foreach (var item in itemsList)
            {
                total += item.Item2 * getPriceOfItem(item.Item1);
            }

            return total;
        }
    }

}