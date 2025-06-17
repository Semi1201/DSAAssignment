using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// A class representing a Binary Search Tree aimed at facilitating the search of orders by order id.
    /// TODO: You are to implement the Build() and Find() methods for this class; additional methods may be added but
    /// any methods added to this class must be declared as private and called within the Build() or Find() method (Done)
    /// </summary>
    internal class BinarySearchTree
    {

        //Points to the top node in the tree
        public TreeNode Root { get; private set; }

        /// <summary>
        /// Builds a Binary Search tree based on the list of orders passed as parameter i.e.
        /// It inserts each order in the list into the tree
        /// 
        /// TODO: Implement this methods as described above and in Task 1 (Done)
        /// 
        /// </summary>
        /// <param name="Orders">List<Order> list of orders to be inserted in the tree</param>
        public void Build(List<Order> Orders)
        {
            if (Orders == null || Orders.Count == 0)
                return;

            // Sets the root as the first order
            Root = new TreeNode(Orders[0]);

            // Inserts the rest
            for (int i = 1; i < Orders.Count; i++)
            {
                Insert(Root, Orders[i]);
            }
        }

        /// <summary>
        /// Searches for an Order with given id in the tree, if no match is found, null is returned
        /// 
        /// TODO: Implement this methods as described above and in Task 1 (Done)
        /// 
        /// </summary>
        /// <param name="orderID">Guid id of order to search for</param>
        /// <returns>Order matching id or null</returns>
        public Order Get(Guid orderID)
        {
            return Search(Root, orderID);
        }

        private void Insert(TreeNode node, Order order)
        {
            if (order.ID.CompareTo(node.order.ID) < 0)
            {
                // Goes left of the tree
                if (node.Left == null)
                    node.Left = new TreeNode(order);
                else
                    Insert(node.Left, order);
            }
            else
            {
                // Goes right of the tree
                if (node.Right == null)
                    node.Right = new TreeNode(order);
                else
                    Insert(node.Right, order);
            }
        }

        private Order Search(TreeNode node, Guid orderID)
        {
            //order isnt in tree
            if (node == null)
                return null;

            //checks the current ID of the node and compares with the target node
            int comparison = orderID.CompareTo(node.order.ID);

            
            if (comparison == 0)
                return node.order; 

            //check left
            else if (comparison < 0)
                return Search(node.Left, orderID);

            //check right
            else
                return Search(node.Right, orderID);
        }
    }
}


