using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class TemperatureFahrenheitTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenTemperatureIsLessThan32
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new TemperatureFahrenheit(31));
                }
            }

            [TestFixture]
            public class WhenTemperatureIsGreaterThan212
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new TemperatureFahrenheit(213));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnTemperature()
            {
                var temperature = new TemperatureFahrenheit(34);

                Assert.AreEqual("34", temperature.ToString());
            }
        }
    }
}