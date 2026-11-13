using System;

namespace Program
{
    class HomeWork7
    {
        static string ReverseLetters(string input)
        {
            Stack<char> letters = new Stack<char>();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    letters.Push(c);
            }

            char[] result = input.ToCharArray();
            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                    result[i] = letters.Pop();
            }

            return new string(result);
        }

        public static void Main()
        {
            Console.WriteLine("Введите строк:");
            string text = Console.ReadLine() ?? "";
            Console.WriteLine($"Вывод: {ReverseLetters(text)}");
        }
    }
}