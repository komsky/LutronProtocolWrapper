using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class CoolSetPointFahrenheitTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenCoolSetPointIsLessThan32
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new CoolSetPointFahrenheit(31));
                }
            }

            [TestFixture]
            public class WhenCoolSetPointIsGreaterThan212
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new CoolSetPointFahrenheit(213));
                }
            }

            [TestFixture]
            public class WhenCoolSetPointIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new CoolSetPointFahrenheit(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var coolSetPoint = new CoolSetPointFahrenheit(34);

                Assert.AreEqual("34", coolSetPoint.ToString());
            }
        }
    }
}