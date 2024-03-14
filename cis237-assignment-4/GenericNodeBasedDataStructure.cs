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
            //
            public Type Data { get; set; }

            //
            public Node NextNode { get; set; }

        }

        /************************************************************
         * Variables/Backing Fields
         * *********************************************************/
        //
        protected Node _head;

        //
        protected Node _tail;

        //
        protected int _size;

        /************************************************************
         * Variables
         * *********************************************************/
        //
        public bool IsEmpty
        {
            get
            {
                // Returns true if _head is null and returns false if
                // _head has something in it
                return _head == null;

            }

        }

        //
        public int Size
        {
            get
            {
                //
                return _size;

            }

        }

    }

}
