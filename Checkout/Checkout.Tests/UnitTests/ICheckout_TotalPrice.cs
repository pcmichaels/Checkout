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

        [Test]
        public void MultipleSingleItemsScanned_NoSpecialPrice()
        {

        }

        [Test]
        public void MultipleSingleItemsScanned_SpecialPrice()
        {

        }

        [Test]
        public void MultipleMixedItemsScanned_NoSpecialPrice()
        {

        }

        [Test]
        public void MultipleMixedItemsScanned_SpecialPrice()
        {

        }
    }
}
