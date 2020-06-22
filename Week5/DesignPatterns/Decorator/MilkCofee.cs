using System;
using System.Collections.Generic;
using System.Text;

namespace ExDecorator
{
    class MilkCofee: ICondimentedCofee
    {
        private string price = "3$";

        protected ICoffee cofee;

        public MilkCofee(ICoffee cofee)
        {
            this.cofee = cofee;
        }


        public string GetDescription()
        {
            return this.cofee.GetDescription() + " + " + this.GetIngredientName();
        }

        public string GetPrice()
        {
            return this.cofee.GetPrice() + " + " + this.price;
        }

        public string GetIngredientName()
        {
            return "Milk";
        }
    }
}
