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
        public List<int> ShoppingCart { get; set; }
        public User(string Username, List<int> ShoppingCart)
        {
            this.Username = Username;
            this.ShoppingCart = ShoppingCart;
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
