using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class Product
    {
        public int ProductNumber { get; set; }
        public string Name { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

       
        public Product()
        {

        }

        public Product(int productNumber, string name, double price, string description)
        {
            Name = name;
            Description = description;
            Price = price;
            ProductNumber = productNumber;
        }
    }
}