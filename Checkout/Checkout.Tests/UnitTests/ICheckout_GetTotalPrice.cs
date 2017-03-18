using System;
using NUnit.Framework;
using Checkout.Interface;
using Checkout.Core;

namespace Checkout.Tests
{
    /// <summary>
    /// Test calculation of price
    /// Invalid arguments are tested separately
    /// </summary>
    [TestFixture]
    public class ICheckout_GetTotalPrice
    {
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void SingleItemScanned_GetTotalPrice(string sku, decimal expectedPrice)
        {
            // Arrange
            PriceTable priceTable = PriceTableFactory.GetDefaultPriceTable();
            ICheckout checkout = new Checkout.Core.Checkout(priceTable);

            // Act
            checkout.Scan(sku);

            // Asert
            Assert.AreEqual(expectedPrice, checkout.GetTotalPrice());
        }

        [TestCase(100, "A", "A")]
        [TestCase(90, "B", "B", "B", "B")]
        [TestCase(160, "A", "A", "B", "A")]
        [TestCase(205, "B", "B", "B", "B", "A", "D", "A")]
        [TestCase(190, "B", "B", "B", "A", "D", "A")]
        [TestCase(260, "C", "C", "C", "C", "D", "A", "B", "A", "B", "C")]
        public void MultipleSingleItemsScanned_GetTotalPrice(decimal expectedPrice, params string[] skus)
        {
            // Arrange
            PriceTable priceTable = PriceTableFactory.GetDefaultPriceTable();
            foreach (string sku in skus)
            {
                ICheckout checkout = new Checkout.Core.Checkout(priceTable);

            // Act
                checkout.Scan(sku);

            // Asert
                Assert.AreEqual(expectedPrice, checkout.GetTotalPrice());
            }
        }
    }
}
