using NCodexSDK.McpServer;
using NCodexSDK.Public;
using NCodexSDK.Tests.TestHelpers;

namespace NCodexSDK.Tests.Integration;

public sealed class McpServerE2ETests
{
    [CodexE2EFact]
    public async Task McpServer_Starts_AndListsTools_WhenEnabled()
    {
        await using var client = await CodexMcpServerClient.StartAsync(new CodexMcpServerClientOptions
        {
            Launch = CodexLaunch.CodexOnPath().WithArgs("mcp-server")
        });

        _ = await client.ListToolsAsync();
    }
}
