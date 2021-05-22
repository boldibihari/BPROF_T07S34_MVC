// <copyright file="ICommonRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Repository.Interfaces
{
    using System.Linq;

    /// <summary>
    /// ICommonRepository interface.
    /// </summary>
    /// <typeparam name="T">Any object.</typeparam>
    public interface ICommonRepository<T>
        where T : class
    {
        /// <summary>
        /// Add method.
        /// </summary>
        /// <param name="item">Any object.</param>
        void Add(T item);

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="item">Any object.</param>
        void Delete(T item);

        void Delete(int id);

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="oldid">ObjectId that we want to update.</param>
        /// <param name="newitem">The updated object.</param>
        void Update(int oldid, T newitem);

        /// <summary>
        /// GetOne method.
        /// </summary>
        /// <param name="id">Object to list.</param>
        /// <returns>
        /// One object.
        /// </returns>
        T GetOne(int id);

        /// <summary>
        /// GetAll method.
        /// </summary>
        /// <returns>
        /// All object.
        /// </returns>
        IQueryable<T> GetAll();
    }
}
