<#
  Generates a Codex app-server JSON schema bundle.

  This is an optional, manual developer tool. It is not invoked by builds/tests.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$OutDir,

    [string]$CodexBinary = 'codex',

    [string[]]$CodexBinaryArgs = @()
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$resolvedOutDir = (Resolve-Path -LiteralPath $OutDir -ErrorAction SilentlyContinue)
if (-not $resolvedOutDir) {
    $null = New-Item -ItemType Directory -Force -Path $OutDir
    $resolvedOutDir = (Resolve-Path -LiteralPath $OutDir)
}

Write-Host "Generating schema bundle to: $($resolvedOutDir.Path)"

$args = @()
if ($CodexBinaryArgs) {
    $args += $CodexBinaryArgs
}
$args += @('app-server', 'generate-json-schema', '--out', $resolvedOutDir.Path)

& $CodexBinary @args
if ($LASTEXITCODE -ne 0) {
    throw "codex schema generation failed with exit code $LASTEXITCODE"
}

