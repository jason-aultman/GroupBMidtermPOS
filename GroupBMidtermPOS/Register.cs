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
        //C:\Users\bepol\Source\Repos\GroupBMidtermPOS\GroupBMidtermPOS\Inventory.csv
        private string filePath = FileHandler.currentDirectory + @"\Inventory.csv";
        public string ReceiptWriterPath { get; set; }
        public double TotalSales  { get; set; }
        public Register(string receiptWriterPath)
         {
            ReceiptWriterPath = receiptWriterPath;
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
        
        public double TakePaymentCash(double cashAmount, double totalOwed)
        {
            Console.WriteLine("Cash: ");
            var userAmountTendered = cashAmount;
            if (userAmountTendered < totalOwed)
            {
                double amountOwed = totalOwed - cashAmount;
                Console.WriteLine($"You still owe ${amountOwed:C}");
                var difference = amountOwed - userAmountTendered;
                TotalSales += userAmountTendered;
                return difference;
            }
            //go back to enter payment type screen if money is owed

            var changeDue = userAmountTendered - totalOwed;
            Console.WriteLine($"Change due: ${changeDue:C}");
            TotalSales += totalOwed;
            return changeDue;
            
        }
        public double TakePaymentCash(double totalOwed)
        {
            Console.WriteLine("Cash: ");
            Console.WriteLine("Please enter amount tendered: ");
            double userAmountTendered = double.Parse(Console.ReadLine()); 
            if (userAmountTendered < totalOwed)  
            {
                double amountOwed = userAmountTendered-totalOwed; 
                Console.WriteLine($"You still owe ${amountOwed:C}");
                FileHandler.Writereceipt("Receipt.txt", $"                                                 Owed   {totalOwed:C}",true);
                FileHandler.Writereceipt("Receipt.txt", $"Tendered-Cash:                                   Amount {userAmountTendered:C}",true);
                FileHandler.Writereceipt("Receipt.txt", $"Remaining Bal:                                   Amount {amountOwed:C}",true);
                return amountOwed;  
            }
            var changeDue = userAmountTendered - totalOwed;
            Console.WriteLine($"Change due: {changeDue:C}");
            FileHandler.Writereceipt("Receipt.txt", $"                                                     Owed   {totalOwed:C}",true);
            FileHandler.Writereceipt("Receipt.txt", $"Tendered-Cash:                                       Amount {userAmountTendered:C}",true);
            FileHandler.Writereceipt("Receipt.txt", $"Change Due:                                          Amount {changeDue:C}", true);
            return changeDue;
           
        }
        public double TakePaymentCash(List<KeyValuePair<Product, int>> shoppingCart)
        {
            Console.WriteLine("Cash: ");
            Console.WriteLine("Please enter amount tendered; ");
            double userAmountTendered = double.Parse(Console.ReadLine());
            if (userAmountTendered < GetGrandTotal(shoppingCart))
            {
                double amountOwed = GetGrandTotal(shoppingCart) - userAmountTendered;
                Console.WriteLine($"You still owe {amountOwed:C}");
                var difference = amountOwed - userAmountTendered;
                TotalSales += userAmountTendered;
                return difference;
                
            }
            //go back to enter payment type screen if money is owed
            
             var changeDue = userAmountTendered - GetGrandTotal(shoppingCart);
             Console.WriteLine($"Change due: {changeDue:C}");
             TotalSales += GetGrandTotal(shoppingCart);
             return changeDue;

        }
    

        public void TakePaymentCreditCard(double totalOwed)
        {//Menu.cs  Ask user for cc number, expiry date, and  cvv number 
            bool validatedUserInput;
            do
            {
            Console.WriteLine("Credit/Debit card: ");
            Console.WriteLine("Please enter your 12 digit credit card number: ");
            var userCardNumber = Console.ReadLine();
                validatedUserInput = (!(ValidatePayment.ValidateCreditCardAccountNumberIsLongEnough(userCardNumber) &&
                ValidatePayment.ValidateAcctNum(userCardNumber)));
                if (validatedUserInput)
                {
                    Console.WriteLine("Sorry, that number is not a valid credit card number.");
                    //TakePaymentCreditCard(totalOwed);

                }

            }

            while (validatedUserInput);
            bool validateUserExpiration;
            do
            {
                Console.WriteLine("Please enter your 4 digit expiration date (MMYY): ");
                var userExpirationDate = Console.ReadLine();
                validateUserExpiration = !(ValidatePayment.ValidateExpDate(userExpirationDate));
                if (validateUserExpiration)
                {
                    Console.WriteLine("Sorry, that number is not a valid expiration date (MMYY)");
                    //TakePaymentCreditCard(totalOwed);
                }
            }
            while (validateUserExpiration);
            bool cvvUserValidation;
            do
            {
                Console.WriteLine("Please enter your 3 digit CVV number: ");
                var userCvvNumber = Console.ReadLine();
                cvvUserValidation = !(ValidatePayment.ValidateCVV(userCvvNumber));
                if (cvvUserValidation)
                {
                    Console.WriteLine("Sorry, that number is not a valid CVV number.");
                    //TakePaymentCreditCard(totalOwed);
                }
            }
            while (cvvUserValidation);
            FileHandler.Writereceipt(ReceiptWriterPath, "Method of payment credit/debit card");

        }

        public void TakePaymentCheck(double totalOwed)
        {
            //Menu.cs Ask user for check number
            Console.WriteLine("Check: ");
            Console.WriteLine("Please enter your 4 digit check number: ");
            var userCheckNumber = Console.ReadLine();
            Console.WriteLine("Please enter your 9 digit routing number: ");
            var userRoutingNumber = Console.ReadLine();
            var userRoutingNumberValidation = (!(ValidatePayment.ValidateRoutingNum(userRoutingNumber)));
            Console.WriteLine("Please enter your checking 9 digit account number: ");
            var userCheckingAccountNumber = Console.ReadLine();
            var checkingAccountValidation = (!(ValidatePayment.ValidaCheckingAccountNum(userCheckingAccountNumber)));

            TotalSales += totalOwed;
        }

        //add this later
        public List<Product> ProductSearch(string searchString, List<Product> products)
        {
           
            var results = new List<Product>();
            results=products.FindAll(thing => thing.Description.Contains(searchString));
            
            return results;
        }
        
        public void Close()
        {
            listOfProducts = null;
            filePath = "";
            Product.NumberOfProducts = 0;

        }
        
        
    }
}