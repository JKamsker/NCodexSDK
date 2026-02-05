namespace JKToolKit.CodexSDK.Models;

/// <summary>
/// Represents a Codex approval policy identifier.
/// </summary>
/// <remarks>
/// This value object is forward-compatible: callers may use any string value supported by their Codex version.
/// </remarks>
public readonly record struct CodexApprovalPolicy
{
    /// <summary>
    /// Gets the underlying wire value.
    /// </summary>
    public string Value { get; }

    private CodexApprovalPolicy(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ApprovalPolicy cannot be empty or whitespace.", nameof(value));

        Value = value;
    }

    /// <summary>
    /// Gets the <c>untrusted</c> approval policy.
    /// </summary>
    public static CodexApprovalPolicy Untrusted => new("untrusted");

    /// <summary>
    /// Gets the <c>on-request</c> approval policy.
    /// </summary>
    public static CodexApprovalPolicy OnRequest => new("on-request");

    /// <summary>
    /// Gets the <c>on-failure</c> approval policy.
    /// </summary>
    public static CodexApprovalPolicy OnFailure => new("on-failure");

    /// <summary>
    /// Gets the <c>never</c> approval policy.
    /// </summary>
    public static CodexApprovalPolicy Never => new("never");

    /// <summary>
    /// Parses an approval policy from a wire value.
    /// </summary>
    public static CodexApprovalPolicy Parse(string value) => new(value);

    /// <summary>
    /// Tries to parse an approval policy from a wire value.
    /// </summary>
    public static bool TryParse(string? value, out CodexApprovalPolicy policy)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            policy = default;
            return false;
        }

        policy = new CodexApprovalPolicy(value);
        return true;
    }

    /// <summary>
    /// Converts a string to a <see cref="CodexApprovalPolicy"/>.
    /// </summary>
    public static implicit operator CodexApprovalPolicy(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="CodexApprovalPolicy"/> to its wire value.
    /// </summary>
    public static implicit operator string(CodexApprovalPolicy policy) => policy.Value;

    /// <summary>
    /// Returns the underlying wire value.
    /// </summary>
    public override string ToString() => Value;
}

