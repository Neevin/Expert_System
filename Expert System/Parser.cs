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
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();

        public void ParseFile(string path)
        {
            //Отображение чисел через точку
            
            ci.NumberFormat.NumberDecimalSeparator = ".";
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

                this.Objects = parseObjects(AutorQuestionsObjects[2]);
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Все очень плохо", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        public Object[] parseObjects(string AQO)
        {
            
         
            string[] ObjectsAndP = AQO.Split('\r');
            Object[] Objects = new Object[ObjectsAndP.Length - 1];
            
            //На каждый объект создаем свой экземпляр
            for (int i = 0; i < ObjectsAndP.Length - 1; i++)
            {
                Objects[i] = new Object();
            }

            for (int i = 1, o=0; i < ObjectsAndP.Length; i++, o++)
            {

                string[] Object = ObjectsAndP[i].Split(',');
                Objects[o].Name = Object[0];
                Objects[o].pConst = double.Parse(Object[1], ci);

                for (int j = 2; j < Object.Length; j++)
                {
                    int number = Convert.ToInt32(Object[j]);
                    j++;
                    double pPlus1 = double.Parse(Object[j], ci);
                    j++;
                    double pMinus1 = double.Parse(Object[j], ci);
                    Question quest = new Question(pPlus1, pMinus1);
                    Objects[o].Questions.Add(number, quest);
                }

            }
            return Objects;
        }
    }
}
