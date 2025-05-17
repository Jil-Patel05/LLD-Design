using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.VendingMachine
{
    public interface IState
    {
        public void pressIcButton(VendingMachine v);
        public void insertCoin(VendingMachine v);
        public void cancel(VendingMachine v);
        public void selectItem(VendingMachine v);
        public void ValidationAndDispendeItem(VendingMachine v);
        public void manageMoney(VendingMachine v);
    }

    public class IdelState : IState
    {
        public void cancel(VendingMachine v)
        {
            v.cancel();
            v.changeVendingMachineState(new Cancel());
        }

        public void insertCoin(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void manageMoney(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void pressIcButton(VendingMachine v)
        {
            Console.WriteLine("press ic");
            if (v == null)
            {
                Console.WriteLine("v is null");
            }
            v.changeVendingMachineState(new InsertCoin());
            if (v == null)
            {
                Console.WriteLine("v is null");
            }
            v.configureMachine();
        }

        public void selectItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void ValidationAndDispendeItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }
    }
    public class InsertCoin : IState
    {
        public void cancel(VendingMachine v)
        {
            v.changeVendingMachineState(new Cancel());
            v.cancel();
        }

        public void insertCoin(VendingMachine v)
        {
            Console.WriteLine("insert coin called");
            v.changeVendingMachineState(new SelectItem());
            v.insertCoin();
        }

        public void manageMoney(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void pressIcButton(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void selectItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void ValidationAndDispendeItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }
    }
    public class SelectItem : IState
    {
        public void cancel(VendingMachine v)
        {
            v.changeVendingMachineState(new Cancel());
            v.cancel();
        }

        public void insertCoin(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void manageMoney(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void pressIcButton(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void selectItem(VendingMachine v)
        {
            v.changeVendingMachineState(new DispenseItem());
            v.selectItemFromList();
        }

        public void ValidationAndDispendeItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }
    }
    public class DispenseItem : IState
    {
        public void cancel(VendingMachine v)
        {
            v.changeVendingMachineState(new Cancel());
            v.cancel();
        }

        public void insertCoin(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void manageMoney(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void pressIcButton(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void selectItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void ValidationAndDispendeItem(VendingMachine v)
        {
            v.changeVendingMachineState(new inventoryManagement());
            v.validationAndDispense();
        }
    }
    public class inventoryManagement : IState
    {
        public void cancel(VendingMachine v)
        {
            v.changeVendingMachineState(new Cancel());
            v.cancel();
        }

        public void insertCoin(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void manageMoney(VendingMachine v)
        {
            v.changeVendingMachineState(new IdelState());
            v.manageInventory();
        }

        public void pressIcButton(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void selectItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void ValidationAndDispendeItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }
    }
    public class Cancel : IState
    {
        public void cancel(VendingMachine v)
        {
            v.changeVendingMachineState(new inventoryManagement());
        }

        public void insertCoin(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void manageMoney(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void pressIcButton(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void selectItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }

        public void ValidationAndDispendeItem(VendingMachine v)
        {
            throw new NotImplementedException();
        }
    }
}