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
    public partial class Form1 : Form
    {
        //контроллер перевода систем счисления и истории
        Utils.Control control = new Utils.Control();

        //флаг, определяющий, происходит ли разворот
        bool isSwaping = false;

        //главный конструктор создания формы
        public Form1()
        {
            //инициализация компонентов
            InitializeComponent();

            //добавления слушателя на все кнопки, для ввода чисел
            foreach (var button in Controls.OfType<Button>())
                button.Click += button_Click;
        }

        //обновление интерфейса при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        //метод обновления интерфейса, вызываемый при обновлении данных, производящий вычисления
        private void UpdateUI()
        {
            if (numericFrom.Value != control.pIn)
                numericFrom.Value = control.pIn;

            if (numericTo.Value != control.pOut)
                numericTo.Value = control.pOut;

            control.Calculate();

            if (textBoxFrom.Text != control.GetNumber())
                textBoxFrom.Text = control.GetNumber();
            if (textBoxTo.Text != control.GetResult())
                textBoxTo.Text = control.GetResult();
        }

        //ввод чисел с кнопок
        private void button_Click(object sender, EventArgs eventArgs)
        {
            var text = ((Button)sender).Text;

            var isNumeric = int.TryParse(text, out int n);
            var isLetter = text.Length == 1 && text[0] >= 'A' && text[0] <= 'F';

            if (isNumeric || isLetter)
            {
                control.AddDigit(text[0]);
                UpdateUI();
            }
        }

        //добавление разделителя
        private void buttonDot_Click(object sender, EventArgs e)
        {
            control.AddDelim();
            UpdateUI();
        }

        //удаление самого правого символа
        private void buttonBack_Click(object sender, EventArgs e)
        {
            control.Bs();
            UpdateUI();
        }

        //обработка изменения поля системы исходного числа
        private void numericFrom_ValueChanged(object sender, EventArgs e)
        {
            //если происходит разворот - ничего не делать
            if (isSwaping)
                return;

            //поиск наименьшей системы счисления исходного числа
            int limit = Utils.Extensions.GetMinBase(control.GetNumber());

            //если система не удовлетворяет числу, установить минимальную допустимую
            if (limit > control.pIn)
                control.pIn = limit;
            else
                control.pIn = (int)numericFrom.Value;

            UpdateUI();
        }

        //обработка изменения поля системы результата
        private void numericTo_ValueChanged(object sender, EventArgs e)
        {
            //если происходит разворот - ничего не делать
            if (isSwaping)
                return;

            //изменение системы результата в контроллере
            control.pOut = (int)numericTo.Value;
            UpdateUI();
        }

        //обработка очистки полей
        private void buttonClear_Click(object sender, EventArgs e)
        {
            control.Clear();
            UpdateUI();
        }

        //обработка разворота полей
        private void buttonSwap_Click(object sender, EventArgs e)
        {
            //установка флага - происходит разворот
            isSwaping = true;

            //поменять значения местами
            control.Swap();
            UpdateUI();

            //установка флага - разворот не происходит
            isSwaping = false;
        }

        //обработка изменения поля исходного числа
        private void textBoxFrom_TextChanged(object sender, EventArgs e)
        {
            //если происходит разворот - ничего не делать
            if (isSwaping)
                return;

            control.Set(textBoxFrom.Text);

            UpdateUI();
        }

        //открыть форму с результатами
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(control);
            historyForm.ShowDialog();
            UpdateUI();
        }

        //сохранить результат в истории
        private void buttonSave_Click(object sender, EventArgs e)
        {
            control.Save();
        }

        //открыть форму со справкой
        private void buttonFAQ_Click(object sender, EventArgs e)
        {
            FAQForm faqForm = new FAQForm();
            faqForm.Show();
        }
    }
}
