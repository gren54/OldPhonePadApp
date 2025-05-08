using Microsoft.VisualStudio.TestTools.UnitTesting;
using OldPhonePadApp;

namespace OldPhonePadTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSingleLetter()
        {
            Assert.AreEqual("E", OldPhonePadConverter.OldPhonePad("33#"));
        }

        [TestMethod]
        public void TestWithBackspace()
        {
            Assert.AreEqual("B", OldPhonePadConverter.OldPhonePad("227*#"));
        }

        [TestMethod]
        public void TestWordHello()
        {
            Assert.AreEqual("HELLO", OldPhonePadConverter.OldPhonePad("4433555 555666#"));
        }

        [TestMethod]
        public void TestComplexCase()
        {
            Assert.AreEqual("TOM", OldPhonePadConverter.OldPhonePad("8 88777444666*664#"));
        }

        [TestMethod]
        public void TestEmptyInput()
        {
            Assert.AreEqual("", OldPhonePadConverter.OldPhonePad("#"));
        }
    }
}