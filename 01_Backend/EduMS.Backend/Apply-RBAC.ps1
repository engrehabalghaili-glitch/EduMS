$ErrorActionPreference = "Stop"

$workspace = "D:\EduMS-Unified-Workspace\01_Backend\EduMS.Backend\src"
$moduleTarget = "M7_CommunicationManagement"
$controllersPath = "$workspace\EduMS.WebApi\Controllers\v1\$moduleTarget"
$permissionsFile = "$workspace\EduMS.Domain\Constants\Permissions.cs"

Write-Host "Starting RBAC Automation for module: $moduleTarget"

$controllers = Get-ChildItem -Path $controllersPath -Filter "*Controller.cs" -File

$permissionsContent = Get-Content $permissionsFile -Raw

foreach ($controller in $controllers) {
    $entityName = $controller.BaseName.Replace("Controller", "")
    Write-Host "Processing Entity: $entityName"

    # 1. Update Permissions.cs
    $classPattern = "public static class $entityName\s*{"
    if ($permissionsContent -notmatch $classPattern) {
        Write-Host "  -> Adding $entityName to Permissions.cs"
        $newPermissionClass = @"
    public static class $entityName
    {
        public const string View = `"Permissions.$entityName.View`";
        public const string Create = `"Permissions.$entityName.Create`";
        public const string Update = `"Permissions.$entityName.Update`";
        public const string Delete = `"Permissions.$entityName.Delete`";
    }
"@
        $lastBraceIndex = $permissionsContent.LastIndexOf("}")
        $permissionsContent = $permissionsContent.Insert($lastBraceIndex, "`n$newPermissionClass`n")
    }

    # 2. Update Controller File
    $ctrlContent = Get-Content $controller.FullName -Raw
    $hasChanges = $false

    if (-not $ctrlContent.Contains("using EduMS.Domain.Constants;")) {
        $ctrlContent = "using EduMS.Domain.Constants;`nusing EduMS.Infrastructure.Security.Authorization;`n" + $ctrlContent
        $hasChanges = $true
    }

    if (-not $ctrlContent.Contains("[Authorize]")) {
        $ctrlContent = $ctrlContent.Replace("[ApiController]`n[Route(`"api/v1/[controller]`")]", "[ApiController]`n[Route(`"api/v1/[controller]`")]`n[Authorize]")
        $ctrlContent = $ctrlContent.Replace("[ApiController]`r`n[Route(`"api/v1/[controller]`")]", "[ApiController]`r`n[Route(`"api/v1/[controller]`")]`r`n[Authorize]")
        $hasChanges = $true
    }

    if (-not $ctrlContent.Contains("[HasPermission(Permissions.$entityName.View)]")) {
        $ctrlContent = $ctrlContent.Replace("[HttpGet]", "[HasPermission(Permissions.$entityName.View)]`n    [HttpGet]")
        $ctrlContent = $ctrlContent.Replace("[HttpGet(`"{id}`")]", "[HasPermission(Permissions.$entityName.View)]`n    [HttpGet(`"{id}`")]")
        $ctrlContent = $ctrlContent.Replace("[HttpPost]", "[HasPermission(Permissions.$entityName.Create)]`n    [HttpPost]")
        $ctrlContent = $ctrlContent.Replace("[HttpPut(`"{id}`")]", "[HasPermission(Permissions.$entityName.Update)]`n    [HttpPut(`"{id}`")]")
        $ctrlContent = $ctrlContent.Replace("[HttpDelete(`"{id}`")]", "[HasPermission(Permissions.$entityName.Delete)]`n    [HttpDelete(`"{id}`")]")
        $hasChanges = $true
    }

    if ($hasChanges) {
        Write-Host "  -> Updating $($controller.Name)"
        Set-Content -Path $controller.FullName -Value $ctrlContent
    }
}

Set-Content -Path $permissionsFile -Value $permissionsContent
Write-Host "RBAC Automation for $moduleTarget completed successfully."
