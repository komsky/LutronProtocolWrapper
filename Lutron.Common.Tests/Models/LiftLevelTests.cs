using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class LiftLevelTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenLiftLevelIsLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new LiftLevel(-1));
                }
            }

            [TestFixture]
            public class WhenLiftLevelIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new LiftLevel(101));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnLiftLevel()
            {
                var fade = new LiftLevel(34);

                Assert.AreEqual("34", fade.ToString());
            }
        }
    }
}