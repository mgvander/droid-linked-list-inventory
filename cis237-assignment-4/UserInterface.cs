/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    public class UserInterface
    {
        /*****************************************************************
         * Constants
         * **************************************************************/
        //
        private string[] mainMenuOptions = new string[] {
            "Add a New Droid",
            "Organize Droids by Type",
            "Organize Droids by Price",
            "Display Inventory",
            "Exit the Program" };

        //
        private string[] droidMenuOptions = new string[] {
            "Astromech",
            "Janitor",
            "Protocol",
            "Utility" };

        /*****************************************************************
         * Methods
         * **************************************************************/
        public void DisplayProgramGreeting()
        {
            // Program greeting message
            Console.WriteLine("Compiling Program...");
            Console.WriteLine("M'um m'aloo.");
            Console.WriteLine("Translating to: GALACTIC BASIC");
            Console.WriteLine("Greetings, Hello.");
            Console.WriteLine("Welcome to the droid cataloging program.");
            Console.WriteLine();

        }

        public string DiplayMenuAndGetInput(string passMenuString)
        {
            // Display Menu
            this.DisplayMenuHeader();
            int numberOfMenuOptionsInteger = this.DisplayMenuOptions(passMenuString);

            // Call DiplayInputPromptAndGetUserInput() method
            string choiceString = this.DiplayInputPromptAndGetUserInput();

            //
            while (!ValidOption(choiceString, numberOfMenuOptionsInteger))
            {
                // Call DiplayInputPromptAndGetUserInput() method
                choiceString = this.DiplayInputPromptAndGetUserInput();

            }

            return choiceString;

        }

        private void DisplayMenuHeader()
        {
            //
            Console.WriteLine("Please enter a number from the list of options below.");
            Console.WriteLine("=====================================================");

        }



        private int DisplayMenuOptions(string passMenuString)
        {
            // Declare number of options in the menu
            int numberOfMenuOptionsInteger;

            //
            switch (passMenuString)
            {
                case "Main":
                    // Display menu options from passed in array
                    // Set the number of options in the Main Menu
                    numberOfMenuOptionsInteger = this.DisplayMenuOptions(mainMenuOptions);

                    break;

                case "Droids":
                    // Display menu options from passed in array
                    // Set the number of Droid Options Menu
                    numberOfMenuOptionsInteger = this.DisplayMenuOptions(droidMenuOptions);

                    break;

                case "Materials":
                    // Create an empty protocol droid to gain access to the droid class properties
                    Protocol fakeDroid = new Protocol("", "", "", 0);

                    // Set the variable to the array of droid hull materials
                    string[] materialMenuOptions = fakeDroid.Materials;

                    // Display material options from passed in array
                    // Set the number of Droid Options Menu
                    numberOfMenuOptionsInteger = this.DisplayMenuOptions(materialMenuOptions);

                    break;

                default:
                    //
                    numberOfMenuOptionsInteger = 0;

                    break;

            }

            return numberOfMenuOptionsInteger;

        }

        protected int DisplayMenuOptions(string[] passMenuOptions)
        {
            //
            int counterInteger = 0;

            //
            foreach (string option in passMenuOptions)
            {
                //
                ++counterInteger;

                //
                Console.WriteLine($"{counterInteger}. {option}");

            }

            //
            Console.WriteLine();

            //
            return passMenuOptions.Length;
        }

        private string DiplayInputPromptAndGetUserInput()
        {
            // Display prompt
            Console.Write("Enter here >>> ");

            //
            string userInputString = Console.ReadLine();
            Console.WriteLine();

            return userInputString;

        }

        private string GetUserInput()
        {
            // Read in user's input
            return Console.ReadLine();

        }

        private bool ValidOption(string passChoiceString, int passMaxNumOptionsInteger)
        {
            // Out of lower bounds to check against
            const int NON_OPTION_INTEGER = 0;

            // Is the user input valid?
            bool isValidBoolean = false;

            try
            {
                // Convert the user choice to integer type
                int choiceInteger = Int32.Parse(passChoiceString);

                // Check that user choice is with in the bounds of the menu
                if (choiceInteger > NON_OPTION_INTEGER && choiceInteger <= passMaxNumOptionsInteger)
                {
                    // The user input it valid
                    isValidBoolean = true;

                }
                else
                {
                    // Display the invalis input error
                    this.DisplayMenuInputErrorMessage(passChoiceString);

                }

            }
            catch (Exception e)
            {
                // Set the variable to false
                isValidBoolean = false;

                // Display exception message
                Console.WriteLine(e.Message);

                //
                this.DisplayMenuInputErrorMessage(passChoiceString);

            }

            // Return the state of validity
            return isValidBoolean;

        }

        public Droid GetNewDroidPropertiesAndCreateNewDroid(string passDroidTypeString)
        {
            //
            Droid newDroid = null;

            //
            switch (passDroidTypeString)
            {
                case "1":
                    // Get astromech droid properties
                    string[] astromechProperties = this.GetAstromechProperties();

                    //
                    newDroid = new Astromech(
                        astromechProperties[0],
                        astromechProperties[1],
                        astromechProperties[2],
                        Convert.ToBoolean(astromechProperties[3]),
                        Convert.ToBoolean(astromechProperties[4]),
                        Convert.ToBoolean(astromechProperties[5]),
                        Convert.ToBoolean(astromechProperties[6]),
                        Convert.ToInt32(astromechProperties[7]));

                    break;

                case "2":
                    // Get janitor droid properties
                    string[] janitorProperties = this.GetJanitorProperties();

                    //
                    newDroid = new Janitor(
                        janitorProperties[0],
                        janitorProperties[1],
                        janitorProperties[2],
                        Convert.ToBoolean(janitorProperties[3]),
                        Convert.ToBoolean(janitorProperties[4]),
                        Convert.ToBoolean(janitorProperties[5]),
                        Convert.ToBoolean(janitorProperties[6]),
                        Convert.ToBoolean(janitorProperties[7]));

                    break;

                case "3":
                    // Get protocol droid properties
                    string[] protocolProperties = this.GetProtocolProperties();

                    //
                    newDroid = new Protocol(
                        protocolProperties[0],
                        protocolProperties[1],
                        protocolProperties[2],
                        Convert.ToInt32(protocolProperties[3]));

                    break;

                case "4":
                    // Get utility droid properties
                    string[] utilityProperties = this.GetUtilityProperties();

                    //
                    newDroid = new Utility(
                        utilityProperties[0],
                        utilityProperties[1],
                        utilityProperties[2],
                        Convert.ToBoolean(utilityProperties[3]),
                        Convert.ToBoolean(utilityProperties[4]),
                        Convert.ToBoolean(utilityProperties[5]));

                    break;

            }

            //
            newDroid.CalculateTotalCost();

            //
            return newDroid;

        }

        private string[] GetDroidProperties()
        {
            // Create an empty protocol droid to gain access to the droid class properties
            Protocol fakeDroid = new Protocol("", "", "", 0);

            // Set the variable to the array of droid hull materials
            string[] materialMenuOptions = fakeDroid.Materials;

            //
            string nameString = this.GetStringProperty("Serial Designation");
            this.DisplayStringPrompt("Hull Material");
            string materialChoicString = this.DiplayMenuAndGetInput("Materials");
            string materialString = materialMenuOptions[Convert.ToInt32(materialChoicString) - 1];
            string colorString = this.GetStringProperty("Hull Color");

            //
            return new string[] { nameString, materialString, colorString };

        }

        private string[] GetProtocolProperties()
        {
            //
            string[] driodProperties = this.GetDroidProperties();
            string languagesString = this.GetIntegerlProperty("Languages Beyond Binary");

            //
            return new string[] {
                driodProperties[0],
                driodProperties[1],
                driodProperties[2],
                languagesString };

        }

        private string[] GetUtilityProperties()
        {
            //
            string[] driodProperties = this.GetDroidProperties();
            string toolsString = this.GetBoolProperty("a Tool Box");
            string computerConnectionString = this.GetBoolProperty("a Data Probe");
            string scannerString = this.GetBoolProperty("a Scanner Array");

            //
            return new string[] {
                driodProperties[0],
                driodProperties[1],
                driodProperties[2],
                toolsString,
                computerConnectionString,
                scannerString };

        }

        private string[] GetAstromechProperties()
        {
            //
            string[] utilityProperties = this.GetUtilityProperties();
            string navigationString = this.GetBoolProperty("a Navi-Computer Interface");
            string shipsString = this.GetIntegerlProperty("Ship Interfaces");

            //
            return new string[] {
                utilityProperties[0],
                utilityProperties[1],
                utilityProperties[2],
                utilityProperties[3],
                utilityProperties[4],
                utilityProperties[5],
                navigationString,
                shipsString };

        }

        private string[] GetJanitorProperties()
        {
            //
            string[] utilityProperties = this.GetUtilityProperties();
            string broomString = this.GetBoolProperty("a Broom");
            string vacuumString = this.GetBoolProperty("a Vacuum");

            //
            return new string[] {
                utilityProperties[0],
                utilityProperties[1],
                utilityProperties[2],
                utilityProperties[3],
                utilityProperties[4],
                utilityProperties[5],
                broomString,
                vacuumString };

        }

        private string GetBoolProperty(string passPropertyString)
        {
            //
            bool booleanValueBoolean = false;

            //
            bool validBoolean = false;

            //
            do
            {
                //
                this.DisplayBoolPrompt(passPropertyString);

                // Call DiplayInputPromptAndGetUserInput() method
                string inputString = this.DiplayInputPromptAndGetUserInput();

                if (inputString.ToLower() == "y" || inputString.ToLower() == "n")
                {
                    // If the input is "y" or "Y" then set the value to true
                    // "n" or "N" will set the value to false
                    booleanValueBoolean = (inputString.ToLower() == "y");

                    // The input was valid
                    validBoolean = true;

                }
                //
                else
                {
                    //
                    DisplayInvalidInputErrorMessage(inputString);

                }

            } while (!validBoolean); // 

            //
            return booleanValueBoolean.ToString();

        }

        private string GetIntegerlProperty(string passPropertyString)
        {

            //
            string inputString = null;

            //
            int integerValueInteger;

            //
            bool validBoolean = false;

            //
            do
            {
                //
                this.DisplayIntegerPrompt(passPropertyString);

                // Call DiplayInputPromptAndGetUserInput() method
                inputString = this.DiplayInputPromptAndGetUserInput();

                //
                try
                {
                    //
                    integerValueInteger = int.Parse(inputString);

                    // The input was valid
                    validBoolean = true;

                }
                //
                catch (Exception e)
                {
                    // Display exception message
                    Console.WriteLine(e.Message);

                    //
                    DisplayInvalidInputErrorMessage(inputString);

                }

            } while (!validBoolean); //

            //
            return inputString;

        }

        private string GetStringProperty(string passPropertyString)
        {
            //
            string inputString = null;

            //
            bool validBoolean = false;

            //
            do
            {
                //
                this.DisplayStringPrompt(passPropertyString);

                // Call DiplayInputPromptAndGetUserInput() method
                inputString = this.DiplayInputPromptAndGetUserInput();

                //
                if (!String.IsNullOrWhiteSpace(inputString))
                {
                    //
                    validBoolean = true;

                }
                else
                {
                    //
                    DisplayInvalidInputErrorMessage(inputString);

                }

            } while (!validBoolean); //


            //
            return inputString;

        }

        private void DisplayBoolPrompt(string passSubjectString)
        {
            //
            Console.WriteLine($"Is the droid equipped with {passSubjectString}? (Y/N)");
            Console.WriteLine();

        }

        private void DisplayIntegerPrompt(string passSubjectString)
        {
            //
            Console.WriteLine($"How many {passSubjectString} is the droid programmed with?");
            Console.WriteLine();

        }

        private void DisplayStringPrompt(string passSubjectString)
        {
            //
            Console.WriteLine($"What is the droid's {passSubjectString}?");
            Console.WriteLine();

        }

        private void DisplayMenuInputErrorMessage(string passUserInputString)
        {
            //
            Console.WriteLine($"{passUserInputString} is not a number from the list of options.");
            Console.WriteLine("Please try again.");
            Console.WriteLine();

        }

        private void DisplayInvalidInputErrorMessage(string passUserInputString)
        {
            Console.WriteLine($"{passUserInputString} is not a valid input.");
            Console.WriteLine("Please try again.");
            Console.WriteLine();

        }

    }

}
