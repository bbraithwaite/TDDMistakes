using System;

namespace TDDMistakes
{
    public enum CalculationRules
    {
        None = 0,
        Discounted = 1,
        Standard = 2
    }

    public class Product
    {
        private const decimal DiscountedRate = 10m;
        private const decimal StandardRate = 20m;

        public string ID { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }

        internal decimal CalculatePrice(CalculationRules calculationRules)
        {
            decimal rate = 0;

            switch (calculationRules)
            {
                case CalculationRules.None:
                    return BasePrice;
                case CalculationRules.Discounted:
                    rate = DiscountedRate;
                    break;
                case CalculationRules.Standard:
                    rate = StandardRate;
                    break;
            }

            return  BasePrice + (BasePrice * rate / 100);
        }
    }
}
