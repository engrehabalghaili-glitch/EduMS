param (
    [string]$ModuleName = "M3_EmployeeManagement"
)

$srcPath = "h:\EduMS\EduMS.Backend\src"
$entitiesPath = "$srcPath\EduMS.Domain\Entities\$ModuleName"
$dtoBasePath = "$srcPath\EduMS.Application\$ModuleName\DTOs"

if (!(Test-Path $dtoBasePath)) {
    New-Item -ItemType Directory -Force -Path $dtoBasePath | Out-Null
}

$files = Get-ChildItem -Path $entitiesPath -Filter "*.cs"

$auditProps = @(
    "    public DateTimeOffset CreatedAt { get; set; }",
    "    public long CreatedByUserId { get; set; }",
    "    public DateTimeOffset? ModifiedAt { get; set; }",
    "    public long? ModifiedByUserId { get; set; }",
    "    public bool IsDeleted { get; set; }",
    "    public DateTimeOffset? DeletedAt { get; set; }",
    "    public long? DeletedByUserId { get; set; }",
    "    public Guid VersionToken { get; set; }",
    "    public DateTimeOffset? LastSyncedAt { get; set; }",
    "    public string SyncStatus { get; set; } = string.Empty;"
)

function Generate-Dtos($className, $props, $moduleName, $basePath, $auditProps) {
    $folderName = $className + "s"
    if ($className.EndsWith("y")) {
        $folderName = $className.Substring(0, $className.Length - 1) + "ies"
    }
    elseif ($className.EndsWith("s") -or $className.EndsWith("x")) {
        $folderName = $className + "es"
    }

    $classDir = Join-Path $basePath $folderName
    if (!(Test-Path $classDir)) {
        New-Item -ItemType Directory -Force -Path $classDir | Out-Null
    }
    
    # 1. Generate Main Dto
    $dtoName = "$($className)Dto"
    $dtoPath = Join-Path $classDir "$($dtoName).cs"
    $dtoContent = @()
    $dtoContent += "using System;"
    $dtoContent += ""
    $dtoContent += "namespace EduMS.Application.$moduleName.DTOs.$folderName;"
    $dtoContent += ""
    $dtoContent += "public class $dtoName"
    $dtoContent += "{"
    $dtoContent += "    public long Id { get; set; }"
    $dtoContent += $props
    $dtoContent += $auditProps
    $dtoContent += "}"
    $dtoContent | Set-Content -Path $dtoPath -Encoding UTF8
    
    # 2. Generate Create Dto
    $createDtoName = "Create$($className)Dto"
    $createDtoPath = Join-Path $classDir "$($createDtoName).cs"
    $createDtoContent = @()
    $createDtoContent += "using System;"
    $createDtoContent += ""
    $createDtoContent += "namespace EduMS.Application.$moduleName.DTOs.$folderName;"
    $createDtoContent += ""
    $createDtoContent += "public class $createDtoName"
    $createDtoContent += "{"
    $createDtoContent += $props
    $createDtoContent += "}"
    $createDtoContent | Set-Content -Path $createDtoPath -Encoding UTF8
    
    # 3. Generate Update Dto
    $updateDtoName = "Update$($className)Dto"
    $updateDtoPath = Join-Path $classDir "$($updateDtoName).cs"
    $updateDtoContent = @()
    $updateDtoContent += "using System;"
    $updateDtoContent += ""
    $updateDtoContent += "namespace EduMS.Application.$moduleName.DTOs.$folderName;"
    $updateDtoContent += ""
    $updateDtoContent += "public class $updateDtoName"
    $updateDtoContent += "{"
    $updateDtoContent += "    public long Id { get; set; }"
    $updateDtoContent += $props
    $updateDtoContent += "}"
    $updateDtoContent | Set-Content -Path $updateDtoPath -Encoding UTF8
    
    Write-Host "Generated DTOs for $className in $classDir"
}

foreach ($file in $files) {
    $content = Get-Content $file.FullName
    
    $currentClass = $null
    $classProps = @()
    
    foreach ($line in $content) {
        if ($line -match "public class\s+([A-Za-z0-9_]+)") {
            if ($currentClass -ne $null) {
                Generate-Dtos -className $currentClass -props $classProps -moduleName $ModuleName -basePath $dtoBasePath -auditProps $auditProps
            }
            $currentClass = $matches[1]
            $classProps = @()
            continue
        }
        
        if ($currentClass -ne $null) {
            if ($line -match "^\s*}") {
                Generate-Dtos -className $currentClass -props $classProps -moduleName $ModuleName -basePath $dtoBasePath -auditProps $auditProps
                $currentClass = $null
                continue
            }
            
            if ($line -match "public\s+virtual\s+") {
                continue
            }
            
            if ($line -match "public\s+([a-zA-Z0-9_\.\?\<\>\[\]]+)\s+([a-zA-Z0-9_]+)\s*\{\s*get;\s*set;\s*\}") {
                $propType = $matches[1]
                $propName = $matches[2]
                
                if ($propName -eq "Id") { continue }
                
                $propDef = "    public $propType $propName { get; set; }"
                if ($line -match "(=\s*[^;]+;)") {
                    $propDef += " " + $matches[1]
                }
                $classProps += $propDef
            }
        }
    }
}
