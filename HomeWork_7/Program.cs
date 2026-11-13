using System;

namespace Program
{
    class HomeWork7
    {
        static bool ImplementsIFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formattable = obj as IFormattable;

                if (formattable != null)
                {
                    Console.WriteLine($"Объект типа {obj.GetType().Name} реализует IFormattable.");
                    return true;
                }
            }

            Console.WriteLine($"Объект типа {obj?.GetType().Name ?? "null"} НЕ реализует IFormattable.");
            return false;
        }

        public static void Main()
        {
            object[] testObjects =
            {
            42,
            3.14,
            123.45m,
            'A',
            true,
            "Hello",
            };

            Console.WriteLine("Проверка реализации интерфейса IFormattable:\n");

            foreach (object obj in testObjects)
            {
                bool result = ImplementsIFormattable(obj);
                Console.WriteLine($"Результат: {result}\n");
            }
        }
    }
}
