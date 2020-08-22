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
            Register register = new Register(); //open a new Register
            var clearConsole = false;

            DisplayHeader();

            do
            {
                var userItemNumber = GetItemNumberFromUser(register, clearConsole);
                var userItemQuantity = GetUserItemQuantity();
                var kvpUserSelection = new KeyValuePair<Product, int>(GetProduct(register.listOfProducts, userItemNumber), userItemQuantity);
                shoppingCart.Add(kvpUserSelection);
                clearConsole = DisplayTransactionDetails(shoppingCart, register, kvpUserSelection);
            } while (AskToContinueToShop());

            Menu.DisplayOrderSummary(shoppingCart, register);
            var payment = Menu.AskForPaymentMethodMenu();
            TakePayment(payment, register.GetGrandTotal(shoppingCart), register);

           

        }

        private static int GetItemNumberFromUser(Register register, bool clearConsole)
        {
            Console.WriteLine($"Menu: Choose an Item # or [: + search term] to search");
            Menu.DisplayMainMenu(register, clearConsole);
            var userItemNumber = 0;
            do
            {
                var userItemAsString = Console.ReadLine();
                if (userItemAsString.StartsWith(":"))
                {
                    SearchForProduct(userItemAsString.Substring(1), register);
                }
                else
                {
                    if (ValidateInput.GetIsInteger(userItemAsString))
                    {
                        userItemNumber = int.Parse(userItemAsString) - 1;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please input a valid integer.");
                    }
                }

            } while (true);
            return userItemNumber;
        }

        public static bool AskToContinueToShop()
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
        static bool AskToCheckOut()
        {
            Console.WriteLine("Are you ready to check out? (Y/N) ");
            var checkOutYesNo = Console.ReadLine().ToLower();
            return false;
        }
        static Product GetProduct(List<Product> productList, int userChoice)
        {
            Product choice = productList[userChoice];
            return choice;
        }

        public static void TakePayment(PaymentTypeEnum paymentType, double amountDue, Register register)
        {
            var amount = amountDue;
            switch (paymentType)
            {

                case PaymentTypeEnum.Cash:
                    amount = register.TakePaymentCash(amount);
                    while (amount < 0.00)
                    {
                        var payment = Menu.AskForPaymentMethodMenu();
                        TakePayment(payment, Math.Abs(amount), register); //1 -20, 
                    }
                    break;
                case PaymentTypeEnum.Check:
                    register.TakePaymentCheck(amountDue);
                    break;
                case PaymentTypeEnum.Credit_Card:
                    register.TakePaymentCreditCard(amountDue);
                    break;
                default:
                    break;
            }
        }

        public static void SearchForProduct(string descriptor, Register register)
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
    }
}