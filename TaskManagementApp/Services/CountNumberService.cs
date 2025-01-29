using System.Diagnostics;

public class CountNumberService
{
    private readonly string _pythonPath = "python"; // Убедись, что Python доступен в PATH
    private readonly string _scriptPath = "count_number.py"; // Путь к Python-скрипту

    public int CalculateOutput(int inputValue)
    {
        try
        {
            // Запускаем Python-скрипт с аргументом
            var processStartInfo = new ProcessStartInfo
            {
                FileName = _pythonPath,
                Arguments = $"{_scriptPath} {inputValue}",
                RedirectStandardOutput = true, // Перенаправление вывода в C#
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();
                string result = process.StandardOutput.ReadToEnd(); // Читаем результат
                process.WaitForExit();

                return int.Parse(result.Trim()); // Конвертируем в число
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при вызове Python: {ex.Message}");
            return -1; // Возвращаем ошибку
        }
    }
}
