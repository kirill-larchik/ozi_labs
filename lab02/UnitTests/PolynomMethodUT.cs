using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomMethodLibrary;

namespace UnitTests
{
    [TestClass]
    public class PolynomMethodUT
    {
        [TestMethod]
        public void EncryptionAndDecryption()
        {
            string expected = "ПРИКАЗ";

            PolynomMethod polynomMethod = new PolynomMethod();

            polynomMethod.N = 4;
            polynomMethod.P = 991;

            string encryptedMessage = polynomMethod.Encryption(expected);
            string actual = polynomMethod.Decryption(encryptedMessage);

            Assert.AreEqual(expected, actual);
        }
    }
}
