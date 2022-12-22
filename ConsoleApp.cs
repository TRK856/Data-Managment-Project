namespace ConsoleApp
{
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
