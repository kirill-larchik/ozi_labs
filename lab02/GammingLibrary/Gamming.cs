using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GammingLibrary
{
    public class Gamming
    {
        private char[] letters = "АБВГДЕЁЖЗИЙ".ToCharArray();
        private Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

        private Regex regex = new Regex(@"^[А-ЙЁ]+$");
        private string _key;
        private int[] keyValues;

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                if (regex.IsMatch(value))
                {
                    _key = value;
                    keyValues = GetValues(value);
                }
                else
                    throw new Exception("Неверный формат кода.");
            }
        }

        public Gamming(string key)
        {
            FillKeyValuePairs();
            Key = key;
        }

        private void FillKeyValuePairs()
        {
            for (int i = 0; i < letters.Length; i++)
                keyValuePairs.Add(letters[i], i);
        }

        private int[] GetValues(string word)
        {
            int[] values = new int[word.Length];

            char[] wordLetters = word.ToCharArray();

            for (int i = 0; i < wordLetters.Length; i++)
            {
                foreach (KeyValuePair<char, int> pair in keyValuePairs)
                {
                    if (wordLetters[i] == pair.Key)
                    {
                        values[i] = pair.Value;
                    }
                }
            }

            return values;
        }

        private string GetMessage(int[] values)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                foreach (KeyValuePair<char, int> pair in keyValuePairs)
                {
                    if (values[i] == pair.Value)
                        builder.Append(pair.Key);
                }
            }

            return builder.ToString();
        }

        public string Encryption(string message)
        {
            if (message.Length != Key.Length)
                throw new Exception("Сообщение и ключ должны быть одинаковый длины.");

            if (!regex.IsMatch(message))
                throw new Exception("Неверный формат сообщения.");

            int[] values = GetValues(message);

            int[] newValues = new int[message.Length];
            for (int i = 0; i < newValues.Length; i++)
                newValues[i] = (values[i] + keyValues[i]) % keyValuePairs.Count;

            return GetMessage(newValues);
        }

        public string Decryption(string message)
        {
            if (message.Length != Key.Length)
                throw new Exception("Сообщение и ключ должны быть одинаковый длины.");

            if (!regex.IsMatch(message))
                throw new Exception("Неверный формат сообщения.");

            int[] values = GetValues(message);

            int[] newValues = new int[message.Length];
            for (int i = 0; i < newValues.Length; i++)
                newValues[i] = (values[i] + keyValuePairs.Count - keyValues[i]) % keyValuePairs.Count;

            return GetMessage(newValues);
        }
    }
}
