namespace Serilog.Enrichers;

using Core;

using Events;

public abstract class CachedPropertyEnricher : ILogEventEnricher
{
    private LogEventProperty _cachedProperty { get; set; }

    /// <summary>
    /// Enrich the log event.
    /// </summary>
    /// <param name="logEvent">The log event to enrich.</param>
    /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));
    }

    private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory)
    {
        // Don't care about thread-safety, in the worst case the field gets overwritten and one
        // property will be GCed
        if (_cachedProperty == null)
            _cachedProperty = CreateProperty(propertyFactory);

        return _cachedProperty;
    }
        
    protected abstract LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory);
}