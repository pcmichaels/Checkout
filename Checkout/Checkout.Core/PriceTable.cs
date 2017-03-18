using System.Collections.Generic;

namespace Checkout.Core
{
    public class PriceTable
    {
        public IEnumerable<ItemPrice> ItemPrices { get; set; }
    }
}