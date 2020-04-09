using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        //https://en.wikipedia.org/wiki/Bubble_sort

        
    }

    public interface ISort<T> where T :IComparable
    {
        public T[] Sort(T[] values); 
    }

    public class BubbleSort<T> : ISort<T> where T :IComparable
    {
        bool swap = true;
        public T[] Sort(T[] values)
        {
            swap = false;
            var temp = SortEnumerable(values).ToArray();

            while (swap)
            {
                swap = false;
                temp = SortEnumerable(temp).ToArray();
            }

            return SortEnumerable(temp).ToArray();
        }


        public IEnumerable<T> SortEnumerable(T[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i].CompareTo(nums[i + 1])>0)
                {
                    swap = true;
                    var swaps = nums[i + 1];
                    nums[i + 1] = nums[i];
                    nums[i] = swaps;
                }
                yield return nums[i];
            }

            yield return nums[nums.Length - 1];
        }

    }
}
