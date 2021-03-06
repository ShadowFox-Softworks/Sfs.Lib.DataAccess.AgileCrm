﻿namespace SFS.AgileCRM.Library.Data.Configurations
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The AgileCRM Configuration.
    /// </summary>
    public class AgileCrmConfiguration
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        [Required]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Required]
        public string Username { get; set; }
    }
}