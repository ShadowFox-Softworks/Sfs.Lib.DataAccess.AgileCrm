namespace SFS.AgileCRM.Test
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using SFS.AgileCRM.Library;
    using SFS.AgileCRM.Library.Entities;
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
            this.Stopwatch = new Stopwatch();

            this.StubbedLoggerFactory = new LoggerFactory();

            this.InitializedLoggerFactory = new LoggerFactory().AddSerilog();

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().Enrich.FromLogContext().WriteTo.Console().CreateLogger();

            var configuration = new ConfigurationBuilder().AddUserSecrets<AgileCrmConfiguration>().Build();

            this.AgileCrmConfiguration = configuration.GetValue<AgileCrmConfiguration>(nameof(this.AgileCrmConfiguration));

            this.AgileCrmClient = AgileCrmFactory.Create(this.InitializedLoggerFactory, this.AgileCrmConfiguration);
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
        /// Gets the stopwatch.
        /// </summary>
        protected Stopwatch Stopwatch { get; }

        /// <summary>
        /// Gets the stubbed logger factory.
        /// </summary>
        protected ILoggerFactory StubbedLoggerFactory { get; }

        /// <summary>
        /// Measures performance by writing the time that was elapsed during 'act' phase of the test.
        /// </summary>
        /// <param name="stopwatch">The stopwatch.</param>
        protected static void WriteTimeElapsed(Stopwatch stopwatch)
        {
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.Elapsed})");

            stopwatch.Reset();
        }
    }
}