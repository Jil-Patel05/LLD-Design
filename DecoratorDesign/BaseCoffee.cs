using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.DecoratorDesign
{
    public interface ICoffee
    {
        public void getDescription();
        public int cost();

    }
    public class CamiloCoffe : ICoffee
    {
        public int cost()
        {
            return 10;
        }

        public void getDescription()
        {
            Console.WriteLine("Coffee with greate sugar taste");
        }
    }
    public class Cappauccino : ICoffee
    {
        public int cost()
        {
            return 15;
        }

        public void getDescription()
        {
            Console.WriteLine("Coffe with bitterness inside it with sugar");
        }
    }
    public class FlatWhite : ICoffee
    {
        public int cost()
        {
            return 20;
        }

        public void getDescription()
        {
            Console.WriteLine("Coffee with very bitter taste and less sugar");
        }
    }
}