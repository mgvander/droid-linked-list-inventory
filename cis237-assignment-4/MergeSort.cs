/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class MergeSort
    {
        /*****************************************************************
         * Methods
         * **************************************************************/
        /// <summary>
        /// Create an auxiliary array of IComparable type to sort a passed in array
        /// with no null element proceeding non-null elements
        /// </summary>
        /// <param name="passArray"> Array to be sorted </param>
        /// <param name="passHighestFilledElement"> Number of elements in the array of non-null value </param>
        public void Sort(IComparable[] passArray, int passHighestFilledElement)
        {
            // Create an array that will only be as long as the number of droids
            // needing to be sorted.
            IComparable[] auxiliaryArray = new IComparable[passHighestFilledElement];

            // Pass in the array and auxiliary array and the range to be sorted
            this.Sort(passArray, auxiliaryArray, 0, passHighestFilledElement - 1);

        }

        /// <summary>
        /// Divide the array in two subsets until each subset cannot be divider further 
        /// and then merge the subsets into sorted sequencial order
        /// </summary>
        /// <param name="passArray"> Array to be sorted </param>
        /// <param name="passAuxiliaryArray"> Auxiliary array for temporarily holding the array's values </param>
        /// <param name="passLowestIndexInteger"> Lowest index in the range of indexes </param>
        /// <param name="passHighestIndexInteger"> Highest index in the range of the indexes  </param>
        private void Sort(
            IComparable[] passArray,
            IComparable[] passAuxiliaryArray,
            int passLowestIndexInteger,
            int passHighestIndexInteger)
        {
            // Check if the highest index is greater than the lowest index
            if (passHighestIndexInteger > passLowestIndexInteger)
            {
                // Calculate the median for the current subsection of the array
                int medianIndexInteger = this.CalculateMiddle(passLowestIndexInteger, passHighestIndexInteger);

                // Recurse using the first half of the current subset of the array
                this.Sort(passArray, passAuxiliaryArray, passLowestIndexInteger, medianIndexInteger);

                // Recurse using the second half of the current subset of the array
                this.Sort(passArray, passAuxiliaryArray, medianIndexInteger + 1, passHighestIndexInteger);

                // Merge the two subset back together in ascending order using the auxiliary array as temporary storage
                // for the elements in the array
                this.Merge(passArray, passAuxiliaryArray, passLowestIndexInteger, medianIndexInteger, passHighestIndexInteger);

            }

        }

        /// <summary>
        /// Merge the elements of two subsets of an array in sorted sequencial order
        /// </summary>
        /// <param name="passArray"> Array to be sorted </param>
        /// <param name="passAuxiliaryArray"> Auxiliary array for temporarily holding the array's values </param>
        /// <param name="passLowestIndexInteger"> Lowest index in the range of indexes </param>
        /// <param name="passMiddleIndexInteger"> Middle index in the range of indexes </param>
        /// <param name="passHighestIndexInteger"> Highest index in the range of indexes </param>
        private void Merge(
            IComparable[] passArray,
            IComparable[] passAuxiliaryArray,
            int passLowestIndexInteger,
            int passMiddleIndexInteger,
            int passHighestIndexInteger)
        {
            // Loop through the current range of indexes
            for (int indexInteger = passLowestIndexInteger; indexInteger <= passHighestIndexInteger; ++indexInteger)
            {
                // Copy the element of the current index from the array into
                // the auxiliary array
                passAuxiliaryArray[indexInteger] = passArray[indexInteger];

            }

            // Set the index to the starting index of the first subset
            int firstSubsetIndexInteger = passLowestIndexInteger;

            // Set the index to the starting index of the second subset
            int secondSubsetIndexInteger = passMiddleIndexInteger + 1;

            // Loop through the current range of indexes
            for (int indexInteger = passLowestIndexInteger; indexInteger <= passHighestIndexInteger; ++indexInteger)
            {
                // Check that the index has left the bounds of the first subset
                if (firstSubsetIndexInteger > passMiddleIndexInteger)
                {
                    // Copy the element of the auxiliary array from the second subset
                    // back into array at relevant index
                    // Then iterate through the index of the second subset
                    passArray[indexInteger] = passAuxiliaryArray[secondSubsetIndexInteger++];

                }
                // Check that the index has left the bounds of the second subset
                else if (secondSubsetIndexInteger > passHighestIndexInteger)
                {
                    // Copy the element of the auxiliary array from the first subset
                    // back into array at relevant index
                    // Then iterate through the index of the first subset
                    passArray[indexInteger] = passAuxiliaryArray[firstSubsetIndexInteger++];

                }
                // Check if the current element in the second subset of the auxiliary array
                // belongs before the current element in the first subset of the auxiliary array
                else if (passAuxiliaryArray[secondSubsetIndexInteger].CompareTo(passAuxiliaryArray[firstSubsetIndexInteger]) < 0)
                {
                    // Copy the element of the auxiliary array from the second subset
                    // back into the array at the relevant index.
                    // Then iterate through the index of the second subset.
                    passArray[indexInteger] = passAuxiliaryArray[secondSubsetIndexInteger++];

                }
                // The current element in the second subset of the auxiliary array
                // is either equivalent to or belongs later in sequence, than the current element in
                // the first subset of the auxiliary array
                else
                {
                    // Copy the element of the auxiliary array from the first subset
                    // back into the array at the relevant index.
                    // Then iterate through the index of the first subset.
                    passArray[indexInteger] = passAuxiliaryArray[firstSubsetIndexInteger++];

                }

            }

        }

        /// <summary>
        /// Calculate the middle integer between two integers
        /// </summary>
        /// <param name="passLowestValueInteger"> Lowest integer </param>
        /// <param name="passHighestInteger"> Highest integer </param>
        /// <returns> Middle integer </returns>
        private int CalculateMiddle(int passLowestValueInteger, int passHighestInteger)
        {
            // Calculate half the range and add it to the lowest value to find and return the middle integer
            return (passHighestInteger - passLowestValueInteger) / 2 + passLowestValueInteger;

        }

    }

}
