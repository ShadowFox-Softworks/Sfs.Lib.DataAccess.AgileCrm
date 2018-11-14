namespace Osw.Lib.DataAccess.AgileCrm.Interfaces.Internal.Processors
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
        /// Deletes an existing company via its unique identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task DeleteContactAsync(
            string companyId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets an existing company related to a contact via their email address.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task{TResult}" />.
        /// </returns>
        Task<AgileCrmServerCompanyEntity> GetCompanyAsync(
            string companyId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing company via its unique identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="agileCrmClientCompanyEntity">The agile CRM client company entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <see cref="Task" />.
        /// </returns>
        Task UpdateCompanyAsync(
            string companyId,
            AgileCrmClientCompanyEntity agileCrmClientCompanyEntity,
            CancellationToken cancellationToken);
    }
}