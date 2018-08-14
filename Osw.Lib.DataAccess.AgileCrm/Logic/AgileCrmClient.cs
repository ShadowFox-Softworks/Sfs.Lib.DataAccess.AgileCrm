namespace Osw.Lib.DataAccess.AgileCrm.Logic
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entity;
    using Interface;
    using Interface.Internal.Processors;
    using JetBrains.Annotations;

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
            [NotNull] IContactProcessor contactProcessor,
            [NotNull] IDealProcessor dealProcessor)
        {
            if (contactProcessor == null)
            {
                throw new ArgumentNullException(nameof(contactProcessor));
            }

            if (dealProcessor == null)
            {
                throw new ArgumentNullException(nameof(dealProcessor));
            }

            this.contactProcessor = contactProcessor;
            this.dealProcessor = dealProcessor;
        }

        /// <inheritdoc />
        public async Task CreateContactAsync(
            AgileCrmContactEntity contactEntity,
            CancellationToken cancellationToken)
        {
            await this.contactProcessor.CreateContactAsync(
                    contactEntity,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task CreateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken)
        {
            await this.dealProcessor.CreateDealAsync(
                    emailAddress,
                    dealEntity,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteContactAsync(string emailAddress, CancellationToken cancellationToken)
        {
            await this.contactProcessor.DeleteContactAsync(
                    emailAddress,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
        {
            await this.dealProcessor.DeleteDealAsync(
                    emailAddress,
                    cancellationToken,
                    dealFilter)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<AgileCrmContactEntity> GetContactAsync(
            string emailAddress,
            CancellationToken cancellationToken)
        {
            var agileCrmContactEntity = await this.contactProcessor.GetContactAsync(
                    emailAddress,
                    cancellationToken)
                .ConfigureAwait(false);

            return agileCrmContactEntity;
        }

        /// <inheritdoc />
        public async Task<AgileCrmDealEntity> GetDealAsync(
            string emailAddress,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
        {
            var agileCrmDealEntity = await this.dealProcessor.GetDealAsync(
                    emailAddress,
                    cancellationToken,
                    dealFilter)
                .ConfigureAwait(false);

            return agileCrmDealEntity;
        }

        /// <inheritdoc />
        public async Task UpdateContactAsync(
            string emailAddress,
            AgileCrmContactEntity contactEntity,
            CancellationToken cancellationToken)
        {
            await this.contactProcessor.UpdateContactAsync(
                    emailAddress,
                    contactEntity,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task UpdateDealAsync(
            string emailAddress,
            AgileCrmDealEntity dealEntity,
            CancellationToken cancellationToken,
            AgileCrmDealFilter dealFilter = default(AgileCrmDealFilter))
        {
            await this.dealProcessor.UpdateDealAsync(
                    emailAddress,
                    dealEntity,
                    cancellationToken,
                    dealFilter)
                .ConfigureAwait(false);
        }
    }
}