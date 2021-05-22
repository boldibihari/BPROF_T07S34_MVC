// <copyright file="CommonRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Repository.Classes
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NationalChampionship.Repository.Interfaces;

    /// <summary>
    /// CommonRepository main abstract class.
    /// </summary>
    /// <typeparam name="T">Any object.</typeparam>
    public abstract class CommonRepository<T> : ICommonRepository<T>
        where T : class
    {
        /// <summary>
        /// Context implementation.
        /// </summary>
        protected DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRepository{T}"/> class.
        /// CommonRepository constructor.
        /// </summary>
        /// <param name="context">NationalChampionshipDbContext class implementation.</param>
        protected CommonRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <param name="item">Any object.</param>
        public void Add(T item)
        {
            this.context.Set<T>().Add(item);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="item">Any object.</param>
        public void Delete(T item)
        {
            this.context.Set<T>().Remove(item);
            this.context.SaveChanges();
        }

        public abstract void Delete(int id);

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="oldid">ObjectId that we want to update.</param>
        /// <param name="newitem">The updated object.</param>
        public abstract void Update(int oldid, T newitem);

        /// <summary>
        /// GetOne method.
        /// </summary>
        /// <param name="id">Object to list.</param>
        /// <returns>
        /// One object.
        /// </returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// GetAll method.
        /// </summary>
        /// <returns>
        /// All object.
        /// </returns>
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }
    }
}
