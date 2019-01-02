using System;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class FadeTests
    {
        [TestFixture]
        public class Constructor
        {
            [TestFixture]
            public class WhenHoursAreLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(-1, 0, 0, 0));
                }
            }

            [TestFixture]
            public class WhenMinutesAreLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(0, -1, 0, 0));
                }
            }

            [TestFixture]
            public class WhenMinutesAreGreaterThan59
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(0, 60, 0, 0));
                }
            }

            [TestFixture]
            public class WhenSecondsAreLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(0, 0, -1, 0));
                }
            }

            [TestFixture]
            public class WhenSecondsAreGreaterThan59
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(0, 0, 60, 0));
                }
            }

            [TestFixture]
            public class WhenFractionalIsLessThanZero
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(0, 0, 0, -1));
                }
            }

            [TestFixture]
            public class WhenFractionalIsGreaterThan99
            {
                [Test]
                public void ShouldThrowException()
                {
                    Assert.Throws<ArgumentException>(() => new Fade(0, 0, 0, 100));
                }
            }
        }

        [TestFixture]
        public class WhenToString
        {
            [TestFixture]
            public class WhenThereAreSecondsWithFractional
            {
                [Test]
                public void ShouldIncludeSecondsAndFractionalOnly()
                {
                    var fade = new Fade(0, 0, 4, 25);

                    Assert.AreEqual("4.25", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereAreSecondsOnly
            {
                [Test]
                public void ShouldIncludeSecondsOnly()
                {
                    var fade = new Fade(0, 0, 4, 0);

                    Assert.AreEqual("4", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereMinutesAndSecondsOnly
            {
                [Test]
                public void ShouldIncludeMinutestAndSecondsOnly()
                {
                    var fade = new Fade(0, 16, 4, 0);

                    Assert.AreEqual("16:04", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereHoursMinutesAndSecondsOnly
            {
                [Test]
                public void ShouldIncludeHoursMinutesAndSecondsOnly()
                {
                    var fade = new Fade(3, 16, 4, 0);

                    Assert.AreEqual("03:16:04", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereAreNoHoursMinutesSecondsOrFractional
            {
                [Test]
                public void ShouldReturnZeroString()
                {
                    var fade = new Fade();

                    Assert.AreEqual("0", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereAreMinutesOnly
            {
                [Test]
                public void ShouldReturnMinutesAndZeroSecondsOnly()
                {
                    var fade = new Fade(minutes: 15);

                    Assert.AreEqual("15:00", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereAreHoursAndMinutesOnly
            {
                [Test]
                public void ShouldReturnHoursMinutesAndZeroSecondsOnly()
                {
                    var fade = new Fade(hours: 2, minutes: 15);

                    Assert.AreEqual("02:15:00", fade.ToString());
                }
            }

            [TestFixture]
            public class WhenThereAreHoursOnly
            {
                [Test]
                public void ShouldReturnHoursZeroMinutesAndZeroSecondsOnly()
                {
                    var fade = new Fade(hours: 2);

                    Assert.AreEqual("02:00:00", fade.ToString());
                }
            }
        }
    }
}