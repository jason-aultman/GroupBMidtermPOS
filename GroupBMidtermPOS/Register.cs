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
        public string filePath = FileHandler.currentDirectory + @"\Inventory.csv";
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

            return subtotal + tax;
        }
        public void TakePayment(PaymentTypeEnum paymentType, double amountDue, Register register, List<KeyValuePair<Product, int>> shoppingCart)  //Take payment from user, really should be in the register class probably, since that is pretty much what they are for
        {

            if (paymentType == PaymentTypeEnum.Cash)
            {
                var amountRemainingToPay = register.TakePaymentCash(amountDue);
                while (amountRemainingToPay < 0.00)
                {
                    paymentType = Menu.AskForPaymentMethodMenu();
                    amountRemainingToPay = Math.Round(Math.Abs(amountRemainingToPay), 2, MidpointRounding.AwayFromZero);
                    TakePayment(paymentType, amountRemainingToPay, register, shoppingCart);
                }
                //add call to receipt display method here
            }
            else if (paymentType == PaymentTypeEnum.Check)
            {
                register.TakePaymentCheck(amountDue);
                //Menu.DisplayOrderSummary(shoppingCart, register);
                //confirmation
            }
            else if (paymentType == PaymentTypeEnum.Credit_Card)
            {
                register.TakePaymentCreditCard(amountDue);
                //confirmation
            }
            else
            {
            }
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
            var grandTotalOwed = (totalOwed + (totalOwed * Taxrate));
            Console.WriteLine("Cash: ");
            Console.WriteLine("Please enter amount tendered: ");
            double userAmountTendered = double.Parse(Console.ReadLine()); 
            if (userAmountTendered < totalOwed)  
            {
                double amountOwed = userAmountTendered-totalOwed; 
                Console.WriteLine($"You still owe ${amountOwed:C}");
                //FileHandler.Writereceipt("Receipt.txt", $"                                                 Tax   {:C}", true);
                FileHandler.Writereceipt("Receipt.txt", $"                                                 Owed   {totalOwed:C}",true);

                FileHandler.Writereceipt("Receipt.txt", $"Tendered-Cash:                                   Amount {userAmountTendered:C}",true);
                FileHandler.Writereceipt("Receipt.txt", $"Remaining Bal:                                   Amount {amountOwed:C}",true);
                return amountOwed;  
            }
            var changeDue = userAmountTendered - totalOwed;
            Console.WriteLine($"Change due: {changeDue:C}");
            FileHandler.Writereceipt("Receipt.txt", $"                                                     Tax   {(Taxrate * totalOwed):C}", true);
            FileHandler.Writereceipt("Receipt.txt", $"                                                     Owed   {grandTotalOwed:C}",true);

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
            //to do receipt writer
        }

        public void TakePaymentCheck(double totalOwed)
        {
            //Menu.cs Ask user for check number
            Console.WriteLine("Check: ");
            Console.WriteLine("Please enter your 4 digit check number: ");
            var userCheckNumber = Console.ReadLine();
            bool userRoutingNumberValidation;
            do
            {
                Console.WriteLine("Please enter your 9 digit routing number: ");
                var userRoutingNumber = Console.ReadLine();
                userRoutingNumberValidation = (!(ValidatePayment.ValidateRoutingNum(userRoutingNumber)));
                if (userRoutingNumberValidation)
                {
                    Console.WriteLine("Incorrect routing number, please enter a valid 9 digit number");
                }
            } while (userRoutingNumberValidation);


            Console.WriteLine("Please enter your checking 9 digit account number: ");
            var userCheckingAccountNumber = Console.ReadLine();
            var checkingAccountValidation = (!(ValidatePayment.ValidaCheckingAccountNum(userCheckingAccountNumber)));
            
            FileHandler.Writereceipt(ReceiptWriterPath, $"Method of payment check: in the amount of {totalOwed}");


        }
        public void SearchForProduct(string descriptor, Register register) //performs a product search based on user input string
        {
            var results = register.ProductSearch(descriptor, register.listOfProducts);
            if (results.Count < 1)
            {
                Console.WriteLine("No products were found that match the search string.");
            }
            else
            {
                Menu.DisplayAllProducts(results);
            }

        }

        //add this later
        public List<Product> ProductSearch(string searchString, List<Product> products)
        {
           
            var results = new List<Product>();
            results=products.FindAll(thing => thing.Description.Contains(searchString));
            
            return results;
        }

        public void WriteToInventoryProductList (string filePath, string lineForEntryIntoFile)
        {
            var parsedLineForEntryIntoFile = lineForEntryIntoFile.Substring(1);
            parsedLineForEntryIntoFile = "\n" + parsedLineForEntryIntoFile;
            FileHandler.WriteFile(filePath, parsedLineForEntryIntoFile);
        }
        public Product GetProduct(List<Product> productList, int userChoice) //returns a product based on an index that the user selects...aka their choice.
        {
            if (userChoice == null)
            {
                return null;
            }
            Product choice = productList[userChoice];  //see above
            return choice;
        }


        public void Close()
        {
            listOfProducts = null;
            filePath = "";
            Product.NumberOfProducts = 0;

        }
        
        
    }
}