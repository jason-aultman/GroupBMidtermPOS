using System.Collections.Generic;

namespace GroupBMidtermPOS
{
    public class Register
    {
        public const double TAXRATE = .06;
        public double NumberOrdered { get; set; }
        List<Product> listOfProducts = new List<Product>();

        public List<Product> createTemporaryListOfProductsForDemoOnly(List<Product>listOfProducts)
        {
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