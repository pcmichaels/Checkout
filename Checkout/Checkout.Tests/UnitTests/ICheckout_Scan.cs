using Checkout.Interface;
using NUnit.Framework;
using System;

namespace Checkout.Tests.UnitTests
{
    /// <summary>
    /// Test input validation
    /// </summary>
    [TestFixture]
    public class ICheckout_Scan
    {
        [TestCase("A")]
        [TestCase("B")]
        [TestCase("C")]
        [TestCase("D")]
        public void SingleItemScanned(string sku)
        {   
            void ScanItem()
            {
                // Arrange
                ICheckout checkout = new Checkout.Core.Checkout();

                // Act
                checkout.Scan(sku);
            }

            // Assert
            Assert.DoesNotThrow(ScanItem);
        }

        [TestCase("1234")]
        [TestCase("\\*7&565632%''")]
        [TestCase(null)]
        public void SingleItemScanned_Invalid(string sku)
        {
            void ScanItem()
            {
                // Arrange
                ICheckout checkout = new Checkout.Core.Checkout();

                // Act
                checkout.Scan(sku);
            }

            // Assert
            Assert.Throws(typeof(ArgumentException), ScanItem);
        }        

        [TestCase("A", "A")]
        [TestCase("B", "B", "B", "B")]
        [TestCase("A", "A", "B", "A")]
        [TestCase("B", "B", "B", "B", "A", "D", "A")]
        public void MultipleItemsScanned(params string[] skus)
        {
            foreach (string sku in skus)
            {
                void ScanItem()
                {
                    // Arrange
                    ICheckout checkout = new Checkout.Core.Checkout();

                    // Act
                    checkout.Scan(sku);
                }

                // Assert
                Assert.DoesNotThrow(ScanItem);
            }
        }

        [TestCase("1233", "aaa", "1231", "1232")]        
        [TestCase("1233", "1233", "1233", "1233")]
        [TestCase(null)]
        public void MultipleItemsScanned_Invalid(params string[] skus)
        {
            foreach (string sku in skus)
            {
                void ScanItem()
                {
                    // Arrange
                    ICheckout checkout = new Checkout.Core.Checkout();

                    // Act
                    checkout.Scan(sku);
                }

                // Assert
                Assert.Throws(typeof(ArgumentException), ScanItem);
            }
        }

    }
}
