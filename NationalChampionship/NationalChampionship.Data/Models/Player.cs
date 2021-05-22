// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    /// <summary>
    /// PlayerPosition enum.
    /// </summary>
    public enum PlayerPosition
    {
        /// <summary>
        /// Goalkeeper position.
        /// </summary>
        Goalkeeper,

        /// <summary>
        /// Defender position.
        /// </summary>
        Defender,

        /// <summary>
        /// Midfielder postition.
        /// </summary>
        Midfielder,

        /// <summary>
        /// Forward position.
        /// </summary>
        Forward,
    }

    /// <summary>
    /// Player class.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// PlayerId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        /// <summary>
        /// PlayerName property.
        /// </summary>
        [StringLength(100)]
        public string PlayerName { get; set; }

        /// <summary>
        /// PlayerNationality property.
        /// </summary>
        [StringLength(100)]
        public string PlayerNationality { get; set; }

        /// <summary>
        /// PlayerBirthDate property.
        /// </summary>
        public DateTime PlayerBirthDate { get; set; }

        /// <summary>
        /// PlayerPosition property.
        /// </summary>
        public PlayerPosition PlayerPosition { get; set; }

        /// <summary>
        /// PlayerValue property.
        /// </summary>
        public double PlayerValue { get; set; }

        /// <summary>
        /// ClubId ForeignKey property.
        /// </summary>
        [ForeignKey(nameof(Club))]
        public int ClubId { get; set; }

        /// <summary>
        /// Club NotMapped navigation property.
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        public virtual Club Club { get; set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>
        /// Properties separrated by a space.
        /// </returns>
        public override string ToString()
        {
            return $"{this.PlayerNationality} {this.PlayerBirthDate.ToShortDateString()} ({DateTime.Now.Year - this.PlayerBirthDate.Year}) {this.PlayerPosition} {this.PlayerValue} m EUR";
        }
    }
}
