// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspire.Dashboard.Otlp.Model;
using Aspire.Dashboard.Storage.EFCore;
using Google.Protobuf.Collections;
using OpenTelemetry.Proto.Logs.V1;
using OpenTelemetry.Proto.Metrics.V1;
using OpenTelemetry.Proto.Resource.V1;
using OpenTelemetry.Proto.Trace.V1;

namespace Aspire.Dashboard.Otlp.Storage;

public class EFCoreTelemetryDecorator : ITelemetryRepository
{
    private readonly TelemetryDbContext _context;
    private readonly ITelemetryRepository _wrappee;

    public EFCoreTelemetryDecorator(TelemetryDbContext context, ITelemetryRepository repository)
    {
        _context = context;
        _wrappee = repository;
    }

    public TimeSpan SubscriptionMinExecuteInterval => throw new NotImplementedException();

    public void AddLogs(AddContext context, RepeatedField<ResourceLogs> resourceLogs)
    {
        //TODO: sauvegarder ici
        _wrappee.AddLogs(context, resourceLogs);
    }

    public void AddLogsCore(AddContext context, OtlpApplication application, RepeatedField<ScopeLogs> scopeLogs)
    {
        _wrappee.AddLogsCore(context, application, scopeLogs);
    }

    public void AddMetrics(AddContext context, RepeatedField<ResourceMetrics> resourceMetrics)
    {
        _wrappee.AddMetrics(context, resourceMetrics);
    }

    public void AddTraces(AddContext context, RepeatedField<ResourceSpans> resourceSpans)
    {
        _wrappee.AddTraces(context, resourceSpans);
    }

    public OtlpApplication? GetApplication(string instanceId)
    {
        return _wrappee?.GetApplication(instanceId);
    }

    public List<OtlpApplication> GetApplications()
    {
        return _wrappee.GetApplications();
    }

    public Dictionary<OtlpApplication, int> GetApplicationUnviewedErrorLogsCount()
    {
        return _wrappee.GetApplicationUnviewedErrorLogsCount();
    }

    public OtlpInstrument? GetInstrument(GetInstrumentRequest request)
    {
        return _wrappee.GetInstrument(request);
    }

    public List<OtlpInstrument> GetInstrumentsSummary(string applicationServiceId)
    {
        return _wrappee.GetInstrumentsSummary(applicationServiceId);
    }

    public List<string> GetLogPropertyKeys(string? applicationServiceId)
    {
        return _wrappee.GetLogPropertyKeys(applicationServiceId);
    }

    public PagedResult<OtlpLogEntry> GetLogs(GetLogsContext context)
    {
        return _wrappee.GetLogs(context);
    }

    public OtlpApplication GetOrAddApplication(Resource resource)
    {
        return _wrappee.GetOrAddApplication(resource);
    }

    public OtlpTrace? GetTrace(string traceId)
    {
        return _wrappee.GetTrace(traceId);
    }

    public GetTracesResponse GetTraces(GetTracesRequest context)
    {
        return _wrappee.GetTraces(context);
    }

    public int GetUnviewedErrorLogsCount(string? instanceId)
    {
        return _wrappee.GetUnviewedErrorLogsCount(instanceId);
    }

    public void MarkViewedErrorLogs(string? applicationServiceId)
    {
        _wrappee.MarkViewedErrorLogs(applicationServiceId);
    }

    public Subscription OnNewApplications(Func<Task> callback)
    {
        return _wrappee.OnNewApplications(callback);
    }

    public Subscription OnNewLogs(string? applicationId, SubscriptionType subscriptionType, Func<Task> callback)
    {
        return _wrappee.OnNewLogs(applicationId, subscriptionType, callback);
    }

    public Subscription OnNewMetrics(string? applicationId, SubscriptionType subscriptionType, Func<Task> callback)
    {
        return _wrappee.OnNewMetrics(applicationId, subscriptionType, callback);
    }

    public Subscription OnNewTraces(string? applicationId, SubscriptionType subscriptionType, Func<Task> callback)
    {
        return _wrappee.OnNewTraces(applicationId, subscriptionType, callback);
    }
}
