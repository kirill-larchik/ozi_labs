using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace СryptographyLibrary
{
    public class Cryptography
    {
        public Dictionary<int, char> keyValuePairs { get; private set; }

        //TODO: цифры нужно кодировать?
        private char[] letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФЧЦЧШЪЩЬЭЮЯабвгдеёжзийклмнопрстуфхцчшъщьэюя1234567890 .,!?:;-".ToCharArray();

        public Cryptography()
        {
            keyValuePairs = new Dictionary<int, char>();
            GetKeyValuePairs();
        }

        private void GetKeyValuePairs()
        {
            Random random = new Random();
            List<int> randomList = new List<int>();

            for(int i = 0; i < letters.Length; i++)
            {
                while (true)
                {
                    int number = random.Next(0, 128);
                    if (!randomList.Contains(number))
                    {
                        randomList.Add(number);

                        keyValuePairs.Add(number, letters[i]);

                        break;
                    }
                }
            }
        }

        public string Encryption(string message)
        {
            StringBuilder builder = new StringBuilder();

            char[] messageCharArray = message.ToCharArray();

            for(int i = 0; i < messageCharArray.Length; i++)
            {
                try
                {

                    int key = keyValuePairs.First(x => x.Value == messageCharArray[i]).Key;

                    builder.Append(key);
                    builder.Append(" ");
                }
                catch
                {
                    throw new Exception("Неверный формат сообщения.");
                }
            }

            // Removes last space in the builder.
            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }

        public string Decryption(string encryptedMessage)
        {
            StringBuilder builder = new StringBuilder();

            int[] keys = encryptedMessage.Split(' ').Select(k => int.Parse(k)).ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                if (keyValuePairs.ContainsKey(keys[i]))
                    builder.Append(keyValuePairs[keys[i]]);
                else
                    throw new Exception("Неверный формат сообщения.");
            }

            return builder.ToString();
        }

    }
}
