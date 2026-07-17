Get-ChildItem -Path "h:\EduMS\EduMS.Backend\src\EduMS.Application\Interfaces\Repositories" -Recurse -Filter "*.cs" | ForEach-Object {
    $content = Get-Content $_.FullName -Raw
    if ($content -match "CancellationToken cancellationToken") {
        return
    }
    
    $newContent = [regex]::Replace($content, "(Task(?:<[^>]+>)?\s+\w+\s*\()([^)]*)(\))", {
        param($m)
        $args = $m.Groups[2].Value
        if ($args.Trim() -eq "") {
            return $m.Groups[1].Value + "CancellationToken cancellationToken = default)"
        } else {
            $trimmed = $args.TrimEnd()
            $ws = $args.Substring($trimmed.Length)
            return $m.Groups[1].Value + $trimmed + ", CancellationToken cancellationToken = default" + $ws + ")"
        }
    })
    
    if ($newContent -notmatch "using System\.Threading;") {
        $newContent = "using System.Threading;`r`n" + $newContent
    }
    
    Set-Content -Path $_.FullName -Value $newContent
}
