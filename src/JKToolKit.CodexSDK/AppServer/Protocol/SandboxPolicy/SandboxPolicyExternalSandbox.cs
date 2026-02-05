using System.Text.Json.Serialization;

namespace JKToolKit.CodexSDK.AppServer.Protocol;

public abstract partial record class SandboxPolicy
{
    /// <summary>
    /// Sandbox policy used when the client enforces sandboxing externally.
    /// </summary>
    /// <remarks>
    /// The <see cref="NetworkAccess"/> value is passed through to the server to describe whether network access is enabled.
    /// </remarks>
    public sealed record class ExternalSandbox : SandboxPolicy
    {
        /// <inheritdoc />
        public override string Type => "externalSandbox";

        /// <summary>
        /// Gets the network access state (<c>restricted</c> or <c>enabled</c>).
        /// </summary>
        [JsonPropertyName("networkAccess")]
        public required string NetworkAccess { get; init; }
    }
}
