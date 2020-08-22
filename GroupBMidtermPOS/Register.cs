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
        public List<Product> listOfProducts;
        public List<Product> CurrentOrder= new List<Product>();
        private string filePath = @"C:\Users\jason\source\repos\GroupBMidtermPOS\GroupBMidtermPOS\Inventory.csv";

        public Register()
         {
            listOfProducts = FileHandler.ReadInventoryData(filePath);
         }

        public double GetGrandTotal (List<KeyValuePair<Product,int>> shoppingCart)
        {
            var beforeTax = GetSubtotal(shoppingCart);
            var calcTax = Math.Round(GetTotalSalesTax(beforeTax), 2, MidpointRounding.AwayFromZero);
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
            return Math.Round(subTotal, 2, MidpointRounding.AwayFromZero);
        }
        public double GetSubtotal(List<KeyValuePair<Product, int>> shoppingCart)
        {
            var subTotal = 0.0;
            foreach (var product in shoppingCart)
            {
                subTotal += product.Key.Price * product.Value;
            }

            return Math.Round(subTotal, 2, MidpointRounding.AwayFromZero);
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
            return Math.Round(totalTax,2,MidpointRounding.AwayFromZero);
        }

        public double GetTotalWithSalesTax(List<KeyValuePair<Product,int>> shoppingCart)
        {
            var subtotal = GetSubtotal(shoppingCart);
            var tax = GetTotalSalesTax(subtotal);
            Math.Round(tax, 2, MidpointRounding.AwayFromZero);

            return subtotal +tax;
        }
        
        public double TakePaymentCash(double cashAmount, double saleAmount)
        {
            return cashAmount - saleAmount;
        }
        public double TakePaymentCash(List<KeyValuePair<Product, int>> shoppingCart)
        {
            Console.WriteLine("Cash: ");
            Console.WriteLine("Please enter amount tendered; ");
            double userAmountTendered = double.Parse(Console.ReadLine());
            if (userAmountTendered < GetGrandTotal(shoppingCart))
            {
                double amountOwed = GetGrandTotal(shoppingCart) - userAmountTendered;
                Console.WriteLine($"You still owe ${amountOwed}");
                return amountOwed - userAmountTendered;
            }
            //go back to enter payment type screen if money is owed
            
             var changeDue = userAmountTendered - GetGrandTotal(shoppingCart);
                Console.WriteLine($"Change due: ${changeDue}");
                return changeDue;

        }
    

        public void TakePaymentCreditCard()
        {
            //Menu.cs  Ask user for cc number, expiry date, and  cvv number 
            Console.WriteLine("Credit/Debit card: ");
            Console.WriteLine("Please your 12 digit credit card number: ");
            var userCardNumber = Console.ReadLine();
            Console.WriteLine("Please your 4 digit expiration date: ");
            var userExpirationDate = Console.ReadLine();
            Console.WriteLine("Please your 3 digit CVV number: ");
            var userCvvNumber = Console.ReadLine();
        }

        public void TakePaymentCheck()
        {
            //Menu.cs Ask user for check number
            Console.WriteLine("Check: ");
            Console.WriteLine("Please enter your check number: ");
            var userCheckNumber = Console.ReadLine();
            Console.WriteLine("Please enter your routing number: ");
            var userRoutingNumber = Console.ReadLine();
            Console.WriteLine("Please enter your checking account number: ");
            var userCheckingAccountNumber = Console.ReadLine();
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