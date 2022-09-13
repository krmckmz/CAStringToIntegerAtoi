using System;

class Program
{
    static public void Main(string[] args)
    {
        string text = "20000000000000000000";
        int result = MyAtoi(text);
        Console.WriteLine(result);
        Console.Read();
    }

    public static int MyAtoi(string s)
    {
        s = s.Trim();
        bool isNumberNegative = false;
        int zero = default(int);
        long number = zero;
        int ten = 10;

        if (string.IsNullOrEmpty(s))
            return zero;

        if (s[zero] is '-')
        {
            isNumberNegative = true;
            s = s.Remove(zero, 1);
            if (string.IsNullOrEmpty(s) || s.Any(x => x == '+') || s.Any(x => x == '-'))
                return zero;
        }

        if (s[zero] is '+')
        {
            s = s.Remove(zero, 1);
            if (string.IsNullOrEmpty(s) || s.Any(x => x == '+') || s.Any(x => x == '-'))
                return zero;
        }


        if (!char.IsDigit(s[zero]) && s[zero] != '-')
            return default(int);

        foreach (char c in s)
            if (char.IsDigit(c) && number <= Int32.MaxValue)
            {
                number += (int)char.GetNumericValue(c);
                number *= ten;
            }
            /*else if (char.IsPunctuation(c))
                break;*/
            else
                break;

        number /= ten;

        if (isNumberNegative)
            number *= -1;

        if (number > Int32.MaxValue)
            return Int32.MaxValue;
        else if (number < Int32.MinValue)
            return Int32.MinValue;
        else
            return (int)number;
    }
}