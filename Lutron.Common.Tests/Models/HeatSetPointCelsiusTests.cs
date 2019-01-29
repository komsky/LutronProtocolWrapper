using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class HeatSetPointCelsiusTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenHeatSetPointIsLessThan0
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new HeatSetPointCelsius(-1));
                }
            }

            [TestFixture]
            public class WhenHeatSetPointIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new HeatSetPointCelsius(101));
                }
            }

            [TestFixture]
            public class WhenHeatSetPointIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new HeatSetPointCelsius(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnHeatSetPoint()
            {
                var heatSetPoint = new HeatSetPointCelsius(34);

                Assert.AreEqual("34", heatSetPoint.ToString());
            }
        }
    }
}