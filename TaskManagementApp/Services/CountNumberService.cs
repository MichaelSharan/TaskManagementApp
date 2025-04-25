public class CountNumberService
{
    public string CalculateLargestOddNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "NO";
        }

        List<char> digits = GetSortedDigits(input);

        int oddIndex = FindLastOddDigitIndex(digits);

        if (oddIndex == -1)
        {
            return "NO";
        }

        char oddDigit = digits[oddIndex];
        digits.RemoveAt(oddIndex);

        string result = CreateLargestOddNumber(digits, oddDigit);

        return string.IsNullOrEmpty(result) ? "NO" : result;
    }

    private static List<char> GetSortedDigits(string input)
    {
        List<char> digits = input.ToList();
        digits.Sort((a, b) => b.CompareTo(a));
        return digits;
    }

    public static int FindLastOddDigitIndex(List<char> digits)
    {
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            if ((digits[i] - '0') % 2 == 1)
            {
                return i;
            }
        }
        return -1;
    }

    public static string CreateLargestOddNumber(List<char> digits, char oddDigit)
    {
        string result = new string(digits.ToArray()) + oddDigit;
        return result.TrimStart('0'); // Убираем ведущие нули
    }
}
