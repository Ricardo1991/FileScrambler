using System;

namespace FileScrambler
{
    class Program
    {
        static void Main(string[] args)
        {

            string word = "test string wew";
            string keyword = "asffdgersgrrrgszgds";

            Console.WriteLine("Encode \"" + word + "\" with key: " + keyword);

            string result = StringScrambler.Encode(word, keyword);

            Console.WriteLine("Result: " + result);


            string decode = StringScrambler.Decode(result, keyword);

            Console.WriteLine("Decoded: " + decode);


            Console.Write("\nPress any key to exit.");
            Console.ReadKey();

        }
    }
}
