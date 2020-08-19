using System;

namespace GroupBMidtermPOS
{
    public class CalculatePrice
    {
        // calculates price and quanity of item
        //returns the line 
        //decimal plusTax = (total * taxValue) + total;
        //decimal finalTotal = Math.Round(plusTax, 2);

        public decimal Subtotal { get; set; }

        public decimal Tax = .06m;

        public CalculatePrice()
        {

        }

        public CalculatePrice(decimal subtotal)
        {
            Subtotal = subtotal;
        }

        public decimal GetTax(decimal subtotal)
        {
            return Math.Round(subtotal * Tax, 2, MidpointRounding.AwayFromZero);
        }
    }
}