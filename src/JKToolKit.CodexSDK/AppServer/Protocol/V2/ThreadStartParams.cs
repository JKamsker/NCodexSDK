using System.Text.Json;
using System.Text.Json.Serialization;

namespace JKToolKit.CodexSDK.AppServer.Protocol;

/// <summary>
/// Wire parameters for the <c>thread/start</c> request (v2 protocol).
/// </summary>
public sealed record class ThreadStartParams
{
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
    /// Gets an optional working directory for the thread.
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

    /// <summary>
    /// Gets an optional value indicating whether the thread should be ephemeral.
    /// </summary>
    [JsonPropertyName("ephemeral")]
    public bool? Ephemeral { get; init; }

    /// <summary>
    /// Gets a value indicating whether to opt into emitting raw response items.
    /// </summary>
    [JsonPropertyName("experimentalRawEvents")]
    public bool ExperimentalRawEvents { get; init; }
}
