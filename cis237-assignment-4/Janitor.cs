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
    class Janitor : Utility
    {
        /*****************************************************************
         * Constants
         * **************************************************************/
        // Type of droid model
        private const string MODELTYPE = "Janitor";

        // Price increase if the droid is equipped with a broom
        private const decimal COST_OF_BROOM_DECIMAL = 50m;
        // Price increase if the droid is equipped with a vacuum
        private const decimal COST_OF_VACUUM_DECIMAL = 150m;

        /*****************************************************************
         * Variables / Backing Fields
         * **************************************************************/
        // Does the droid have a broom
        private bool _broomBoolean;
        // Does the droid have a vacuum
        private bool _vacuumBoolean;

        /*****************************************************************
         * Constructors
         * **************************************************************/
        public Janitor(
            string passDesignationString,
            string passMaterialString,
            string passColorString,
            bool passToolsBoolean,
            bool passComputerJackBoolean,
            bool passScannerBoolean,
            bool passBroomBoolean,
            bool passVacuumBoolean) : base(
                passDesignationString,
                passMaterialString,
                passColorString,
                passToolsBoolean,
                passComputerJackBoolean,
                passScannerBoolean)
        {
            // Set if the droid is equipped with a broom
            this._broomBoolean = passBroomBoolean;

            // Set if the droid is equipped with a vacuum
            this._vacuumBoolean = passVacuumBoolean;

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
        public override void CalculateTotalCost()
        {
            //
            base.CalculateTotalCost();

            //
            this.TotalCost += this.CalculateEquipmentCost(_broomBoolean, COST_OF_BROOM_DECIMAL) +
                this.CalculateEquipmentCost(_vacuumBoolean, COST_OF_VACUUM_DECIMAL);

        }

        /// <summary>
        /// Create a formatted series of strings containing the values
        /// associated with the Janitor class
        /// </summary>
        /// <returns> The formatted formatted string of a droid's name, hull
        /// material, hull color, tool box status, data probe status, scanner status,
        /// broom status, and vacuum status </returns>
        public override string ToString()
        {
            //
            decimal totalBroomCostDecimal = this.CalculateEquipmentCost(_broomBoolean, COST_OF_BROOM_DECIMAL);

            //
            decimal totalVacuumCostDecimal = this.CalculateEquipmentCost(_vacuumBoolean, COST_OF_VACUUM_DECIMAL);

            //
            return $"{base.ToString()}" +
                "Broom:".PadRight(25) + $"{this._broomBoolean}".PadRight(14) + $"+ {totalBroomCostDecimal} Galactic Credits" + Environment.NewLine +
                "Vacuum:".PadRight(25) + $"{this._vacuumBoolean}".PadRight(14) + $"+ {totalVacuumCostDecimal} Galactic Credits" + Environment.NewLine;

        }

    }

}
