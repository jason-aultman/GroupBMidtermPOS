using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GroupBMidtermPOS
{
    public static class ValidateInput
    {
        public static bool GetIsInteger(string userInputNumber)

        {
            /* //I just added this validation today 8/21 -sj
             var valid = false;
             while (!valid)
             {
                 valid = !string.IsNullOrWhiteSpace(userInputNumber) && userInputNumber.All(c => c >= '0' && c <= '9');
                 return true;
             }
             return false;*/
            return int.TryParse(userInputNumber, out int result);
        }
        public static bool GetIsGreaterThanZero(int numberToCheck)
        {
            if (numberToCheck>0)
            {
                return true;
            }
            return false;
        }
        public static bool IsAnInteger(string userPaymentMethod)
        {
            if (int.TryParse(userPaymentMethod, out int userPaymentMethodInteger)) //check to see if parseable to integer
            {
                var isWithinRange = ValidatePayment.BetweenMoRanges(1, 3, userPaymentMethodInteger); //check to see if within 1-3
                return isWithinRange; //within range and parselable to integer
            }
            return false; //not int or withing 1-3
        }

        public static bool CheckYesNo(string userInputCharacter)
        {
            if (userInputCharacter.ToLower() == "y" || userInputCharacter.ToLower() == "n")
            {
                return true;
            }

            return false;
        }

    }
}
