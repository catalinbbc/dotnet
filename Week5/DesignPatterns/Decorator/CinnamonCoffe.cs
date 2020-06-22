using System;
using System.Collections.Generic;
using System.Text;

namespace ExDecorator
{
    class CinnamonCoffe : ICondimentedCofee
    {
        private string price = "5$";

        protected ICoffee cofee;

        public CinnamonCoffe(ICoffee cofee)
        {
            this.cofee = cofee;
        }


        public string GetDescription()
        {
            return this.cofee.GetDescription() + " + " + "Cinnamon";
        }

        public string GetPrice()
        {
            return this.cofee.GetPrice() + " + " + this.price;
        }

        public string GetIngredientName()
        {
            return "Cinnamon";
        }
    }
}
