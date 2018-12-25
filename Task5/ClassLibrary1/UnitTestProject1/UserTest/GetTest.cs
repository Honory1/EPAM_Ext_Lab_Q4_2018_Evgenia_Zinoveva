namespace ClassLibrary1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var user = new User();
            user.LoadUser();

            var input = 1;
            var exeptedOutput = "john";
            var actualOutput = user.Get(input).name;
            Assert.AreEqual(exeptedOutput, actualOutput);
        }
    }
}