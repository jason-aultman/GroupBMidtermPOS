using System;
using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class Register
    {
        public const double Taxrate = .06;
        public double NumberOrdered { get; set; }
        public List<Product> listOfProducts = new List<Product>();

        /*public Register()
        {
            listOfProducts = FileHandler.ReadInventoryData("/Inventory.csv");
        }*/

        public List<Product> createTemporaryListOfProductsForDemoOnly()
        {
            listOfProducts.Add(new Product(1, "classOne", 1.00, "The first thing"));
            listOfProducts.Add(new Product(2, "classTwo", 2.00, "The second thing"));
            listOfProducts.Add(new Product(3, "classTwo", 3.50,"the third thing"));
            listOfProducts.Add(new Product(4, "classThee", 3.50,"the third thing"));
            listOfProducts.Add(new Product(5, "classFour", 3.50,"the third thing"));
            listOfProducts.Add(new Product(6, "classTwo", 3.50,"the third thing"));
            listOfProducts.Add(new Product(7, "classOne", 3.50,"the third thing"));
            listOfProducts.Add(new Product(8, "classFive", 3.50,"the third thing"));
            listOfProducts.Add(new Product(9, "classTen", 3.50,"the third thing"));
            listOfProducts.Add(new Product(10, "classSeven", 3.50,"the third thing"));
            listOfProducts.Add(new Product(11, "classTwo", 3.50,"the third thing"));
            listOfProducts.Add(new Product(12, "classTwo", 3.50,"the third thing"));
            return listOfProducts;

        }

        public double GetTotalSalesTax(double subTotal)
        {
            return Math.Round((subTotal * Taxrate), 2, MidpointRounding.AwayFromZero);
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