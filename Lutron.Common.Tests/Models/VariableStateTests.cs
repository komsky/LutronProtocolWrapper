using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.Common.Tests.Models
{
    [TestFixture]
    public class VariableStateTests
    {
        [TestFixture]
        public class WhenToString
        {
            [Test]
            public void ShouldReturnVariableState()
            {
                var variableState = new VariableState(34);

                Assert.AreEqual("34", variableState.ToString());
            }
        }
    }
}