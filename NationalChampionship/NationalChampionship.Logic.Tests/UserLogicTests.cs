// <copyright file="UserLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Classes;
    using NationalChampionship.Repository.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// UserLogicTests test class.
    /// </summary>
    [TestFixture]
    public class UserLogicTests
    {
        /// <summary>
        /// GetOneClubTest test method.
        /// </summary>
        [Test]
        public void GetOneClubTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            List<Club> clubs = new List<Club>()
            {
                new Club()
                {
                  ClubId = 1,
                  ClubName = "Mezőkövesd Zsóry FC",
                  ClubCity = "Mezőkövesd",
                  ClubColour = "blue-yellow",
                  ClubFounded = 1975,
                  Stadium = "Mezőkövesdi Stadion",
                },
                new Club()
                {
                  ClubId = 2,
                  ClubName = "Budapest Honvéd FC",
                  ClubCity = "Budapest",
                  ClubColour = "red-black",
                  ClubFounded = 1909,
                  Stadium = "Bozsik József Stadion",
                },
                new Club()
                {
                  ClubId = 3,
                  ClubName = "Újpest FC",
                  ClubCity = "Budapest",
                  ClubColour = "purple-white",
                  ClubFounded = 1885,
                  Stadium = "Szusza Ferenc Stadion",
                },
            };

            clubRepository.Setup(cllub => cllub.GetOne(clubs[1].ClubId)).Returns(clubs[1]);

            UserLogic userLogic = new UserLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            userLogic.GetOneClub(clubs[1].ClubId);
            clubRepository.Verify(repo => repo.GetOne(2), Times.Once);
        }

        /// <summary>
        /// GetAllManagerTest test method.
        /// </summary>
        [Test]
        public void GetAllManagerTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            List<Manager> managers = new List<Manager>()
            {
                new Manager()
                {
                  ManagerId = 1,
                  ManagerName = "Szerhij Rebrov",
                  ManagerNationality = "Ukrainian",
                  ManagerBirthDate = new DateTime(1974, 06, 03),
                  ManagerStartYear = 2018,
                  WonChampionship = true,
                },
                new Manager()
                {
                  ManagerId = 2,
                  ManagerName = "Gábor Márton",
                  ManagerNationality = "Hungarian",
                  ManagerBirthDate = new DateTime(1966, 10, 15),
                  ManagerStartYear = 2020,
                  WonChampionship = false,
                },
                new Manager()
                {
                  ManagerId = 3,
                  ManagerName = "Zsolt Hornyák",
                  ManagerNationality = "Slovakian",
                  ManagerBirthDate = new DateTime(1973, 05, 01),
                  ManagerStartYear = 2019,
                  WonChampionship = false,
                },
            };

            managerRepository.Setup(manager => manager.GetAll()).Returns(managers.AsQueryable());

            UserLogic userLogic = new UserLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            userLogic.GetAllManager();
            managerRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// AverageClubValueTest test method.
        /// </summary>
        [Test]
        public void AverageClubValueTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            List<Club> clubs = new List<Club>()
            {
                new Club()
                {
                  ClubId = 1,
                  ClubName = "Mezőkövesd Zsóry FC",
                  ClubCity = "Mezőkövesd",
                  ClubColour = "blue-yellow",
                  ClubFounded = 1975,
                  Stadium = "Mezőkövesdi Stadion",
                },
                new Club()
                {
                  ClubId = 2,
                  ClubName = "Budapest Honvéd FC",
                  ClubCity = "Budapest",
                  ClubColour = "red-black",
                  ClubFounded = 1909,
                  Stadium = "Bozsik József Stadion",
                },
                new Club()
                {
                  ClubId = 3,
                  ClubName = "Újpest FC",
                  ClubCity = "Budapest",
                  ClubColour = "purple-white",
                  ClubFounded = 1885,
                  Stadium = "Szusza Ferenc Stadion",
                },
            };

            List<Player> players = new List<Player>()
            {
                new Player()
                {
                  PlayerId = 1,
                  PlayerName = "Tokmac Nguen",
                  PlayerNationality = "Norvegian",
                  PlayerBirthDate = new DateTime(1993, 10, 20),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.80,
                  Club = clubs[0],
                },
                new Player()
                {
                  PlayerId = 2,
                  PlayerName = "Myrto Uzuni",
                  PlayerNationality = "Albanian",
                  PlayerBirthDate = new DateTime(1995, 05, 31),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.20,
                  Club = clubs[0],
                },
                new Player()
                {
                  PlayerId = 3,
                  PlayerName = "Tokmac Nguen",
                  PlayerNationality = "Norvegian",
                  PlayerBirthDate = new DateTime(1993, 10, 20),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.80,
                  Club = clubs[1],
                },
                new Player()
                {
                  PlayerId = 4,
                  PlayerName = "Myrto Uzuni",
                  PlayerNationality = "Albanian",
                  PlayerBirthDate = new DateTime(1995, 05, 31),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.20,
                  Club = clubs[1],
                },
                new Player()
                {
                  PlayerId = 5,
                  PlayerName = "Tokmac Nguen",
                  PlayerNationality = "Norvegian",
                  PlayerBirthDate = new DateTime(1993, 10, 20),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.80,
                  Club = clubs[2],
                },
                new Player()
                {
                  PlayerId = 6,
                  PlayerName = "Myrto Uzuni",
                  PlayerNationality = "Hungary",
                  PlayerBirthDate = new DateTime(1995, 05, 31),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.20,
                  Club = clubs[2],
                },
            };

            playerRepository.Setup(repo => repo.GetAll()).Returns(players.AsQueryable());

            UserLogic userLogic = new UserLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            var value = userLogic.AverageClubValue();
            Assert.That(value, Is.EqualTo(5));
            playerRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// GetNationalityOneClubTest test method.
        /// </summary>
        [Test]
        public void GetNationalityOneClubTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            List<Player> players = new List<Player>()
            {
                new Player()
                {
                  PlayerId = 1,
                  PlayerName = "Dénes Dibusz",
                  PlayerNationality = "Hungarian",
                  PlayerBirthDate = new DateTime(1990, 11, 16),
                  PlayerPosition = PlayerPosition.Goalkeeper,
                  PlayerValue = 2.20,
                },
                new Player()
                {
                  PlayerId = 2,
                  PlayerName = "Miha Blazic",
                  PlayerNationality = "Slovenian",
                  PlayerBirthDate = new DateTime(1993, 05, 08),
                  PlayerPosition = PlayerPosition.Defender,
                  PlayerValue = 2.00,
                },
                new Player()
                {
                  PlayerId = 3,
                  PlayerName = "Gergő Lovrencsics C",
                  PlayerNationality = "Hungarian",
                  PlayerBirthDate = new DateTime(1988, 11, 01),
                  PlayerPosition = PlayerPosition.Defender,
                  PlayerValue = 0.800,
                },
                new Player()
                {
                  PlayerId = 4,
                  PlayerName = "Igor Kharatin",
                  PlayerNationality = "Ukrainian",
                  PlayerBirthDate = new DateTime(1995, 02, 02),
                  PlayerPosition = PlayerPosition.Midfielder,
                  PlayerValue = 2.50,
                },
                new Player()
                {
                    PlayerId = 5,
                    PlayerName = "Dávid Sigér",
                    PlayerNationality = "Hungarian",
                    PlayerBirthDate = new DateTime(1990, 11, 30),
                    PlayerPosition = PlayerPosition.Midfielder,
                    PlayerValue = 1.00,
                },
                new Player()
                {
                    PlayerId = 6,
                    PlayerName = "Oleksandr Zubkov",
                    PlayerNationality = "Ukrainian",
                    PlayerBirthDate = new DateTime(1996, 08, 03),
                    PlayerPosition = PlayerPosition.Forward,
                    PlayerValue = 2.00,
                },
                new Player()
                {
                  PlayerId = 7,
                  PlayerName = "Tokmac Nguen",
                  PlayerNationality = "Norvegian",
                  PlayerBirthDate = new DateTime(1993, 10, 20),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.80,
                },
                new Player()
                {
                  PlayerId = 8,
                  PlayerName = "Myrto Uzuni",
                  PlayerNationality = "Albanian",
                  PlayerBirthDate = new DateTime(1995, 05, 31),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.20,
                },
            };

            Club club = new Club()
            {
                ClubId = 1,
                ClubName = "Ferencvárosi TC",
                ClubCity = "Budapest",
                ClubColour = "green-white",
                ClubFounded = 1899,
                Stadium = "Groupama Aréna",
                Players = players,
            };

            List<Nationality> nationalities = new List<Nationality>()
            {
                new Nationality()
                {
                    PlayerNationality = "Hungarian",
                    Count = 3,
                },
                new Nationality()
                {
                    PlayerNationality = "Ukrainian",
                    Count = 2,
                },
                new Nationality()
                {
                    PlayerNationality = "Albanian",
                    Count = 1,
                },
                new Nationality()
                {
                    PlayerNationality = "Norvegian",
                    Count = 1,
                },
                new Nationality()
                {
                    PlayerNationality = "Slovenian",
                    Count = 1,
                },
            };

            clubRepository.Setup(repo => repo.GetOne(club.ClubId)).Returns(club);

            UserLogic userLogic = new UserLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            var value = userLogic.GetNationalityOneClub(club.ClubId);
            Assert.That(value, Is.EqualTo(nationalities));
            clubRepository.Verify(repo => repo.GetOne(club.ClubId), Times.Once);
        }

        /// <summary>
        /// GetPositionOneClubTest test method.
        /// </summary>
        [Test]
        public void GetPositionOneClubTest()
        {
            Mock<IClubRepository> clubRepository = new Mock<IClubRepository>();
            Mock<IManagerRepository> managerRepository = new Mock<IManagerRepository>();
            Mock<IPlayerRepository> playerRepository = new Mock<IPlayerRepository>();

            List<Player> players = new List<Player>()
            {
                new Player()
                {
                  PlayerId = 1,
                  PlayerName = "Dénes Dibusz",
                  PlayerNationality = "Hungarian",
                  PlayerBirthDate = new DateTime(1990, 11, 16),
                  PlayerPosition = PlayerPosition.Goalkeeper,
                  PlayerValue = 2.20,
                },
                new Player()
                {
                  PlayerId = 2,
                  PlayerName = "Miha Blazic",
                  PlayerNationality = "Slovenian",
                  PlayerBirthDate = new DateTime(1993, 05, 08),
                  PlayerPosition = PlayerPosition.Defender,
                  PlayerValue = 2.00,
                },
                new Player()
                {
                  PlayerId = 3,
                  PlayerName = "Gergő Lovrencsics C",
                  PlayerNationality = "Hungarian",
                  PlayerBirthDate = new DateTime(1988, 11, 01),
                  PlayerPosition = PlayerPosition.Defender,
                  PlayerValue = 0.800,
                },
                new Player()
                {
                  PlayerId = 4,
                  PlayerName = "Igor Kharatin",
                  PlayerNationality = "Ukrainian",
                  PlayerBirthDate = new DateTime(1995, 02, 02),
                  PlayerPosition = PlayerPosition.Midfielder,
                  PlayerValue = 2.50,
                },
                new Player()
                {
                    PlayerId = 5,
                    PlayerName = "Dávid Sigér",
                    PlayerNationality = "Hungarian",
                    PlayerBirthDate = new DateTime(1990, 11, 30),
                    PlayerPosition = PlayerPosition.Midfielder,
                    PlayerValue = 1.00,
                },
                new Player()
                {
                    PlayerId = 6,
                    PlayerName = "Oleksandr Zubkov",
                    PlayerNationality = "Ukrainian",
                    PlayerBirthDate = new DateTime(1996, 08, 03),
                    PlayerPosition = PlayerPosition.Forward,
                    PlayerValue = 2.00,
                },
                new Player()
                {
                  PlayerId = 7,
                  PlayerName = "Tokmac Nguen",
                  PlayerNationality = "Norvegian",
                  PlayerBirthDate = new DateTime(1993, 10, 20),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.80,
                },
                new Player()
                {
                  PlayerId = 8,
                  PlayerName = "Myrto Uzuni",
                  PlayerNationality = "Albanian",
                  PlayerBirthDate = new DateTime(1995, 05, 31),
                  PlayerPosition = PlayerPosition.Forward,
                  PlayerValue = 2.20,
                },
            };

            Club club = new Club()
            {
                ClubId = 1,
                ClubName = "Ferencvárosi TC",
                ClubCity = "Budapest",
                ClubColour = "green-white",
                ClubFounded = 1899,
                Stadium = "Groupama Aréna",
                Players = players,
            };

            List<Position> positions = new List<Position>()
            {
                new Position()
                {
                    PlayerPosition = PlayerPosition.Goalkeeper,
                    Count = 1,
                },
                new Position()
                {
                    PlayerPosition = PlayerPosition.Defender,
                    Count = 2,
                },
                new Position()
                {
                    PlayerPosition = PlayerPosition.Midfielder,
                    Count = 2,
                },
                new Position()
                {
                    PlayerPosition = PlayerPosition.Forward,
                    Count = 3,
                },
            };

            clubRepository.Setup(repo => repo.GetOne(club.ClubId)).Returns(club);

            UserLogic userLogic = new UserLogic(clubRepository.Object, managerRepository.Object, playerRepository.Object);

            var value = userLogic.GetPositionOneClub(club.ClubId);
            Assert.That(value, Is.EqualTo(positions));
            clubRepository.Verify(repo => repo.GetOne(club.ClubId), Times.Once);
        }
    }
}
