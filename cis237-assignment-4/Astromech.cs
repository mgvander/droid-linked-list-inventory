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
        //
        public override string Model
        {
            get { return MODELTYPE; }
        }

        /*****************************************************************
         * Methods
         * **************************************************************/
        public override void CalculateTotalCost()
        {
            //
            base.CalculateTotalCost();

            //
            this.TotalCost += this.CalculateEquipmentCost(_navigationBoolean, COST_OF_NAVIGATION_DECIMAL) +
                this.CalculateSoftwareCost(_numberOfShipsInteger, COST_PER_SHIP_DECIMAL);

        }

        public override string ToString()
        {
            //
            decimal totalNavigationCostDecimal = this.CalculateEquipmentCost(_navigationBoolean, COST_OF_NAVIGATION_DECIMAL);

            //
            decimal totalShipsCostDecimal = this.CalculateSoftwareCost(_numberOfShipsInteger, COST_PER_SHIP_DECIMAL);

            //
            return $"{base.ToString()}" +
                "Navigation:".PadRight(25) + $"{this._navigationBoolean}".PadRight(14) + $"+ {totalNavigationCostDecimal} Galactic Credits" + Environment.NewLine +
                "Number of Ships:".PadRight(25) + $"{this._numberOfShipsInteger}".PadRight(14) + $"+ {totalShipsCostDecimal} Galactic Credits" + Environment.NewLine;

        }

    }

}
