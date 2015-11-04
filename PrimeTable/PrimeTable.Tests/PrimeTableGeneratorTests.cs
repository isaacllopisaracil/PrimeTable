﻿using Moq;
using NUnit.Framework;
using PrimeTable.Lib;
using PrimeTable.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.Tests
{
    class PrimeTableGeneratorTests
    {
        private Lib.PrimeTableGenerator _testObject;

        [TestFixtureSetUp]
        public void BeforeAllTests()
        {
            // Initialize mocks
            var m_IPrimeNumberGenerator = new Mock<IPrimeNumberGenerator>();
            m_IPrimeNumberGenerator.Setup(x => x.Generate(It.IsInRange(1, 10, Range.Inclusive)))
                .Returns((int x) => new int[] { 2, 3, 5, 7, 11, 13, 19, 21, 29 }.Take(x));

            // Initialize test object
            _testObject = new PrimeTableGenerator(m_IPrimeNumberGenerator.Object);
        }

        [TestCase(3)]
        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [Test]
        public int?[,] PrimeTableGenerator_Generate(int length)
        {
            // Arrange
            var expected_3 = new[,] { { (int?)null, 2, 3, 5 }, { 2, 4, 6, 10 }, { 3, 6, 9, 15 }, { 5, 10, 15, 25 } };

            // Act
            var result = _testObject.Generate(length);

            // Assert
            Assert.AreEqual(null, result[0, 0]);
            Assert.AreEqual(Math.Pow(length + 1, 2), result.Length);

            if (length == 3)
                Assert.AreEqual(expected_3, result);

            return result;
        }
    }
}
