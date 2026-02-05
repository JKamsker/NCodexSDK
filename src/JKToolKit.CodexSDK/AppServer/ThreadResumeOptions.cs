using System.Text.Json;
using JKToolKit.CodexSDK.Models;

namespace JKToolKit.CodexSDK.AppServer;

/// <summary>
/// Options for resuming an existing thread via the Codex app server.
/// </summary>
public sealed class ThreadResumeOptions
{
    /// <summary>
    /// Gets or sets the thread identifier to resume.
    /// </summary>
    public required string ThreadId { get; set; }

    /// <summary>
    /// [UNSTABLE] If specified, resume using the provided history instead of loading from disk.
    /// </summary>
    public JsonElement? History { get; set; }

    /// <summary>
    /// [UNSTABLE] If specified, resume from a specific rollout path (takes precedence over <see cref="ThreadId"/>).
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets an optional model identifier.
    /// </summary>
    public CodexModel? Model { get; set; }

    /// <summary>
    /// Gets or sets an optional model provider identifier.
    /// </summary>
    public string? ModelProvider { get; set; }

    /// <summary>
    /// Gets or sets an optional working directory for the resumed thread.
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
    /// Gets or sets an optional personality identifier (e.g. "friendly", "pragmatic").
    /// </summary>
    public string? Personality { get; set; }
}
