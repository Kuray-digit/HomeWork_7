using System;
using System.IO;
using System.Reflection.Metadata;

///dotnet run -- input.txt output.txt
namespace Program
{
    class HomeWork7
    {
        public static string HasErrors(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                    return "";
                }

                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return "";
            }
        }
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Пожалуйста, укажите путь к файлу в качестве аргумента.");
                return;
            }
            string inputPath = args[0];
            string outputPath = args[1];
            string content = HasErrors(inputPath);
            if (content == "") return;
            else
            {
                string upperContent = content.ToUpper();
                File.WriteAllText(outputPath, upperContent);
                Console.WriteLine("Готово");
            }
        }
    }
}