using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Date Placed (most recent first) using Merge Sort (Done)
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e the sorted array of orders must be returned by the Sort() method provided 
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method 
    /// </summary>
    internal class MergeSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            Console.WriteLine("Sort method called");
            if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
                return unsortedOrderList;

            return MergeSortRecursive(unsortedOrderList);
        }

        private List<Order> MergeSortRecursive(List<Order> orders)
        {
            // Base case
            if (orders.Count <= 1)
                return orders;

            // Split the list into two halves
            int mid = orders.Count / 2;

            //First half
            List<Order> p1_unsorted = orders.GetRange(0, mid);
            //Second half
            List<Order> p2_unsorted = orders.GetRange(mid, orders.Count - mid);

            // 2 recursive calls 
            p1_unsorted = MergeSortRecursive(p1_unsorted);
            p2_unsorted = MergeSortRecursive(p2_unsorted);

            // Merge sorted arrays together
            return Merge(p1_unsorted, p2_unsorted);
        }

        private List<Order> Merge(List<Order> p1_sorted, List<Order> p2_sorted)
        {
            List<Order> output = new List<Order>();
            int i = 0;
            int j = 0;

            // While both halves have elements to compare
            while (i < p1_sorted.Count && j < p2_sorted.Count)
            {
                // find the smallest element
                if (p1_sorted[i].placedOn >= p2_sorted[j].placedOn)
                {
                    output.Add(p1_sorted[i]);
                    i++;
                }
                else
                {
                    output.Add(p2_sorted[j]);
                    j++;
                }
            }

            // Adds any remaining elements from left
            while (i < p1_sorted.Count)
            {
                output.Add(p1_sorted[i]);
                i++;
            }

            // Adds any remaining elements from right
            while (j < p2_sorted.Count)
            {
                output.Add(p2_sorted[j]);
                j++;
            }

            return output;
        }
    }

}
