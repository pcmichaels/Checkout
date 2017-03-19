using System;
using Checkout.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        Dictionary<string, int> _scannedItems = new Dictionary<string, int>();
        PriceTable _priceTable;

        public Checkout(PriceTable priceTable)
        {
            _priceTable = priceTable;
        }

        /// <summary>
        /// Makes sense as a function because the calculation should be donen here
        /// and potentially reduce load        
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalPrice()
        {
            decimal runningTotal = 0;

            // Iterate through the scanned items and add up the running total
            foreach (var item in _scannedItems)
            {
                runningTotal += CalculatePrice(item.Key, item.Value);
            }

            return runningTotal;
        }

        private decimal CalculatePrice(string sku, int quantity)
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

            return total;
        }

        public void Scan(string sku)
        {
            if (!_priceTable.ItemPrices.Any(a => a.SKU == sku))
            {
                throw new ArgumentException();
            }

            if (_scannedItems.ContainsKey(sku))
            {
                _scannedItems[sku]++;
            }
            else
            {
                _scannedItems.Add(sku, 1);
            }
        }
    }
}
