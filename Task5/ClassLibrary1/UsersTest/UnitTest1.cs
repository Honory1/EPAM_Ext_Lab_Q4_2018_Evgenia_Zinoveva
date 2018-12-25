using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace ClassLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var input = 1;
            var exeptedOutput = 2;
            var actualOutput = ClassLibrary1.User.
            Assert.AreEqual(exeptedOutput, actualOutput);
        }
    }
}
