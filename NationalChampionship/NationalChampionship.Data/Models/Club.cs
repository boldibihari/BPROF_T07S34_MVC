// <copyright file="Club.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Club class.
    /// </summary>
    public class Club
    {
        /// <summary>
        /// ClubId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }

        /// <summary>
        /// ClubName property.
        /// </summary>
        [StringLength(100)]
        public string ClubName { get; set; }

        /// <summary>
        /// ClubColour property.
        /// </summary>
        [StringLength(100)]
        public string ClubColour { get; set; }

        /// <summary>
        /// ClubCity property.
        /// </summary>
        [StringLength(100)]
        public string ClubCity { get; set; }

        /// <summary>
        /// ClubFounded property.
        /// </summary>
        public int ClubFounded { get; set; }

        /// <summary>
        /// Stadium property.
        /// </summary>
        [StringLength(100)]
        public string Stadium { get; set; }

        /// <summary>
        /// Manager NotMapped navigation property.
        /// </summary>
        [NotMapped]
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Players NotMapped navigation property.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Club"/> class.
        /// Club constructor.
        /// </summary>
        public Club()
        {
            this.Players = new HashSet<Player>();
        }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>
        /// Properties separrated by a space.
        /// </returns>
        public override string ToString()
        {
            return $"{this.ClubColour} {this.ClubCity} {this.ClubFounded} {this.Stadium}";
        }
    }
}
