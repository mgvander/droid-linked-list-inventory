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
        private int droidsIndexInteger;
        
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
            this.droidsIndexInteger = 0;

            // Add 8 premade droids to the array
            this.AddPremadeDroid();

        }

        /*****************************************************************
         * Methods
         * **************************************************************/
        public void AddDroid(Droid passDroid)
        {
            // Clear any data left over if this droid has been added
            // to the array before
            passDroid.TotalCost = 0m;

            // Calculate the droid's total cost
            passDroid.CalculateTotalCost();

            // Add the droid to the first available index
            droids[droidsIndexInteger] = passDroid;

            // Iterate to the next index in the array
            ++droidsIndexInteger;

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

        public void OrganizeDroidsArray()
        {
            // Call the SendDroidsToTypeSortedStacks() method
            this.SendDroidsToTypeSortedStacks();

            // Call the SendDroidStacksToDroidQueue() method
            this.SendDroidStacksToSortedDroidQueue();

            // Call the SendDroidQueueToDroidsArray() method
            this.SendDroidQueueToDroidsArray();

        }

        private void SendDroidsToTypeSortedStacks()
        {
            // Iterate through each element in the droids array
            foreach (IDroid droid in droids)
            {
                // Check that the current element is not null
                if (droid != null)
                {
                    // Check if the type of the current droid is Astromech
                    if (droid.GetType() == typeof(Astromech))
                    {
                        // Downcast the droid to the Astromech type and pass it to the astromech stack
                        astromechStack.PushToFront((Astromech)droid);

                    }

                    // Check if the type of the current droid is Janitor
                    if (droid.GetType() == typeof(Janitor))
                    {
                        // Downcast the droid to the Janitor type and pass it to the janitor stack
                        janitorStack.PushToFront((Janitor)droid);

                    }

                    // Check if the type of the current droid is Protocol
                    if (droid.GetType() == typeof(Protocol))
                    {
                        // Downcast the droid to the Protocol type and pass it to the protocol stack
                        protocolStack.PushToFront((Protocol)droid);

                    }

                    // Check if the type of the current droid is Utility
                    if (droid.GetType() == typeof(Utility))
                    {
                        // Downcast the droid to the Utility type and pass it to the utility stack
                        utilityStack.PushToFront((Utility)droid);

                    }                    

                }

            }

        }

        private void SendDroidStacksToSortedDroidQueue()
        {
            // Loop through while the astromech stack has droids in it
            while (astromechStack.Size > 0)
            {
                // Get the astromech from the stack and add it to the queue
                droidQueue.PushToBack(astromechStack.PopFromFront());

            }

            // Loop through while the janitor stack has droids in it
            while (janitorStack.Size > 0)
            {
                // Get the janitor from the stack and add it to the queue
                droidQueue.PushToBack(janitorStack.PopFromFront());

            }

            // Loop through while the utility stack has droids in it
            while (utilityStack.Size > 0)
            {
                // Get the utility from the stack and add it to the queue
                droidQueue.PushToBack(utilityStack.PopFromFront());

            }

            // Loop through while the protocol stack has droids in it
            while (protocolStack.Size > 0)
            {
                // Get the protocol from the stack and add it to the queue
                droidQueue.PushToBack(protocolStack.PopFromFront());

            }

        }

        private void SendDroidQueueToDroidsArray()
        {
            //// The relevant index of the droids array
            //int index = 0;

            //// Loop through while the queue has droids in it
            //while (droidQueue.Size > 0)
            //{
            //    // Take the droid from the front of the queue and
            //    // add them to the droids array
            //    droids[index] = droidQueue.PopFromFront();

            //    // Increment to the next index in the array
            //    ++index;

            //}

            // Return to the beginning of the droids array
            this.droidsIndexInteger = 0;

            // Loop through while the queue has droids in it
            while (droidQueue.Size > 0)
            {
                // Take and downcast the Node from the queue, of IDroid type, to Droid type and
                // add it to the droids array array
                this.AddDroid((Droid)droidQueue.PopFromFront());

            }

        }

    }

}
