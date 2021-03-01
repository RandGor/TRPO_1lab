using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab_1.Utils
{    
    //Структура для представления записи преобразования
    public class Record
    {
        //исходная система счисления
        public int p1 { get; set; }

        //результирующая система счисления
        public int p2 { get; set; }

        //исходное число
        public string number1 { get; set; }

        //результат
        public string number2 { get; set; }

        //конструктор создания новой записи
        public Record(int p1, int p2, string number1, string number2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.number1 = number1;
            this.number2 = number2;
        }

        //переопределение метода для удобной интерпретации записи
        public override string ToString()
        {
            return String.Format("{0} ({1}) => {2} ({3})", number1, p1, number2, p2);
        }
    }
}
