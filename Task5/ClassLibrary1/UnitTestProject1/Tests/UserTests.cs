namespace ClassLibrary1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserTests 
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

        public void TestMethodDelete()
        {
            var user = new User();
            user.LoadUser();

            var input = 3;
            var exeptedOutput = false;
            var actualOutput = user.Delete(input);
            Assert.AreEqual(exeptedOutput, actualOutput);
        }

        public void TestMethodGet()
        {
            var user = new User();
            user.LoadUser();

            var input = 1;
            var exeptedOutput = "john";
            var actualOutput = user.Get(input).name;
            Assert.AreEqual(exeptedOutput, actualOutput);
        }

        public void TestMethodSave()
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