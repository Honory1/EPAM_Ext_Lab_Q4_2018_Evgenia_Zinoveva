namespace ClassLibrary1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SaveTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var user = new User();
            user.LoadUser();

            var input = user.Get(1);
            var exeptedOutput = false;
            var actualOutput = user.Save(input);
            Assert.AreEqual(exeptedOutput, actualOutput);
        }
    }
}
