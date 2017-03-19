using System;
using Checkout.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        Dictionary<string, int> _scannedItems = new Dictionary<string, int>();
        IPriceEngine _priceEngine;

        public Checkout(IPriceEngine priceEngine)
        {
            _priceEngine = priceEngine;
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
                runningTotal += _priceEngine.Calculate(item.Key, item.Value);
            }

            return runningTotal;
        }

        public void Scan(string sku)
        {
            if (!_priceEngine.Validate(sku))            
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
