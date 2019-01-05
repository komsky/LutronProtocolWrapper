using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class SerialNumberTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenSerialNumberIs8CharactersButNotHexadecimal
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SerialNumber("JKLMO787"));
                }
            }

            [TestFixture]
            public class WhenSerialNumberIsHexadecimalButNot8Characters
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SerialNumber("5678E"));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnLevel()
            {
                var serialNumber = new SerialNumber("5678EFEF");

                Assert.AreEqual("5678EFEF", serialNumber.ToString());
            }
        }
    }
}