// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspire.Dashboard.Otlp.Model;
using Google.Protobuf.Collections;
using OpenTelemetry.Proto.Logs.V1;
using OpenTelemetry.Proto.Metrics.V1;
using OpenTelemetry.Proto.Resource.V1;
using OpenTelemetry.Proto.Trace.V1;

namespace Aspire.Dashboard.Otlp.Storage;
public interface ITelemetryRepository
{
    TimeSpan SubscriptionMinExecuteInterval { get; }
    void AddLogs(AddContext context, RepeatedField<ResourceLogs> resourceLogs);
    void AddLogsCore(AddContext context, OtlpApplication application, RepeatedField<ScopeLogs> scopeLogs);
    void AddMetrics(AddContext context, RepeatedField<ResourceMetrics> resourceMetrics);
    void AddTraces(AddContext context, RepeatedField<ResourceSpans> resourceSpans);
    OtlpApplication? GetApplication(string instanceId);
    List<OtlpApplication> GetApplications();
    Dictionary<OtlpApplication, int> GetApplicationUnviewedErrorLogsCount();
    OtlpInstrument? GetInstrument(GetInstrumentRequest request);
    List<OtlpInstrument> GetInstrumentsSummary(string applicationServiceId);
    List<string> GetLogPropertyKeys(string? applicationServiceId);
    PagedResult<OtlpLogEntry> GetLogs(GetLogsContext context);
    OtlpApplication GetOrAddApplication(Resource resource);
    OtlpTrace? GetTrace(string traceId);
    GetTracesResponse GetTraces(GetTracesRequest context);
    int GetUnviewedErrorLogsCount(string? instanceId);
    void MarkViewedErrorLogs(string? applicationServiceId);
    Subscription OnNewApplications(Func<Task> callback);
    Subscription OnNewLogs(string? applicationId, SubscriptionType subscriptionType, Func<Task> callback);
    Subscription OnNewMetrics(string? applicationId, SubscriptionType subscriptionType, Func<Task> callback);
    Subscription OnNewTraces(string? applicationId, SubscriptionType subscriptionType, Func<Task> callback);
}
