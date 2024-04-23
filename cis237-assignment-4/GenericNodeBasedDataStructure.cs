/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class GenericNodeBasedDataStructure<Type>
    {
        /************************************************************
         * Inner Classes
         * *********************************************************/
        protected class Node
        {
            // Data representing the object/value contained in the node
            public Type Data { get; set; }

            // the node linked to this instance of Nnode
            public Node NextNode { get; set; }

        }

        /************************************************************
         * Variables/Backing Fields
         * *********************************************************/
        // The node at the head of the linked list
        protected Node _head;

        // The node at the tail end of the linked list
        protected Node _tail;

        // Number of nodes in the list
        protected int _size;

        /************************************************************
         * Properties
         * *********************************************************/
        // Is the linked list empty
        public bool IsEmpty
        {
            get
            {
                // Returns true if _head is null and returns false if
                // _head has something in it
                return _head == null;

            }

        }

        // Number of nodes in the list
        public int Size
        {
            get
            {
                // Returns the list's size
                return _size;

            }

        }

    }

}
