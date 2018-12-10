namespace Sfs.Lib.DataAccess.AgileCrm.Test
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Serilog;

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
            this.LoggerFactoryStub = new LoggerFactory();

            this.InitializedLoggerFactory = new LoggerFactory().AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        /// <summary>
        /// Gets an initialized logger factory.
        /// </summary>
        protected ILoggerFactory InitializedLoggerFactory { get; }

        /// <summary>
        /// Gets the stubbed logger factory.
        /// </summary>
        protected ILoggerFactory LoggerFactoryStub { get; }

        /// <summary>
        /// Writes the time that was elapsed during the test.
        /// </summary>
        /// <param name="stopwatch">The stopwatch.</param>
        protected static void WriteTimeElapsed(Stopwatch stopwatch)
        {
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.Elapsed})");
        }
    }
}