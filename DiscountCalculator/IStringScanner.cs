using System;

namespace DiscountCalculator
{
    public interface IStringScanner
    {
        void Scan(string input);
        decimal GetTotal();
    }
}