namespace ClassLibrary1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var user = new User();
            user.LoadUser();

            var input = 3;
            var exeptedOutput = false;
            var actualOutput = user.Delete(input);
            Assert.AreEqual(exeptedOutput, actualOutput);
        }
    }
}