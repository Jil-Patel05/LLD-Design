using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.StateDesignPattern
{
    public interface IState
    {
        public void next();
        public string getState();// No necessary to implement
    }
}