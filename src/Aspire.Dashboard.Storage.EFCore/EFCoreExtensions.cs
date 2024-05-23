// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aspire.Dashboard.Storage.EFCore;

/// <summary>
/// 
/// </summary>
public static class EFCoreExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(nameof(TelemetryDbContext));
        if (connectionString is null)
        {
            throw new ArgumentException("No connection strings defined");
        }

        // options.UseNpgsql(connectionString, x => x.MaxBatchSize(10)) //Temporary fix: https://github.com/npgsql/npgsql/issues/5362
        services.AddDbContext<TelemetryDbContext>(options => options.UseNpgsql(connectionString, x =>
        {
            //Azure SQL for PostgreSQL fix
            //x.SetPostgresVersion(12, 0);
        }));

        return services;
    }
}
