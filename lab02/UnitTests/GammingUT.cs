using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GammingLibrary;

namespace UnitTests
{
    [TestClass]
    public class GammingUT
    {
        [DataTestMethod]
        [DataRow("АБВГДЕЁЖЗИЙ", "АБВВГЕЕЖЗИЙ")]
        [DataRow("АБВГД", "ДГВБА")]
        [DataRow("ЕЁЖЗИЙ", "ДГВБАЙ")]
        public void Encrypted_Decrypted(string message, string key)
        {
            Gamming gamming = new Gamming(key);
            string encryptedMessage = gamming.Encryption(message);
            string actual = gamming.Decryption(encryptedMessage);

            Assert.AreEqual(message, actual);
        }
    }
}
