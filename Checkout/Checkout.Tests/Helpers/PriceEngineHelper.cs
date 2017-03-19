using Checkout.Core;
using Checkout.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Tests.Helpers
{
    public static class PriceEngineHelper
    {
        /// <summary>
        /// Return a default price engine with a default price table
        /// </summary>
        /// <returns></returns>
        public static IPriceEngine GetDefaultPriceEngine()
        {
            PriceTable priceTable = PriceTableFactory.GetDefaultPriceTable();
            PriceEngine priceEngine = new PriceEngine(priceTable);

            return priceEngine;
        }

        public static IPriceEngine GetDefaultPriceEngineWithInvalidPriceTable()
        {
            PriceTable priceTable = GetInvalidPriceTable();
            PriceEngine priceEngine = new PriceEngine(priceTable);

            return priceEngine;
        }

        private static PriceTable GetInvalidPriceTable()
        {
            PriceTable priceTable = new PriceTable()
            {
                ItemPrices = new List<ItemPrice>()
                {
                    { new ItemPrice() { SKU = "A", UnitPrice = -3, Threshold = 3, GroupPrice = 1 } },
                    { new ItemPrice() { SKU = "B", UnitPrice = 2, Threshold = 1, GroupPrice = -1 } },
                    { new ItemPrice() { SKU = "C", UnitPrice = -2, Threshold = 3, GroupPrice = 0 } },
                    { new ItemPrice() { SKU = "D", UnitPrice = -1, Threshold = null, GroupPrice = 2 } }
                }
            };

            return priceTable;
        }

    }
}
