using System;
using System.Linq;
using System.Collections.Generic;

public class CountNumberService
{
    public string CalculateLargestOddNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "NO";
        }

        List<char> digits = input.ToList();
        digits.Sort((a, b) => b.CompareTo(a)); // Быстрая сортировка по убыванию

        int oddIndex = -1;
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            if ((digits[i] - '0') % 2 == 1)
            {
                oddIndex = i;
                break;
            }
        }

        if (oddIndex == -1)
        {
            return "NO";
        }

        char oddDigit = digits[oddIndex];
        digits.RemoveAt(oddIndex); // Быстрее, чем сдвиг элементов

        string result = new string(digits.ToArray()) + oddDigit;
        result = result.TrimStart('0');

        return string.IsNullOrEmpty(result) ? "NO" : result;
    }
}
