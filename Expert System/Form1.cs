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

            PrintObjects(parser.Objects);
            QuestionsText.Text = parser.Questions;
            AutorText.Text = parser.Autor;
     

        }

        void PrintObjects(Object[] obj)
        {
            string Objects = "";
            for (int i = 0; i < obj.Length; i++)
            {
                Objects += obj[i].Name + "[" + obj[i].pConst + "]" + "\n";
            }
            ObjectsText.Text = Objects;
        }

    }
}
