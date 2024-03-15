/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;

namespace cis237_assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*************************************************************
             * Constants
             * **********************************************************/
            // Maximum capacity of droids
            const int DROID_COLLECTION_SIZE_INTEGER = 100;
            // String value for exiting the program
            const string EXIT_STRING = "5";

            /*************************************************************
             * Variables
             * **********************************************************/
            //
            string actionString;

            // Create an instance of the DroidCollection Class
            DroidCollection droidCollection = new DroidCollection(DROID_COLLECTION_SIZE_INTEGER);

            // Create an instance of the UserInterface Class
            UserInterface ui = new UserInterface();

            // Call DisplayProgramGreeting() method to display greeting message
            ui.DisplayProgramGreeting();

            //
            do
            {
                // Call DiplayMainMenuAndGetInput() method
                // Pass in which menu to display
                // Set the returned user input
                actionString = ui.DiplayMenuAndGetInput("Main");

                //
                switch (actionString)
                {
                    case "1":
                        // User adds a droid from a numbered menu of droid types
                        string droidChoiceString = ui.DiplayMenuAndGetInput("Droids");

                        // Based on the choice of droid, the user will be prompted with the necessary
                        // properties of of the droid type pass the new droid to the Droid Collection
                        droidCollection.AddDroid(ui.GetNewDroidPropertiesAndCreateNewDroid(droidChoiceString));

                        break;

                    case "2":
                        // Organize the droids by droid type
                        droidCollection.OrganizeDroidsArray();

                        break;

                    case "3":
                        //

                        break;

                    case "4":
                        // Display all the added droids
                        Console.Write(droidCollection.ToString());

                        break;

                }

            } while (actionString != EXIT_STRING);

        }

    }

}
