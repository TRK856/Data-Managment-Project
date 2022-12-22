// See https://aka.ms/new-console-template for more information
#nullable disable
using System.Text.Json;
using ConsoleApp;

Console.Clear();
Random rnd = new Random();
List<Product> products = new List<Product>();
bool loop;

// check for json
string currentLocation = Directory.GetCurrentDirectory();
string jsonCurrentPath = @$"{currentLocation}/products.json";
bool jsonExists = File.Exists(jsonCurrentPath);

if (jsonExists)
{
    string jsonStringFromFile = File.ReadAllText(jsonCurrentPath);
    products = JsonSerializer.Deserialize<List<Product>>(jsonStringFromFile);
}
else
{
    Environment.Exit(1);
}

// actual program
while (true)
{
    string userName = "bob the builder";
    Console.Clear();
    Console.WriteLine($"MAIN MENU ({userName})");
    Console.WriteLine("    1. Display All Data");
    Console.WriteLine("    2. Filter for Products Catagory");
    Console.WriteLine("    3. Sort Price");
    Console.WriteLine("    4. Shopping Cart");
    Console.WriteLine("    5. Checkout");
    Console.WriteLine("    6. Exit");
    Console.Write("-> ");
    int mainMenuChoice = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    if (mainMenuChoice == 1)
    {
        Console.WriteLine("DISPLAY ALL DATA");
        Console.WriteLine(File.ReadAllText(jsonCurrentPath));
    }
    if (mainMenuChoice == 2)
    {
        Console.WriteLine(
            "Filter for Product Catagory\nCatagories avilable are: Bedroom, Living Room, Bathroom;"
        );
        Console.Write("Filter for: ");
        for (int i = 0; i < products.Count(); i++) { }
    }
    if (mainMenuChoice == 6)
    {
        Console.WriteLine("Save Data? Y - N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            string jsonString2 = JsonSerializer.Serialize(products);
            File.WriteAllText(jsonCurrentPath, jsonString2);
        }
        break;
    }

    Console.WriteLine();

    Console.WriteLine("");
    Console.WriteLine("Back to Main Menu?");
    Console.Write("-> ");
    Console.ReadLine();
}
