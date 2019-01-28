using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class TemperatureCelsiusTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenTemperatureIsLessThan0
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new TemperatureCelsius(-1));
                }
            }

            [TestFixture]
            public class WhenTemperatureIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new TemperatureCelsius(101));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnTemperature()
            {
                var temperature = new TemperatureCelsius(34);

                Assert.AreEqual("34", temperature.ToString());
            }
        }
    }
}