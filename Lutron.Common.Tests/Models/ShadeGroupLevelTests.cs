using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class ShadeGroupLevelTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenLevelIsLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new ShadeGroupLevel(-1));
                }
            }

            [TestFixture]
            public class WhenLevelIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new ShadeGroupLevel(101));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnLevel()
            {
                var fade = new ShadeGroupLevel(34);

                Assert.AreEqual("34", fade.ToString());
            }
        }
    }
}