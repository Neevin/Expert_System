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

        public void Calculate(int Otv,int NubmerQuestion)
        {
            if (Otv == 5)
            {
                    //Pc = (Pplus * Pc) / (Pplus * Pc) + (Pminus - (1 - Pc)) 
                    pCurrent = (Questions[NubmerQuestion].pPlus * pCurrent) / ((Questions[NubmerQuestion].pPlus * pCurrent) + (Questions[NubmerQuestion].pMinus * (1 - pCurrent)));
            }
            if (Otv == -5)
            {
                    //Pc = ((1-Pplus)*Pc) / ((1-Pplus)* Pc) - (Pminus * (1 - Pc))
                   pCurrent = ((1 - Questions[NubmerQuestion].pPlus) * pCurrent) / ((1 - Questions[NubmerQuestion].pPlus) * pCurrent) - (Questions[NubmerQuestion].pMinus * (1 - pCurrent));
            }
            if (Otv > -5 && Otv < 0)
            {
                    //Pc = (((Otv+5) * (Pc - Pminus)) / 5) + Pminus
                    pCurrent = (((Otv + 5) * (pCurrent - Questions[NubmerQuestion].pMinus)) / 5) + Questions[NubmerQuestion].pMinus;
            }
            if (Otv > 0 && Otv < 5)
            {
                    //Pc = (((Otv-0) * (Pplus - Pc)) / 5) + Pc
                    pCurrent = (((Otv - 0) * (Questions[NubmerQuestion].pPlus - pCurrent)) / 5) + pCurrent;
            }
            if (Otv == 0)
            {
                    //Pc = Pc
                   pCurrent = pCurrent;
            }

        }
    }
}
