﻿using System;
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
            int Otv = Convert.ToInt32(AnswerText.Text);
            if (Otv == 5)
            {
                for (int i = 0; i < Objects.Length; i++)
                {
                    //Pc = (Pplus * Pc) / (Pplus * Pc) + (Pminus - (1 - Pc)) 
                    Objects[i].pCurrent = (Objects[i].Questions[NubmerQuestion].pPlus * Objects[i].pCurrent) / ((Objects[i].Questions[NubmerQuestion].pPlus * Objects[i].pCurrent) + (Objects[i].Questions[NubmerQuestion].pMinus * (1 - Objects[i].pCurrent)));
                }
            }
            if (Otv == -5)
            {
                for (int i = 0; i < Objects.Length; i++)
                {
                    //Pc = ((1-Pplus)*Pc) / ((1-Pplus)* Pc) - (Pminus * (1 - Pc))
                    Objects[i].pCurrent = ((1 - Objects[i].Questions[NubmerQuestion].pPlus) * Objects[i].pCurrent) / ((1 - Objects[i].Questions[NubmerQuestion].pPlus) * Objects[i].pCurrent) - (Objects[i].Questions[NubmerQuestion].pMinus * (1 - Objects[i].pCurrent));
                }
            }
            if (Otv > -5 && Otv < 0)
            {
                for (int i = 0; i < Objects.Length; i++)
                {
                    //Pc = (((Otv+5) * (Pc - Pminus)) / 5) + Pminus
                    Objects[i].pCurrent = (((Otv + 5) * (Objects[i].pCurrent - Objects[i].Questions[NubmerQuestion].pMinus)) / 5) + Objects[i].Questions[NubmerQuestion].pMinus;
                }
            }
            if (Otv > 0 && Otv < 5)
            {
                for (int i = 0; i < Objects.Length; i++)
                {
                    //Pc = (((Otv-0) * (Pplus - Pc)) / 5) + Pc
                    Objects[i].pCurrent = (((Otv - 0) * (Objects[i].Questions[NubmerQuestion].pPlus - Objects[i].pCurrent)) / 5) + Objects[i].pCurrent;
                }
            }
            if (Otv == 0)
            {
                for (int i = 0; i < parser.Objects.Length; i++)
                {
                    //Pc = Pc
                    Objects[i].pCurrent = Objects[i].pCurrent;
                }
            }

            
            if (NubmerQuestion + 1 == Quest.Length - 1)
            {
                MessageBox.Show("Закончились вопросы",
               "ВОПРОСОВ НЕТ!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NextButton.Enabled = false;
                return;
            }
        }

   

    }
}
