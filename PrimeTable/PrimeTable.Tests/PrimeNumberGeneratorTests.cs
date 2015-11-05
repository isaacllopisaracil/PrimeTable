using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.Tests
{
    [TestFixture]
    class PrimeNumberGeneratorTests
    {
        [TestCase(10, ExpectedResult = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [Test]
        public IEnumerable<int> PrimeNumberGenerator_Generate(int length)
        {
            // Arrange
            var testObject = new Lib.PrimeNumberGenerator();

            // Act
            var result = testObject.Generate(length);

            // Assert
            Assert.AreEqual(length, result.Count());

            return result;
        }

        [TestCase(4, ExpectedResult = false)]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [Test]
        public bool PrimeNumberGenerator_IsPrime(int value)
        {
            // Arrange
            var testObject = new Lib.PrimeNumberGenerator();

            // Act
            var result = testObject.IsPrime(value);

            // Assert
            return result;
        }
    }
}
