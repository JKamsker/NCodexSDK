using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NCodexSDK.Abstractions;
using NCodexSDK.Infrastructure.Stdio;

namespace NCodexSDK.Infrastructure;

internal static class InternalServiceCollectionExtensions
{
    public static IServiceCollection AddCodexCoreInfrastructure(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.TryAddSingleton<IFileSystem, RealFileSystem>();
        services.TryAddSingleton<ICodexPathProvider, DefaultCodexPathProvider>();

        return services;
    }

    public static IServiceCollection AddCodexStdioInfrastructure(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddCodexCoreInfrastructure();
        services.TryAddSingleton<StdioProcessFactory>();

        return services;
    }
}

