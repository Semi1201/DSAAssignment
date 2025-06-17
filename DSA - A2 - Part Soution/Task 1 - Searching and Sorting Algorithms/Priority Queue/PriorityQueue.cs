using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// This class represents the priority queue that will be used to identify the 5 most urgent orders 
    /// based on their delivery date.  This priority queue bases itsef on the heap constructed in Heap.cs
    /// and uses its operations to carry out the taks as described in Task 1 (Done)
    /// </summary>
    internal class PriorityQueue
    {
        private Heap priorityQueue;

        /// <summary>
        /// Instanciates the priorityQueue as a heap of the required size and 
        /// adds all elements in the orders list provided to the Heap. 
        /// </summary>
        /// <param name="orders">List of orders to be added to the Heap</param>
        private void Build(List<Order> orders)
        {
            // Initialize the heap with the size of the input list
            priorityQueue = new Heap(orders.Count);

            // Insert orders
            foreach (var order in orders)
            {
                priorityQueue.Insert(order); 
            }
        }


        /// <summary>
        /// Builds a Priority Queue based on the list of orders passed as parameter by calling the Build() method
        /// Extracts the 5 most urgent orders from the Heap and adds them to a list which is returned at the end.
        /// </summary>
        /// <param name="orders">List of Orders that were placed, used to build the heap</param>
        /// <returns>List if 5 most important orders extacted from the heap</returns>
        public List<Order> GetMostUrgentOrders(List<Order> orders)
        {
            // Builds the minheap
            Build(orders);

            List<Order> urgentOrders = new List<Order>();

            //Gets the latest 5 orders from top of heap
            for (int i = 0; i < 5 && orders.Count > 0; i++)
            {
                var mostUrgent = priorityQueue.Remove();
                if (mostUrgent != null)
                    urgentOrders.Add(mostUrgent);
            }

            return urgentOrders;
        }




    }
}
