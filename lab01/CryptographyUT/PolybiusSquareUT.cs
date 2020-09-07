using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolybiusSquareLibrary;

namespace CryptographyUT
{
    [TestClass]
    public class PolybiusSquareUT
    {
        [DataTestMethod]
        [DataRow("ТЕСТ")]
        [DataRow("ТЕСТОВЫЙ ТЕСТ")]
        [DataRow("ЕЩЁ ТЕСТОВЫЙ ТЕСТ")]
        public void EncryptionAndDecryption(string expected)
        {
            PolybiusSquare polybius = new PolybiusSquare();

            string encryptedMessage = polybius.Encryption(expected);
            string actual = polybius.Decryption(encryptedMessage);

            Assert.AreEqual(expected, actual);
        }
    }
}
