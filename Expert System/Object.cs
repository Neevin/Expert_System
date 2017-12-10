using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert_System
{
    public class Object
    {

        public Dictionary<int, Question> Questions = new Dictionary<int, Question>();
        public string Name;
        public double pConst;
        public double pCurrent;
        public Object()
        {
            pCurrent = pConst;
        }

        void Calculate(int Otv,int NubmerQuestion)
        {
            if (Otv == 5)
            {
                    //Pc = (Pplus * Pc) / (Pplus * Pc) + (Pminus - (1 - Pc)) 
                    pCurrent = (Questions[NubmerQuestion].pPlus * pCurrent) / ((Questions[NubmerQuestion].pPlus * pCurrent) + (Questions[NubmerQuestion].pMinus * (1 - pCurrent)));
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
        }
    }
}
