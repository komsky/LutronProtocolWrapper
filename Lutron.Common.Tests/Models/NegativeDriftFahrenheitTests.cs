using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class NegativeDriftFahrenheitTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenNegativeDriftIsLessThan0
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new NegativeDriftFahrenheit(-1));
                }
            }

            [TestFixture]
            public class WhenNegativeDriftIsGreaterThan15
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new NegativeDriftFahrenheit(16));
                }
            }

            [TestFixture]
            public class WhenNegativeDriftIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new NegativeDriftFahrenheit(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var drift = new NegativeDriftFahrenheit(13);

                Assert.AreEqual("13", drift.ToString());
            }
        }
    }
}