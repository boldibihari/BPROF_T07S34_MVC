// <copyright file="Manager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Manager class.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// ManagerId property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerId { get; set; }

        /// <summary>
        /// ManagerName property.
        /// </summary>
        [StringLength(100)]
        public string ManagerName { get; set; }

        /// <summary>
        /// ManagerNationality property.
        /// </summary>
        [StringLength(100)]
        public string ManagerNationality { get; set; }

        /// <summary>
        /// ManagerBirthDate property.
        /// </summary>
        public DateTime ManagerBirthDate { get; set; }

        /// <summary>
        /// ManagerStartYear property.
        /// </summary>
        public int ManagerStartYear { get; set; }

        /// <summary>
        /// WonChampionship property.
        /// </summary>
        public bool WonChampionship { get; set; }

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
            return $"{this.ManagerNationality} {this.ManagerBirthDate.ToShortDateString()} ({DateTime.Now.Year - this.ManagerBirthDate.Year}) {this.ManagerStartYear} {this.WonChampionship}";
        }
    }
}
