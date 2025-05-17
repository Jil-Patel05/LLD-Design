using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.StrategyDesign
{
    public class Parent
    {
        public StrategyInterface st;
        public Parent(StrategyInterface st)
        {
            this.st = st;
        }

        public void setSortingMethod(StrategyInterface newMethod)
        {
            this.st = newMethod;
        }

        public void sortArray()
        {
            this.st.sortArray();
        }
    }
}