using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab_1.Utils
{
    class Conver_10_p
    {
        // точность вычисления
        public const int accuracy = 16;


        //Преобразовать десятичное целое в с.сч. с основанием р.
        public static string int_to_P(int n, int p)
        {
            string result = "";
            string result1 = "";

            while (n >= p)
            {
                result1 += Extensions.GetCharValue(n % p);
                n = n / p;
            }
            result1 += Extensions.GetCharValue(n);

            for (int i = 0; i < result1.Length; i++)
            {
                result += result1[result1.Length - i - 1];
            }
            return result;
        }

        //Преобразовать десятичную дробь в с.сч. с основанием р.
        public static string flt_to_P(double n, int p, int c)
        {
            string result = "";
            double S = n;
            int k = 0;

            while (S != 0 && k < c)
            {
                double a = p * S;
                int Z = Convert.ToInt32(a);
                if ((double)Z > a)
                    Z--;
                S = a - (double)Z;
                result += Extensions.GetCharValue(Z);
                k++;
            }
            return result;
        }

        //Преобразовать десятичное 
        //действительное число в с.сч. с осн. р.
        public static string Do(double n, int p)
        {
            int Z = Convert.ToInt32(n); // целая часть изменяемого числа

            // проверка, округлилось ли число в правильную сторону
            if ((double)Z > n)
                Z--;

            // получаем дробную часть числа
            double R = n - (double)Z;

            if (R == 0)
                return int_to_P((int)Z, p);
            else
            {
                string result = int_to_P((int)Z, p);
                result += Extensions.delim + flt_to_P(R, p, accuracy);
                return result;
            }
        }
    }

}