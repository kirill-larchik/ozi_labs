using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PolynomMethodLibrary
{
    public class PolynomMethod
    {
        private Regex regex = new Regex(@"^[А-ЯЁ]+$");
        private Regex numberRegex = new Regex(@"[0-9]+\s?");

        private char[] letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        private Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

        private Dictionary<char, int> newKeyValuePairs = new Dictionary<char, int>();

        private int _n;
        public int N 
        {
            get
            {
                return _n;
            }
            set
            {
                if (value > 3)
                {
                    _n = value;
                    
                }
                else
                    throw new Exception("Неверный формат последовательности чисел.");
            }
        }

        private int _p;
        public int P
        {
            get
            {
                return _p;
            }
            set
            {
                if (value > 0)
                {
                    _p = value;
                }
                else
                    throw new Exception("Неверный формат большого простого числа.");
            }
        }


        public PolynomMethod()
        {
            _n = 1;
            _p = 1;

            FillKeyValuePairs();
        }

        private void FillKeyValuePairs()
        {
            for (int i = 0; i < letters.Length; i++)
                keyValuePairs.Add(letters[i], i + 1);
        }

        private void FillNewValueKeyPairs()
        {
            newKeyValuePairs.Clear();
            foreach (KeyValuePair<char, int> pair in keyValuePairs)
            {
                newKeyValuePairs.Add(pair.Key, Function(pair.Value));
            }
        }

        private int Function(int value)
        {
            int sum = 0;
            for (int i = 0; i < _n; i++)
            {
                if (value < 1)
                    throw new Exception("Неверный формат большого простого числа.");

                sum += (int)(i * Math.Pow(value, _n - i));
            }
            sum = (sum + _n) % _p;
                
            if (sum > _p || sum < 1)
                throw new Exception("Неверный формат чисел (n и p)."); 

            return sum;
        }

        private int[] GetValues(string word)
        {
            int[] values = new int[word.Length];

            char[] wordLetters = word.ToCharArray();

            for (int i = 0; i < wordLetters.Length; i++)
            {
                foreach (KeyValuePair<char, int> pair in newKeyValuePairs)
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
                foreach (KeyValuePair<char, int> pair in newKeyValuePairs)
                {
                    if (values[i] == pair.Value)
                        builder.Append(pair.Key);
                }
            }

            return builder.ToString();
        }

        public string Encryption(string message)
        {
            FillNewValueKeyPairs();

            if (!regex.IsMatch(message))
                throw new Exception("Неверный формат сообщения.");

            int[] values = GetValues(message);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                //if (i == values.Length - 1)
                //    builder.Append(Function(values[i]));
                //else
                //    builder.Append(Function(values[i]) + " ");
                if (i == values.Length - 1)
                    builder.Append(values[i]);
                else
                    builder.Append(values[i] + " ");
            }

            return builder.ToString();
        }

        public string Decryption(string message)
        {
            FillNewValueKeyPairs();

            if (!numberRegex.IsMatch(message))
                throw new Exception("Неверный формат сообщения.");

            int[] values = message.Split(' ').Select(s => int.Parse(s)).ToArray();
            return GetMessage(values);
        }
    }
}
