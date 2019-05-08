namespace SFS.AgileCRM.Library.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;

    /// <summary>
    /// DO NOT USE.
    /// </summary>
    [Obsolete("DO NOT USE.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDealsService
    {
        /// <summary>
        /// Creates a new deal and attaches it to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="agileCrmDealModel">The AgileCRM deal model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task CreateAsync(string emailAddress, AgileCrmDealRequest agileCrmDealModel);

        /// <summary>
        /// Deletes an existing deal via its identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task DeleteAsync(long dealId);

        /// <summary>
        /// Gets all existing deal(s) related to a contact via their email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<AgileCrmDealEntity>> GetAllAsync(string emailAddress);

        /// <summary>
        /// Updates an existing deal via its identifier.
        /// </summary>
        /// <param name="dealId">The deal identifier.</param>
        /// <param name="agileCrmDealModel">The AgileCRM deal model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task UpdateAsync(long dealId, AgileCrmDealRequest agileCrmDealModel);
    }
}