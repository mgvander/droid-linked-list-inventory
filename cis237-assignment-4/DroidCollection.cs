/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    public class DroidCollection
    {
        /*****************************************************************
         * Variables
         * **************************************************************/
        // Declare array for holding the list of droids
        private Droid[] droids;

        // Declare index of the droids array
        private int droidsIndex;

        /*****************************************************************
         * Constructors
         * **************************************************************/
        public DroidCollection(int passSize)
        {
            // Create an array for droids of all types
            this.droids = new Droid[passSize];

            // Set the index of the array the first index
            // This will be changed as droids are added to the array
            this.droidsIndex = 0;

        }

        /*****************************************************************
         * Methods
         * **************************************************************/
        public void AddDroid(Droid passDroid)
        {
            // Add the droid to the first available index
            droids[droidsIndex] = passDroid;

            // Iterate to the next index in the array
            ++droidsIndex;

        }

        public override string ToString()
        {
            //
            string outputString = "";

            //
            foreach (Droid droid in droids)
            {
                if (droid != null)
                {
                    //
                    outputString += " ".PadLeft(39, '=') + $"{droid.Model} Droid" + Environment.NewLine;

                    //
                    outputString += droid.ToString();

                    //
                    outputString += " ".PadLeft(39, '=') + $"{droid.TotalCost} " + "Galactic Credits" + Environment.NewLine +
                        Environment.NewLine;

                }

            }

            //
            return outputString;

        }

    }

}
