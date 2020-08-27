using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace GroupBMidtermPOS
{
    static class Program
    {
        static void Main(string[] args)
        {
            do
            {

            var shoppingCart = new List<KeyValuePair<Product, int>>();
                //initialize a "shopping cart" as a List of KeyValuePairs Key = Product Type, 
                //Value being an int representing the amount of  Products
            string receiptWriterPath = "receipt.txt";

            Register register = new Register(receiptWriterPath);
            //open a new Register
            
            var clearConsole = false;  
            //a variable representing whether or not to clear the Console screen between screens

            
            
            Menu.DisplayHeader(); 
            //simple call to display the header on screen. ie Store name, possible welcome or address or telephone #, etc...

            do
            {
                var userItemNumber = GetItemNumberFromUser(register, clearConsole); 
                //requests an Item Number from the user, which sends in a register parameter and whether or not to clear the console.  False for the 1st run because we want the header to be displayed when the program is first run, but not necessarily any time after.
               
                var userItemQuantity = GetUserItemQuantity();  
                //ask the user for a quantity of whichever item was selected above.
                
                Menu.Printreceipt(receiptWriterPath);  
                //initialize the methodology for printing  a reciept.  "Prints" a header to a .txt file.

                var kvpUserSelection = new KeyValuePair<Product, int>(register.GetProduct(register.listOfProducts, userItemNumber), userItemQuantity); 
                //gets selected product # and quantity and makes a new KeyValuePair containing said info

                shoppingCart.Add(kvpUserSelection);  
                //adds previously made KeyValuePair to the users shopping cart
                
                clearConsole = Menu.DisplayTransactionDetails(shoppingCart, register, kvpUserSelection); 
                //displays transaction details for users selected items and quantity, showing price each  and subtotal

            } while (AskToContinueToShop());  
            //ask user  if they would like to continue to shop, if yes, goes back to the beginning of the do, if not, onto the next line.

            Menu.DisplayOrderSummary(shoppingCart, register); 
            //displays a summary of everything in the users shopping cart, including tax and grand total
          
            var payment = Menu.AskForPaymentMethodMenu();  //gets an enum for which type of payment will they be paying with, Cash, Credit, or Check
            register.TakePayment(payment, register.GetGrandTotal(shoppingCart), register, shoppingCart);

            Console.WriteLine();
            Console.WriteLine("YOUR RECEIPT:");
            Menu.DisplayReceipt(receiptWriterPath);

            register.Close();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ENTER");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" to return to main menu");
                Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            } while (true);
          
            //take payment based on which method the  user chose above.
        }
        //END OF MAIN -- 

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
                    register.SearchForProduct(userItemAsString.Substring(1), register);
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


    }
}