using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class HeatSetPointFahrenheitTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenHeatSetPointIsLessThan32
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new HeatSetPointFahrenheit(31));
                }
            }

            [TestFixture]
            public class WhenHeatSetPointIsGreaterThan212
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new HeatSetPointFahrenheit(213));
                }
            }

            [TestFixture]
            public class WhenHeatSetPointIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new HeatSetPointFahrenheit(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnHeatSetPoint()
            {
                var heatSetPoint = new HeatSetPointFahrenheit(34);

                Assert.AreEqual("34", heatSetPoint.ToString());
            }
        }
    }
}