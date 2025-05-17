using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.VendingMachine
{
    public class Item
    {
        public string name;
        public string description;
        public int quantity;
        public int price;
        public Item(string name, string description, int quantity, int price)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
        }
    }
    public class Container
    {
        public int id;
        public Item item;
        public Container(Item item, int id)
        {
            this.id = id;
            this.item = item;
        }
    }

    public class VendingMachine
    {
        public List<Container> items = new List<Container>();
        public IState? state;
        public int insertedMoney;
        public int insertedId;
        public int amountToBeRefunded;
        public Item? selectedItem;
        public VendingMachine()
        {
            this.state = new IdelState();
        }

        public void displayItems()
        {
            foreach (Container c in items)
            {
                Console.WriteLine($"{c.id} is id and contains item {c.item.name}, {c.item.description}, {c.item.price}, {c.item.quantity} ");
            }
        }
        public void addContainer(Container newC)
        {
            this.items.Add(newC);
        }

        public void changeVendingMachineState(IState state)
        {
            this.state = state;
        }

        public void pressICButton()
        {
            this.state.pressIcButton(this);
        }

        public void configureMachine()
        {
            this.state?.insertCoin(this);
        }

        public void insertCoin()
        {
            Console.WriteLine("Please insert money from right side input");
            string? input = Console.ReadLine();
            input = input?.Trim();
            Console.WriteLine(input);
            if (input?.Length > 0)
            {
                this.insertedMoney = int.Parse(input);
            }
            this.state?.selectItem(this);
        }

        public void selectItemFromList()
        {
            Console.WriteLine("Please select any item from machine by entering it's id");
            string? input = Console.ReadLine();
            if (input?.Length < 0 || input?.Length > 6)
            {
                Console.WriteLine("ERROR! Input not valid");
                return;
            }
            this.insertedId = int.Parse(input);
            this.state?.ValidationAndDispendeItem(this);
        }
        public void cancel()
        {
            Console.WriteLine("Cancel button pressed..");
            this.state?.manageMoney(this);
        }

        public void validationAndDispense()
        {
            for (var i = 0; i < this.items.Count; i++)
            {
                Container item = this.items[i];
                if (item.id == this.insertedId)
                {
                    this.selectedItem = item.item;
                }
            }
            if (this.selectedItem == null)
            {
                Console.WriteLine("Your written id is not valid, please enter again");
                this.changeVendingMachineState(new SelectItem());
                this.state.selectItem(this);
            }
            if (this.selectedItem.price < this.insertedMoney)
            {
                Console.WriteLine("Money is not sufficient for this product, pleae add more money");
                this.changeVendingMachineState(new InsertCoin());
                this.state.insertCoin(this);
            }
            this.amountToBeRefunded = Math.Abs(this.selectedItem.price - this.insertedMoney);
            this.state.manageMoney(this);
        }
        public void manageInventory()
        {
            this.selectedItem.quantity -= 1;
            foreach (Container item in items)
            {
                if (item.id == this.insertedId)
                {
                    item.item = this.selectedItem;
                    break;
                }
            }
            // Return amount to the user
            Console.WriteLine($"Amount it refunde {this.amountToBeRefunded}");
            this.changeVendingMachineState(new IdelState());
        }
    }
}