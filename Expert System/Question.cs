using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert_System
{
    public class Question
    {
        public string Text;
        public double pPlus;
        public double pMinus;

        public Question(double pPlus1, double pMinus1)
        {

            this.pPlus = pPlus1;
            this.pMinus = pMinus1;
        }
    }
}

