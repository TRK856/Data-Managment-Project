#nullable disable
namespace ConsoleApp
{
    public class Sort
    {
        static public void InsertionPrice(List<Product> aList)
        {
            for (int i = 1; i < aList.Count; i++)
            {
                int insertPos = i - 1;
                Product insertValue = aList[i];

                while (insertPos >= 0 && aList[insertPos].Price > insertValue.Price)
                {
                    aList[insertPos + 1] = aList[insertPos];
                    insertPos--;
                }

                aList[insertPos + 1] = insertValue;
            }
        }
        static public void InsertionReset(List<Product> aList)
        {
            for (int i = 1; i < aList.Count; i++)
            {
                int insertPos = i - 1;
                Product insertValue = aList[i];

                while (insertPos >= 0 && aList[insertPos].Id > insertValue.Id)
                {
                    aList[insertPos + 1] = aList[insertPos];
                    insertPos--;
                }

                aList[insertPos + 1] = insertValue;
            }
        }
    }
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public List<int> ShoppingCart { get; set; }
        public User(string Username, string Password, List<int> ShoppingCart)
        {
            this.Username = Username;
            this.Password = Password;
            this.ShoppingCart = ShoppingCart;
        }

        public static void Create(List<User> userList)
        {
            Console.Write("Username: "); string username = Console.ReadLine();
            Console.Write("Password: "); string password = Console.ReadLine();
            userList.Add(new User(username, password, new List<int>()));
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public Product(string Name, int Id, string Description, int Price, string Category)
        {
            this.Name = Name;
            this.Id = Id;
            this.Description = Description;
            this.Price = Price;
            this.Category = Category;
        }
    }
}
