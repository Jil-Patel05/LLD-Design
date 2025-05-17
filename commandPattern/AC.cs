using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.commandPattern
{
    public class AC
    {
        public void turnOn()
        {
            Console.WriteLine("Ac is turned on");
        }
        public void turnOff()
        {
            Console.WriteLine("Ac is turned off");
        }
    }

    public class RemoteControl
    {
        private ICommand _ic;
        public void setCommand(ICommand ic)
        {
            this._ic = ic;
        }
        public void turnOn()
        {
            this._ic.execute();
        }
    }
}