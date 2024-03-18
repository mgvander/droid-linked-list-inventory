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
    class Astromech : Utility
    {
        /*****************************************************************
         * Constants
         * **************************************************************/
        // Type of droid model
        private const string MODELTYPE = "Astromech";

        // Price increase if the droid can operate a navi computer
        private const decimal COST_OF_NAVIGATION_DECIMAL = 500m;
        // Price increase for knowing how to operate a single ship type
        private const decimal COST_PER_SHIP_DECIMAL = 2m;

        /*****************************************************************
         * Variables / Backing Fields
         * **************************************************************/
        // Does the droid have the programming to interface with a navi computer
        private bool _navigationBoolean;
        // Number of ship types the droid can operate
        private int _numberOfShipsInteger;

        /*****************************************************************
         * Constructors
         * **************************************************************/
        public Astromech(
            string passDesignationString,
            string passMaterialString,
            string passColorString,
            bool passToolsBoolean,
            bool passDataProbeBoolean,
            bool passScannerBoolean,
            bool passNavigationBoolean,
            int passShipsInteger) : base(
                passDesignationString,
                passMaterialString,
                passColorString,
                passToolsBoolean,
                passDataProbeBoolean,
                passScannerBoolean)
        {
            // Set if the droid is equipped with a navigation computer interface
            this._navigationBoolean = passNavigationBoolean;

            // Set the number of ships the droid can pilot
            this._numberOfShipsInteger = passShipsInteger;

        }

        /*****************************************************************
         * Properties
         * **************************************************************/
        // The type of droid
        public override string Model
        {
            get { return MODELTYPE; }
        }

        /*****************************************************************
         * Methods
         * **************************************************************/
        /// <summary>
        /// Calls the base version of the method and then adds the equipment cost
        /// and the number of ships the droid can opperate, to the class property, TotalCost
        /// </summary>
        public override void CalculateTotalCost()
        {
            // Call the base class CalculateTotalCost() method
            base.CalculateTotalCost();

            // Add the the equipment cost and the number of ships the droid can opperate to the TotalCost
            this.TotalCost += this.CalculateEquipmentCost(_navigationBoolean, COST_OF_NAVIGATION_DECIMAL) +
                this.CalculateSoftwareCost(_numberOfShipsInteger, COST_PER_SHIP_DECIMAL);

        }

        /// <summary>
        /// Create a formatted series of strings containing the values
        /// associated with the Astromech class
        /// </summary>
        /// <returns> The formatted formatted string of a droid's name, hull
        /// material, hull color, tool box status, data probe status, scanner status,
        /// navigation status, and number of ships </returns>
        public override string ToString()
        {
            // Set the variable to the calculated cost of navigation
            decimal totalNavigationCostDecimal = this.CalculateEquipmentCost(_navigationBoolean, COST_OF_NAVIGATION_DECIMAL);

            // Set the variable to the calculated cost of the number of ships
            decimal totalShipsCostDecimal = this.CalculateSoftwareCost(_numberOfShipsInteger, COST_PER_SHIP_DECIMAL);

            // Return the formatted concatenated string a values associated with the Astromech class
            return $"{base.ToString()}" +
                "Navigation:".PadRight(25) + $"{this._navigationBoolean}".PadRight(14) + $"+ {totalNavigationCostDecimal} Galactic Credits" + Environment.NewLine +
                "Number of Ships:".PadRight(25) + $"{this._numberOfShipsInteger}".PadRight(14) + $"+ {totalShipsCostDecimal} Galactic Credits" + Environment.NewLine;

        }

    }

}
