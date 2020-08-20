using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace GroupBMidtermPOS
{
    public class ValidatePayment
    {
        //credit card
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        public string CVVCode { get; set; }
        
        //check
        public string RoutingNum { get; set; }
        public string AcctNum { get; set; }


        public ValidatePayment()
        {

        }
        public ValidatePayment(string creditCard, string expDate, string cvvCode, string routingNum, string acctNum)
        {
            //credit card
            CreditCard = creditCard;
            ExpDate = expDate;
            CVVCode = cvvCode;
            //check
            RoutingNum = routingNum;
            AcctNum = acctNum;

        }

        //validate length 12-digit and that it's parseable to an integer
        public bool ValidateCreditCard(string creditCard)
        {
            var userCreditCard = creditCard.Trim();
            var isPassing = userCreditCard.All(char.IsDigit);
            //const string regex = @"([0-9]{4}\-[0-9]{4}\-[0-9]{4}\-[0-9]{4})";

            if (Regex.IsMatch(userCreditCard, @"([0-9]{4}[0-9]{4}[0-9]{4}[0-9]{4})"))
            {
                return true;
            }
            return isPassing;

        }

        //validate date format?  ToDate (parse) -- or take 4-digit input, validate first 2 digits between 1-12; year is greater than 20 (not expired)
        public bool ValidateExpDate(string expDate)
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
        public bool ValidateCVV(string cvvCode)
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
        public bool ValidateAcctNum(string acctNum)
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
        public bool ValidateRoutingNum(string routingNum)
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