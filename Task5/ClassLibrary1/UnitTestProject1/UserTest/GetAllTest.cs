namespace ClassLibrary1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetAllTest
    {
        [TestMethod]
        public void TestMethodGetAll()
        {
            var user = new User();
            user.LoadUser();
            var exeptedOutput = 2;
            var actualOutput = user.GetAll().Count;
            Assert.AreEqual(exeptedOutput, actualOutput);
        }
    }
}
