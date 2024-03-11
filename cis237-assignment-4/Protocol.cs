/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class Protocol : Droid
    {
        /*****************************************************************
         * Constants
         * **************************************************************/
        // Type of droid model
        private const string MODELTYPE = "Protocol";

        // Price increase for a single language known
        private const decimal COST_PER_LANGUAGE_DECIMAL = 0.1m;

        /*****************************************************************
         * Variables / Backing Fields
         * **************************************************************/
        // Number of languages (beyond binary) the droid is programmed with
        private int _numberOfLanguagesInteger;

        /*****************************************************************
         * Constructors
         * **************************************************************/
        public Protocol(
            string passDesignationString,
            string passMaterialString,
            string passColorString,
            int passNumOfLanguagesInteger) : base(
                passDesignationString,
                passMaterialString,
                passColorString)
        {
            // Set the number of languages the droid knows
            this._numberOfLanguagesInteger = passNumOfLanguagesInteger;

        }

        /*****************************************************************
         * Properties
         * **************************************************************/
        // Model of the droid
        public override string Model
        {
            get { return MODELTYPE; }
        }

        /*****************************************************************
         * Methods
         * **************************************************************/
        /// <summary>
        /// Add the calculated costs unique to protocol droids to the parent class
        /// </summary>
        public override void CalculateTotalCost()
        {
            // Call the base classes CalculateTotal to calculate any costs not unique to Protocol droids
            base.CalculateTotalCost();


            // Add the costs unique to the Protocol to the TotalCost property
            this.TotalCost += this.CalculateSoftwareCost(_numberOfLanguagesInteger, COST_PER_LANGUAGE_DECIMAL);

        }

        /// <summary>
        /// Create a formatted series of strings containing the values
        /// associated with the Protocol class and adds it the the parent
        /// class
        /// </summary>
        /// <returns> The formatted string of a droid's name, hull material,
        /// hull color, and languages known </returns>
        public override string ToString()
        {
            // Calculate the price of the languages known
            decimal totalLanguagesCostDecimal = this.CalculateSoftwareCost(_numberOfLanguagesInteger, COST_PER_LANGUAGE_DECIMAL);

            // Return the formatted concatenated string a values associated with the Protocol class and the parent class
            return $"{base.ToString()}" +
               "Number of Languages:".PadRight(25) + $"{this._numberOfLanguagesInteger}".PadRight(14) + $"+ {totalLanguagesCostDecimal} Galactic Credits" + Environment.NewLine;

        }

    }

}
