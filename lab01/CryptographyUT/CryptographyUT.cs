using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using СryptographyLibrary;
using PolybiusSquareLibrary;

namespace CryptographyUT
{
    [TestClass]
    public class CryptographyUT
    {
        [DataTestMethod]
        [DataRow("1 2 3 45 66 что-то там.")]
        [DataRow("Привет, мир!")]
        [DataRow("Тест, тест, и ещё раз тест!!!")]
        public void EncryptionAndDecryption(string expected)
        {
            Cryptography cryptography = new Cryptography();

            string encryptedMessage = cryptography.Encryption(expected);
            string actual = cryptography.Decryption(encryptedMessage);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("Hello, world!")]
        [DataRow("Test, test, and more test!!!")]
        public void EncryptionAndDecryption_Exeption(string expected)
        {
            Cryptography cryptography = new Cryptography();

            string encryptedMessage = cryptography.Encryption(expected);
            string actual = cryptography.Decryption(encryptedMessage);

            Assert.AreEqual(expected, actual);
        }
    }
}
