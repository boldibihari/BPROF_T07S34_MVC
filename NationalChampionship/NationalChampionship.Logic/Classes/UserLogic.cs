// <copyright file="UserLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Interfaces;
    using NationalChampionship.Repository.Interfaces;

    /// <summary>
    /// UserLogic with all user methods.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly IClubRepository clubRepository;

        private readonly IManagerRepository managerRepository;

        private readonly IPlayerRepository playerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// AdministratorLogic constructor.
        /// </summary>
        /// <param name="clubRepository">ClubRepository class implementation.</param>
        /// <param name="managerRepository">ManagerRepository class implementation.</param>
        /// <param name="playerRepository">PlayerRepository class implementation.</param>
        public UserLogic(IClubRepository clubRepository, IManagerRepository managerRepository, IPlayerRepository playerRepository)
        {
            this.clubRepository = clubRepository;
            this.managerRepository = managerRepository;
            this.playerRepository = playerRepository;
        }

        /// <summary>
        /// GetOneClub method.
        /// </summary>
        /// <param name="idClub">Club to list.</param>
        /// <returns>
        /// One club.
        /// </returns>
        public Club GetOneClub(int idClub)
        {
            return this.clubRepository.GetOne(idClub);
        }

        /// <summary>
        /// GetOneManager method.
        /// </summary>
        /// <param name="idManager">Manager to list.</param>
        /// /// <returns>
        /// One manager.
        /// </returns>
        public Manager GetOneManager(int idManager)
        {
            return this.managerRepository.GetOne(idManager);
        }

        /// <summary>
        /// GetOnePlayer method.
        /// </summary>
        /// <param name="idPlayer">Player to list.</param>
        /// /// <returns>
        /// One player.
        /// </returns>
        public Player GetOnePlayer(int idPlayer)
        {
            return this.playerRepository.GetOne(idPlayer);
        }

        /// <summary>
        /// GetAllClub method.
        /// </summary>
        /// <returns>
        /// All club.
        /// </returns>
        public IList<Club> GetAllClub()
        {
            return this.clubRepository.GetAll().ToList();
        }

        /// <summary>
        /// GetAllManager method.
        /// </summary>
        /// <returns>
        /// All manager.
        /// </returns>
        public IList<Manager> GetAllManager()
        {
            return this.managerRepository.GetAll().ToList();
        }

        /// <summary>
        /// GetAllPlayer method.
        /// </summary>
        /// <returns>
        /// All player.
        /// </returns>
        public IList<Player> GetAllPlayer()
        {
            return this.playerRepository.GetAll().ToList();
        }

        /// <summary>
        /// GetAllCaptain method.
        /// </summary>
        /// <returns>
        /// All captain.
        /// </returns>
        public IList<Player> GetAllCaptain()
        {
            return this.playerRepository.GetAll().Where(player => player.PlayerName.EndsWith(" C")).ToList();
        }

        /// <summary>
        /// ClubAverageAge method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// One average club player age.
        /// </returns>
        public int ClubAverageAge(int idClub)
        {
            return (int)this.GetOneClub(idClub).Players.Average(x => DateTime.Now.Year - x.PlayerBirthDate.Year);
        }

        /// <summary>
        /// AllAverageAge method.
        /// </summary>
        /// <returns>
        /// One average age.
        /// </returns>
        public int AllAverageAge()
        {
            return (int)this.GetAllPlayer().Average(x => DateTime.Now.Year - x.PlayerBirthDate.Year);
        }

        /// <summary>
        /// ClubValue method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// One club value.
        /// </returns>
        public double ClubValue(int idClub)
        {
            return Math.Round(this.GetOneClub(idClub).Players.Sum(x => x.PlayerValue), 2);
        }

        /// <summary>
        /// AllValue method.
        /// </summary>
        /// <returns>
        /// Total value.
        /// </returns>
        public double AllValue()
        {
            return Math.Round(this.GetAllPlayer().Sum(x => x.PlayerValue), 2);
        }

        /// <summary>
        /// AverageClubValue method.
        /// </summary>
        /// <returns>
        /// One average club value.
        /// </returns>
        public double AverageClubValue()
        {
            var players = this.GetAllPlayer();

            var q = (from x in players
                     group x by x.Club.ClubId into g
                     select new
                     {
                         ClubID = g.Key,
                         Value = g.Sum(x => x.PlayerValue),
                     }).Average(x => x.Value);

            return Math.Round(q, 2);
        }

        /// <summary>
        /// AverageClubValueAsync method.
        /// </summary>
        /// <returns>
        /// One average club value.
        /// </returns>
        public Task<double> AverageClubValueAsync()
        {
            return Task.Run(() => this.AverageClubValue());
        }

        /// <summary>
        /// ClubAveragePlayerValue method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// One average club player value.
        /// </returns>
        public double ClubAveragePlayerValue(int idClub)
        {
            return Math.Round(this.GetOneClub(idClub).Players.Average(x => x.PlayerValue), 2);
        }

        /// <summary>
        /// AveragePlayerValue method.
        /// </summary>
        /// <returns>
        /// One average player value.
        /// </returns>
        public double AveragePlayerValue()
        {
            return Math.Round(this.GetAllPlayer().Average(x => x.PlayerValue), 2);
        }

        /// <summary>
        /// GetNationalityOneClub method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by nationality and count.
        /// </returns>
        public IList<Nationality> GetNationalityOneClub(int idClub)
        {
            Club club = this.GetOneClub(idClub);

            var q = (from x in club.Players
                    group x by x.PlayerNationality into g
                    select new Nationality()
                    {
                        PlayerNationality = g.Key,
                        Count = g.Count(),
                    }).OrderByDescending(x => x.Count).ThenBy(x => x.PlayerNationality);

            return q.ToList();
        }

        /// <summary>
        /// GetNationalityOneClubAsync method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by nationality and count.
        /// </returns>
        public Task<IList<Nationality>> GetNationalityOneClubAsync(int idClub)
        {
            return Task.Run(() => this.GetNationalityOneClub(idClub));
        }

        /// <summary>
        /// GetAllNationality method.
        /// </summary>
        /// <returns>
        /// Grouped by nationality and count.
        /// </returns>
        public IList<Nationality> GetAllNationality()
        {
            var players = this.GetAllPlayer();

            var q = (from x in players
                    group x by x.PlayerNationality into g
                    select new Nationality()
                    {
                        PlayerNationality = g.Key,
                        Count = g.Count(),
                    }).OrderByDescending(x => x.Count).ThenBy(x => x.PlayerNationality);

            return q.ToList();
        }

        /// <summary>
        /// GetPositionOneClub method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by position and count.
        /// </returns>
        public IList<Position> GetPositionOneClub(int idClub)
        {
            Club club = this.GetOneClub(idClub);

            var q = (from x in club.Players
                     group x by x.PlayerPosition into g
                     select new Position()
                     {
                         PlayerPosition = g.Key,
                         Count = g.Count(),
                     }).OrderBy(x => x.PlayerPosition);

            return q.ToList();
        }

        /// <summary>
        /// GetPositionOneClubAsync method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to list.</param>
        /// <returns>
        /// Grouped by position and count.
        /// </returns>
        public Task<IList<Position>> GetPositionOneClubAsync(int idClub)
        {
            return Task.Run(() => this.GetPositionOneClub(idClub));
        }

        /// <summary>
        /// GetAllPosition method.
        /// </summary>
        /// <returns>
        /// Grouped by position and count.
        /// </returns>
        public IList<Position> GetAllPosition()
        {
            var players = this.GetAllPlayer();

            var q = (from x in players
                     group x by x.PlayerPosition into g
                     select new Position()
                     {
                         PlayerPosition = g.Key,
                         Count = g.Count(),
                     }).OrderBy(x => x.PlayerPosition);

            return q.ToList();
        }
    }
}
