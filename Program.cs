// <copyright file="Program.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// This is the driver class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This is the main entry point of execution.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This method creates the host builder.
        /// </summary>
        /// <param name="args">System arguments.</param>
        /// <returns>An instance of type <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}