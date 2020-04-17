using System;
using System.Collections.Concurrent;
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
            int[] testData3 = new int[6]{5, 1, 1, 2, 0, 0};
              


        var bubbleSort = new BubbleSort<int>();
            
            //Console.WriteLine(ConvertStringArrayToString(testData2));
            //Console.WriteLine("Results:");
            //Console.WriteLine(ConvertStringArrayToString(bubbleSort.Sort(testData2)));

            //Console.WriteLine(ConvertStringArrayToString(testData));
            //Console.WriteLine("Results:");
            //Console.WriteLine(ConvertStringArrayToString(bubbleSort.Sort(testData)));

            var quickSort= new QuickSort<int>();

            Console.WriteLine(ConvertStringArrayToString(testData));
            Console.WriteLine("Results:");
            Console.WriteLine(ConvertStringArrayToString(quickSort.Sort(testData2)));


            Console.WriteLine(ConvertStringArrayToString(testData2));
            Console.WriteLine("Results:");
            Console.WriteLine(ConvertStringArrayToString(quickSort.Sort(testData2)));

            Console.WriteLine(ConvertStringArrayToString(testData3));
            Console.WriteLine("Results:");
            Console.WriteLine(ConvertStringArrayToString(quickSort.Sort(testData3)));
            Console.ReadLine();


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

    public class QuickSort<T> : ISort<T> where T : IComparable
    {
        public T[] Sort(T[] values)
        {
            return QuickSortA(values, 0, values.Length - 1);
        }

        public T[] QuickSortA(T[] values,int firstValue, int lastValue)
        {
            if (firstValue.CompareTo(lastValue) < 0)
            {
                var p = Partition(values, firstValue, lastValue);
                QuickSortA(values, firstValue, p - 1);
                QuickSortA(values, p+1, lastValue);
            }

            return values;
        }

        private int Partition(T[]  values, int firstValue, int lastValue)
        {
            var pivot = firstValue-1;
            var i = firstValue-1;
            for (int j = firstValue; j < lastValue; j++)
            {
                if (values[j].CompareTo(values[lastValue]) < 0)
                {
                    pivot++;
                    i++;

                    var temp = values[i];
                    values[i] = values[j];
                    values[j] = temp;
                }

            }
            i++;

            var temp2 = values[i];
            values[i] = values[lastValue];
            values[lastValue] = temp2;
            return i;
        }
    }




 //   https://programm.top/en/c-sharp/algorithm/array-sort/quick-sort/


}
