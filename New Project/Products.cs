using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_Project
{
    internal class Products
    {
        string brand, model, category;
        decimal price;
        int quantity;


        ArrayList products;

        public Products()
        {
            products = new ArrayList();
        }

        public void AddNewProducts(string brand,
                                    string model,
                                    decimal price,
                                    int quantity,
                                    string category)
        {

            products.Add(new ArrayList() { brand, model, price, quantity, category });

        }

        public ArrayList GetProducts()
        {
            return products;
        }

        public void ShowAllProducts()
        {
            int counter = 1;
            foreach (ArrayList allproducts in products)
            {
                Console.WriteLine($"Product ID: {counter++}\n\n" +
                                    $"Category: {allproducts[4]},\n\n" +
                                    $"Brand: {allproducts[0]},\n" +
                                    $"Model: {allproducts[1]},\n" +
                                    $"Price: {allproducts[2]},\n" +
                                    $"Quantity: {allproducts[3]}\n\n\n");
            }
        }

        public void UpdateProduct(int indexOfProduct,
                                    string newBrand,
                                    string newModel,
                                    decimal newPrice,
                                    int newQuantity,
                                    string newCategory)
        {
            products[indexOfProduct - 1] = new ArrayList() { newBrand, newModel, newPrice, newQuantity, newCategory };
        }

        public void UpdatePropertyOfProduct(int indexOfProducts,
                                                int propertyID,
                                                string newProperty)
        {
            ArrayList product = (ArrayList)products[indexOfProducts - 1];

            var oldProperty = product[propertyID - 1];

            if (oldProperty is string)
            {
                product[propertyID - 1] = newProperty;

                Console.WriteLine($"\nProduct ID: {indexOfProducts}\n\n" +
                  $"Category: {product[4]},\n\n" +
                  $"Brand: {product[0]},\n" +
                  $"Model: {product[1]},\n" +
                  $"Price: {product[2]},\n" +
                  $"Quantity: {product[3]}\n\n\n");

                Console.WriteLine("Property updated succesfully!");

            }

            else if (oldProperty is decimal)
            {
                // Qiyməti yeniləyirik (decimal olmalıdır)
                if (decimal.TryParse(newProperty, out decimal newPrice))
                {
                    product[propertyID - 1] = newPrice;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid price format! Please, try again.");
                    Thread.Sleep(1000);
                    
                }

                Console.WriteLine($"Product ID: {indexOfProducts}\n\n" +
                                    $"Category: {product[4]},\n\n" +
                                    $"Brand: {product[0]},\n" +
                                    $"Model: {product[1]},\n" +
                                    $"Price: {product[2]},\n" +
                                    $"Quantity: {product[3]}\n\n\n");

                Console.WriteLine("Property updated succesfully!");
            }

            else if (oldProperty is int)
            {


                if (int.TryParse(newProperty, out int newQuantity))
                {
                    product[propertyID - 1] = newQuantity;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid quantity format! Please, try again.");
                    Thread.Sleep(1000);


                    Console.WriteLine($"Product ID: {indexOfProducts}\n\n" +
                                       $"Category: {product[4]},\n\n" +
                                       $"Brand: {product[0]},\n" +
                                       $"Model: {product[1]},\n" +
                                       $"Price: {product[2]},\n" +
                                       $"Quantity: {product[3]}\n\n\n");

                    Console.WriteLine("Property updated succesfully!");
                }
            }

            else
            {
                Console.WriteLine("Unknown Property!");
            }
        }

        public void SellProduct(int indexOfProduct)
        {
            products.RemoveAt(indexOfProduct - 1);
        }

        public void ShowTotalPrice()
        {
            int s = 0;
            foreach (ArrayList allproducts in products)
            {
                decimal Price = Convert.ToDecimal(allproducts[2]);

                decimal Quantity = Convert.ToDecimal(allproducts[3]);

                s = (int)(s + (Price * Quantity));

                
                
            }
            Console.WriteLine($"Total Price is: {s}");
        }

        public void ShowTotalQuantity()
        {
            int s = 0;
            foreach (ArrayList allproducts in products)
            {

                decimal Quantity = Convert.ToDecimal(allproducts[3]);

                s = (int)(s + Quantity);

            }
            Console.WriteLine($"Total Quantity is: {s}");
        }

        public void ShowTotalPriceByCategory(string Category)
        {
           

            int s = 0;
            for (int i = 0; i < products.Count; i++)
            {
                ArrayList category = (ArrayList)products[i];

                if(Category == category[4].ToString())
                {
                    
                    decimal price = Convert.ToDecimal(category[2]);

                    decimal quantity = Convert.ToDecimal(category[3]);

                    s = (int)(s + (price * quantity));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Note found");

                }
            }
           
            Console.WriteLine($"Total price for {Category} is: {s}");

        }

        public void ShowTotalQuantityByCategory(string Category)
        {
            int s = 0;
            for (int i = 0; i < products.Count; i++)
            {
                ArrayList category = (ArrayList)products[i];

                if (Category == category[4].ToString())
                {
                    decimal quantity = Convert.ToDecimal(category[3]);

                    s = (int)(s + quantity);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Note found");
   
                }
            }
            
            Console.WriteLine($"Total Quantity for {Category} is: {s}");
        }
    }


}


