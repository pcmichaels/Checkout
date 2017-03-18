using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    { new ItemPrice() { SKU = "A", UnitPrice = 50, Threshold = 3, GroupPrice = 130 } },
                    { new ItemPrice() { SKU = "A", UnitPrice = 50, Threshold = 3, GroupPrice = 130 } },
                    { new ItemPrice() { SKU = "A", UnitPrice = 50, Threshold = 3, GroupPrice = 130 } }
                }
            };

            return priceTable;
        }
    }
}
