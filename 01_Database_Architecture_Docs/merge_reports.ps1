$docsPath = "h:\EduMS\01_Database_Architecture_Docs"
$outputFile = "$docsPath\EduMS_Master_Architecture_Source_Of_Truth.md"

$files = Get-ChildItem -Path $docsPath -Include *.md,*.txt -File -Exclude "EduMS_Master_Architecture_Source_Of_Truth.md"

$content = "# الدليل المعماري الشامل لنظام EduMS`r`n`r`n"
$content += "> **ملاحظة:** تم تجميع كافة التقارير المعمارية هنا لتكون المصدر الموجه للعمل.`r`n`r`n"

foreach ($file in $files) {
    $content += "---`r`n"
    $content += "# 📄 التقرير: $($file.Name)`r`n"
    $content += "---`r`n`r`n"
    $fileContent = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    $content += $fileContent + "`r`n`r`n"
}

Set-Content -Path $outputFile -Value $content -Encoding UTF8
