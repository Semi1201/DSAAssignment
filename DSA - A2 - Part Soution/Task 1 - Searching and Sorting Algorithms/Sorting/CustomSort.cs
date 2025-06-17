using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Deliver Date (most recent first) 
    /// using any sorting algorithm of your choice
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class CustomSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            Console.WriteLine("Sort method called");
            if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
                return unsortedOrderList;

            // Copy list
            List<Order> sortedList = new List<Order>(unsortedOrderList);

            sortedList.Sort(CompareByDeliverDateDescending);

            return sortedList;
        }

        //comparing the orders by the deliverOn date descending
        private int CompareByDeliverDateDescending(Order x, Order y)
        {
            return x.deliverOn.CompareTo(y.deliverOn); // IMP: Most recent WILL BE first
        }
    }

}
