using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class NegativeDriftCelsiusTests
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
                    Assert.Throws<ArgumentException>(() => new NegativeDriftCelsius(-1));
                }
            }

            [TestFixture]
            public class WhenNegativeDriftIsGreaterThan8
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new NegativeDriftCelsius(9));
                }
            }

            [TestFixture]
            public class WhenNegativeDriftIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new NegativeDriftCelsius(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var drift = new NegativeDriftCelsius(5);

                Assert.AreEqual("5", drift.ToString());
            }
        }
    }
}