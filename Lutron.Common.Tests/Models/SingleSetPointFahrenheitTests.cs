using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class SingleSetPointFahrenheitTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenSingleSetPointIsLessThan32
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SingleSetPointFahrenheit(31));
                }
            }

            [TestFixture]
            public class WhenSingleSetPointIsGreaterThan212
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SingleSetPointFahrenheit(213));
                }
            }

            [TestFixture]
            public class WhenSingleSetPointIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new SingleSetPointFahrenheit(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var setPoint = new SingleSetPointFahrenheit(34);

                Assert.AreEqual("34", setPoint.ToString());
            }
        }
    }
}