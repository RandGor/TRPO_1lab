using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab_1.Utils
{
    class Extensions
    {

        // разделитель целой и дробной частей
        public const string delim = ",";

        // если символ является числом
        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        // если символ является буквой
        public static bool IsLetter(char c)
        {
            return c >= 'A' && c <= 'F';
        }

        // если символ является буквой или числом
        public static bool IsDigitOrLetter(char c)
        {
            return IsDigit(c) || IsLetter(c);
        }

        // взятие абсолютной величины символа
        public static int GetCharValue(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';

            return c - 'A' + 10;
        }

        // преобразование целого в символ
        public static char GetCharValue(int i)
        {
            if (i >= 0 && i <= 9)
                return (char)(i + '0');

            return (char)(i - 10 + 'A');
        }

        // преобразование целого в символ
        public static bool IfCharOnBase(char c, int p)
        {
            return GetCharValue(c) < p;
        }

        // поиск минимальной системы счисления для заданного числа
        public static int GetMinBase(string t)
        {
            int max = 1;

            foreach (char c in t)
            {
                int next = GetCharValue(c);
                
                if (next > max)
                    max = next;
            }

            return max + 1;
        }

        // удалить все символы в t, не удовлетворяющие системе p, обрезать нули слева
        public static string ClampByBase(string t, int p)
        {
            string output = "";

            // поиск максимальной базы числа
            foreach(char c in t)
            {
                if (!IfCharOnBase(c, p))
                    continue;

                output += c;
            }

            // обрезка всех нулей слева
            int zeroCount = 0;

            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == '0')
                    zeroCount++;

                if (output[i] == delim[0] || output[i] != '0')
                    break;
            }

            if (zeroCount > 1)
                output = output.Substring(zeroCount - 1);

            // удаление самого левого нуля, если число не дробное
            if (output.Length > 1 && output[0] == '0' && output[1] != delim[0])
                output = output.Substring(1);

            // если осталась пустая строка - приводить к нулю
            if (output.Length == 0)
                output = "0";

            return output;
        }
    }
}
