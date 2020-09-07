using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PolybiusSquareLibrary
{
    public class PolybiusSquare
    {
        Regex regex = new Regex(@"(^|\s)[а-яА-Я]+");

        private char[,] polybiusSquare = new char[,]
        {
            { 'А', 'Б', 'В', 'Г', 'Д', 'Е' },
            { 'Ё', 'Ж', 'З', 'И', 'Й', 'К' },
            { 'М', 'Л', 'Н', 'О', 'П', 'Р' },
            { 'С', 'Т', 'У', 'Ф', 'Х', 'Ц' },
            { 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь' },
            { 'Э', 'Ю', 'Я', '-', '-', '-' }
        };

        public string Encryption(string message)
        {
            if (!regex.IsMatch(message))
                throw new Exception("Неверный формат сообщения.");

            string[] words = message.Split(' ');
            string[] encryptedWords = new string[words.Length];

            // Get horizontal and vertical coordinates.
            for (int i = 0; i < words.Length; i++)
            {
                string encryptedWord = EncrypteWord(words[i]);

                if (i == words.Length - 1)
                    encryptedWords[i] = encryptedWord;
                else
                    encryptedWords[i] = encryptedWord + " ";
            }

            return string.Join(null, encryptedWords);
        }

        public string Decryption(string encryptedMessage)
        {
            if (!regex.IsMatch(encryptedMessage))
                throw new Exception("Неверный формат сообщения.");

            string[] words = encryptedMessage.Split(' ');
            string[] decryptedWords = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                string decryptedWord = DecrypteWord(words[i]);

                if (i == words.Length - 1)
                    decryptedWords[i] = decryptedWord;
                else
                    decryptedWords[i] = decryptedWord + " ";
            }

            return string.Join(null, decryptedWords);
        }

        private string EncrypteWord(string word)
        {
            int[] verticalCoordinate = new int[word.Length];
            int[] horizontalCoordinate = new int[word.Length];

            char[] letters = word.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < polybiusSquare.GetLength(0); j++)
                {
                    for (int k = 0; k < polybiusSquare.GetLength(1); k++)
                    {
                        if (polybiusSquare[j, k] == letters[i])
                        {
                            verticalCoordinate[i] = j;
                            horizontalCoordinate[i] = k;
                        }
                    }
                }
            }

            int[] indexs = verticalCoordinate.Concat(horizontalCoordinate).ToArray();
            StringBuilder builder = new StringBuilder();

            for (int j = 0; j < indexs.Length - 1; j += 2)
            {
                builder.Append(polybiusSquare[indexs[j], indexs[j + 1]]);
            }

            return builder.ToString();
        }

        private string DecrypteWord(string word)
        {
            int[] verticalCoordinate = new int[word.Length];
            int[] horizontalCoordinate = new int[word.Length];

            char[] letters = word.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < polybiusSquare.GetLength(0); j++)
                {
                    for (int k = 0; k < polybiusSquare.GetLength(1); k++)
                    {
                        if (polybiusSquare[j, k] == letters[i])
                        {
                            verticalCoordinate[i] = j;
                            horizontalCoordinate[i] = k;
                        }
                    }
                }
            }

            int[] indexs = new int[letters.Length * 2];
            int state = 0;
            for (int i = 0; i < indexs.Length - 1; i+=2)
            {
                indexs[i] = verticalCoordinate[state];
                indexs[i + 1] = horizontalCoordinate[state];
                state++;
            }

            StringBuilder builder = new StringBuilder();
            for (int j = 0; j < indexs.Length / 2; j ++)
            {
                builder.Append(polybiusSquare[indexs[j], indexs[indexs.Length / 2 + j]]);
            }

            return builder.ToString();
        }
    }
}
