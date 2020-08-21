using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBMidtermPOS
{
    public static class ValidateInput
    {
        public static bool GetIsInteger(string userInputNumber)
        {
            return false;
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
