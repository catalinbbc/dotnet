using System;

namespace ConsoleApp1
{
    public abstract class Shape

    {

        public string Name { get; set; }
        protected Shape(string name)

        {

            name = name + "2_";

            Name = name;

        }

    }

    public class Circle : Shape

    {

        public Circle(string name) : base(name + "3_")

        {

        }

    }

    public class SuperCircle : Circle

    {

        public SuperCircle(string name) : base(name + "1_")

        {

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            var circle = new SuperCircle("circle");

            Console.WriteLine(circle.Name);

        }

    }

}
