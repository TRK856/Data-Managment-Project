namespace ConsoleApp
{
    public class user
    {
        static public void newUser() { }
    }

    public class Product
    {
        public string Name;
        public int Id;
        public string Description;
        public int Price;
        public string Catagory;

        public Product(string name, int id, string description, int price, string category)
        {
            this.Name = name;
            this.Id = id;
            this.Description = description;
            this.Price = price;
            this.Catagory = category;
        }
    }

    public class Utility
    {
        static public void writeAll(int[] anArray)
        {
            Console.Write("[");
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                Console.Write($"{anArray[i]}, ");
            }
            Console.WriteLine($"{anArray[anArray.Length - 1]}]");
        }

        static public void writeAll(string[] anArray)
        {
            Console.Write("[");
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                Console.Write($"{anArray[i]}, ");
            }
            Console.WriteLine($"{anArray[anArray.Length - 1]}]");
        }

        static public void writeAll(List<Product> aList)
        {
            Console.Write("[{");
            for (int i = 0; i < aList.Count() - 1; i++)
            {
                Console.Write($"Name: {aList[i].Name}, ");
                Console.Write($"Id: {aList[i].Id}, ");
                Console.Write($"Description: {aList[i].Description}, ");
                Console.Write($"Price: {aList[i].Price}, ");
                Console.Write($"Catagory: {aList[i].Catagory}, ");
            }
            Console.WriteLine("}]");
        }

        static public void swap(int[] anArray, int pos1, int pos2)
        {
            int swap = anArray[pos1];
            anArray[pos1] = anArray[pos2];
            anArray[pos2] = swap;
        }

        static public void swap(string[] anArray, int pos1, int pos2)
        {
            string swap = anArray[pos1];
            anArray[pos1] = anArray[pos2];
            anArray[pos2] = swap;
        }
    }

    public class Algorithms
    {
        public static int linearSearch(string[] anArray, string item)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                if (anArray[i] == item)
                {
                    return i;
                }
            }

            // Went through for loop without finding item, so...
            return -1;
        }

        static public void insertion(int[] anArray)
        {
            for (int i = 1; i < anArray.Length; i++)
            {
                int insertPos = i;
                int insertValue = anArray[i];

                while (insertPos > 0 && anArray[insertPos - 1] > insertValue)
                {
                    anArray[insertPos] = anArray[insertPos - 1];
                    insertPos--;
                }

                anArray[insertPos] = insertValue;
            }
        }

        static public void insertion(string[] anArray)
        {
            for (int i = 1; i < anArray.Length; i++)
            {
                int insertPos = i;
                string insertValue = anArray[i];

                while (insertPos > 0 && String.Compare(anArray[insertPos - 1], insertValue) > 0)
                {
                    anArray[insertPos] = anArray[insertPos - 1];
                    insertPos--;
                }

                anArray[insertPos] = insertValue;
            }
        }
    }
}
