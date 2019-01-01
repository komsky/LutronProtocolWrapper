using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    public class DelayTests
    {
    
        public class Constructor
        {
            public class WhenHoursAreLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(-1, 0, 0, 0));
                }
            }  
            
            public class WhenMinutesAreLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(0, -1, 0, 0));
                }
            }         
            
            public class WhenMinutesAreGreaterThan59
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(0, 60, 0, 0));
                }
            }  
            
            public class WhenSecondsAreLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(0, 0, -1, 0));
                }
            }         
            
            public class WhenSecondsAreGreaterThan59
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(0, 0, 60, 0));
                }
            }   
            
            public class WhenFractionalIsLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(0, 0, 0, -1));
                }
            }         
            
            public class WhenFractionalIsGreaterThan99
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Delay(0, 0, 0, 100));
                }
            }
        }

        public class ToString
        {
            public class WhenThereAreSecondsWithFractional
            {
                [Test]
                public void ShouldIncludeSecondsAndFractionalOnly()
                {
                    var fade = new Delay(0,0,4,25);
                    
                    Assert.AreEqual("4.25", fade.ToString());
                }
            }     
            
            public class WhenThereAreSecondsOnly
            {
                [Test]
                public void ShouldIncludeSecondsOnly()
                {
                    var fade = new Delay(0,0,4,0);
                    
                    Assert.AreEqual("4", fade.ToString());
                }
            }
            
            public class WhenThereMinutesAndSecondsOnly
            {
                [Test]
                public void ShouldIncludeMinutestAndSecondsOnly()
                {
                    var fade = new Delay(0,16,4,0);
                    
                    Assert.AreEqual("16:4", fade.ToString());
                }
            }    
            
            public class WhenThereHoursMinutesAndSecondsOnly
            {
                [Test]
                public void ShouldIncludeHoursMinutesAndSecondsOnly()
                {
                    var fade = new Delay(3,16,4,0);
                    
                    Assert.AreEqual("3:16:4", fade.ToString());
                }
            }  
            
            public class WhenThereAreNoHoursMinutesSecondsOrFractional
            {
                [Test]
                public void ShouldReturnZeroString()
                {
                    var fade = new Delay();
                    
                    Assert.AreEqual("0", fade.ToString());
                }
            }
        }
    }
}