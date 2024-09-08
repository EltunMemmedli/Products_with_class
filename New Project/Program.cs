using New_Project;
using System.Collections;
using System.Diagnostics.Metrics;

Products Product = new Products();

Product.AddNewProducts("Apple", "Macbook Pro", 3000, 20, "Notebook");
Product.AddNewProducts("Apple", "Iphone 15 Pro", 3500, 20, "Phone");
Product.AddNewProducts("Asus", "Vivabook", 2000, 50, "Notebook");
Product.AddNewProducts("Samsung", "S24 Ultra", 4000, 30, "Phone");

Start:
Console.WriteLine($"Welcome!\n\n" +
                    $"Select the option:\n\n" +
                    $"1.Show all products,\n" +
                    $"2.Add new products,\n" +
                    $"3.Update product,\n" +
                    $"4.Update property of product,\n" +
                    $"5.Sell products,\n" +
                    $"6.Show total price,\n" +
                    $"7.Show total quantity,\n" +
                    $"8.Show total price by category,\n" +
                    $"9.Show total quantity by category\n" +
                    $"====================================");

string input = Console.ReadLine();
int Secim;

if(int.TryParse(input, out Secim) && Secim > 0 && Secim <= 9)
{

    if(Secim == 1)
    {
        Console.Clear();
        Product.ShowAllProducts();
     
        Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }

    }

    else if(Secim == 2)
    {
        Console.Clear();

        Console.Write("Write new brand: ");
        string brand = Console.ReadLine();
        Console.Clear();

        Console.Write("Write new model: ");
        string model = Console.ReadLine();
        Console.Clear();

        price:
        Console.Write("Write new price: ");
        string Price = Console.ReadLine();
        decimal price;

        if(decimal.TryParse(Price, out price) && price > 0 )
        {
            Console.Clear();
            quantity:
            Console.Write("Write new quantity: ");
            string Quantity = Console.ReadLine();
            int quantity;

            if(int.TryParse(Quantity, out quantity) && quantity > 0)
            {
                Console.Clear();
                Console.Write("Write new category: ");
                string category = Console.ReadLine();
                Console.Clear();


                Product.AddNewProducts(brand, model, price, quantity, category);
                Console.Clear();


                ArrayList products = Product.GetProducts();

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
                Kec:
                Thread.Sleep(1000);
                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                string Kec = Console.ReadLine().ToLower();

                if (Kec == "f".ToLower())
                {
                    Console.Clear();
                    goto Start;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press the right button!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Kec;
                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Text! Please, try again.");
                Thread.Sleep(1000);
                Console.Clear();
                goto quantity;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Text! Please, try again.");
            Thread.Sleep(1000);
            Console.Clear();
            goto price;
        }
    }

    else if(Secim == 3)
    {
        Console.Clear();

    index:
        Product.ShowAllProducts();

        Console.Write("\nWrite the ID of product: ");
        string Index = Console.ReadLine();
        int index;

        ArrayList products = Product.GetProducts();

        int a = 0;
        for (int i = 0; i < products.Count; i++)
        {
            a = i;
        }      
        if (int.TryParse(Index, out index) && index >= 0 && index <= a+1)
        {
            Console.Clear();
            Console.Write("Write the new Brand: ");
            string newBrand = Console.ReadLine();
            Console.Clear();


            Console.Write("Write the new Model: ");
            string newModel = Console.ReadLine();
            Console.Clear();


        newPrice:
            Console.Write("Write the new Price: ");
            string Price = Console.ReadLine();
            int newPrice;

            if (int.TryParse(Price, out newPrice) && newPrice >= 0)
            {
                Console.Clear();
            newQuantity:
                Console.Write("Write the new Quantity: ");
                string Quantity = Console.ReadLine();
                int newQuantity;

                if(int.TryParse(Quantity, out newQuantity) && newQuantity >= 0)
                {
                    Console.Clear();
                    Console.Write("Write the new Category: ");
                    string newCategory = Console.ReadLine();

                    Product.UpdateProduct(index,
                                        newBrand,
                                        newModel,
                                        newPrice,
                                        newQuantity,
                                        newCategory);

                    Console.Clear();
                    Console.WriteLine("Product updated succesfully!");

                Kec:
                    Thread.Sleep(1000);
                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                    string Kec = Console.ReadLine().ToLower();

                    if (Kec == "f".ToLower())
                    {
                        Console.Clear();
                        goto Start;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Press the right button!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto Kec;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid text! Please, try again.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto newQuantity;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid text! Please, try again.");
                Thread.Sleep(1000);
                Console.Clear();
                goto newPrice;
            }

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid text! Please, try again.");
            Thread.Sleep(1000);
            Console.Clear();
            goto index;
        }
    }

    else if(Secim == 4)
    {
    Update:
        Console.Clear();
        Product.ShowAllProducts();
        ArrayList products = Product.GetProducts();

        int a = products.Count;

   


        Console.Write("\nWrite the ID of the product: ");
        string IndexOfProducts = Console.ReadLine();
        int indexOfProducts;



        if (int.TryParse(IndexOfProducts, out indexOfProducts) &&
                                            indexOfProducts >= 0 &&
                                                indexOfProducts <= a)
        {
        NewPropety:
            Console.Clear();
            ArrayList product = (ArrayList)products[indexOfProducts - 1];

            Console.WriteLine($"Product ID: {indexOfProducts}\n\n" +
                                        $"Category: {product[4]},\n\n" +
                                        $"Brand: {product[0]},\n" +
                                        $"Model: {product[1]},\n" +
                                        $"Price: {product[2]},\n" +
                                        $"Quantity: {product[3]}\n\n\n");

        
            Console.Write("Write the ID of property: ");
            string PropertyID = Console.ReadLine();
            int propertyID;

            if (int.TryParse(PropertyID, out propertyID) && propertyID >= 0 && propertyID < 5)
            {
                newProperty:
                var oldProperty = product[propertyID - 1];
                Console.Clear();
                Console.Write("Write new property: ");
                string newProperty = Console.ReadLine();



                if (oldProperty is decimal)
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
                        goto newProperty;

                    }
                    
                    Console.WriteLine($"\nProduct ID: {indexOfProducts}\n\n" +
                                        $"Category: {product[4]},\n\n" +
                                        $"Brand: {product[0]},\n" +
                                        $"Model: {product[1]},\n" +
                                        $"Price: {product[2]},\n" +
                                        $"Quantity: {product[3]}\n\n\n");

                    Console.WriteLine("Property updated succesfully!");
                    Console.Clear();
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
                        goto newProperty;
                    }

                    Console.WriteLine($"\nProduct ID: {indexOfProducts}\n\n" +
                                           $"Category: {product[4]},\n\n" +
                                           $"Brand: {product[0]},\n" +
                                           $"Model: {product[1]},\n" +
                                           $"Price: {product[2]},\n" +
                                           $"Quantity: {product[3]}\n\n\n");

                    Console.WriteLine("Property updated succesfully!");
                }

                /*Console.Clear();*/
                Product.UpdatePropertyOfProduct(indexOfProducts, propertyID, newProperty);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid ID! Please, try again.");
                Thread.Sleep(1000);
                Console.Clear();
                goto NewPropety;
            }

            

           
            


        Kec:
            Thread.Sleep(1000);
            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
            string Kec = Console.ReadLine().ToLower();

            if (Kec == "f".ToLower())
            {
                Console.Clear();
                goto Start;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Press the right button!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Kec;
            }



        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid text! Please, try again.");
            Thread.Sleep(1000);
            Console.Clear();
            goto Update;
        }
    }

    else if(Secim == 5)
    {
        Removed:
        Console.Clear();
        Product.ShowAllProducts();  
        Console.Write("Write the ID of product: ");
        string Index = Console.ReadLine();
        int index;

        ArrayList products = Product.GetProducts();

        int a = products.Count;

        
        if (int.TryParse(Index, out index) && index >= 0 && index < a+1)
        {
            Product.SellProduct(index);
            Console.Clear();
            Console.WriteLine("\nProduct sold succesfully!");

            
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Select the right option!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Removed;
        }
        Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(Secim == 6)
    {
        Console.Clear();
        Product.ShowTotalPrice();

        Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(Secim == 7)
    {
        Console.Clear();
        Product.ShowTotalQuantity();

        Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(Secim == 8)
    {
        Console.Clear();
        Console.WriteLine("Write the category: ");
        string category = Console.ReadLine();

        Product.ShowTotalPriceByCategory(category);
        Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }
    }

    else if(Secim == 9)
    {
        Console.Clear();
        Console.WriteLine("Write the category: ");
        string category = Console.ReadLine();

        Product.ShowTotalQuantityByCategory(category);
    Kec:
        Thread.Sleep(1000);
        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
        string Kec = Console.ReadLine().ToLower();

        if (Kec == "f".ToLower())
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Press the right button!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Kec;
        }

    }
}
else
{
    Console.Clear();
    Console.WriteLine("Select the right option!");
    Thread.Sleep(1000);
    Console.Clear();
    goto Start;
};