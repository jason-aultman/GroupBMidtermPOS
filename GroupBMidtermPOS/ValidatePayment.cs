//
using MiNET.Blocks;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace GroupBMidtermPOS
{
    public static class ValidatePayment
    {
       

       

        //validate length 12-digit and that it's parseable to an integer
        public static bool ValidateCreditCardAccountNumberIsLongEnough(string creditCard)
        {
            creditCard = creditCard.Trim();  //changed this line to eliminate initializing another variable
            if (creditCard.Length==12)
            {
                return true;
            }
            return false;
           
        }

        //validate date format?  
        //ToDate (parse) -- or take 4-digit input
        //validate first 2 digits between 1-12
        //year is greater than 20 (not expired)
        
        //new method to determine if the first 2 numbers are between a range
        public static bool BetweenMoRanges(int a,int b, int number)
        {
            a = 1;
            b = 12;
            return (a >= number && number <= b);
        }
        //new method to determine if the second set of 2 numbers are between a range
        public static bool BetweenYrRanges(int a,int b, int number)
        {
            a = 1;
            b = 9;
            return (a <= number && number <= b);
        }
        
        
        public static bool ValidateExpDate(string expDate)
        {
            var cardExpDate = expDate.Trim();
            var isPassing = expDate.All(char.IsDigit);

            if (Regex.IsMatch(expDate, @"([0-1]{1}[0-9]{1}[1-2]{1}[0-9]{1})")&& isPassing)
            {
                return true;
            }
            return false;

        }

        //validate 3-digits and an integer
        public static bool ValidateCVV(string cvvCode)
        {
            var usercvvCode = cvvCode.Trim();
            var isPassing = cvvCode.All(char.IsDigit);

            if (Regex.IsMatch(cvvCode, @"([0-1]{1}[0-9]{1}[1-2]{1})"))
            {
                return true;
            }
            return false;

        }

        //validate 12 digit account number length and is an integer
        //combine this method with credit card validation method to economize!
        public static bool ValidateAcctNum(string acctNum)
        {
            var useracctNum = acctNum.Trim();
            var isPassing = acctNum.All(char.IsDigit);

            if (Regex.IsMatch(acctNum, @"([0-9]{1}[0-9]{1}[1-9]{1}[0-9]{1}[0-9]{1}[1-9]{1}[0-9]{1}[0-9]{1}[1-9]{1}[0-9]{1}[0-9]{1}[1-9]{1})"))
            {
                return true;
            }
            return false;
        }

        //Validate 9 digital routing number length and is an integer
        public static bool ValidateRoutingNum(string routingNum)
        {
            var userroutingNum = routingNum.Trim();
            var isPassing = routingNum.All(char.IsDigit);

            if (Regex.IsMatch(routingNum, @"([0-9]{1}[0-9]{1}[1-9]{1}[0-9]{1}[0-9]{1}[1-9]{1}[0-9]{1}[0-9]{1}[1-9]{1})"))
            {
                return true;
            }
            return false;

        }
    }

}