using Moq;
using NUnit.Framework;
using PrimeTable.CLI;
using PrimeTable.CLI.Contracts;
using PrimeTable.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTable.Tests.CLI
{
    [TestFixture]
    class PrimeNumbersAppControllerTests
    {
        Mock<IOutputWriter> m_outputWriter;
        StringWriter m_outputWriter_string;

        [SetUp]
        public void BeforeEachTest()
        {
            m_outputWriter_string = new StringWriter();
            m_outputWriter = new Mock<IOutputWriter>();
            m_outputWriter.Setup(x => x.Write(It.IsAny<string>())).Callback<string>(x => m_outputWriter_string.Write(x));
            m_outputWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>(x => m_outputWriter_string.WriteLine(x));
        }

        [Test]
        void PrimeNumbersAppController_ctor_ParametersCannotBeNull()
        {
            // Arrange, Act, Assert
            Assert.Throws(typeof(ArgumentNullException), () => new PrimeNumbersAppController(null, new Mock<IOutputWriter>().Object));
            Assert.Throws(typeof(ArgumentNullException), () => new PrimeNumbersAppController(new Mock<IPrimeTableGenerator>().Object, null));
            Assert.DoesNotThrow(() => new PrimeNumbersAppController(new Mock<IPrimeTableGenerator>().Object, new Mock<IOutputWriter>().Object));
        }

        [TestCase(3)]
        [TestCase(0, ExpectedException = typeof(ArgumentException))]
        [Test]
        void PrimeNumbersAppController_Run(int value)
        {
            // Arrange
            var m_PrimeTableGenerator = new Mock<IPrimeTableGenerator>();
            m_PrimeTableGenerator.Setup(x => x.Generate(3))
                .Returns(new[,] { { (int?)null, 2, 3, 5 }, { 2, 4, 6, 10 }, { 3, 6, 9, 15 }, { 5, 10, 15, 25 } });

            var testObject = new PrimeNumbersAppController(m_PrimeTableGenerator.Object, m_outputWriter.Object);

            // Act
            testObject.Run(value);

            // Assert
            Assert.AreEqual(
@"
--------------------
¦   ¦  2 ¦  3 ¦  5 ¦
--------------------
¦ 2 ¦  4 ¦  6 ¦ 10 ¦
--------------------
¦ 3 ¦  6 ¦  9 ¦ 15 ¦
--------------------
¦ 5 ¦ 10 ¦ 15 ¦ 25 ¦
--------------------", m_outputWriter_string.ToString());
        }
    }
}
