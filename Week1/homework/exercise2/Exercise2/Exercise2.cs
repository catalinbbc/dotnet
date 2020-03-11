using System;
using System.Collections.Generic;
using System.Text;

namespace homework1
{
    public class Excercise2
    {
        public static void goex2()
        {

            int[] arr = new int[10];
            int i;
            Console.Write("\n\nGiven an unsorted array which has a number in the majority (a number appears more than 50% in the array/list), find that number.:\n");
            Console.Write("-----------------------------------------\n");

            Console.Write("Input 10 elements in the array :\n");
            for (i = 0; i < 10; i++)
            {
                Console.Write("element - {0} : ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            
            }

            int n = arr.Length;

            // Function calling  
            findMajority(arr, n);



        }

        static void findMajority(int[] arr, int n)
        {
            int maxCount = 0;
            int index = -1; // sentinels  
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }

                // update maxCount if count of  
                // current element is greater  
                if (count > maxCount)
                {
                    maxCount = count;
                    index = i;
                }
            }

            // if maxCount is greater than n/2  
            // return the corresponding element  
            if (maxCount > n / 2)
                Console.WriteLine("Majority Element is :"+arr[index]);

            else
                Console.WriteLine("No Majority Element present"); 
        }
    }

}
