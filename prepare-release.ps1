# Stop script on first error
$ErrorActionPreference = 'Stop'

# Define the version parameter passed from the command line
param (
  [string]$Version
)

if (-not $Version) {
  Write-Error "Version parameter is missing."
  exit 1
}

Write-Host "Preparing release for version: $Version"

# Update .csproj file
$projPath = 'mage/mage.csproj'
Write-Host "Updating version in $projPath..."
$xml = [xml](Get-Content $projPath -Raw)
$xml.SelectSingleNode('//Version').'#text' = $Version
$xml.SelectSingleNode('//ApplicationVersion').'#text' = $Version
$xml.Save($projPath)
Write-Host ".csproj file updated successfully."

# Build the application
$publishDir = 'build'
Write-Host "Publishing application to '$publishDir'..."
dotnet publish mage -r win-x64 -c release -o $publishDir --sc false

# Copy documentation files
Write-Host "Copying documentation..."
Copy-Item -Path Docs/doc.html -Destination $publishDir/doc.html
Copy-Item -Path Docs/technical.html -Destination $publishDir/technical.html

# Create the release archive
$archiveName = "MAGEThemes-v${Version}.zip"
Write-Host "Creating archive: $archiveName..."
Compress-Archive -Path "$publishDir/*" -DestinationPath $archiveName

Write-Host "Preparation complete."