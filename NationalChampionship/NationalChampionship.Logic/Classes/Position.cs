// <copyright file="Position.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Classes
{
    using System;
    using NationalChampionship.Data.Models;

    /// <summary>
    /// Position Logic classes.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// PlayerPosition property.
        /// </summary>
        public PlayerPosition PlayerPosition { get; set; }

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
            return $"{this.PlayerPosition}: {this.Count}";
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
            return obj is Position position &&
                   this.PlayerPosition == position.PlayerPosition &&
                   this.Count == position.Count;
        }

        /// <summary>
        /// GetHashCode method.
        /// </summary>
        /// <returns>
        /// GetHashCode value.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.PlayerPosition, this.Count);
        }
    }
}
