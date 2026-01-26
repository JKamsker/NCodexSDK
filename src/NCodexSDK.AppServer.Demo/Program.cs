using NCodexSDK.AppServer;
using NCodexSDK.AppServer.Notifications;
using NCodexSDK.Public.Models;

var repoPath = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

int? timeoutSeconds = null;
for (var i = 0; i < args.Length; i++)
{
    if (string.Equals(args[i], "--timeout-seconds", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length &&
        int.TryParse(args[i + 1], out var parsed))
    {
        timeoutSeconds = parsed;
        break;
    }
}

if (timeoutSeconds is null &&
    int.TryParse(Environment.GetEnvironmentVariable("CODEX_DEMO_TIMEOUT_SECONDS"), out var envTimeout))
{
    timeoutSeconds = envTimeout;
}

using var cts = new CancellationTokenSource();
if (timeoutSeconds is > 0)
{
    cts.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds.Value));
}
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

await using var codex = await CodexAppServerClient.StartAsync(new CodexAppServerClientOptions
{
    DefaultClientInfo = new("ncodexsdk-demo", "NCodexSDK AppServer Demo", "1.0.0"),
}, cts.Token);

var thread = await codex.StartThreadAsync(new ThreadStartOptions
{
    Model = CodexModel.Gpt51Codex,
    Cwd = repoPath,
    ApprovalPolicy = CodexApprovalPolicy.Never,
    Sandbox = CodexSandboxMode.WorkspaceWrite
}, cts.Token);

await using var turn = await codex.StartTurnAsync(thread.Id, new TurnStartOptions
{
    Input = [TurnInputItem.Text("Summarize this repo.")],
}, cts.Token);

try
{
    await foreach (var ev in turn.Events(cts.Token))
    {
        if (ev is AgentMessageDeltaNotification delta)
        {
            Console.Write(delta.Delta);
        }
    }

    var completed = await turn.Completion;
    Console.WriteLine($"\nDone: {completed.Status}");
}
catch (OperationCanceledException)
{
    // Treat Ctrl+C / cancellation as a normal exit for the demo.
}
