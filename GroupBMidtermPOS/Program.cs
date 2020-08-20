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

            Console.WriteLine("WELCOME TO CHUCKY'S TOY KINGDOM!!!");
            Console.WriteLine("**********************************");
            Console.WriteLine("Menu: Choose an Item");

            Menu.DisplayMainMenu(register);

            //call the Validator.cs -- this is a new class that will hold all the user input validation before anything else happens
            
            var userItem = Console.ReadLine();

            Console.WriteLine("Enter Quantity:");
            //maybe move this to Validator.cs class (new)
            var takeUserQuantity = int.TryParse(Console.ReadLine(), out int userItemQuantity); // take user user's quantity
            if (!takeUserQuantity)
            {
                Console.WriteLine("Something went wrong");
            }

            var kvpUserSelection = new KeyValuePair<Product, int>(register.listOfProducts[1], userItemQuantity);


            Console.WriteLine($"Subtotal: {register.GetSubtotal(kvpUserSelection)}");
            shoppingCart.Add(kvpUserSelection);
            //items customer selected
            //price of items * quantity = total

            Console.WriteLine("Would you like to continue to shop? (Y/N)");
            var continueYesNo = Console.ReadLine().ToLower();

            Console.WriteLine("Are you ready to check out? (Y/N) ");
            var checkOutYesNo = Console.ReadLine().ToLower();

           Menu.DisplayOrderSummary(shoppingCart, register);

            Console.WriteLine("Enter Payment Type: ");// working with the enums
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit/Debit Card");
            Console.WriteLine("3. Check");
            var paymentType = Console.ReadLine();

            //cash payment
            
            Console.WriteLine("Cash: ");
            Console.WriteLine("Please enter amount tendered");
            double userAmountTendered = double.Parse(Console.ReadLine());
            if (userAmountTendered < total)
            {
                var amountOwed = total - userAmountTendered;
                Console.WriteLine($"You still owe ${amountOwed} How would you like to pay?");
            }
            //go back to enter payment type screen if money is owed
            if (userAmountTendered >= total)
            {
                var changeDue = userAmountTendered - total;
                Console.WriteLine($"Change due: ${changeDue}");
            }
            //credit card payment
            Console.WriteLine("Credit/Debit card: ");
            Console.WriteLine("Please your 12 digit credit card number: ");
            var userCardNumber = Console.ReadLine();
            Console.WriteLine("Please your 4 digit expiration date: ");
            var userExpirationDate = Console.ReadLine();
            Console.WriteLine("Please your 3 digit CVV number: ");
            var userCvvNumber = Console.ReadLine();
            //check payment
            Console.WriteLine("Check: ");
            Console.WriteLine("Please enter your check number: ");
            var userCheckNumber = Console.ReadLine();
            Console.WriteLine("Please enter your routing number: ");
            var userRoutingNumber = Console.ReadLine();
            Console.WriteLine("Please enter your checking account number: ");
            var userCheckNumber = Console.ReadLine();
            



            //   register.TakePaymentCash(userAmountTendered, total);

        }
    }
}