using System.Text.Json.Serialization;

namespace JKToolKit.CodexSDK.AppServer.Protocol;

public abstract partial record class SandboxPolicy
{
    /// <summary>
    /// Sandbox policy that allows writes to a limited set of roots ("workspace write").
    /// </summary>
    public sealed record class WorkspaceWrite : SandboxPolicy
    {
        /// <inheritdoc />
        public override string Type => "workspaceWrite";

        /// <summary>
        /// Gets the explicit writable root directories.
        /// </summary>
        /// <remarks>
        /// The server may also add additional writable roots such as the current working directory and temporary directories.
        /// </remarks>
        [JsonPropertyName("writableRoots")]
        public IReadOnlyList<string> WritableRoots { get; init; } = Array.Empty<string>();

        /// <summary>
        /// Gets a value indicating whether network access is allowed while this policy is active.
        /// </summary>
        [JsonPropertyName("networkAccess")]
        public bool NetworkAccess { get; init; }

        /// <summary>
        /// Gets a value indicating whether the server should exclude the <c>TMPDIR</c> environment variable path
        /// from the set of writable roots.
        /// </summary>
        [JsonPropertyName("excludeTmpdirEnvVar")]
        public bool ExcludeTmpdirEnvVar { get; init; }

        /// <summary>
        /// Gets a value indicating whether the server should exclude <c>/tmp</c> (on Unix) from the set of writable roots.
        /// </summary>
        [JsonPropertyName("excludeSlashTmp")]
        public bool ExcludeSlashTmp { get; init; }
    }
}
