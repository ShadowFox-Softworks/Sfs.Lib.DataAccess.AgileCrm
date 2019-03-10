namespace SFS.AgileCRM.Library.Interfaces.Services
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using SFS.AgileCRM.Library.Entities.Companies;

    /// <summary>
    /// DO NOT USE.
    /// </summary>
    [Obsolete("DO NOT USE.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICompaniesService
    {
        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="agileCrmCompanyModel">The AgileCRM company model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task CreateAsync(AgileCrmCompanyModel agileCrmCompanyModel);

        /// <summary>
        /// Deletes an existing company via its identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task DeleteAsync(long companyId);

        /// <summary>
        /// Gets an existing company via its identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<AgileCrmCompanyEntity> GetAsync(long companyId);

        /// <summary>
        /// Updates an existing company via its identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="agileCrmCompanyModel">The AgileCRM company model.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task UpdateAsync(long companyId, AgileCrmCompanyModel agileCrmCompanyModel);
    }
}