namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Validation Extensions.
    /// </summary>
    internal static class ValidationExtensions
    {
        /// <summary>
        /// Validates the properties of the argument request.
        /// </summary>
        /// <param name="request">The request.</param>
        public static void ValidateModel(this object request)
        {
            var validationContext = new ValidationContext(request);

            Validator.ValidateObject(request, validationContext, true);
        }
    }
}