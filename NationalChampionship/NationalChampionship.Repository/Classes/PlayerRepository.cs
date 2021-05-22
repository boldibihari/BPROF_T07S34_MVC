// <copyright file="PlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Repository.Classes
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Repository.Interfaces;

    /// <summary>
    /// PlayerRepository class with all CRUD methods.
    /// </summary>
    public class PlayerRepository : CommonRepository<Player>, IPlayerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// PlayerRepository constructor.
        /// </summary>
        /// <param name="context">NationalChampionshipDbContext class implementation.</param>
        public PlayerRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="oldid">PlayerId that we want to update.</param>
        /// <param name="newitem">The updated player.</param>
        public override void Update(int oldid, Player newitem)
        {
            var olditem = this.GetOne(oldid);

            if (olditem == null || newitem == null)
            {
                throw new ArgumentNullException(nameof(newitem), nameof(olditem));
            }
            else
            {
                olditem.PlayerName = newitem.PlayerName;
                olditem.PlayerNationality = newitem.PlayerNationality;
                olditem.PlayerBirthDate = newitem.PlayerBirthDate;
                olditem.PlayerPosition = newitem.PlayerPosition;
                olditem.PlayerValue = newitem.PlayerValue;
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// GetOne method.
        /// </summary>
        /// <param name="id">Player to list.</param>
        /// <returns>
        /// One player.
        /// </returns>
        public override Player GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.PlayerId == id);
        }

        public override void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }
    }
}
