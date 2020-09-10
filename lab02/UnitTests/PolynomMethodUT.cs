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

        [TestMethod]
        [ExpectedException(typeof(Exception), "Неверный формат последовательности чисел.")]
        public void EncryptionAndDecryption_FirstException()
        {
            string expected = "ПРИКАЗ";

            PolynomMethod polynomMethod = new PolynomMethod();

            polynomMethod.N = 0;
            polynomMethod.P = 991;

            string encryptedMessage = polynomMethod.Encryption(expected);
            string actual = polynomMethod.Decryption(encryptedMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Неверный формат большого простого числа.")]
        public void EncryptionAndDecryption_SecondException()
        {
            string expected = "ПРИКАЗ";

            PolynomMethod polynomMethod = new PolynomMethod();

            polynomMethod.N = 4;
            polynomMethod.P = 0;

            string encryptedMessage = polynomMethod.Encryption(expected);
            string actual = polynomMethod.Decryption(encryptedMessage);

            Assert.AreEqual(expected, actual);


        }
    }
}
