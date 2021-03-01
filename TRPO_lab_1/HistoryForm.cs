using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPO_lab_1
{
    public partial class HistoryForm : Form
    {
        //ссылка на родительский контроллер
        Utils.Control parentControl;

        //метод инициализации формы без контроллера
        public HistoryForm()
        {
            InitializeComponent();
        }

        //метод инициализации формы с родительским контроллером
        public HistoryForm(Utils.Control control)
        {
            InitializeComponent();

            parentControl = control;

            UpdateUI();
        }

        //обновление списка строк истории
        private void UpdateUI()
        {
            //удаление старых строк истории
            historyList.Rows.Clear();

            //получение списка новых строк истории
            List<Utils.Record> list = parentControl.GetHistory();

            //заполнение таблицы списком истории
            foreach (Utils.Record record in list)
                historyList.Rows.Add(record.ToString());
        }

        //открытие результата, по которому нажали дважды
        private void historyList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //если нажали не на результат - ничего не делать
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            //иначе открыть результат
            parentControl.LoadHistory(e.RowIndex);
            Close();
        }

        //очистка списка истории
        private void buttonClear_Click(object sender, EventArgs e)
        {
            parentControl.ClearHistory();

            UpdateUI();
        }
    }
}
