using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class GenericStack<Type> : GenericNodeBasedDataStructure<Type>
    {
        /// <summary>
        /// Add a node to the head of the stack
        /// </summary>
        /// <param name="passData"> passed in object/value </param>
        public void PushToFront(Type passData)
        {
            // Save the current Head Node in a new variable
            Node oldHead = _head;

            // Make a new Head Node and save it to the list's head
            _head = new Node();

            // Set the Head Node's Data property to the passed in data
            _head.Data = passData;            

            // The old Head Node is now the next to the new Head Node
            _head.NextNode = oldHead;

            // Track the addition of a Node to the list 
            ++_size;

            // Check if this is the first Node to be stored in the list
            if (_size == 1)
            {
                // The last Node is the first Node in a list of 1
                _tail = _head;

            }            

        }

        /// <summary>
        /// Remove a node from the head of the queue
        /// </summary>
        /// <returns> The head node's object/value </returns>
        /// <exception cref="Exception"> No Data was Found When Observing the List! </exception>
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
