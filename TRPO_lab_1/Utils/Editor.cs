using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab_1.Utils
{
    class Editor
    {
        // поле для хранения редактируемого числа
        public string number = "0";

        // поле для хранения результирующего числа
        public string result = "0";

        // добавить символ
        public string AddDigit(char ch)
        {
            if (ch == '0')
            {
                if (number == "0")
                    return number;

                number += ch;
                return number;
            }
            else
            {
                if (ch == 46 || ch == 44 || (ch >= 48 && ch <= 57) || (ch >= 65 && ch <= 70))
                {
                    if (number == "0") 
                        number = ch.ToString();
                    else number += ch;

                    return number;
                }
            }

            return number;
        }

        // добавить разделитель
        public string AddDelim()
        {
            for (int i = 0; i < number.Length; i++)
                if (number[i] == Extensions.delim[0])
                    return number;

            number += Extensions.delim[0];
            return number;
        }

        // удалить символ справа
        public string Bs()
        {
            string a = "";

            for (int i = 0; i < number.Length - 1; i++)
            {
                a += number[i];
            }
            number = a;

            if (number == "") number = "0";

            return number;
        }

        // очистить редактируемое число
        public string Clear()
        {
            number = "0";

            return number;
        }

    }

}
