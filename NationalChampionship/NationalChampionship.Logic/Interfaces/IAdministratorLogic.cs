// <copyright file="IAdministratorLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Interfaces
{
    using NationalChampionship.Data.Models;

    /// <summary>
    /// IAdministratorLogic interface with all administration methods.
    /// </summary>
    public interface IAdministratorLogic
    {
        /// <summary>
        /// AddClub method.
        /// </summary>
        /// <param name="club">Club to add.</param>
        void AddClub(Club club);

        /// <summary>
        /// AddManager method.
        /// </summary>
        /// <param name="manager">Manager to add.</param>
        void AddManager(Manager manager);

        /// <summary>
        /// AddPlayer method.
        /// </summary>
        /// <param name="player">Player to add.</param>
        void AddPlayer(Player player);

        /// <summary>
        /// DeleteClub method.
        /// </summary>
        /// <param name="clubid">Club id to delete.</param>
        void DeleteClub(int clubid);

        /// <summary>
        /// DeleteManager method.
        /// </summary>
        /// <param name="managerid">Manager id to delete.</param>
        void DeleteManager(int managerid);

        /// <summary>
        /// DeletePlayer method.
        /// </summary>
        /// <param name="playerid">Player to delete.</param>
        void DeletePlayer(int playerid);

        /// <summary>
        /// UpdateClub method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to update.</param>
        /// <param name="newClub">The updated club.</param>
        void UpdateClub(int idClub, Club newClub);

        /// <summary>
        /// UpdateManager method.
        /// </summary>
        /// <param name="idManager">ManagerId that we want to update.</param>
        /// <param name="newManager">The updated manager.</param>
        void UpdateManager(int idManager, Manager newManager);

        /// <summary>
        /// UpdatePlayer method.
        /// </summary>
        /// <param name="idPlayer">PlayerId that we want to update.</param>
        /// <param name="newPlayer">The updated player.</param>
        void UpdatePlayer(int idPlayer, Player newPlayer);

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
