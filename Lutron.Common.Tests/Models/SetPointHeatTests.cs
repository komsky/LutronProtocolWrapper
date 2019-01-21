using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class SetPointHeatTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenSetPointHeatIsLessThan32
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SetPointHeat(31));
                }
            }

            [TestFixture]
            public class WhenSetPointHeatIsGreaterThan212
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SetPointHeat(213));
                }
            }

            [TestFixture]
            public class WhenSetPointHeatIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new SetPointHeat(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointHeat()
            {
                var setPointHeat = new SetPointHeat(34);

                Assert.AreEqual("34", setPointHeat.ToString());
            }
        }
    }
}