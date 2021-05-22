// <copyright file="ClubRepository.cs" company="PlaceholderCompany">
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
    /// ClubRepository class with all CRUD methods.
    /// </summary>
    public class ClubRepository : CommonRepository<Club>, IClubRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClubRepository"/> class.
        /// ClubRepository constructor.
        /// </summary>
        /// <param name="context">NationalChampionshipDbContext class implementation.</param>
        public ClubRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="oldid">ClubId that we want to update.</param>
        /// <param name="newitem">The updated club.</param>
        public override void Update(int oldid, Club newitem)
        {
            var olditem = this.GetOne(oldid);
            if (olditem == null || newitem == null)
            {
                throw new ArgumentNullException(nameof(newitem), nameof(olditem));
            }
            else
            {
                olditem.ClubName = newitem.ClubName;
                olditem.ClubColour = newitem.ClubColour;
                olditem.ClubCity = newitem.ClubCity;
                olditem.ClubFounded = newitem.ClubFounded;
                olditem.Stadium = newitem.Stadium;
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// GetOne method.
        /// </summary>
        /// <param name="id">Club to list.</param>
        /// <returns>
        /// One club.
        /// </returns>
        public override Club GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ClubId == id);
        }

        public override void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }

        /// <summary>
        /// AddPlayerToClub method.
        /// </summary>
        /// <param name="player">Player to add.</param>
        /// <param name="clubid">ClubId where we want to add.</param>
        public void AddPlayerToClub(Player player, int clubid)
        {
            this.GetOne(clubid).Players.Add(player);
            this.context.SaveChanges();
        }

        /// <summary>
        /// AddManagerToClub method.
        /// </summary>
        /// <param name="manager">Manager to add.</param>
        /// <param name="clubid">ClubId where we want to add.</param>
        public void AddManagerToClub(Manager manager, int clubid)
        {
            this.GetOne(clubid).Manager = manager;
            this.context.SaveChanges();
        }
    }
}
