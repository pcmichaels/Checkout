using Checkout.Interface;
using System.Linq;
using System;
using Checkout.Model;

namespace Checkout.Core
{
    public class PriceEngine : IPriceEngine
    {
        PriceTable _priceTable;

        public PriceEngine(PriceTable priceTable)
        {
            _priceTable = priceTable;
        }

        /// <summary>
        /// Return the price for a certain quantity of SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public decimal Calculate(string sku, int quantity)
        {
            decimal total = 0;

            ItemPrice itemPrice = _priceTable.ItemPrices.Single(a => a.SKU == sku);
            if (itemPrice.Threshold.HasValue && quantity >= itemPrice.Threshold)
            {
                // Take the grouped items and add on any stray single items that don't qualify
                total = ((quantity / itemPrice.Threshold.Value) * itemPrice.GroupPrice)
                        + (quantity % itemPrice.Threshold.Value) * itemPrice.UnitPrice;
            }
            else
            {
                // No grouped items
                total = quantity * itemPrice.UnitPrice;
            }

            if (total < 0)
            {
                throw new Exception("Invalid Price Table or Quantity"); // ToDo: custom argument
            }


            return total;
        }

        /// <summary>
        /// Validate the the product has a price
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public bool Validate(string sku)
        {
            return (_priceTable.ItemPrices.Any(a => a.SKU == sku));
        }
    }
}
