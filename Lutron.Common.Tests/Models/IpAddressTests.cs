using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class IpAddressTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenIpAddressIsNotValid
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new IpAddress("355.355.355.355"));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnLevel()
            {
                var outputLevel = new IpAddress("192.168.1.1");

                Assert.AreEqual("192.168.1.1", outputLevel.ToString());
            }
        }
    }
}