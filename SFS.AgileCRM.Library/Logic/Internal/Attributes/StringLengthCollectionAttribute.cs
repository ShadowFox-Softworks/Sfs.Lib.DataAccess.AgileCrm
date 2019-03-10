namespace SFS.AgileCRM.Library.Logic.Internal.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The String Length Collection Attribute.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.StringLengthAttribute" />
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class StringLengthCollectionAttribute : StringLengthAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthCollectionAttribute"/> class.
        /// </summary>
        /// <param name="maximumLength">The maximum length of a string.</param>
        public StringLengthCollectionAttribute(int maximumLength)
            : base(maximumLength)
        {
        }

        /// <inheritdoc />
        public override bool IsValid(object value)
        {
            foreach (var item in value as ICollection<string>)
            {
                if (item.Length > this.MaximumLength
                    || item.Length < this.MinimumLength)
                {
                    return false;
                }
            }

            return true;
        }
    }
}