// <copyright file="IClubRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Repository.Interfaces
{
    using NationalChampionship.Data.Models;

    /// <summary>
    /// IClubRepository interface.
    /// </summary>
    public interface IClubRepository : ICommonRepository<Club>
    {
        /// <summary>
        /// AddPlayerToClub method.
        /// </summary>
        /// <param name="player">Player to add.</param>
        /// <param name="clubid">ClubId where we want to add.</param>
        void AddPlayerToClub(Player player, int clubid);

        /// <summary>
        /// AddManagerToClub method.
        /// </summary>
        /// <param name="manager">Manager to add.</param>
        /// <param name="clubid">ClubId where we want to add.</param>
        void AddManagerToClub(Manager manager, int clubid);
    }
}
