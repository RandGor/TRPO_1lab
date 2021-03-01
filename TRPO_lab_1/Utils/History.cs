using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TRPO_lab_1.Utils
{
    public class History
    {
        //Список истории
        List<Record> historyList;

        //Директория с файлом истории
        string dir = "history.json";

        //Конструктор, чтение истории из файла
        public History()
        {
            try
            {
                //считать данные из файла, если он существует
                string jsonString = File.ReadAllText(dir);

                historyList = JsonSerializer.Deserialize<List<Record>>(jsonString);
            }
            catch
            {
                //если не существует - создать пустой список
                historyList = new List<Record>();
            }
        }

        //Деструктор, запись истории в файл
        ~History()
        {
            string jsonString = JsonSerializer.Serialize(historyList);
            File.WriteAllText(dir, jsonString);
        }

        //Получить записть по индексу
        public Record GetRecord(int index)
        {
            return historyList[index];
        }

        //Получить все записи истории
        public List<Record> GetRecords()
        {
            return historyList;
        }

        //Добавление записи
        public void AddRecord(int p1, int p2, string n1, string n2)
        {
            Record newRecord = new Record(p1, p2, n1, n2);
            historyList.Add(newRecord);
        }

        //Очитска Истории
        public void Clear()
        {
            historyList.Clear();
        }

        //Получение количества элементов истории
        public int Count()
        {
            return historyList.Count;
        }

    }
}
