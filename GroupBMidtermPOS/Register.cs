using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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
        public double GetGrandTotal (List<KeyValuePair<Product,int>> shoppingCart)
        {
            var beforeTax = GetSubtotal(shoppingCart);
            var calcTax = GetTotalSalesTax(beforeTax);
            return beforeTax + calcTax;
        }

        public double GetSubtotal(List<Product> shoppingCart)
        {
            var subTotal = 0.0;
            foreach (var product in shoppingCart)
            {
                subTotal += product.Price;
            }

            return subTotal;
        }
        public double GetSubtotal(KeyValuePair<Product, int> keyValuePair)
        {
            var subTotal = 0.0;
            subTotal = keyValuePair.Key.Price * keyValuePair.Value;
            return subTotal;
        }
        public double GetSubtotal(List<KeyValuePair<Product, int>> shoppingCart)
        {
            var subTotal = 0.0;
            foreach (var product in shoppingCart)
            {
                subTotal += product.Key.Price * product.Value;
            }

            return subTotal;
        }
        public double GetTotalSalesTax(double subTotal)
        {
            return subTotal * Taxrate;
        }

        public double GetTotalSalesTax(List<Product> shoppingCart)
        {
            var subTotal = 0.0;
            foreach (var products in shoppingCart)
            {
                subTotal += products.Price;
            }

            var totalTax = Taxrate * subTotal;
            return totalTax;
        }

        public double GetTotalWithSalesTax(List<KeyValuePair<Product,int>> shoppingCart)
        {
            var subtotal = GetSubtotal(shoppingCart);
            var tax = GetTotalSalesTax(subtotal);
            return subtotal+tax;
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

        //add this later
        public List<Product> ProductSearch(string searchString, List<Product> products)
        {
            var results = new List<Product>();
            results=products.FindAll(thing => thing.Description.Contains(searchString));
            
            return results;
        }
        
        
        
        
    }
}