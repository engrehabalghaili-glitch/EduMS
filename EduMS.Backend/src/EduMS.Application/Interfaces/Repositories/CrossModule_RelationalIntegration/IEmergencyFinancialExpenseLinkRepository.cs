using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEmergencyFinancialExpenseLinkRepository : IGenericRepository<EmergencyFinancialExpenseLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التكاليف المالية للطوارئ بناءً على فئة الصرف
    Task<IEnumerable<EmergencyFinancialExpenseLink>> GetExpensesByCategoryAsync(string expenseCategory, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المصاريف المتعلقة بحادثة طارئة
    Task<IEnumerable<EmergencyFinancialExpenseLink>> GetExpensesByIncidentIdAsync(long emergencyIncidentId, CancellationToken cancellationToken = default);
    
    // جلب المصاريف المتعلقة باستضافة طارئة
    Task<IEnumerable<EmergencyFinancialExpenseLink>> GetExpensesByHostingIdAsync(long emergencyHostingId, CancellationToken cancellationToken = default);
    
    // جلب المصاريف المتعلقة بإغلاق طارئ
    Task<IEnumerable<EmergencyFinancialExpenseLink>> GetExpensesByClosureIdAsync(long emergencyClosureId, CancellationToken cancellationToken = default);
    
    // جلب تفاصيل الطوارئ المرتبطة بقيد محاسبي معين
    Task<IEnumerable<EmergencyFinancialExpenseLink>> GetExpensesByJournalEntryIdAsync(long journalEntryId, CancellationToken cancellationToken = default);
}
