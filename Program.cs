// See https://aka.ms/new-console-template for more information
#nullable disable
using System;
using System.Text.Json;
using System.Collections.Generic;
using ConsoleApp;

Console.Clear();
Random rnd = new Random();
List<Product> products = new List<Product>();
User userInfo;

// JSON stuff
string currentLocation = Directory.GetCurrentDirectory();
JsonSerializerOptions options = new JsonSerializerOptions
{
    WriteIndented = true
};

// products JSON check
string productsJsonCurrentPath = @$"{currentLocation}/products.json";

if (File.Exists(productsJsonCurrentPath))
{
    products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(productsJsonCurrentPath));
}
else
{
    Environment.Exit(1);
}

// Create an Account if user doesn't exist
string userJsonCurrentPath = @$"{currentLocation}/user.json";

if (File.Exists(userJsonCurrentPath))
{
    userInfo = JsonSerializer.Deserialize<User>(File.ReadAllText(userJsonCurrentPath));
}
else
{
    Console.WriteLine("NO USER DATA FOUND...SIGN UP");
    Console.Write("Username: "); string username = Console.ReadLine();
    userInfo = new User(username, new List<int>());
}

// actual program
while (true)
{
    Console.Clear();
    Console.WriteLine($"MAIN MENU ({userInfo.Username})");
    Console.WriteLine("    1. Display All Data");
    Console.WriteLine("    2. Filter by Catagory");
    Console.WriteLine("    3. Sort by Price");
    Console.WriteLine("    4. Add to Shopping Cart");
    Console.WriteLine("    5. Remove from Shopping Cart");
    Console.WriteLine("    6. View Shopping Cart");
    Console.WriteLine("    7. Exit");
    Console.Write("-> ");
    int mainMenuChoice = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    if (mainMenuChoice == 1)
    {
        Console.WriteLine("DISPLAY ALL DATA");
        Console.WriteLine(File.ReadAllText(productsJsonCurrentPath));
    }
    if (mainMenuChoice == 2)
    {
        Console.WriteLine(
            "FILTER FOR PRODUCT CATAGORIES\nCatagories avilable are: Bedroom, Living Room, Bathroom;"
        );
        Console.Write("-------\nFilter for: "); string category = Console.ReadLine(); Console.WriteLine("-------");
        for (int i = 0; i < products.Count(); i++)
        {
            if (products[i].Category.ToLower() == category.ToLower())
            {
                Console.WriteLine($"Name: {products[i].Name} \nId: {products[i].Id} \nDescription: {products[i].Description} \nPrice: {products[i].Price} \n------");
            }
        }
    }
    if (mainMenuChoice == 3)
    {
        Console.WriteLine("SORT BY PRICE");
        Sort.InsertionPrice(products);
        File.WriteAllText(productsJsonCurrentPath, JsonSerializer.Serialize(products, options));
        Console.WriteLine(File.ReadAllText(productsJsonCurrentPath));
        Sort.InsertionReset(products);
        File.WriteAllText(productsJsonCurrentPath, JsonSerializer.Serialize(products, options));
    }
    if (mainMenuChoice == 4)
    {
        Console.WriteLine("ADD TO SHOPPING CART");
        Console.Write("Product to Add (name or id): ");
        string shoppingCartAdd = Console.ReadLine();
        int shoppingCartLen = userInfo.ShoppingCart.Count;
        try
        {
            int result = int.Parse(shoppingCartAdd);
            int largest = 0;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id > largest)
                {
                    largest = products[i].Id;
                }
            }
            if (result <= largest)
            {
                userInfo.ShoppingCart.Add(result);
            }
        }
        catch (FormatException)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.ToLower() == shoppingCartAdd.ToLower())
                {
                    userInfo.ShoppingCart.Add(products[i].Id);
                }
            }
        }
        if (shoppingCartLen < userInfo.ShoppingCart.Count)
        {
            Console.WriteLine("SUCESS! Added to Cart");
        }
        else
        {
            Console.WriteLine("ERROR! Invalid Input");
        }
    }
    if (mainMenuChoice == 5)
    {
        Console.WriteLine("REMOVE TO SHOPPING CART");
        Console.Write("Product to Remove (name or id): ");
        string shoppingCartRemove = Console.ReadLine();
        int shoppingCartLen = userInfo.ShoppingCart.Count;
        try
        {
            if (userInfo.ShoppingCart.Contains(int.Parse(shoppingCartRemove)))
            {
                userInfo.ShoppingCart.Remove(int.Parse(shoppingCartRemove));
            }
        }
        catch (FormatException)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.ToLower() == shoppingCartRemove.ToLower())
                {
                    userInfo.ShoppingCart.Remove(products[i].Id);
                }
            }
        }
        if (shoppingCartLen > userInfo.ShoppingCart.Count)
        {
            Console.WriteLine("SUCESS! Removed from Cart");
        }
        else
        {
            Console.WriteLine("ERROR! Invalid Input");
        }
    }
    if (mainMenuChoice == 6)
    {
        Console.WriteLine("ALL ITEMS IN SHOPPING CART\n");
        Console.WriteLine("Your Cart: ");

        Dictionary<int, int> quantity = new Dictionary<int, int>();
        foreach (int numbers in userInfo.ShoppingCart)
        {
            if (quantity.ContainsKey(numbers))
            {
                quantity[numbers]++;
            }
            else
            {
                quantity[numbers] = 1;
            }
        }

        for (int i = 0; i < quantity.Count; i++)
        {
            for (int f = 0; f < products.Count; f++)
            {
                if (products[f].Id == quantity.ElementAt(i).Key)
                {
                    Console.WriteLine($"-----\n|{products[f].Category} Product| {products[f].Name}   Qty. {quantity.ElementAt(i).Value}   ${products[f].Price}\n{products[f].Description}");
                }
            }
        }
    }
    if (mainMenuChoice == 7)
    {
        File.WriteAllText(userJsonCurrentPath, JsonSerializer.Serialize(userInfo, options));
        Console.WriteLine("Thank you for using our product {0}! Bye!", userInfo.Username);
        break;
    }

    Console.WriteLine("");
    Console.WriteLine("Back to Main Menu?");
    Console.Write("-> ");
    Console.ReadLine();
}
