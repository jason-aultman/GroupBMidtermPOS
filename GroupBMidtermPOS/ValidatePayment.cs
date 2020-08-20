/*
using System.Text.RegularExpressions;

namespace GroupBMidtermPOS
{
    public class ValidatePayment
    {
        
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        public string CVVCode { get; set; }
        
        
        public string RoutingNum { get; set; }
        public string AcctNum { get; set; }


        public ValidatePayment()
        {

        }
        public ValidatePayment(string creditCard, string expDate, string cvvCode, string routingNum, string acctNum)
        {
            CreditCard = creditCard;
            ExpDate = expDate;
            CVVCode = cvvCode;
            RoutingNum = routingNum;
            AcctNum = acctNum;
        }

        //validate length 12-digit and that it's parseable to an integer
        public bool ValidateCreditCard(string creditCard)
        {

        }

        //validate date format?  ToDate (parse) -- or take 4-digit input, validate first 2 digits between 1-12; year is greater than 20 (not expired)
        public bool ValidateExpDate(string expDate)
        {

        }

        //validate 3-digits and an integer
        public bool ValidateCVV(string cvvCode)
        {

        }

        //validate 12 digit account number length and is an integer
        //combine this method with credit card validation method to economize!
        public bool ValidateAcctNum(string acctNum)
        {

        }

        //Validate 9 digital routing number length and is an integer
        public bool ValidateRoutNum(string routingNum)
        {

        }
    }

}*/