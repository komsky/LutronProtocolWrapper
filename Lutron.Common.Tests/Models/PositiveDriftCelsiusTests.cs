using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class PositiveDriftCelsiusTests
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
                    Assert.Throws<ArgumentException>(() => new PositiveDriftCelsius(-1));
                }
            }

            [TestFixture]
            public class WhenPositiveDriftIsGreaterThan8
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new PositiveDriftCelsius(9));
                }
            }

            [TestFixture]
            public class WhenPositiveDriftIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new PositiveDriftCelsius(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var drift = new PositiveDriftCelsius(4);

                Assert.AreEqual("4", drift.ToString());
            }
        }
    }
}