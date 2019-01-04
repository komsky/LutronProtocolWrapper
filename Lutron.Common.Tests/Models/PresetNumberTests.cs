using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class PresetNumberTests
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
                    Assert.Throws<ArgumentException>(() => new PresetNumber(-1));
                }
            }

            [TestFixture]
            public class WhenLevelIsGreaterThan30
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new PresetNumber(101));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnLevel()
            {
                var presetNumber = new PresetNumber(15);

                Assert.AreEqual("15", presetNumber.ToString());
            }
        }
    }
}