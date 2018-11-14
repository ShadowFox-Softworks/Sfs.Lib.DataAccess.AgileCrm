namespace Osw.Lib.DataAccess.AgileCrm.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Osw.Lib.DataAccess.AgileCrm.Interface;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <inheritdoc />
    public sealed class AgileCrmClient : IAgileCrmClient
    {
        /// <summary>
        /// The update contact processor
        /// </summary>
        private readonly IContactProcessor contactProcessor;

        /// <summary>
        /// The create deal processor
        /// </summary>
        private readonly IDealProcessor dealProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgileCrmClient"/> class.
        /// </summary>
        /// <param name="contactProcessor">The contact processor.</param>
        /// <param name="dealProcessor">The deal processor.</param>
        /// <exception cref="ArgumentNullException">
        /// contactProcessor
        /// or
        /// dealProcessor
        /// </exception>
        internal AgileCrmClient(
            IContactProcessor contactProcessor,
            IDealProcessor dealProcessor)
        {
            NullGuard.EnsureNotNull(contactProcessor, nameof(contactProcessor));
            NullGuard.EnsureNotNull(contactProcessor, nameof(contactProcessor));

            this.contactProcessor = contactProcessor;
            this.dealProcessor = dealProcessor;
        }

        /// <inheritdoc />
        public async Task CreateContactAsync(
            AgileCrmContactRequest contactEntity,
            CancellationToken cancellationToken)
        {
            await this.contactProcessor.CreateContactAsync(
                contactEntity, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task CreateDealAsync(
            string emailAddress,
            AgileCrmClientDealEntity dealEntity,
            CancellationToken cancellationToken)
        {
            await this.dealProcessor.CreateDealAsync(
                emailAddress, dealEntity, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteContactAsync(string emailAddress, CancellationToken cancellationToken)
        {
            await this.contactProcessor.DeleteContactAsync(
                emailAddress, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            string dealId = default(string))
        {
            await this.dealProcessor.DeleteDealAsync(
                emailAddress, cancellationToken, dealId).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<AgileCrmClientDealEntity>> GetAllDealsAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            var agileCrmDealEntities = await this.dealProcessor.GetAllDealsAsync(
                emailAddress, cancellationToken).ConfigureAwait(false);

            return agileCrmDealEntities;
        }

        /// <inheritdoc />
        public async Task<AgileCrmContactRequest> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            var agileCrmContactEntity = await this.contactProcessor.GetContactAsync(
                emailAddress, cancellationToken).ConfigureAwait(false);

            return agileCrmContactEntity;
        }

        /// <inheritdoc />
        public async Task<AgileCrmClientDealEntity> GetDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            string dealId = default(string))
        {
            var agileCrmDealEntity = await this.dealProcessor.GetDealAsync(
                emailAddress, cancellationToken).ConfigureAwait(false);

            return agileCrmDealEntity;
        }

        /// <inheritdoc />
        public async Task UpdateContactAsync(
            string emailAddress,
            AgileCrmContactRequest contactEntity,
            CancellationToken cancellationToken)
        {
            await this.contactProcessor.UpdateContactAsync(
                emailAddress, contactEntity, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task UpdateDealAsync(
            string emailAddress,
            AgileCrmClientDealEntity dealEntity,
            CancellationToken cancellationToken,
            string dealId = default(string))
        {
            await this.dealProcessor.UpdateDealAsync(
                emailAddress, dealEntity, cancellationToken, dealId).ConfigureAwait(false);
        }
    }
}