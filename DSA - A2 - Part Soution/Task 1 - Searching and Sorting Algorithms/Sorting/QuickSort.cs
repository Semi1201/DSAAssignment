using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on based on Order ID (ascending order) 
    /// using Quick Sort where the pivot is the left-most element (Done)
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided 
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {

            Console.WriteLine("Sort method called");
            //check null or if sorted already
            if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
                return unsortedOrderList;

            Order[] ordersArray = unsortedOrderList.ToArray();

            QuickSortRecursive(ordersArray, 0, ordersArray.Length - 1);

            return ordersArray.ToList();
        }

        // Using recursive method to sort
        private void QuickSortRecursive(Order[] orders, int lo, int hi)
        {
            if (lo < hi)
            {
                // gets pivot (the thing that is used to sort accordingly)
                int pivotIndex = Partition(orders, lo, hi);

                // accordingly it sorts to left of pivot or right
                QuickSortRecursive(orders, lo, pivotIndex - 1);
                QuickSortRecursive(orders, pivotIndex + 1, hi);
            }
        }

        //Uses partitions for the array by using the left most element as the pivot.
        //If less then pivot, they go left, if not they go right (of pivot).
        private int Partition(Order[] orders, int lo, int hi)
        {
            Order pivot = orders[lo]; // Picks left-most as pivot (IMP REQUIREMENT)
            int i = lo + 1;           
            int j = hi;              


            while (i <= j)
            {
                // Move i  until element greater than pivot is found
                while (i <= j && orders[i].ID <= pivot.ID)
                    i++;

                // Move j until element lesser than pivot is found
                while (i <= j && orders[j].ID > pivot.ID)
                    j--;

                // If i is still to the left of j, swap the elements (Note to self: IMP DO NOT REMOVE, sequence will not be correct otherwise!!)
                if (i < j)
                    Swap(orders, i, j);
            }

            // place pivot in the correct position
            Swap(orders, lo, j);
            return j;
        }

        // to swap two elements in the array using a temp array
        private void Swap(Order[] orders, int i, int j)
        {
            Order temp = orders[i];
            orders[i] = orders[j];
            orders[j] = temp;
        }
    }

}
