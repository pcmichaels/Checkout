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
    }
}
