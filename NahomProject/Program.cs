using System;
using System.Collections.Generic;



namespace NahomProject
{
    public class Program
    {
        private static char[] _punctuations = {
            ',', ';', ':', '?', '!','-','\\','\"', ' ', '.',
            '/','@','#','$','%', '&','(',')','{','}'
            };
        public static bool contains(char a, char[] arr)
        {
            foreach (char x in arr)
            {
                if (x == a)
                    return true;
            }
            return false;
        }
        static string RemovePunctuationAndSpace(string input)
        {
            //declar stack of char type
            Stack<char> stringtWithOutPunctuationAndSpace = new Stack<char>();

            for (int i = input.Length - 1; i>=0; i--)
            {
                var character = input[i];

                if (!contains(character,_punctuations))
                {
                    stringtWithOutPunctuationAndSpace.Push(character);
                }

            }
            return string.Join(string.Empty, stringtWithOutPunctuationAndSpace);
        }
        public static void Main(string[] args)
        {
            // Ask string input from user
            Console.WriteLine("Enter string: ");

            //read user input
            String str = Console.ReadLine(); ;

            // apply the method that remove punctaution and space
            // and return string
            String processedString = RemovePunctuationAndSpace(str);

           
            Console.WriteLine("A string without Puctuation is : " + processedString);
            
            Console.ReadKey();

        }

    }
}

