using System;

namespace GroupBMidtermPOS
{
    public class CalculateTotal : CalculatePrice
    {
        //calculates subtotal, sales tax and grand total
        public decimal FinalTotal { get; set; }

        public CalculateTotal()
        {

        }

        public CalculateTotal(decimal finalTotal, decimal subtotal) : base(subtotal)
        {
            FinalTotal = finalTotal;
        }

        public decimal GetFinalTotal(decimal subtotal)
        {
            FinalTotal = Math.Round(subtotal + (subtotal * Tax), 2);
            return FinalTotal;
        }
    }
}
