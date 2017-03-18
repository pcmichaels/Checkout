using System;
using NUnit.Framework;
using Checkout.Interface;

namespace Checkout.Tests
{
    /// <summary>
    /// Test calculation of price
    /// Invalid arguments are tested separately
    /// </summary>
    [TestFixture]
    public class ICheckout_TotalPrice
    {
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void SingleItemScanned_TotalPrice(string sku, decimal expectedPrice)
        {
            // Arrange
            ICheckout checkout = new Checkout.Core.Checkout();

            // Act
            checkout.Scan(sku);

            // Asert
            Assert.AreEqual(expectedPrice, checkout.TotalPrice);
        }

        [TestCase(100, "A", "A")]
        [TestCase(90, "B", "B", "B", "B")]
        [TestCase(160, "A", "A", "B", "A")]
        [TestCase(205, "B", "B", "B", "B", "A", "D", "A")]
        [TestCase(190, "B", "B", "B", "A", "D", "A")]
        [TestCase(260, "C", "C", "C", "C", "D", "A", "B", "A", "B", "C")]
        public void MultipleSingleItemsScanned(decimal expectedPrice, params string[] skus)
        {
            foreach (string sku in skus)
            {
                // Arrange
                ICheckout checkout = new Checkout.Core.Checkout();

                // Act
                checkout.Scan(sku);

                // Asert
                Assert.AreEqual(expectedPrice, checkout.TotalPrice);
            }
        }
    }
}
