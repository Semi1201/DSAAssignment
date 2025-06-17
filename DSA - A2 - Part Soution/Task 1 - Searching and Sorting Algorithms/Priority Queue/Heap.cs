using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class used to build the Heap serving as the underlying data structure for the Priority Queue required to
    /// get the most urgent orders i.e. the ones with the soonest deliver date
    /// 
    /// TODO: You are to determine whether this Heap should be a MinHeap or a MaxHeap
    /// based on the way that urgent orders need to be identified i.e. soonest delivery date first.
    /// Implement the Insert() and Remove() method for this class; additional methods may be added but these 
    /// must be declared as private and called within the Insert() or Remove() method (Done)
    /// </summary>
    internal class Heap
    {
        //The array contaaining order elements upon which the heap is based
        private Order[] orderHeap;
        // Current number of elements in the heap
        private int size = 0;       



        //Constructs a heap of the given size (based on how many orders need to be stored)
        public Heap(int maxSize)
        {
            orderHeap = new Order[maxSize];
        }

        /// <summary>
        /// Inserts an order into the heap based on its delivery date.  
        /// Orders having the most recent delivery date should be place at the top of the heap
        /// </summary>
        /// <param name="order">Order to be inserted in the heap</param>
        public void Insert(Order order)
        {
            if (size >= orderHeap.Length)
                throw new InvalidOperationException("Heap is full");

            // Add order to the next available position
            orderHeap[size] = order;
            UpHeap(size); // Restore heap property
            size++;
        }

        /// <summary>
        /// Returns the most recent order i.e. the one with the soonest delivery date
        /// </summary>
        /// <returns>Order with the soonest delivery date</returns>
        public Order Remove()
        {
            if (size == 0)
                return null;

            // Get the top of the heap (minimum deliver date)
            Order root = orderHeap[0];

            // Move last element to root and reduce size
            orderHeap[0] = orderHeap[size - 1];
            size--;

            DownHeap(0);

            return root;
        }


        private void UpHeap(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                // If current order has earlier deliverOn than parent, swap
                if (orderHeap[index].deliverOn < orderHeap[parentIndex].deliverOn)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void DownHeap(int index)
        {
            while (index < size)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int smallest = index;

                // Find the child with the soonest deliverOn
                if (leftChild < size && orderHeap[leftChild].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = leftChild;

                if (rightChild < size && orderHeap[rightChild].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = rightChild;

                // If child is smaller, swap and continue
                if (smallest != index)
                {
                    Swap(index, smallest);
                    index = smallest;
                }
                else
                {
                    break;
                }
            }
        }

        /// Swaps two elements in the heap array.
        private void Swap(int i, int j)
        {
            Order temp = orderHeap[i];
            orderHeap[i] = orderHeap[j];
            orderHeap[j] = temp;
        }
    }
}
