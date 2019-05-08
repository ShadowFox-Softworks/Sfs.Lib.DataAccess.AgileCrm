namespace SFS.AgileCRM.Test
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using SFS.AgileCRM.Library;
    using SFS.AgileCRM.Library.Data.Configurations;
    using SFS.AgileCRM.Library.Interface;

    /// <summary>
    /// The Test Base.
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        protected TestBase()
        {
            this.StubbedLoggerFactory = new LoggerFactory();

            //this.InitializedLoggerFactory = new LoggerFactory().AddSerilog();

            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().Enrich.FromLogContext().WriteTo.Console().CreateLogger();

            //var configuration = new ConfigurationBuilder().AddUserSecrets<AgileCrmConfiguration>().Build();

            //this.AgileCrmConfiguration = configuration.GetValue<AgileCrmConfiguration>(nameof(this.AgileCrmConfiguration));

            //this.AgileCrmClient = AgileCrmFactory.Create(this.AgileCrmConfiguration, this.InitializedLoggerFactory);
        }

        /// <summary>
        /// Gets the agile CRM client.
        /// </summary>
        protected IAgileCrm AgileCrmClient { get; }

        /// <summary>
        /// Gets the agile CRM configuration.
        /// </summary>
        protected AgileCrmConfiguration AgileCrmConfiguration { get; }

        /// <summary>
        /// Gets an initialized logger factory.
        /// </summary>
        protected ILoggerFactory InitializedLoggerFactory { get; }

        /// <summary>
        /// Gets the stubbed logger factory.
        /// </summary>
        protected ILoggerFactory StubbedLoggerFactory { get; }

        /// <summary>
        /// Gets or sets the stopwatch.
        /// </summary>
        private static Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// Starts the stopwatch.
        /// </summary>
        protected static void StartStopwatch()
        {
            Stopwatch = new Stopwatch();

            Stopwatch.Start();
        }

        /// <summary>
        /// Stops the stopwatch.
        /// </summary>
        protected static void StopStopwatch()
        {
            Stopwatch.Stop();
        }

        /// <summary>
        /// Writes the time elapsed.
        /// </summary>
        protected static void WriteTimeElapsed()
        {
            Console.WriteLine($"Elapsed: {Stopwatch.ElapsedMilliseconds}ms ({Stopwatch.Elapsed})");
        }
    }
}