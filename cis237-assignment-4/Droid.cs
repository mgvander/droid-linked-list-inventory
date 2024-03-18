/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 4

using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    public abstract class Droid : IDroid
    {
        /*****************************************************************
         * Constants
         * **************************************************************/
        // Number of predetermined materials the user can choose from
        private const int NUMBER_OF_MATERIALS = 9;

        // Array of predetermined materials the user can choose from
        private string[] _materials = new string[NUMBER_OF_MATERIALS] {
            "Chromium",
            "Cortosis",
            "Dolovite",
            "Duraplast",
            "Durasteel",
            "Iron",
            "Plasteel",
            "Platinum",
            "Silver" };

        // An array parallel to the materials array, containing the cost of the materials
        private decimal[] _materialPrices = new decimal[NUMBER_OF_MATERIALS] {
            11_000m,
            12_000m,
            9_000m,
            8_000m,
            10_000m,
            8_500m,
            9_500m,
            15_000m,
            13_000m };

        /*****************************************************************
         * Variables / Backing Fields
         * **************************************************************/
        // Total cost of a droid
        private decimal _totalCostDecimal;
        // Serial designation of the driod
        private string _serialDesignationString;
        // Hull material of a droid
        private string _materialString;
        // Hull coloring
        private string _colorString;

        /*****************************************************************
         * Constructors
         * **************************************************************/
        protected Droid(string passDesignationString, string passMaterialString, string passColorString)
        {
            // Set the droid's serial designation
            this._serialDesignationString = passDesignationString;
            // Set the droid's hull material
            this._materialString = passMaterialString;
            // Set the droid's hull color
            this._colorString = passColorString;

        }

        /*****************************************************************
         * Properties
         * **************************************************************/
        // Total cost of a droid
        public decimal TotalCost
        {
            get { return _totalCostDecimal; }
            set { _totalCostDecimal = value; }
        }

        // The type of droid
        public abstract string Model { get; }

        // The array of materials
        public string[] Materials
        {
            get { return this._materials; }
        }

        // The array of material prices
        public decimal[] MaterialPrices
        {
            get { return this._materialPrices; }
        }

        // The material the droid is made out of
        public string Material
        {
            get { return _materialString; }
        }

        /*****************************************************************
         * Methods
         * **************************************************************/
        /// <summary>
        /// Adds calculated material cost to the class property, TotalCost
        /// </summary>
        public virtual void CalculateTotalCost()
        {
            // Add the cost of the material to the TotalCost
            this.TotalCost += this.CalculateMaterialCost();

        }

        /// <summary>
        /// Create a formatted series of strings containing the values
        /// associated with the Droid class
        /// </summary>
        /// <returns> The formatted string of a droid's name, hull
        /// material, and hull color </returns>
        public override string ToString()
        {
            // Set the variable to the cost
            decimal totalMaterialCost = this.CalculateMaterialCost();

            // Return the formatted concatenated string a values associated with the Droid class
            return "Serial Designation:".PadRight(25) + $"{this._serialDesignationString}" + Environment.NewLine +
                "Hull Material:".PadRight(25) + $"{this._materialString}".PadRight(14) + $"+ {totalMaterialCost} Galactic Credits" + Environment.NewLine +
                "Hull Color:".PadRight(25) + $"{this._colorString}" + Environment.NewLine;

        }

        /// <summary>
        /// Search for a value in the materials array that matches the value of
        /// the droid's material and then return the cost of the that material.
        /// </summary>
        /// <returns> The price of the droid's material </returns>
        protected decimal CalculateMaterialCost()
        {
            // Check that the class Property holds a value
            if (this.Material != null)
            {
                // Iterate through the length of the materials array
                for (int indexInteger = 0; indexInteger < this.Materials.Length; ++indexInteger)
                {
                    // Checks if the element being looked at is equal to the droid's hull material
                    if (string.Equals(this.Materials[indexInteger], this.Material))
                    {
                        // Set the index from the array of prices, equal to the index the material was
                        // found at
                        int materialPriceIndexInteger = indexInteger;

                        // Return the price from material price array
                        return this.MaterialPrices[materialPriceIndexInteger];

                    }

                }

            }

            // No material means 0 price
            return 0;

        }

        /// <summary>
        /// Return the cost of the equipment if doid has it.
        /// </summary>
        /// <param name="passEquippedBoolean"> Does the droid have the equipment? </param>
        /// <param name="passPriceDecimal"> Price of the equipment </param>
        /// <returns> Either the price of the equipment or 0 </returns>
        protected decimal CalculateEquipmentCost(bool passEquippedBoolean, decimal passPriceDecimal)
        {

            // Check if the droid is equipped
            if (passEquippedBoolean)
            {
                // Return the price of the equipment
                return passPriceDecimal;

            }

            // The droid was not equipped so the price is 0
            return 0;

        }

        /// <summary>
        /// Multiply the price of one software varient by the number of varient is knows
        /// </summary>
        /// <param name="passSoftwaresInteger"> Number of software varient known </param>
        /// <param name="passPriceDecimal"> Price of one software varient </param>
        /// <returns> Product value of the droids software </returns>
        protected decimal CalculateSoftwareCost(int passSoftwaresInteger, decimal passPriceDecimal)
        {
            // Return the product value of the price
            return passSoftwaresInteger * passPriceDecimal;

        }

        /// <summary>
        /// Compare the current instance of Droid's total price to a passed in Droid's
        /// total price
        /// </summary>
        /// <param name="obj"> Droid to be compared to the current instance of Droid </param>
        /// <returns> Comparison in integer form.
        ///  Less than zero - This instance proceeds obj in sequence
        ///  Zero - This instance occurs in the same position in sequence as obj
        ///  Greater than zero - This instance follows obj in sequence </returns>
        /// <exception cref="Exception"> Object is not a Droid </exception>
        public int CompareTo(object obj)
        {
            // Check data is stored in the passed in object
            // This instance of Droid should proceed null values
            // This is represented by negative values
            if (obj == null) return -1;

            // Set a variable to the passed in droid as the highest inheritance of Droid
            Droid otherDroid = obj as Droid;
            
            // Check that other droid holds data
            if (otherDroid != null)
            {
                // Compare this instance's total price to the passed in droid's total cost
                // Return the outcome
                return this._totalCostDecimal.CompareTo(otherDroid._totalCostDecimal);

            }
            // The otherDroid was null
            else
            {
                // Display Error Message
                throw new Exception("Object is not a Droid");

            }

        }
    }

}
