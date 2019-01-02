using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class TiltTiltLevelTests
    {
    
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenTiltLevelIsLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new TiltLevel(-1));
                }
            }  
            
            [TestFixture]
            public class WhenTiltLevelIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new TiltLevel(101));
                }
            }         
        }

        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnTiltLevel()
            {
                var fade = new TiltLevel(34);
                    
                Assert.AreEqual("34", fade.ToString());
            }
        }
    }
}