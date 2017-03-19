using Checkout.Model;
using System.Collections.Generic;


namespace Checkout.Core
{
    public static class PriceTableFactory
    {
        public static PriceTable GetDefaultPriceTable()
        {
            PriceTable priceTable = new PriceTable()
            {
                ItemPrices = new List<ItemPrice>()
                {
                    { new ItemPrice() { SKU = "A", UnitPrice = 50, Threshold = 3, GroupPrice = 130 } },
                    { new ItemPrice() { SKU = "B", UnitPrice = 30, Threshold = 2, GroupPrice = 45 } },
                    { new ItemPrice() { SKU = "C", UnitPrice = 20, Threshold = null, GroupPrice = 0 } },
                    { new ItemPrice() { SKU = "D", UnitPrice = 15, Threshold = null, GroupPrice = 0 } }
                }
            };

            return priceTable;
        }
    }
}
