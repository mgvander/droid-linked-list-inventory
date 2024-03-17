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
        public void Sort(IComparable[] passArray, int passMaxFilledElement)
        {
            // Create an array that will only be as long as the number of droids
            // needing to be sorted.
            IComparable[] auxiliaryArray = new IComparable[passMaxFilledElement];

            // Pass in the array and auxiliary array and the range to be sorted
            this.Sort(passArray, auxiliaryArray, 0, passMaxFilledElement - 1);

        }

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
                int medianIndexInteger = this.CalculateMedian(passLowestIndexInteger, passHighestIndexInteger);

                // Recurse using the first half of the current subset of the array
                this.Sort(passArray, passAuxiliaryArray, passLowestIndexInteger, medianIndexInteger);

                // Recurse using the second half of the current subset of the array
                this.Sort(passArray, passAuxiliaryArray, medianIndexInteger + 1, passHighestIndexInteger);

                // Merge the two subset back together in ascending order using the auxiliary array as temporary storage
                // for the elements in the array
                this.Merge(passArray, passAuxiliaryArray, passLowestIndexInteger, medianIndexInteger, passHighestIndexInteger);

            }

        }

        private void Merge(
            IComparable[] passArray,
            IComparable[] passAuxiliaryArray,
            int passLowestIndexInteger,
            int passMedianIndexInteger,
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
            int secondSubsetIndexInteger = passMedianIndexInteger + 1;

            // Loop through the current range of indexes
            for (int indexInteger = passLowestIndexInteger; indexInteger <= passHighestIndexInteger; ++indexInteger)
            {
                // Check that the index has left the bounds of the first subset
                if (firstSubsetIndexInteger > passMedianIndexInteger)
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

        private int CalculateMedian(int passLowestValueInteger, int passHighestInteger)
        {
            // Calculate half the range and add it to the lowest value to find and return the middle integer
            return (passHighestInteger - passLowestValueInteger) / 2 + passLowestValueInteger;

        }

    }

}
