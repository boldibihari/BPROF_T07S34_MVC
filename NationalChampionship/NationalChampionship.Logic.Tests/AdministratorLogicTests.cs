// <copyright file="AdministratorLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Tests
{
    using System;
    using Moq;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Classes;
    using NationalChampionship.Repository.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// AdministratorLogicTests test class.
    /// </summary>
    [TestFixture]
    public class AdministratorLogicTests
    {
        /// <summary>
        /// AddClubTest test method.
        /// </summary>
        [Test]
        public void AddClubTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            clubRepository.Setup(club => club.Add(It.IsAny<Club>()));

            AdministratorLogic administratorLogic = new AdministratorLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            Club club = new Club()
            {
                ClubId = 1,
                ClubName = "Puskás Akadémia FC",
                ClubCity = "Felcsút",
                ClubColour = "blue-yellow",
                ClubFounded = 2012,
                Stadium = "Pancho Aréna",
            };

            administratorLogic.AddClub(club);
            clubRepository.Verify(repo => repo.Add(club), Times.Once);
        }

        /// <summary>
        /// DeleteManagerTest test method.
        /// </summary>
        [Test]
        public void DeleteManagerTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            managerRepository.Setup(manager => manager.Delete(It.IsAny<int>()));

            AdministratorLogic administratorLogic = new AdministratorLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            Manager manager = new Manager()
            {
                ManagerId = 1,
                ManagerName = "Szerhij Rebrov",
                ManagerNationality = "Ukrainian",
                ManagerBirthDate = new DateTime(1974, 06, 03),
                ManagerStartYear = 2018,
                WonChampionship = true,
            };

            administratorLogic.DeleteManager(manager.ManagerId);
            managerRepository.Verify(repo => repo.Delete(manager.ManagerId), Times.Once);
        }

        /// <summary>
        /// UpdatePlayerTest test method.
        /// </summary>
        [Test]
        public void UpdatePlayerTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            Player oldPlayer = new Player()
            {
                PlayerId = 1,
                PlayerName = "Tokmac Nguen",
                PlayerNationality = "Norvegian",
                PlayerBirthDate = new DateTime(1993, 10, 20),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.80,
            };

            Player newPlayer = new Player()
            {
                PlayerName = "Tokmac Nguen",
                PlayerNationality = "Norvegian",
                PlayerBirthDate = new DateTime(1993, 10, 20),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 5,
            };

            playerRepository.Setup(player => player.Update(oldPlayer.PlayerId, newPlayer));

            AdministratorLogic administratorLogic = new AdministratorLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            administratorLogic.UpdatePlayer(oldPlayer.PlayerId, newPlayer);
            playerRepository.Verify(repo => repo.Update(oldPlayer.PlayerId, newPlayer), Times.Once);
        }
    }
}
