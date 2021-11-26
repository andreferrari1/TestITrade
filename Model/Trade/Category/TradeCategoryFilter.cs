using System;

namespace TestITrade.Model.Category
{
    public class TradeCategoryFilter : TradeCategory
    {
        public int FilterExpiredDate { get; set; }
        public double FilterValueLimit { get; set; }
        public string FilterClientSector { get; set; }
        public bool IsPoliticallyExposed { get; set; } // Question 2:Category PEP
    }
}
