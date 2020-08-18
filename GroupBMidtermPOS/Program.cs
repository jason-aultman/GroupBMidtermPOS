using System;

namespace GroupBMidtermPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bernard test
            //Jason test
            //sandy test change

            Console.WriteLine("WELCOME TO CHUCKY'S TOY KINGDOM!!!");
            Console.WriteLine("**********************************");
            Console.WriteLine("Menu: Choose an Item");

            Register register = new Register(); //open a new Register
            Console.WriteLine(register.productListFile); //write out the list of products 1 thru end of list
            var userItem = Console.ReadLine();

            Console.WriteLine("Enter Quantity:");
            var userItemQuantity = Console.ReadLine();







        }
    }
}