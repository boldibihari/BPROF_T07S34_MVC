// <copyright file="Nationality.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Classes
{
    using System;

    /// <summary>
    /// Nationality Logic classes.
    /// </summary>
    public class Nationality
    {
        /// <summary>
        /// PlayerNationality property.
        /// </summary>
        public string PlayerNationality { get; set; }

        /// <summary>
        /// Count property.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>
        /// Properties separrated by a space.
        /// </returns>
        public override string ToString()
        {
            return $"{this.PlayerNationality}: {this.Count}";
        }

        /// <summary>
        /// Equals method.
        /// </summary>
        /// <param name="obj">Object to be compared.</param>
        /// <returns>
        /// True or false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Nationality nationality &&
                   this.PlayerNationality == nationality.PlayerNationality &&
                   this.Count == nationality.Count;
        }

        /// <summary>
        /// GetHashCode method.
        /// </summary>
        /// <returns>
        /// GetHashCode value.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.PlayerNationality, this.Count);
        }
    }
}
