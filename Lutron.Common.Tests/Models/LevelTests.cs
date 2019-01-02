using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class LevelTests
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
                    Assert.Throws<ArgumentException>(() => new Level(-1));
                }
            }  
            
            [TestFixture]
            public class WhenLevelIsGreaterThan100
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Level(101));
                }
            }         
        }

        [TestFixture]
        public class WhenToString
        {
                [Test]
                public void ShouldReturnLevel()
                {
                    var fade = new Level(34);
                    
                    Assert.AreEqual("34", fade.ToString());
                }
        }
    }
}