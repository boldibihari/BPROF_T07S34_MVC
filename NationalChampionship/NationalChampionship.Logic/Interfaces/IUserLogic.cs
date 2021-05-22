// <copyright file="IUserLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Classes;

    /// <summary>
    /// IUserLogic interface with all user methods.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// GetOneClub method.
        /// </summary>
        /// <param name="idClub">Club to list.</param>
        /// <returns>
        /// One club.
        /// </returns>
        Club GetOneClub(int idClub);

        /// <summary>
        /// GetOneManager method.
        /// </summary>
        /// <param name="idManager">Manager to list.</param>
        /// /// <returns>
        /// One manager.
        /// </returns>
        Manager GetOneManager(int idManager);

        /// <summary>
        /// GetOnePlayer method.
        /// </summary>
        /// <param name="idPlayer">Player to list.</param>
        /// /// <returns>
        /// One player.
        /// </returns>
        Player GetOnePlayer(int idPlayer);

        /// <summary>
        /// GetAllClub method.
        /// </summary>
        /// <returns>
        /// All club.
        /// </returns>
        IList<Club> GetAllClub();

        /// <summary>
        /// GetAllManager method.
        /// </summary>
        /// <returns>
        /// All manager.
        /// </returns>
        IList<Manager> GetAllManager();

        /// <summary>
        /// GetAllPlayer method.
        /// </summary>
        /// <returns>
        /// All player.
        /// </returns>
        IList<Player> GetAllPlayer();

        /// <summary>
        /// GetAllCaptain method.
        /// </summary>
        /// <returns>
        /// All captain.
        /// </returns>
        IList<Player> GetAllCaptain();

        /// <summary>
        /// ClubAverageAge method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// One average club player age.
        /// </returns>
        int ClubAverageAge(int idClub);

        /// <summary>
        /// AllAverageAge method.
        /// </summary>
        /// <returns>
        /// One average age.
        /// </returns>
        int AllAverageAge();

        /// <summary>
        /// ClubValue method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// One club value.
        /// </returns>
        double ClubValue(int idClub);

        /// <summary>
        /// AllValue method.
        /// </summary>
        /// <returns>
        /// Total value.
        /// </returns>
        double AllValue();

        /// <summary>
        /// AverageClubValue method.
        /// </summary>
        /// <returns>
        /// One average club value.
        /// </returns>
        double AverageClubValue();

        /// <summary>
        /// AverageClubValueAsync method.
        /// </summary>
        /// <returns>
        /// One average club value.
        /// </returns>
        Task<double> AverageClubValueAsync();

        /// <summary>
        /// ClubAveragePlayerValue method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// One average club player value.
        /// </returns>
        double ClubAveragePlayerValue(int idClub);

        /// <summary>
        /// AveragePlayerValue method.
        /// </summary>
        /// <returns>
        /// One average player value.
        /// </returns>
        double AveragePlayerValue();

        /// <summary>
        /// GetNationalityOneClub method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by nationality and count.
        /// </returns>
        IList<Nationality> GetNationalityOneClub(int idClub);

        /// <summary>
        /// GetNationalityOneClubAsync method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by nationality and count.
        /// </returns>
        Task<IList<Nationality>> GetNationalityOneClubAsync(int idClub);

        /// <summary>
        /// GetAllNationality method.
        /// </summary>
        /// <returns>
        /// Grouped by nationality and count.
        /// </returns>
        IList<Nationality> GetAllNationality();

        /// <summary>
        /// GetPositionOneClub method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by position and count.
        /// </returns>
        IList<Position> GetPositionOneClub(int idClub);

        /// <summary>
        /// GetPositionOneClubAsync method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by position and count.
        /// </returns>
        Task<IList<Position>> GetPositionOneClubAsync(int idClub);

        /// <summary>
        /// GetAllPosition method.
        /// </summary>
        /// <returns>
        /// Grouped by position and count.
        /// </returns>
        IList<Position> GetAllPosition();
    }
}
