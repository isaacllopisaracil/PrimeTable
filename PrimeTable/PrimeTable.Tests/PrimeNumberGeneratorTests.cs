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
        void BeforeEachTest()
        {
            _testObject = new Lib.PrimeNumberGenerator();
        }

        [TestCase(10)]
        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1,ExpectedException = typeof(ArgumentOutOfRangeException))]
        [Test]
        void PrimeNumberGenerator_Generate(int length)
        {
            // Arrange
            // Act
            var result = _testObject.Generate(length);

            // Assert
            Assert.Equals(length, result.Count());
        }
    }
}
