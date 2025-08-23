using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.StateDesignPattern
{
    public class State1 : IState
    {
        public void next(Context cs)
        {
            cs.setState(new State2());
        }
    }
    public class State2 : IState
    {
        public void next(Context cs)
        {
            cs.setState(new State1());
        }
    }
}