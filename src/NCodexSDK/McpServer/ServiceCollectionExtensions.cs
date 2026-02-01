using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NCodexSDK.Infrastructure;

namespace NCodexSDK.McpServer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCodexMcpServerClient(
        this IServiceCollection services,
        Action<CodexMcpServerClientOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOptions();
        if (configure is not null)
        {
            services.Configure(configure);
        }

        services.AddCodexStdioInfrastructure();

        services.TryAddSingleton<ICodexMcpServerClientFactory, CodexMcpServerClientFactory>();

        return services;
    }
}
