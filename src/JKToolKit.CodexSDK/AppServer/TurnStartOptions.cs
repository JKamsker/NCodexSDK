using System.Text.Json;
using JKToolKit.CodexSDK.Models;
using JKToolKit.CodexSDK.AppServer.Protocol;

namespace JKToolKit.CodexSDK.AppServer;

/// <summary>
/// Options for starting a new turn on an existing thread.
/// </summary>
public sealed class TurnStartOptions
{
    /// <summary>
    /// Gets or sets the input items for the turn.
    /// </summary>
    public IReadOnlyList<TurnInputItem> Input { get; set; } = Array.Empty<TurnInputItem>();

    /// <summary>
    /// Gets or sets an optional working directory for the turn.
    /// </summary>
    public string? Cwd { get; set; }

    /// <summary>
    /// Gets or sets an optional approval policy.
    /// </summary>
    public CodexApprovalPolicy? ApprovalPolicy { get; set; }

    /// <summary>
    /// Optional sandbox policy override for this turn and subsequent turns.
    /// </summary>
    public SandboxPolicy? SandboxPolicy { get; set; }

    /// <summary>
    /// Gets or sets an optional model identifier.
    /// </summary>
    public CodexModel? Model { get; set; }

    /// <summary>
    /// Gets or sets an optional reasoning effort.
    /// </summary>
    public CodexReasoningEffort? Effort { get; set; }

    /// <summary>
    /// Optional reasoning summary setting (e.g. "auto", "concise", "detailed", "none").
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Optional personality identifier (e.g. "friendly", "pragmatic").
    /// </summary>
    public string? Personality { get; set; }

    /// <summary>
    /// Optional JSON Schema used to constrain the final assistant message for this turn.
    /// </summary>
    public JsonElement? OutputSchema { get; set; }

    /// <summary>
    /// Optional collaboration mode object (experimental).
    /// </summary>
    public JsonElement? CollaborationMode { get; set; }
}

