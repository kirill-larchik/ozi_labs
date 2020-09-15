using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGridLibrary
{
    public class CardanoGrid
    {
        int[,] cryptArray =
        {
            {0, 1 },
            {1, 0 },
            {1, 4 },
            {1, 6 },
            {1, 7 },
            {2, 1 },
            {2, 5 },
            {2, 9 },
            {3, 3 },
            {3, 7 },
            {4, 1 },
            {5, 2 },
            {5, 5 },
            {5, 6 },
            {5, 9 },
            {0, 0 },
            {0, 3 },
            {0, 4 },
            {0, 7 },
            {1, 8 },
            {2, 2 },
            {2, 6 },
            {3, 0 },
            {3, 4 },
            {3, 8 },
            {4, 2 },
            {4, 3 },
            {4, 5 },
            {4, 9 },
            {5, 8 },
            {0, 2 },
            {0, 5 },
            {0, 6 },
            {0, 9 },
            {1, 1 },
            {2, 3 },
            {2, 7 },
            {3, 1 },
            {3, 5 },
            {3, 9 },
            {4, 1 },
            {4, 4 },
            {4, 6 },
            {4, 7 },
            {5, 1 },
            {0, 8 },
            {1, 2 },
            {1, 3 },
            {1, 5 },
            {1, 9 },
            {2, 0 },
            {2, 4 },
            {2, 8 },
            {3, 2 },
            {3, 6 },
            {4, 8 },
            {5, 0 },
            {5, 3 },
            {5, 4 },
            {5 ,7 }
        };

        Random random = new Random();

        public string Encryption(string message)
        {
            string[,] table = new string[6, 10];

            int i = 0;
            foreach (char c in message)
            {
                table[cryptArray[i, 0], cryptArray[i, 1]] = c.ToString();
                i++;
            }

            StringBuilder builder = new StringBuilder();
            for (i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == null)
                        builder.Append((char)random.Next(1040, 1104));
                    else
                        builder.Append(table[i, j]);
                }
            }

            return builder.ToString();
        }

        public string Decryption(string message)
        {
            string result = "";
            List<char> t = new List<char>();
            foreach (char c in message)
                t.Add(c);

            for (int i = 0; i < t.Count; i++)
                result += t[cryptArray[i, 0] * 10 + cryptArray[i, 1]];
           
            return result;
        }
    }
}
