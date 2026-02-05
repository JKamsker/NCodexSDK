using System.Text.Json;
using System.Text.Json.Serialization;

namespace JKToolKit.CodexSDK.AppServer.Protocol;

/// <summary>
/// Wire parameters for the <c>turn/start</c> request (v2 protocol).
/// </summary>
public sealed record class TurnStartParams
{
    /// <summary>
    /// Gets the thread identifier to start the turn in.
    /// </summary>
    [JsonPropertyName("threadId")]
    public required string ThreadId { get; init; }

    /// <summary>
    /// Gets the input items for the turn (wire payloads).
    /// </summary>
    [JsonPropertyName("input")]
    public required IReadOnlyList<object> Input { get; init; }

    /// <summary>
    /// Gets an optional working directory for the turn.
    /// </summary>
    [JsonPropertyName("cwd")]
    public string? Cwd { get; init; }

    /// <summary>
    /// Gets an optional approval policy wire value.
    /// </summary>
    [JsonPropertyName("approvalPolicy")]
    public string? ApprovalPolicy { get; init; }

    /// <summary>
    /// Gets an optional sandbox policy override.
    /// </summary>
    [JsonPropertyName("sandboxPolicy")]
    public SandboxPolicy? SandboxPolicy { get; init; }

    /// <summary>
    /// Gets an optional model identifier.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; init; }

    /// <summary>
    /// Gets an optional reasoning effort wire value.
    /// </summary>
    [JsonPropertyName("effort")]
    public string? Effort { get; init; }

    /// <summary>
    /// Gets an optional reasoning summary setting.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; init; }

    /// <summary>
    /// Gets an optional personality identifier.
    /// </summary>
    [JsonPropertyName("personality")]
    public string? Personality { get; init; }

    /// <summary>
    /// Gets an optional JSON Schema used to constrain the final assistant message.
    /// </summary>
    [JsonPropertyName("outputSchema")]
    public JsonElement? OutputSchema { get; init; }

    /// <summary>
    /// Gets an optional collaboration mode object (experimental).
    /// </summary>
    [JsonPropertyName("collaborationMode")]
    public JsonElement? CollaborationMode { get; init; }
}
