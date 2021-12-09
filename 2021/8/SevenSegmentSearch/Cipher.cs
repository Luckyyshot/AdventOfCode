using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSegmentSearch
{
    class Cipher
    {
        string[] cipher;
        readonly string[] numbers;

        public Cipher(string[] cipher, string[] numbers)
        {
            this.cipher = cipher;
            this.numbers = numbers;
            DetermineCipher();
        }

        public Cipher(string[] numbers)
        {
            this.cipher = Enumerable.Repeat("acedgfb", 7).ToArray();
            this.numbers = numbers;
            DetermineCipher();
        }

        public int DetermineNumber(string[] input)
        {
            return DetermineSingleNumber(cipher, input[0]) * 1000 +
                   DetermineSingleNumber(cipher, input[1]) * 100 +
                   DetermineSingleNumber(cipher, input[2]) * 10 +
                   DetermineSingleNumber(cipher, input[3]);
        }

        void DetermineCipher()
        {
            string one = numbers.First(x => x.Length == 2), seven = numbers.First(x => x.Length == 3), four = numbers.First(x => x.Length == 4);
            string three = numbers.First(x => x.Length == 5 && seven.All(y => x.Contains(y)));

            cipher = DetermineCipherFromKnownNumber(cipher, GetIntArr(1), one);
            cipher = DetermineCipherFromKnownNumber(cipher, GetIntArr(7), seven);
            cipher = DetermineCipherFromKnownNumber(cipher, GetIntArr(4), four);
            cipher = DetermineCipherFromKnownNumber(cipher, GetIntArr(3), three);

            foreach (var num in numbers)
            {
                if (num.Length == 5)
                {
                    string contained = one.First(x => num.Contains(x)).ToString();
                    int count = 0;
                    foreach (var num2 in numbers)
                    {
                        if (num2.Contains(contained))
                            count++;
                    }
                    if (count == 8)
                    {
                        cipher[2] = contained;
                        cipher[5] = cipher[5].First(x => x != contained.ToCharArray()[0]).ToString();
                    }
                }
            }
            if (!TrueCipher())
                throw new Exception();
        }

        static string[] DetermineCipherFromKnownNumber(string[] currentPossible, int[] numberIndexes, string num)
        {
            string[] result = (string[])currentPossible.Clone();
            for (int i = 0; i < 7; i++)
            {
                if (numberIndexes.Contains(i))
                {
                    result[i] = RemoveCharsNotPresent(result[i], num);
                }
                else
                {
                    foreach (var chr in num)
                    {
                        result[i] = result[i].Replace(chr.ToString(), "");
                    }
                }
            }
            return result;
        }

        static string RemoveCharsNotPresent(string input, string conditionalChars)
        {
            string result = input;
            for (int i = 0; i < input.Length; i++)
            {
                if (!conditionalChars.Contains(input[i]))
                    result = result.Replace(input[i].ToString(), "");
            }
            return result;
        }

        bool TrueCipher()
        {
            return cipher.All(x => x.Length == 1);
        }

        static int DetermineSingleNumber(string[] cipher, string num)
        {
            if (num.Length == 2)
                return 1;

            else if (num.Length == 3)
                return 7;

            else if (num.Length == 4)
                return 4;

            else if (num.Length == 7)
                return 8;

            else if (num.Length == 6 && num.Contains(cipher[0]) && num.Contains(cipher[1]) && num.Contains(cipher[2])
                     && num.Contains(cipher[4]) && num.Contains(cipher[5]) && num.Contains(cipher[6]))
                return 0;

            else if (num.Length == 5 && num.Contains(cipher[0]) && num.Contains(cipher[2]) && num.Contains(cipher[3])
                     && num.Contains(cipher[4]) && num.Contains(cipher[6]))
                return 2;

            else if (num.Length == 5 && num.Contains(cipher[0]) && num.Contains(cipher[2]) && num.Contains(cipher[3])
                     && num.Contains(cipher[5]) && num.Contains(cipher[6]))
                return 3;

            else if (num.Length == 5 && num.Contains(cipher[0]) && num.Contains(cipher[1]) && num.Contains(cipher[3])
                     && num.Contains(cipher[5]) && num.Contains(cipher[6]))
                return 5;

            else if (num.Length == 6 && num.Contains(cipher[0]) && num.Contains(cipher[1]) && num.Contains(cipher[3])
                     && num.Contains(cipher[4]) && num.Contains(cipher[5]) && num.Contains(cipher[6]))
                return 6;

            else if (num.Length == 6 && num.Contains(cipher[0]) && num.Contains(cipher[1]) && num.Contains(cipher[2])
                     && num.Contains(cipher[3]) && num.Contains(cipher[5]) && num.Contains(cipher[6]))
                return 9;

            else
                throw new Exception();
        }

        static int[] GetIntArr(int num)
        {
            return num switch
            {
                0 => new int[] { 0, 1, 2, 4, 5, 6 },
                1 => new int[] { 2, 5 },
                2 => new int[] { 0, 2, 3, 4, 6 },
                3 => new int[] { 0, 2, 3, 5, 6 },
                4 => new int[] { 1, 2, 3, 5 },
                5 => new int[] { 0, 1, 3, 5, 6 },
                6 => new int[] { 0, 1, 3, 4, 5, 6 },
                7 => new int[] { 0, 2, 5 },
                8 => new int[] { 0, 1, 2, 3, 4, 5, 6 },
                9 => new int[] { 0, 1, 2, 3, 5, 6 },
                _ => throw new Exception(),
            };
        }
    }
}
