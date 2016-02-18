using System;
using NUnit.Framework;
using System.IO;

namespace TicTacToe.Tests.TestHelper
{
    [TestFixture]
    public class TestHelperTest
    {
        [Test]
        public void Custom_Input_Stream()
        {
            TestHelper testHelper = new TestHelper();
            testHelper.InputStream("Robert");
            Assert.AreEqual("Robert", testHelper.SpecificInput(0));
        }
    }
}
