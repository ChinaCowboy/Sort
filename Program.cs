using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] testData = new int[] { 3, 2, 5, 1, 2, 3 };
            int[] testData2 = new int[5] { 99, 98, 92, 97, 95 };

            var bubbleSort = new BubbleSort<int>();
            
            Console.WriteLine(ConvertStringArrayToString(testData2));
            Console.WriteLine("Results:");
            Console.WriteLine(ConvertStringArrayToString(bubbleSort.Sort(testData2)));

            Console.WriteLine(ConvertStringArrayToString(testData));
            Console.WriteLine("Results:");
            Console.WriteLine(ConvertStringArrayToString(bubbleSort.Sort(testData)));
        }


        //https://en.wikipedia.org/wiki/Bubble_sort
        public static string ConvertStringArrayToString(int[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (int value in array)
            {
                builder.Append(value);
                builder.Append('.');
            }
            return builder.ToString();
        }

    }

    public interface ISort<T> where T :IComparable
    {
        public T[] Sort(T[] values); 
    }

    public class BubbleSort<T> : ISort<T> where T :IComparable
    {
        public T[] Sort(T[] nums)
        {
            bool swap = true;
            var n = nums.Length - 1;
            while (swap)
            {
                swap = false;
                var newn = 1;
                for (int i = 0; i < n; i++)
                {
                    if (nums[i].CompareTo(nums[i + 1]) > 0)
                    {
                        swap = true;
                        var swaps = nums[i + 1];
                        nums[i + 1] = nums[i];
                        nums[i] = swaps;
                        newn= i + 1;
                    }
                }
                n = newn;
            }

            return nums;
        }

    }
    //https://en.wikipedia.org/wiki/Insertion_sort

    public class InsertSort<T> : ISort<T> where T : IComparable
    {
        public T[] Sort(T[] values)
        {
            throw new NotImplementedException();
        }
    }
}
