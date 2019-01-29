using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class CoolSetPointCelsiusTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenCoolSetPointIsLessThan0
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new CoolSetPointCelsius(-1));
                }
            }

            [TestFixture]
            public class WhenCoolSetPointIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new CoolSetPointCelsius(101));
                }
            }

            [TestFixture]
            public class WhenCoolSetPointIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new CoolSetPointCelsius(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var coolSetPoint = new CoolSetPointCelsius(34);

                Assert.AreEqual("34", coolSetPoint.ToString());
            }
        }
    }
}