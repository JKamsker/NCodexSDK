using JKToolKit.CodexSDK;
using JKToolKit.CodexSDK.AppServer;
using JKToolKit.CodexSDK.AppServer.Notifications;
using JKToolKit.CodexSDK.Public.Models;

namespace JKToolKit.CodexSDK.AppServer.Demo.Demos;

public sealed class StreamingDemo : IAppServerDemo
{
    public async Task RunAsync(string repoPath, CancellationToken ct)
    {
        await using var sdk = CodexSdk.Create(builder =>
            builder.ConfigureAppServer(o =>
                o.DefaultClientInfo = new("ncodexsdk-demo", "JKToolKit.CodexSDK AppServer Demo", "1.0.0")));

        await using var codex = await sdk.AppServer.StartAsync(ct);

        var thread = await codex.StartThreadAsync(new ThreadStartOptions
        {
            Model = CodexModel.Gpt52Codex,
            Cwd = repoPath,
            ApprovalPolicy = CodexApprovalPolicy.Never,
            Sandbox = CodexSandboxMode.WorkspaceWrite
        }, ct);

        await using var turn = await codex.StartTurnAsync(thread.Id, new TurnStartOptions
        {
            Input = [TurnInputItem.Text("Summarize this repo.")],
        }, ct);

        await foreach (var ev in turn.Events(ct))
        {
            if (ev is AgentMessageDeltaNotification delta)
            {
                Console.Write(delta.Delta);
            }
        }

        var completed = await turn.Completion;
        Console.WriteLine($"\nDone: {completed.Status}");
    }
}
