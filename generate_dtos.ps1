param (
    [string]$ModuleFolderName
)

$srcPath = "h:\EduMS\EduMS.Backend\src"
$entitiesPath = "$srcPath\EduMS.Domain\Entities\$ModuleFolderName"
$dtoBasePath = "$srcPath\EduMS.Application\$ModuleFolderName\DTOs"

if (!(Test-Path $dtoBasePath)) {
    New-Item -ItemType Directory -Force -Path $dtoBasePath | Out-Null
}

$files = Get-ChildItem -Path $entitiesPath -Filter "*.cs"

foreach ($file in $files) {
    $content = Get-Content $file.FullName
    $entityName = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
    $dtoName = "$($entityName)Dto"
    $dtoFilePath = Join-Path $dtoBasePath "$($dtoName).cs"
    
    $dtoContent = @()
    $dtoContent += "using System;"
    $dtoContent += ""
    $dtoContent += "namespace EduMS.Application.$ModuleFolderName.DTOs;"
    $dtoContent += ""
    $dtoContent += "public class $dtoName"
    $dtoContent += "{"
    $dtoContent += "    public long Id { get; set; }"
    
    $insideClass = $false
    foreach ($line in $content) {
        if ($line -match "public class $entityName") {
            $insideClass = $true
            continue
        }
        
        if ($insideClass) {
            # Check for end of class
            if ($line -match "^}") {
                $insideClass = $false
                continue
            }
            
            # Skip navigation properties (virtual)
            if ($line -match "public virtual") {
                continue
            }
            
            # Keep standard public properties
            if ($line -match "public\s+([a-zA-Z0-9_\.\?\<\>\[\]]+)\s+([a-zA-Z0-9_]+)\s*\{\s*get;\s*set;\s*\}") {
                # Add it as is, perhaps clean up formatting
                $dtoContent += $line
            }
        }
    }
    
    $dtoContent += "}"
    $dtoContent += ""
    
    $dtoContent | Set-Content -Path $dtoFilePath -Encoding UTF8
    Write-Host "Generated $dtoFilePath"
}
