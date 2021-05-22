// <copyright file="AdministratorLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Classes
{
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Interfaces;
    using NationalChampionship.Repository.Interfaces;

    /// <summary>
    /// AdministratorLogic with all administration methods.
    /// </summary>
    public class AdministratorLogic : IAdministratorLogic
    {
        private readonly IClubRepository clubRepository;

        private readonly IManagerRepository managerRepository;

        private readonly IPlayerRepository playerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorLogic"/> class.
        /// AdministratorLogic constructor.
        /// </summary>
        /// <param name="clubRepository">ClubRepository class implementation.</param>
        /// <param name="managerRepository">ManagerRepository class implementation.</param>
        /// <param name="playerRepository">PlayerRepository class implementation.</param>
        public AdministratorLogic(IClubRepository clubRepository, IManagerRepository managerRepository, IPlayerRepository playerRepository)
        {
            this.clubRepository = clubRepository;
            this.managerRepository = managerRepository;
            this.playerRepository = playerRepository;
        }

        /// <summary>
        /// AddClub method.
        /// </summary>
        /// <param name="club">Club to add.</param>
        public void AddClub(Club club)
        {
            this.clubRepository.Add(club);
        }

        /// <summary>
        /// AddManager method.
        /// </summary>
        /// <param name="manager">Manager to add.</param>
        public void AddManager(Manager manager)
        {
            this.managerRepository.Add(manager);
        }

        /// <summary>
        /// AddManagerToClub method.
        /// </summary>
        /// <param name="manager">Manager to add.</param>
        /// <param name="clubid">ClubId where we want to add.</param>
        public void AddManagerToClub(Manager manager, int clubid)
        {
            this.clubRepository.AddManagerToClub(manager, clubid);
        }

        /// <summary>
        /// AddPlayer method.
        /// </summary>
        /// <param name="player">Player to add.</param>
        public void AddPlayer(Player player)
        {
            this.playerRepository.Add(player);
        }

        /// <summary>
        /// AddPlayerToClub method.
        /// </summary>
        /// <param name="player">Player to add.</param>
        /// <param name="clubid">ClubId where we want to add.</param>
        public void AddPlayerToClub(Player player, int clubid)
        {
            this.clubRepository.AddPlayerToClub(player, clubid);
        }

        /// <summary>
        /// DeleteClub method.
        /// </summary>
        /// <param name="clubid">Club to delete.</param>
        public void DeleteClub(int clubid)
        {
            this.clubRepository.Delete(clubid);
        }

        /// <summary>
        /// DeleteManager method.
        /// </summary>
        /// <param name="managerid">Manager to delete.</param>
        public void DeleteManager(int managerid)
        {
            this.managerRepository.Delete(managerid);
        }

        /// <summary>
        /// DeletePlayer method.
        /// </summary>
        /// <param name="playerid">Player to delete.</param>
        public void DeletePlayer(int playerid)
        {
            this.playerRepository.Delete(playerid);
        }

        /// <summary>
        /// UpdateClub method.
        /// </summary>
        /// <param name="idClub">ClubId that we want to update.</param>
        /// <param name="newClub">The updated club.</param>
        public void UpdateClub(int idClub, Club newClub)
        {
            this.clubRepository.Update(idClub, newClub);
        }

        /// <summary>
        /// UpdateManager method.
        /// </summary>
        /// <param name="idManager">ManagerId that we want to update.</param>
        /// <param name="newManager">The updated manager.</param>
        public void UpdateManager(int idManager, Manager newManager)
        {
            this.managerRepository.Update(idManager, newManager);
        }

        /// <summary>
        /// UpdatePlayer method.
        /// </summary>
        /// <param name="idPlayer">PlayerId that we want to update.</param>
        /// <param name="newPlayer">The updated player.</param>
        public void UpdatePlayer(int idPlayer, Player newPlayer)
        {
            this.playerRepository.Update(idPlayer, newPlayer);
        }
    }
}
