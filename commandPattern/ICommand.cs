using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.commandPattern
{
    public interface ICommand
    {
        public void execute();
        public void undo();
    }

    public class ACOnCommand : ICommand
    {
        private AC _ac;
        public ACOnCommand(AC ac)
        {
            this._ac = ac;
        }
        public void execute()
        {
            this._ac.turnOn();
        }

        public void undo()
        {
            this._ac.turnOff();            
        }
    }
}