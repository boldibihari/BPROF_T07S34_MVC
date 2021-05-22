// <copyright file="ManagerRepository.cs" company="PlaceholderCompany">
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
    /// ManagerRepository class with all CRUD methods.
    /// </summary>
    public class ManagerRepository : CommonRepository<Manager>, IManagerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerRepository"/> class.
        /// ClubRepository constructor.
        /// </summary>
        /// <param name="context">>NationalChampionshipDbContext class implementation.</param>
        public ManagerRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="oldid">ManagerId that we want to update.</param>
        /// <param name="newitem">The updated manager.</param>
        public override void Update(int oldid, Manager newitem)
        {
            var olditem = this.GetOne(oldid);

            if (olditem == null || newitem == null)
            {
                throw new ArgumentNullException(nameof(newitem), nameof(olditem));
            }
            else
            {
                olditem.ManagerName = newitem.ManagerName;
                olditem.ManagerNationality = newitem.ManagerNationality;
                olditem.ManagerBirthDate = newitem.ManagerBirthDate;
                olditem.ManagerStartYear = newitem.ManagerStartYear;
                olditem.WonChampionship = newitem.WonChampionship;
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// GetOne method.
        /// </summary>
        /// <param name="id">Manager to list.</param>
        /// <returns>
        /// One manager.
        /// </returns>
        public override Manager GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ManagerId == id);
        }

        public override void Delete(int id)
        {
            this.Delete(this.GetOne(id));
        }
    }
}
