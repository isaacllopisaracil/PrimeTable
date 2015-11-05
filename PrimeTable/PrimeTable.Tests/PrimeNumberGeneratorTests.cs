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
        [TestCase(50000000, Explicit = true)]
        [TestCase(1000000, Explicit = true)]
        [TestCase(100000)]
        [Test]
        public void PrimeNumberGenerator_Generate_LargeNumbers(int length)
        {
            // Arrange
            IEnumerable<int> result = null;
            var testObject = new Lib.PrimeNumberGenerator();

            // Act, Assert
            Assert.DoesNotThrow(() => result = testObject.Generate(length));
            if (length >= 500) Assert.AreEqual(3571, result.ElementAt(499));
            if (length >= 10000) Assert.AreEqual(104729, result.ElementAt(9999));
            if (length >= 100000) Assert.AreEqual(1299709, result.ElementAt(99999));

            // Note that tests of this and higher ranges may take very long to compute
            if (length >= 1000000) Assert.AreEqual(15485863, result.ElementAt(999999));
            if (length >= 10000000) Assert.AreEqual(179424673, result.ElementAt(9999999));
            if (length >= 50000000) Assert.AreEqual(982451653, result.ElementAt(49999999));
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
