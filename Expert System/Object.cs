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
    }
}
