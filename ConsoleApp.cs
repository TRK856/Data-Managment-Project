namespace ConsoleApp {
    public class user {
        static public void newUser() {
            
        }
    }
    public class Product {
        public string Name; 
        public int Id; 
        public string Description; 
        public int Price; 
        public string Category; 
        public Product(string name, int id, string description, int price, string category) {
            this.Name = name;
            this.Id = id;
            this.Description = description;
            this.Price = price;
            this.Category = category;
            
        }
    }
}