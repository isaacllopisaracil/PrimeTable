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
        private Lib.PrimeNumberGenerator _testObject;

        [SetUp]
        public void BeforeEachTest()
        {
            _testObject = new Lib.PrimeNumberGenerator();
        }

        [TestCase(10, ExpectedResult = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [Test]
        public IEnumerable<int> PrimeNumberGenerator_Generate(int length)
        {
            // Arrange
            // Act
            var result = _testObject.Generate(length);

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
            // Act
            var result = _testObject.IsPrime(value);

            // Assert
            return result;
        }
    }
}
