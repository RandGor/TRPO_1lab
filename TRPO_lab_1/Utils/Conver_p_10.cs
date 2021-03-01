using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab_1.Utils
{
    class Conver_p_10
    {

        //Преобразовать строку в число
        private static double convert(string P_num, int P, int step)
        {
            double result = 0;
            int s = step;

            // суммируем к результату числа до запятой
            for (int i = 0; i < step + 1; i++)
            {
                result += Extensions.GetCharValue(P_num[i]) * Math.Pow(P, s);
                s--;
            }

            // суммируем к результату числа после запятой
            for (int i = step + 2; i < P_num.Length; i++)
            {
                result += Extensions.GetCharValue(P_num[i]) * Math.Pow(P, s);
                s--;
            }

            return result;

        }

        //Преобразовать из с.сч. с основанием р 
        //в с.сч. с основанием 10.
        public static double dval(string P_num, int P)
        {
            double result;
            int i = 0;

            // определяется позиция запятой
            while (i < P_num.Length && P_num[i] != Extensions.delim[0])
            {
                i++;
            }

            // отправляем число на преобразование
            result = convert(P_num, P, i - 1);

            return result;

        }


    }
}
