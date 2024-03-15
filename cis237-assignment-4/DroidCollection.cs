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
        private IDroid[] droids;

        // Declare index of the droids array
        private int droidsIndex;
        
        // Create an instance of the GenericStack for storing instances of Astromechs
        GenericStack<Astromech> astromechStack = new GenericStack<Astromech>();

        // Create an instance of the GenericStack for storing instances of Janitors
        GenericStack<Janitor> janitorStack = new GenericStack<Janitor>();

        // Create an instance of the GenericStack for storing instances of Utilities
        GenericStack<Utility> utilityStack = new GenericStack<Utility>();

        // Create an instance of the GenericStack for storing instances of Protocols
        GenericStack<Protocol> protocolStack = new GenericStack<Protocol>();

        // Create an instance of the GenericQueue for storing instances of Droids
        GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

        /*****************************************************************
         * Constructors
         * **************************************************************/
        public DroidCollection(int passSize)
        {
            // Create an array for droids of all types
            this.droids = new IDroid[passSize];

            // Set the index of the array the first index
            // This will be changed as droids are added to the array
            this.droidsIndex = 0;

            // Add 8 premade droids to the array
            this.AddPremadeDroid();

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

        public void AddPremadeDroid()
        {
            // Create a prepared protocol droid
            Protocol protocolDroid1 = new Protocol("C-3PO", "Chromium", "Gold", 6000000);

            // Create a prepared protocol droid
            Protocol protocolDroid2 = new Protocol("GS-8", "Platinum", "White", 12000000);

            // Create a prepared utility droid
            Utility utilityDroid1 = new Utility("JR-RM", "Dolovite", "Gunmetal", true, true, false);

            // Create a prepared utility droid
            Utility utilityDroid2 = new Utility("KJ-7", "Iron", "Black", false, true, true);

            // Create a prepared astromech droid
            Astromech astromechDroid1 = new Astromech("R2-D2", "Plasteel", "Blue", true, true, true, true, 400);

            // Create a prepared astromech droid
            Astromech astromechDroid2 = new Astromech("R2-D6", "Cortosis", "Red", false, true, false, true, 100);

            // Create a prepared janitor droid
            Janitor janitorDroid1 = new Janitor("JX-9", "Durasteel", "Green", true, true, true, true, true);

            // Create a prepared janitor droid
            Janitor janitorDroid2 = new Janitor("SK-33", "Duraplast", "Seafoam", true, false, false, true, true);

            // Add premade droids to the array
            this.AddDroid(protocolDroid2);
            this.AddDroid(utilityDroid2);
            this.AddDroid(janitorDroid1);
            this.AddDroid(utilityDroid1);
            this.AddDroid(protocolDroid1);
            this.AddDroid(astromechDroid2);
            this.AddDroid(janitorDroid2);
            this.AddDroid(astromechDroid1);

        }

        public void OrganizeDroids()
        {
            //
            this.SendDroidsToStack();

            //
            this.SendDroidsToQueue();

        }

        private void SendDroidsToStack()
        {
            // Iterate through each element in the droids array
            foreach (IDroid droid in droids)
            {
                // Check that the current element is not null
                if (droid != null)
                {
                    // 
                    if (droid.GetType() == typeof(Astromech))
                    {
                        //
                        astromechStack.PushToFront((Astromech)droid);

                    }

                    // 
                    if (droid.GetType() == typeof(Janitor))
                    {
                        //
                        janitorStack.PushToFront((Janitor)droid);

                    }

                    // 
                    if (droid.GetType() == typeof(Utility))
                    {
                        //
                        utilityStack.PushToFront((Utility)droid);

                    }

                    // 
                    if (droid.GetType() == typeof(Protocol))
                    {
                        //
                        protocolStack.PushToFront((Protocol)droid);

                    }

                }

            }

        }

        private void SendDroidsToQueue()
        {

        }

    }

}
