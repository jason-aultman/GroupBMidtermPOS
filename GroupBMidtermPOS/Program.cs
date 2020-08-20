using System;
using System.Collections.Generic;
using MiNET.Utils;

namespace GroupBMidtermPOS
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Bernard test
            //Jason test
            //sandy test change
            var saletransaction = new Dictionary<Product,int>();
            var shoppingCart = new List<Product>();
            
            Console.WriteLine("WELCOME TO CHUCKY'S TOY KINGDOM!!!");
            Console.WriteLine("**********************************");
            Console.WriteLine("Menu: Choose an Item");

            Register register = new Register(); //open a new Register
           // register.createTemporaryListOfProductsForDemoOnly(); //delete whence Filehandler passes all tests
           var count = 1;
            foreach (var product in register.listOfProducts)
            {
                Console.WriteLine($"[{product.ProductNumber}] {product.Name} "); //write out the list of products 1 thru end of list
                count++;
            }

            count = 1;
            var userItem = Console.ReadLine();
            

            Console.WriteLine("Enter Quantity:");
            var takeUserQuantity = int.TryParse(Console.ReadLine(), out int userItemQuantity); // take user user's quantity
            if (!takeUserQuantity)
            {
                Console.WriteLine("Something went wrong");
            }
            Console.WriteLine("Subtotal: ");
            //items customer selected
            //price of items * quantity = total

            Console.WriteLine("Would you like to continue? (Y/N)");
            var continueYesNo = Console.ReadLine().ToLower();

            Console.WriteLine("Are you ready to check out? (Y/N) ");
            var checkOutYesNo = Console.ReadLine().ToLower();

            /*Console.WriteLine("Order Summary: ");
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
            double userAmountTendered = double.Parse(Console.ReadLine());*/
            /*if (userAmountTendered < total)
            {
                var amountOwed = total - userAmountTendered;
                Console.WriteLine($"You still owe {amountOwed} ");
            }*/
         //   register.TakePaymentCash(userAmountTendered, total);

        }
    }
}