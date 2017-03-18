using Checkout.Interface;
using NUnit.Framework;

namespace Checkout.Tests.UnitTests
{
    [TestFixture]
    public class ICheckout_Scan
    {
        [TestCase("A")]
        [TestCase("B")]
        [TestCase("C")]
        [TestCase("D")]
        [TestCase("1234")]
        [TestCase("\\*7&565632%''")]
        [TestCase(null)]
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

        [TestCase("A", "A")]
        [TestCase("B", "B", "B", "B")]
        [TestCase("1233", "1233", "1233", "1233")]
        [TestCase("A", "A", "B", "A")]
        [TestCase("B", "B", "B", "B", "A", "D", "A")]
        [TestCase("1233", "aaa", "1231", "1232")]        
        [TestCase(null)]
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


    }
}
