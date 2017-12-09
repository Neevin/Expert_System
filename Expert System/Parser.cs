using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert_System
{
    class Parser
    {
        public string Autor;
        public Object[] Objects;
        public string Questions;

        public void ParseFile(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);
                //Массив строк для Автора, Вопросов, Обьектов
                string[] AutorQuestionsObjects = new string[3];
                int j = 0;

                string file = reader.ReadToEnd();
                //Разделение прочитанного файла на Автора, Вопросы, Обьекты
                string[] Entit = file.Split('\n');
                for (int i = 0; i < Entit.Length; i++)
                {
                    if (Entit[i] == "\r")
                    {
                        j++;
                    }
                    AutorQuestionsObjects[j] += Entit[i];

                }
                this.Autor = AutorQuestionsObjects[0];

                string[] Q = AutorQuestionsObjects[1].Split(':');
                this.Questions = Q[1];

               
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Все очень плохо", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

      