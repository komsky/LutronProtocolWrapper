using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class SetPointCoolTests
    {       
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenSetPointCoolIsLessThan32
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SetPointCool(31));
                }
            }

            [TestFixture]
            public class WhenSetPointCoolIsGreaterThan212
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new SetPointCool(213));
                }
            }

            [TestFixture]
            public class WhenSetPointCoolIs255
            {
                [Test]
                public void ShouldNotThrowException()
                {
                    Assert.DoesNotThrow(() => new SetPointCool(255));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnSetPointCool()
            {
                var setPointCool = new SetPointCool(34);

                Assert.AreEqual("34", setPointCool.ToString());
            }
        }
    }
}