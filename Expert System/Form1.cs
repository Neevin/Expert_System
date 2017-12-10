using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert_System
{
    public partial class Form1 : Form
    {
        Parser parser = new Parser();
        string Questions="";
        string Autor = "";
        Object[] Objects;
        int NubmerQuestion;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            //Очистка RichTextBox и открытие файла
            AutorText.Clear();
            QuestionsText.Clear();
            QuestionText.Clear();
            ObjectsText.Clear();

            openFile.ShowDialog();
            string path = openFile.FileName;

            parser.ParseFile(path);

            Questions = parser.Questions;
            Autor = parser.Autor;
            Objects = parser.Objects;
            NubmerQuestion = 0;

            Reload();

            GoButton.Enabled = true;
        }

        

        private void GoButton_Click(object sender, EventArgs e)
        {
            //Вывод первого вопроса
            Reload();
            NextButton.Enabled = true;
            string[] Quest = Questions.Split('\r');
            QuestionText.Text = Quest[1];
        }

        void Reload()
        {
            string TextObjects = "";
            //Работа со Текстом/Строкой Объектов
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i].pCurrent = Objects[i].pConst;
            }
            for (int i = 0; i < Objects.Length; i++)
            {
                TextObjects += Objects[i].Name + "[" + parser.Objects[i].pConst + "]" + "\n";
            }

            ObjectsText.Text = TextObjects;
            QuestionsText.Text = Questions;
            AutorText.Text = Autor;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            string[] Quest = Questions.Split('\r');

            NubmerQuestion++;
            if (AnswerText.Text == "")
            {
                MessageBox.Show("Впишите свой ответ от -5 до +5",
                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Подсчёт
            int Otv = Convert.ToInt32(AnswerText.Text);
            for(int i = 0; i < Objects.Length; i++)
            {
                Objects[i].Calculate(Otv, NubmerQuestion);
            }
            //Обновляем
            Modify();
            if (NubmerQuestion + 1 == Quest.Length - 1)
            {
                MessageBox.Show("Закончились вопросы",
               "ВОПРОСОВ НЕТ!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NextButton.Enabled = false;
                return;
            }
        }

        void Modify()
        {
            //Объекты
            string Object = "";
            //Сортировка по возрастанию 
            var sortedObjects = Objects.OrderByDescending(o => o.pCurrent);
            foreach(Object Obj in sortedObjects) { 
                if (Obj.pCurrent == 0)
                {
                    Object += "//" + Obj.Name + "[" + Obj.pCurrent + "]" + "\n";
                }
                else
                {
                    Object += Obj.Name + "[" + Obj.pCurrent + "]" + "\n";
                }
            }
            ObjectsText.Text = Object;

            //Вопрос
            string[] Quest = Questions.Split('\r');
            QuestionText.Text = Quest[1 + NubmerQuestion];

            //Вопросы
            QuestionsText.Clear();
            for (int i = 2 + NubmerQuestion; i < Quest.Length; i++)
            {
                QuestionsText.Text += Quest[i] + "\n";
            }
        }


    }
}
