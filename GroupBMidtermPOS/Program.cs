using System;
using System.Collections.Generic;


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

            Console.WriteLine("Order Summary: ");
            Console.WriteLine($"Quantity {quantity} Item{item}Price {price}");//quantity-item-price for each item. may need for each statement
            Console.WriteLine($"Subtotal ${subtotal}");//subtotal
            Console.WriteLine($"Tax ${tax}");//tax
            Console.WriteLine($"Total {total} ");//total

            Console.WriteLine("Enter Payment Type: ");// working with the enums
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit/Debit Card");
            Console.WriteLine("3. Check");
            var paymentType = Console.ReadLine();

            Console.WriteLine("Cash: ");
            Console.WriteLine("Please enter amount tendered");
            double userAmountTendered = double.Parse(Console.ReadLine());
            if (userAmountTendered < total)
            {
                var amountOwed = total - userAmountTendered;
                Console.WriteLine($"You still owe {amountOwed} ");
            }
         //   register.TakePaymentCash(userAmountTendered, total);

        }
    }
}