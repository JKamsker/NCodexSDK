using System.Text.Json;
using System.Text.Json.Serialization;

namespace JKToolKit.CodexSDK.AppServer.Protocol;

/// <summary>
/// Wire parameters for the <c>thread/resume</c> request (v2 protocol).
/// </summary>
public sealed record class ThreadResumeParams
{
    /// <summary>
    /// Gets the thread identifier to resume.
    /// </summary>
    [JsonPropertyName("threadId")]
    public required string ThreadId { get; init; }

    /// <summary>
    /// Gets an optional history override (raw JSON) to resume from.
    /// </summary>
    [JsonPropertyName("history")]
    public JsonElement? History { get; init; }

    /// <summary>
    /// Gets an optional rollout path to resume from (takes precedence over <see cref="ThreadId"/>).
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; init; }

    /// <summary>
    /// Gets an optional model identifier.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; init; }

    /// <summary>
    /// Gets an optional model provider identifier.
    /// </summary>
    [JsonPropertyName("modelProvider")]
    public string? ModelProvider { get; init; }

    /// <summary>
    /// Gets an optional working directory for the resumed thread.
    /// </summary>
    [JsonPropertyName("cwd")]
    public string? Cwd { get; init; }

    /// <summary>
    /// Gets an optional approval policy wire value.
    /// </summary>
    [JsonPropertyName("approvalPolicy")]
    public string? ApprovalPolicy { get; init; }

    /// <summary>
    /// Gets an optional sandbox mode wire value.
    /// </summary>
    [JsonPropertyName("sandbox")]
    public string? Sandbox { get; init; }

    /// <summary>
    /// Gets optional config overrides (raw JSON object).
    /// </summary>
    [JsonPropertyName("config")]
    public JsonElement? Config { get; init; }

    /// <summary>
    /// Gets optional base instructions.
    /// </summary>
    [JsonPropertyName("baseInstructions")]
    public string? BaseInstructions { get; init; }

    /// <summary>
    /// Gets optional developer instructions.
    /// </summary>
    [JsonPropertyName("developerInstructions")]
    public string? DeveloperInstructions { get; init; }

    /// <summary>
    /// Gets an optional personality identifier.
    /// </summary>
    [JsonPropertyName("personality")]
    public string? Personality { get; init; }
}
