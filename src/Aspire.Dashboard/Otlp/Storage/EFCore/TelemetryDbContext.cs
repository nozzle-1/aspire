// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspire.Dashboard.Otlp.Storage.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspire.Dashboard.Otlp.Storage.EFCore;

public class TelemetryDbContext : DbContext
{
    public TelemetryDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
