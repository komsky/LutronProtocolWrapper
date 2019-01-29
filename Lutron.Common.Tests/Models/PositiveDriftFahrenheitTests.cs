using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class PositiveDriftFahrenheitTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenPositiveDriftIsLessThan0
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new PositiveDriftFahrenheit(-1));
                }
            }

            [TestFixture]
            public class WhenPositiveDriftIsGreaterThan15
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new PositiveDriftFahrenheit(16));
                }
            }

            [TestFixture]
            public class WhenPositiveDriftIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new PositiveDriftFahrenheit(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var drift = new PositiveDriftFahrenheit(12);

                Assert.AreEqual("12", drift.ToString());
            }
        }
    }
}