using Checkout.Interface;
using NUnit.Framework;
using System;

namespace Checkout.Tests.UnitTests
{
    [TestFixture]
    public class ICheckout_PriceEngine
    {
        [TestCase("A")]
        [TestCase("B")]
        [TestCase("C")]
        [TestCase("D")]
        public void Validate_Valid(string sku)
        {
            // Arrange
            IPriceEngine priceEngine = Helpers.PriceEngineHelper.GetDefaultPriceEngine();

            // Act
            bool valid = priceEngine.Validate(sku);

            // Assert
            Assert.IsTrue(valid);
        }

        [TestCase("122Z '")]
        [TestCase("AABA")]
        [TestCase("F")]
        [TestCase("")]
        public void Validate_InValid(string sku)
        {
            // Arrange
            IPriceEngine priceEngine = Helpers.PriceEngineHelper.GetDefaultPriceEngine();

            // Act
            bool valid = priceEngine.Validate(sku);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestCase("A", 12, 520)]
        [TestCase("C", 1, 20)]
        [TestCase("B", 0, 0)]
        [TestCase("B", 3, 75)]
        public void Calculate_Valid(string sku, int quantity, decimal expectedTotal)
        {
            // Arrange
            IPriceEngine priceEngine = Helpers.PriceEngineHelper.GetDefaultPriceEngine();

            // Act
            decimal value = priceEngine.Calculate(sku, quantity);

            // Assert
            Assert.AreEqual(expectedTotal, value);
        }

        [TestCase("A", -1)]
        [TestCase("B", -21)]
        public void Calculate_InValid_Quantity(string sku, int quantity)
        {
            // Arrange
            void Calculate()
            {

                // Arrange
                IPriceEngine priceEngine = Helpers.PriceEngineHelper.GetDefaultPriceEngine();

                // Act
                decimal value = priceEngine.Calculate(sku, quantity);
            }

            // Assert
            Assert.Throws(typeof(Exception), Calculate);
        }

        [TestCase("CCA", 1)]
        [TestCase(" ", 0)]
        [TestCase("1234", 3)]
        public void Calculate_InValid_SKU(string sku, int quantity)
        {
            // Arrange
            void Calculate()
            {
                IPriceEngine priceEngine = Helpers.PriceEngineHelper.GetDefaultPriceEngine();

                // Act
                decimal value = priceEngine.Calculate(sku, quantity);
            }

            // Assert
            Assert.Throws(typeof(InvalidOperationException), Calculate);
        }

        [TestCase("A", 5)]
        [TestCase("B", 5)]
        [TestCase("C", 5)]
        [TestCase("D", 5)]
        public void Calculate_InValid_InvalidPriceTable(string sku, int quantity)
        {
            // Arrange
            void Calculate()
            {
                IPriceEngine priceEngine = Helpers.PriceEngineHelper.GetDefaultPriceEngineWithInvalidPriceTable();

                // Act
                decimal value = priceEngine.Calculate(sku, quantity);
            }

            // Assert
            Assert.Throws(typeof(Exception), Calculate);
        }


    }
}
