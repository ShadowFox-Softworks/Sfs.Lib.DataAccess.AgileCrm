namespace Sfs.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Companies;

    /// <summary>
    /// The Companies Processor.
    /// </summary>
    internal interface ICompaniesProcessor
    {
        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="agileCrmClientCompanyEntity">The agile CRM client company entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task CreateCompanyAsync(
            AgileCrmClientCompanyEntity agileCrmClientCompanyEntity,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes an existing company via its identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task DeleteConpanyAsync(
            long companyId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets an existing company via their name.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<AgileCrmServerCompanyEntity> GetCompanyAsync(
            long companyId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing company via its identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="agileCrmClientCompanyEntity">The agile CRM client company entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task UpdateCompanyAsync(
            long companyId,
            AgileCrmClientCompanyEntity agileCrmClientCompanyEntity,
            CancellationToken cancellationToken);
    }
}