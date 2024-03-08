using System;
using System.Collections.Generic;
using System.Linq;



namespace Assignment2
{
    class Program
    {
        public static void Main(string[] args)
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

}