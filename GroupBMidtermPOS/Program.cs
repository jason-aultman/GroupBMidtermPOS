using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace GroupBMidtermPOS
{
    static class Program
    {
        static void Main(string[] args)
        {
            var shoppingCart = new List<KeyValuePair<Product, int>>();
            //initialize a "shopping cart" as a List of KeyValuePairs Key = Product Type, 
            //Value being an int representing the amount of  Products

            Register register = new Register();
            //open a new Register

            var clearConsole = false;  
            //a variable representing whether or not to clear the Console screen between screens

            string receiptWriterPath = "receipt.txt";  
            //The path file to send to FileHandler.ReceiptWriter() which is what will write to the reciept file
            
            DisplayHeader(); 
            //simple call to display the header on screen. ie Store name, possible welcome or address or telephone #, etc...

            do
            {
                var userItemNumber = GetItemNumberFromUser(register, clearConsole); 
                //requests an Item Number from the user, which sends in a register parameter and whether or not to clear the console.  False for the 1st run because we want the header to be displayed when the program is first run, but not necessarily any time after.
               
                var userItemQuantity = GetUserItemQuantity();  
                //ask the user for a quantity of whichever item was selected above.
                
                Printreceipt(receiptWriterPath);  
                //initialize the methodology for printing  a reciept.  "Prints" a header to a .txt file.

                var kvpUserSelection = new KeyValuePair<Product, int>(GetProduct(register.listOfProducts, userItemNumber), userItemQuantity); 
                //gets selected product # and quantity and makes a new KeyValuePair containing said info

                shoppingCart.Add(kvpUserSelection);  
                //adds previously made KeyValuePair to the users shopping cart
                
                clearConsole = DisplayTransactionDetails(shoppingCart, register, kvpUserSelection); 
                //displays transaction details for users selected items and quantity, showing price each  and subtotal

            } while (AskToContinueToShop());  
            //ask user  if they would like to continue to shop, if yes, goes back to the beginning of the do, if not, onto the next line.

            Menu.DisplayOrderSummary(shoppingCart, register); 
            //displays a summary of everything in the users shopping cart, including tax and grand total
          
            var payment = Menu.AskForPaymentMethodMenu();  //gets an enum for which type of payment will they be paying with, Cash, Credit, or Check
            TakePayment(payment, register.GetGrandTotal(shoppingCart), register);

            Console.WriteLine();
            Console.WriteLine("YOUR RECEIPT:");
            DisplayReceipt(receiptWriterPath);

            //take payment based on which method the  user chose above.
        }
        //END OF MAIN

        private static int GetItemNumberFromUser(Register register, bool clearConsole)
        {
            Console.WriteLine($"Menu: Choose an Item # or [: + search term] to search");  //ask user to choose an item number from the list
            Menu.DisplayMainMenu(register, clearConsole);  //displays the list of items in the register
            var userItemNumber = 0;
            do
            {
                var userItemAsString = Console.ReadLine();  //get users input as a string
                if (userItemAsString.StartsWith(":"))  //parses out user input, if it starts with a : then send the string to the search function instead
                {
                    SearchForProduct(userItemAsString.Substring(1), register);
                }
                else // otherwise, it must be a integer...try parsing it to an int, and hopefully  dont break anything...
                {
                    if (ValidateInput.GetIsInteger(userItemAsString))  //check, is it an integer??  yes?  
                    {
                        userItemNumber = int.Parse(userItemAsString) - 1;  //parse that to an integer then
                        //move to validation class?
                        break;  //no need to check anything else, leave the if statement
                    }
                    else
                    {
                        Console.WriteLine("Please input a valid integer.");  //otherwise, you done messed up sir, let them know.
                    }
                }

            } while (true);  //keep asking until they get really annoyed or they put in the correct input

            return userItemNumber;  //should never, ever get here, but the compiler seems to think I need to  return  something  just  in case.
        }

        public static bool AskToContinueToShop()  //Think we've done this a bazillion times in class, Continue?  Yes or no?
        {
            Console.WriteLine("Would you like to continue to shop? (Y/N)");
            var continueYesNo = Console.ReadLine().ToLower();
            if (ValidateInput.CheckYesNo(continueYesNo))//todo 
            {
                if (continueYesNo == "y")
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Please make a valid input");
                AskToContinueToShop();
            }

            return false;
        }
        
        static Product GetProduct(List<Product> productList, int userChoice) //returns a product based on an index that the user selects...aka their choice.
        {
            Product choice = productList[userChoice];  //see above
            return choice;
        }

        public static void TakePayment(PaymentTypeEnum paymentType, double amountDue, Register register)  //Take payment from user, really should be in the register class probably, since that is pretty much what they are for
        {
            
            if (paymentType == PaymentTypeEnum.Cash)  
            {
                var amountRemainingToPay = register.TakePaymentCash(amountDue);
                while (amountRemainingToPay < 0.00) 
                {
                    paymentType = Menu.AskForPaymentMethodMenu();
                    amountRemainingToPay = Math.Round(Math.Abs(amountRemainingToPay),2, MidpointRounding.AwayFromZero);
                    TakePayment(paymentType, amountRemainingToPay, register);
                }
                //add call to receipt display method here
            }
            else if (paymentType == PaymentTypeEnum.Check)
            {
                register.TakePaymentCheck(amountDue);
            }
            else if (paymentType == PaymentTypeEnum.Credit_Card)
            {
                register.TakePaymentCreditCard(amountDue);
            }
            else
            {
            }
        }

        public static void SearchForProduct(string descriptor, Register register) //performs a product search based on user input string
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
        private static bool DisplayTransactionDetails(List<KeyValuePair<Product, int>> shoppingCart, Register register, KeyValuePair<Product, int> kvpUserSelection)
        {
            bool clearConsole;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Transaction total: {register.GetSubtotal(kvpUserSelection)}");
            Console.WriteLine($"Subtotal: {register.GetSubtotal(shoppingCart)}");
            clearConsole = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            return clearConsole;
        }

        private static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("WELCOME TO CHUCKY'S TOY KINGDOM!!!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("**********************************");
            Console.WriteLine();
        }

        public static int GetUserItemQuantity()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter Quantity:");
            var takeUserQuantity = Console.ReadLine();
           
            if (ValidateInput.GetIsInteger(takeUserQuantity))
            {
                return int.Parse(takeUserQuantity);
            }
            Console.WriteLine("Something went wrong");
            return GetUserItemQuantity();
        }

        public static void DisplayReceipt(string path)
        {
            var paidDisplayReceipt = new List<string>();
            //go to file handler file
            //var receiptWriterPath = path;
            //call file reader

            string displayReceipt = FileHandler.ReadFile(path);
            Console.WriteLine(displayReceipt);
        }

        public static void Printreceipt(string path)
            //We need to display this to the screen
        {
          FileHandler.Writereceipt(path,$"{DateTime.Now.ToString()}", false);
          var businessNameAndAddress = new string[]
          {
              "Chucky's Toy Kingdom", "40 Pearl St NW #200", "Grand Rapids, MI 49503", "555-555-1234", "-------------------------------------------"
          };
          foreach (var addressLine in businessNameAndAddress)
          {
              FileHandler.Writereceipt(path,addressLine,true);
          }
        }
    }
}