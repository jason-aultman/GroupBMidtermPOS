using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class Product
    {
        public string ProductClass { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product()
        {
            
        }
        public Product(string name, string productClass, double price, string description)
        {
            Name = name;
            ProductClass = productClass;
            Description = description;
            Price = price;
        }
        
    }
    
}