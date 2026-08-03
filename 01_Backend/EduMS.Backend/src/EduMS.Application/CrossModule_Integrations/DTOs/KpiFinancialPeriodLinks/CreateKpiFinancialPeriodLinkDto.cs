using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.KpiFinancialPeriodLinks;

public class CreateKpiFinancialPeriodLinkDto
{
    public long KpiMetricRecordId { get; set; }
    public long? PayrollRunId { get; set; }
    public long? JournalEntryId { get; set; }
    public long SchoolId { get; set; }
    public string PeriodLabel { get; set; } = string.Empty;
    public string? Notes { get; set; }
}
