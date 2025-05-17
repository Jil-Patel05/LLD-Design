using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.StrategyDesign
{
    public class Child : Parent
    {
        // At runtime decide which algorithm you have to use
        public Child() : base(new BubbleSort())
        {
            Console.WriteLine("Hey inside child class");
        }
    }
}