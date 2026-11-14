using System;

namespace Program
{
    class HomeWork7
    {
        public static string ReadFileSafely(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                    return null;
                }
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
        }
        public void SearchMail(ref string s)
        {
            if (string.IsNullOrEmpty(s)) return;

            int separatorIndex = s.IndexOf('#');

            if (separatorIndex != -1)
            {
                s = s.Substring(separatorIndex + 1).Trim();
            }
            else
            {
                s = "";
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Пожалуйста, укажите входной и выходной файлы.");
                Console.WriteLine("Пример: dotnet run -- input.txt output.txt");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            string content = ReadFileSafely(inputPath);
            if (content == null) return;

            try
            {
                string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                string[] emails = new string[lines.Length];
                int count = 0;

                foreach (string line in lines)
                {
                    string currentLine = line;
                    HomeWork7 NewMail = new HomeWork7();
                    NewMail.SearchMail(ref currentLine);

                    if (!string.IsNullOrWhiteSpace(currentLine))
                    {
                        emails[count] = currentLine;
                        count++;
                    }
                }

                Array.Resize(ref emails, count);

                File.WriteAllLines(outputPath, emails);

                Console.WriteLine($"Готово! Найдено адресов: {count}. Сохранено в {outputPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке данных или записи файла: {ex.Message}");
            }
        }
    }
}
