using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {


            //base types
            ICoffee expreso = new ExpressoCoffe("5$");
            Console.WriteLine(expreso.GetDescription() + " = " + expreso.GetPrice());

            //add decorators - milk
            ICoffee expresoMilk = new MilkCofee(expreso);
            Console.WriteLine(expresoMilk.GetDescription() + " = " + expresoMilk.GetPrice());

            //add decorators - milk + cinnamon
            ICoffee expresoMilkCinnamon = new CinnamonCoffe(expresoMilk);
            Console.WriteLine(expresoMilkCinnamon.GetDescription() + " = " + expresoMilkCinnamon.GetPrice());
        }
    }
}
