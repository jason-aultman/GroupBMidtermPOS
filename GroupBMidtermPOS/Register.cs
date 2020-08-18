using System.Collections.Generic;

namespace GroupBMidtermPOS
{
    public class Register
    {
        public const double Taxrate = .06;
        public double NumberOrdered { get; set; }
        public List<Product> listOfProducts = new List<Product>();

        public Register()
        {
            //Pull List<string> from FileHandler here
        }

        public List<Product> createTemporaryListOfProductsForDemoOnly()
        {
            listOfProducts.Add(new Product("productOne", "classOne", 1.00, "The first thing"));
            listOfProducts.Add(new Product("product two", "classTwo", 2.00, "The second thing"));
            listOfProducts.Add(new Product("product three", "classTwo", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product four", "classThee", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product five", "classFour", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product six", "classTwo", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product seven", "classOne", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product eight", "classFive", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product nine", "classTen", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product ten", "classSeven", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product eleven", "classTwo", 3.50,"the third thing"));
            listOfProducts.Add(new Product("product twelve", "classTwo", 3.50,"the third thing"));
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

        public void TakePaymentCreditCard()
        {
            //Menu.cs  Ask user  for cc number, expiry date, and  cvv number 
        }

        public void TakePaymentCheck()
        {
            //Menu.cs Ask user for  check number
        }
        
        
    }
}