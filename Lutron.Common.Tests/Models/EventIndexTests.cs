using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class EventIndexTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenEventIndexIsLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new EventIndex(-1));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnEventIndex()
            {
                var eventIndex = new EventIndex(34);
                Assert.AreEqual("34", eventIndex.ToString());
            }
        }
    }
}