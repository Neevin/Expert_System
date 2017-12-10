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

     /*   void PrintObjects(Object[] obj)
        {
            string Objects = "";
            for (int i = 0; i < obj.Length; i++)
            {
                Objects += obj[i].Name + "[" + obj[i].pConst + "]" + "\n";
            }
            ObjectsText.Text = Objects;
        }*/

    }
}
