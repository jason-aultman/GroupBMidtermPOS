using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace GroupBMidtermPOS
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Bernard test
            //Jason test
            //sandy test change
           
            var shoppingCart = new List<KeyValuePair<Product, int>>();
            
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

            var kvpUserSelection = new KeyValuePair<Product, int>(register.listOfProducts[1], userItemQuantity);
            Console.WriteLine($"Subtotal: {register.GetSubtotal(kvpUserSelection)}");
            //items customer selected
            //price of items * quantity = total

            Console.WriteLine("Would you like to continue? (Y/N)");
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