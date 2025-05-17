using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.DecoratorDesign
{
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee coffee;
        public CoffeeDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }

        public abstract int cost();

        public abstract void getDescription();
    }
    class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {

        }
        public override int cost()
        {
            return this.coffee.cost() + 2;
        }

        public override void getDescription()
        {
            this.coffee.getDescription();
        }
    }

    class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {

        }
        public override int cost()
        {
            return this.coffee.cost() + 2;
        }

        public override void getDescription()
        {
            this.coffee.getDescription();
        }

    }
}