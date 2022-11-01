// See https://aka.ms/new-console-template for more information
#nullable disable
using System.Text.Json;
using ConsoleApp;
Console.Clear();

string currentLocation = Directory.GetCurrentDirectory();
Random rnd = new Random();
List<> contacts = new List<Contact>();

// check for json
string jsonCurrentPath = @$"{currentLocation}/data.json";
bool jsonExists = File.Exists(jsonCurrentPath);

if (jsonExists)
{
    string jsonStringFromFile = File.ReadAllText(jsonCurrentPath);
    contacts = JsonSerializer.Deserialize<List<Contact>>(jsonStringFromFile);
}
else
{
    contacts.Clear();
    File.WriteAllText(jsonCurrentPath, jsonString);
}

// actual program
bool loop = true;
while (loop)
{
    string userName = "bob the builder";
    Console.Clear();
    Console.WriteLine($"MAIN MENU ({userName})");
    Console.WriteLine("    1. Display All Data");
    Console.WriteLine("    2. Search/Filter for a Product"); 
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
        for (int i = 0; i < contacts.Count(); i++)
        {
            contacts[i].writeAllInfo();
        }
    }
    if (mainMenuChoice == 2)
    {
        Console.WriteLine("SEARCH FOR CONTACTS");
        Console.Write("Enter a Vaild Name: ");
        string searchName = Console.ReadLine();
        for (int i = 0; i < contacts.Count(); i++)
        {
            if (contacts[i].Name.ToLower() == searchName.ToLower())
            {
                Console.WriteLine("------------");
                Console.WriteLine(
                    $"Name: {contacts[i].Name} \nEmail: {contacts[i].Email} \nPhone Number: {contacts[i].PhoneNumber}"
                );
            }
        }
    }
    if (mainMenuChoice == 3)
    {
        Console.WriteLine("EDIT CONTACT");
        Console.Write("Enter a Vaild Name: ");
        string searchName = Console.ReadLine();

        for (int i = 0; i < contacts.Count(); i++)
        {
            if (contacts[i].Name.ToLower() == searchName.ToLower())
            {
                Console.WriteLine("------------\n press enter to not edit info \n------------");
                Console.Write("Edit Name: ");
                string newName = Console.ReadLine();
                if (newName != "")
                {
                    contacts[i].Name = newName;
                }
                Console.Write("Edit Email: ");
                string newEmail = Console.ReadLine();
                if (newEmail != "")
                {
                    contacts[i].Email = newEmail;
                }
                Console.Write("Edit Phone Number: ");
                string newPhoneNumber = Console.ReadLine();
                if (newPhoneNumber != "")
                {
                    contacts[i].PhoneNumber = newPhoneNumber;
                }
            }
        }
    }
    if (mainMenuChoice == 4)
    {
        Console.WriteLine("NEW CONTACT");
        Console.WriteLine("------------");
        Console.Write("New Name: ");
        string newName = Console.ReadLine();

        Console.Write("New Email: ");
        string newEmail = Console.ReadLine();

        Console.Write("New Phone Number: ");
        string newPhoneNumber = Console.ReadLine();

        contacts.Add(new Contact(newName, newEmail, newPhoneNumber));
    }
    if (mainMenuChoice == 5)
    {
        Console.WriteLine("REMOVE CONTACT");
        Console.Write("Enter a Vaild Name: ");
        string searchName = Console.ReadLine();
        for (int i = 0; i < contacts.Count(); i++)
        {
            if (contacts[i].Name.ToLower() == searchName.ToLower())
            {
                Console.WriteLine("------------");
                Console.WriteLine($"Name: {contacts[i].Name}\n ---- REMOVED ----");
                contacts.RemoveAt(i);
            }
        }
    }
    if (mainMenuChoice == 6)
    {
        Console.WriteLine("Save Data? Y - N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            string jsonString2 = JsonSerializer.Serialize(contacts);
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