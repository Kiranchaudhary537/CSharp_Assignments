using System;
using System.Collections.Generic;
using System.Linq;

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

class Program
{
    static void Main(string[] args)
    {
        var inventory = new Inventory();

        // Adding products to the inventory
        inventory.AddProduct(new Product("lettuce", 10.5, 50, "Leafy green"));
        inventory.AddProduct(new Product("cabbage", 20, 100, "Cruciferous"));
        inventory.AddProduct(new Product("pumpkin", 30, 30, "Marrow"));
        inventory.AddProduct(new Product("cauliflower", 10, 25, "Cruciferous"));
        inventory.AddProduct(new Product("zucchini", 20.5, 50, "Marrow"));
        inventory.AddProduct(new Product("yam", 30, 50, "Root"));
        inventory.AddProduct(new Product("spinach", 10, 100, "Leafy green"));
        inventory.AddProduct(new Product("broccoli", 20.2, 75, "Cruciferous"));
        inventory.AddProduct(new Product("garlic", 30, 20, "Leafy green"));
        inventory.AddProduct(new Product("silverbeet", 10, 50, "Marrow"));

        // Total number of products
        System.Console.WriteLine("\n Answer 1. ");
        inventory.PrintTotalProducts();

        // Add a new product
        System.Console.WriteLine("\n Answer 2. ");
        inventory.AddProduct(new Product("Potato", 10, 50, "Root"));
        inventory.PrintAllProducts();

        // Print products of type "Leafy green"
        System.Console.WriteLine("\n Answer 3. ");
        inventory.PrintProductsByType("Leafy green");

        // Remove Garlic from the list
        System.Console.WriteLine("\n Answer 4. ");
        inventory.RemoveProduct("garlic");

        // Update quantity of cabbage
        System.Console.WriteLine("\n Answer 5. ");
        inventory.UpdateProductQuantity("cabbage", 50);

        // Calculate total price for purchasing items
        System.Console.WriteLine("\n Answer 6. ");
        List<(string, int)> itemsList = new List<(string, int)>
        {
            ("lettuce", 1),
            ("zucchini", 2),
            ("broccoli", 1)
        };
        double totalPrice = inventory.CalculateTotalPrice(itemsList);
        Console.WriteLine($"Total price for purchasing items: {totalPrice} RS");

        Console.ReadLine();
    }
}
