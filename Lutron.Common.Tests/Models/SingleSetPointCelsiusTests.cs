using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class SingleSetPointCelsiusTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenSingleSetPointIsLessThan0
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SingleSetPointCelsius(-1));
                }
            }

            [TestFixture]
            public class WhenSingleSetPointIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SingleSetPointCelsius(101));
                }
            }

            [TestFixture]
            public class WhenSingleSetPointIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new SingleSetPointCelsius(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var setPoint = new SingleSetPointCelsius(34);

                Assert.AreEqual("34", setPoint.ToString());
            }
        }
    }
}