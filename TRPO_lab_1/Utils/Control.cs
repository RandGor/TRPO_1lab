using System;
using System.Collections.Generic;

namespace TRPO_lab_1.Utils
{
    public class Control
    {
        //основание системы сч. исходного числа
        public int pIn = 2;

        //основание системы сч. результата
        public int pOut = 2;

        //буфер для хранения промежуточного результата
        private double buffer;

        //объект редактор
        private Editor editor = new Editor();

        //объект история
        private History history = new History();

        //рассчитать результат
        public string Calculate()
        {
            try
            {
                buffer = Conver_p_10.dval(editor.number, pIn);

                editor.result = Conver_10_p.Do(buffer, pOut);

                return editor.result;
            }
            catch
            {
                editor.number = editor.number.Substring(0, editor.number.Length - 1);

                return Calculate();
            }

        }

        //приписать цифру к числу справа
        public void AddDigit(char v)
        {
            if (Extensions.IfCharOnBase(v, pIn))
                editor.AddDigit(v);
        }

        //добавить разделитель
        public void AddDelim()
        {
            editor.AddDelim();
        }

        //удалить правый символ левой части
        public void Bs()
        {
            editor.Bs();
        }

        internal void ClearHistory()
        {
            history.Clear();
        }

        //очистить левую часть
        public void Clear()
        {
            editor.Clear();
        }

        //загрузить результат из истории
        public void LoadHistory(int index)
        {
            //если результата нет в истории - ничего не делать
            if (index >= history.Count())
                return;

            //иначе загрузить результат
            Record historyRecord = history.GetRecord(index);

            pIn = historyRecord.p1;
            pOut = historyRecord.p2;
            editor.number = historyRecord.number1;
            editor.result = historyRecord.number2;
        }

        //поменять местами результат и исходное число
        public void Swap()
        {
            //поменять местами системы счисления
            int oldP = pIn;
            pIn = pOut;
            pOut = oldP;

            //перенести результат в левую часть
            editor.number = editor.result;
        }

        //передача входного числа
        public string GetNumber()
        {
            return editor.number;
        }

        //передача результата
        public string GetResult()
        {
            return editor.result;
        }

        //передача списка истории
        public List<Record> GetHistory()
        {
            return history.GetRecords();
        }

        //сохранение результата
        public void Save()
        {
            history.AddRecord(pIn, pOut, editor.number, editor.result);
        }

        //установить число
        public void Set(string text)
        {
            //фильтровать исходное число по цифрам по установленной системе
            string correctText = Utils.Extensions.ClampByBase(text, pIn);

            editor.number = correctText;
        }
    }
}
