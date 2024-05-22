// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Aspire.Dashboard.Otlp.Storage.EFCore.Models;

public class Application
{
    public string? InstanceId { get; set; }

    public string? ApplicationName { get; set; }
}
