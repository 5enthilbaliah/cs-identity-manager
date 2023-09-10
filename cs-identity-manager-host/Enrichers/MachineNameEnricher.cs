namespace Serilog.Enrichers;

using System.Runtime.CompilerServices;

using Core;

using Events;

public class MachineNameEnricher: CachedPropertyEnricher
{
    /// <summary>
    /// The property name added to enriched log events.
    /// </summary>
    public const string MachineNamePropertyName = "MachineName";

    // Qualify as uncommon-path
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected override LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
    {
        return propertyFactory.CreateProperty(MachineNamePropertyName, Environment.MachineName);
    }
}