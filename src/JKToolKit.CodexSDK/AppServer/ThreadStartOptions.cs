using System.Text.Json;
using JKToolKit.CodexSDK.Models;

namespace JKToolKit.CodexSDK.AppServer;

/// <summary>
/// Options for starting a new thread via the Codex app server.
/// </summary>
public sealed class ThreadStartOptions
{
    /// <summary>
    /// Gets or sets an optional model identifier.
    /// </summary>
    public CodexModel? Model { get; set; }

    /// <summary>
    /// Gets or sets an optional model provider identifier.
    /// </summary>
    public string? ModelProvider { get; set; }

    /// <summary>
    /// Gets or sets an optional working directory for the thread.
    /// </summary>
    public string? Cwd { get; set; }

    /// <summary>
    /// Gets or sets an optional approval policy.
    /// </summary>
    public CodexApprovalPolicy? ApprovalPolicy { get; set; }

    /// <summary>
    /// Gets or sets an optional sandbox mode.
    /// </summary>
    public CodexSandboxMode? Sandbox { get; set; }

    /// <summary>
    /// Optional config overrides (arbitrary JSON object).
    /// </summary>
    public JsonElement? Config { get; set; }

    /// <summary>
    /// Gets or sets optional base instructions.
    /// </summary>
    public string? BaseInstructions { get; set; }

    /// <summary>
    /// Gets or sets optional developer instructions.
    /// </summary>
    public string? DeveloperInstructions { get; set; }

    /// <summary>
    /// Optional personality identifier (e.g. "friendly", "pragmatic").
    /// </summary>
    public string? Personality { get; set; }

    /// <summary>
    /// Gets or sets an optional value indicating whether the thread should be ephemeral.
    /// </summary>
    public bool? Ephemeral { get; set; }

    /// <summary>
    /// If true, opt into emitting raw response items on the event stream.
    /// </summary>
    public bool ExperimentalRawEvents { get; set; }
}

