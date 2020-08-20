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
        public List<Product> CurrentOrder= new List<Product>();
        
         public Register()
         {
             listOfProducts = FileHandler.ReadInventoryData(@"GroupBMidtermPOS\Inventory.csv");
         }

        public List<Product> createTemporaryListOfProductsForDemoOnly()
        {
            
            return listOfProducts;

        }

        public double GetTotalSalesTax(List<Product> shoppingCart)
        {
            var subTotal = 0.0;
            foreach (var product in shoppingCart)
            {
                subTotal += product.Price;
            }
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
            //Menu.cs  Ask user for cc number, expiry date, and  cvv number 
        }

        public void TakePaymentCheck()
        {
            //Menu.cs Ask user for check number
        }
        
        
    }
}