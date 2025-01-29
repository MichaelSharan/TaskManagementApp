using System;
using System.Linq;

public class CountNumberService
{
    public string CalculateLargestOddNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "NO";
        }

        // Преобразуем строку в массив символов и сортируем по убыванию
        char[] digits = input.OrderByDescending(c => c).ToArray();

        // Ищем первую нечётную цифру с конца массива
        int oddIndex = -1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if ((digits[i] - '0') % 2 == 1) // Преобразуем в число и проверяем на нечётность
            {
                oddIndex = i;
                break;
            }
        }

        // Если нечётной цифры нет, возвращаем "NO"
        if (oddIndex == -1)
        {
            return "NO";
        }

        // Перемещаем нечётную цифру в конец массива
        char oddDigit = digits[oddIndex];
        for (int i = oddIndex; i < digits.Length - 1; i++)
        {
            digits[i] = digits[i + 1];
        }
        digits[digits.Length - 1] = oddDigit;

        // Убираем ведущие нули
        string result = new string(digits).TrimStart('0');

        return string.IsNullOrEmpty(result) ? "NO" : result;
    }
}
