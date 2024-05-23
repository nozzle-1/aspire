// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspire.Dashboard.Storage.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspire.Dashboard.Storage.EFCore.Configurations;

internal class ApplicationConfiguration
    : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");

        builder.HasKey(x => x.InstanceId);

        builder.Property(x => x.InstanceId).ValueGeneratedNever();

        builder.Property(x => x.ApplicationName).IsRequired();
    }
}
