using NCodexSDK.AppServer;
using NCodexSDK.Public;
using NCodexSDK.Tests.TestHelpers;

namespace NCodexSDK.Tests.Integration;

public sealed class AppServerE2ETests
{
    [CodexE2EFact]
    public async Task AppServer_Starts_AndInitializes_WhenEnabled()
    {
        await using var client = await CodexAppServerClient.StartAsync(new CodexAppServerClientOptions
        {
            Launch = CodexLaunch.CodexOnPath().WithArgs("app-server")
        });
    }
}
