using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class Product
    {
        private static int NumberOfProducts { get; set; }
        public string Name { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int ProductNumber { get; set; }


        public Product()
        {
            NumberOfProducts++;
            ProductNumber = NumberOfProducts;

        }

        
        public Product(int productNumber, string name, string productCategory, double price, string description)
        {
            Name = name;
            ProductCategory = ProductCategoryEnum(productCategory);
            Description = description;
            Price = price;
            ProductNumber = productNumber;

        }

        public ProductCategoryEnum ProductCategoryEnum(string productCatagory)
        {
            if (productCatagory == "Plush Toys")
            {
                return GroupBMidtermPOS.ProductCategoryEnum.PlushToys;
            }
            else if (productCatagory == "Learning Tools")
            {
                return GroupBMidtermPOS.ProductCategoryEnum.LearningTools;
            }
            else if (productCatagory == "Dolls")
            {
                return GroupBMidtermPOS.ProductCategoryEnum.Dolls;
            }
            else if (productCatagory == "Accessories")
            {
                return (GroupBMidtermPOS.ProductCategoryEnum.Accessories);
            }
            else return GroupBMidtermPOS.ProductCategoryEnum.Games;
        }
    }
}