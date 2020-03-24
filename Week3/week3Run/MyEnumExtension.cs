using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week3Run
{
    static class MyEnumExtension
    {

        public static T Sum<T>(this IEnumerable<T> Container)
        {
            dynamic mySum = Container.Aggregate((total, next) => (dynamic)total + (dynamic)next);
            return mySum;
        }

        public static T Avg<T>(this IEnumerable<T> Container)
        {
            dynamic mySum = Container.Sum();
            int myCount = Container.Count();

            dynamic myAvg = mySum / myCount;
            return myAvg;
        }

        public static T Prod<T>(this IEnumerable<T> Container)
        {
            dynamic myProd = Container.Aggregate((total, next) => (dynamic)total * (dynamic)next);
            return myProd;
        }

        public static T Min<T>(this IEnumerable<T> Container)
        {
            dynamic myMin = Container.First();
            
            foreach (T item in Container)
            {
                if(myMin > item)
                {
                    myMin = item;
                }
            }
            return myMin;
        }

        public static T Max<T>(this IEnumerable<T> Container)
        {
            dynamic myMax = Container.First();

            foreach (T item in Container)
            {
                if (myMax < item)
                {
                    myMax = item;
                }
            }
            return myMax;
        }

    }
}
