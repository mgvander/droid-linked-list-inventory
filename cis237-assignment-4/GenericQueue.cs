using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class GenericQueue<Type> : GenericNodeBasedDataStructure<Type>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passData"></param>
        public void PushToBack(Type passData)
        {
            // Save the current Tail Node in a new variable
            Node oldTail = _tail;

            // Make a new Tail Node and save it to the list's tail
            _tail = new Node();

            // Set the Tail Node's Data property to the passed in data
            _tail.Data = passData;

            // Set the Tail Node's NextNode property to null
            _tail.NextNode = null;

            // Check if a Head Node has not been established yet
            if (IsEmpty)
            {
                // The first Node is the last Node in a list of 1
                _head = _tail;

            }
            // A Head Node has been established
            else
            {
                // The new Tail Node will be the old Tail Node's NextNode property
                oldTail.NextNode = _tail;

            }

            // Track the addition of a Node to the list 
            ++_size;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Type PopFromFront()
        {
            // If the list empty throw an error message
            if (IsEmpty)
            {
                // Display error message
                throw new Exception("No Data was Found When Observing the List!");

            }

            // Get and set the data in the Head Node
            Type data = _head.Data;

            // Replace the Head Node with the Node linked in its NextNode property
            _head = _head.NextNode;

            // Check if the last Node was removed from the list.
            // This works because if the old Head Node has a NextNode property of null, it is the Tail Node.
            // The new Head Node should then have been set to null.
            if (IsEmpty)
            {
                // The Tail Node is confirmed to be the Head Node as well.
                _tail = _head;

            }

            // Track the removal of a Node from the list
            --_size;

            // Return the data from the old Head Node
            return data;

        }

    }

}
