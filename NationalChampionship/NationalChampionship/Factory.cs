// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship
{
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Classes;
    using NationalChampionship.Repository.Classes;

    /// <summary>
    /// Factory class.
    /// </summary>
    public class Factory
    {
        private static readonly NationalChampionshipDbContext Context = new NationalChampionshipDbContext();

        private static readonly ClubRepository ClubRepository = new ClubRepository(Context);

        private static readonly ManagerRepository ManagerRepository = new ManagerRepository(Context);

        private static readonly PlayerRepository PlayerRepository = new PlayerRepository(Context);

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// Factory constructor.
        /// </summary>
        public Factory()
        {
            this.AdministratorLogic = new AdministratorLogic(ClubRepository, ManagerRepository, PlayerRepository);
            this.UserLogic = new UserLogic(ClubRepository, ManagerRepository, PlayerRepository);
        }

        /// <summary>
        /// AdministratorLogic property.
        /// </summary>
        public AdministratorLogic AdministratorLogic { get; set; }

        /// <summary>
        /// UserLogic property.
        /// </summary>
        public UserLogic UserLogic { get; set; }
    }
}
