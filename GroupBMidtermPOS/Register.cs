using System.Collections.Generic;

namespace GroupBMidtermPOS
{
    public class Register
    {
        public const double Taxrate = .06;
        public double NumberOrdered { get; set; }
        public List<Product> listOfProducts = new List<Product>();

        public List<Product> createTemporaryListOfProductsForDemoOnly()
        {
            listOfProducts.Add(new Product("productOne", "classOne", 1.00, "The first thing"));
            listOfProducts.Add(new Product("product two", "classTwo", 2.00, "The second thing"));
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            listOfProducts.Add(new Product());
            return listOfProducts;

        }

        public double GetSubtotalNoTax()
        {
          //write subtotal work here
          return 0.0;
        }
        
        public double TakePaymentCash(double cashAmount, double saleAmount)
        {
            return cashAmount - saleAmount;
        }
        
        
        
    }
}