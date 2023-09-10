namespace Serilog;

using Configuration;

using Enrichers;

public static class EnvironmentLoggerConfigurationExtensions
{
    public static LoggerConfiguration WithMachineName(
        this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
        if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
        return enrichmentConfiguration.With<MachineNameEnricher>();
    }
    
    
}