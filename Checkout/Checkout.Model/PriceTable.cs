using System.Collections.Generic;

namespace Checkout.Model
{
    public class PriceTable
    {
        public IEnumerable<ItemPrice> ItemPrices { get; set; }
    }
}