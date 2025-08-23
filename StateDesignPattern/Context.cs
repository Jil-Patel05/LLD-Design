using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.StateDesignPattern
{
    public class Context
    {
        public IState state;
        public Context()
        {
            this.state = new State1();
        }

        public void setState(IState state)
        {
            this.state = state;
        }

        public void next()
        {
            this.state.next(this);
        }
    }
}