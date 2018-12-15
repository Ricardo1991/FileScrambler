using System;
using System.Text;

namespace FileScrambler
{
    static class FileScrambler
    {
        private static char[] alphabet = { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        static private char[] GenerateEncodeMap(string keycode)
        {
            char[] scramble = new char[alphabet.Length];
            alphabet.CopyTo(scramble, 0);


            foreach (char c in keycode.ToCharArray())
            {
                if (c % 2 == 0)
                {
                    scramble = scrambleMethodOne(scramble);
                }
                else
                    scramble = scrambleMethodTwo(scramble);
            }


            return scramble;
        }

        static private char[] scrambleMethodTwo(char[] scramble)
        {
            char[] s = new char[scramble.Length];
            scramble.CopyTo(s, 0);

            for (int i = 0; i < s.Length; i = i + 2)
            {
                s[i] = scramble[i + 1];
                s[i + 1] = scramble[i];
            }

            return s;
        }

        static private char[] scrambleMethodOne(char[] scramble)
        {
            char[] s = new char[alphabet.Length];
            alphabet.CopyTo(s, 0);

            s[s.Length - 1] = scramble[0];
            for (int i = s.Length-2; i >= 0; i--)
            {
                s[i] = scramble[i + 1];
            }

            return s;
        }

        static public string Encode(string original, string keycode)
        {
            char[] scramble = GenerateEncodeMap(keycode);
            StringBuilder encoded = new StringBuilder();

            original = original.ToLower();

            foreach(char c in original.ToCharArray())
            {
                try
                {
                    encoded.Append(scramble[findPosition(c, alphabet)]);
                }
                catch (Exception ex)
                {
                    encoded.Append(c);
                }
            }


            return encoded.ToString();
        }

        static public string Decode(string encoded, string keycode)
        {
            char[] scramble = GenerateEncodeMap(keycode);
            StringBuilder decoded = new StringBuilder();

            foreach (char c in encoded.ToCharArray())
            {
                try
                {
                    decoded.Append(alphabet[findPosition(c, scramble)]);
                }
                catch (Exception ex){
                    decoded.Append(c);
                }
                
            }

            return decoded.ToString();
        }

        static private int findPosition(char c, char[] scrambled)
        {
            for(int i = 0; i < scrambled.Length;i++)
            {
                if (scrambled[i] == c)
                    return i;
            }

            throw new Exception("Not found");
        }


    }
}
