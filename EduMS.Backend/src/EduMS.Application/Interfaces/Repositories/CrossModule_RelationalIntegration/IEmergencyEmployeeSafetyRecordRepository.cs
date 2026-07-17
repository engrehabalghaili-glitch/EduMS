using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEmergencyEmployeeSafetyRecordRepository : IGenericRepository<EmergencyEmployeeSafetyRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات سلامة الموظفين بناءً على حالة السلامة (آمن، مصاب، مفقود، الخ)
    Task<IEnumerable<EmergencyEmployeeSafetyRecord>> GetRecordsBySafetyStatusAsync(int safetyStatus, CancellationToken cancellationToken = default);
    
    // جلب سجلات الموظفين الذين كانوا على رأس العمل أثناء الحادثة
    Task<IEnumerable<EmergencyEmployeeSafetyRecord>> GetRecordsOnDutyAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات سلامة الموظفين أثناء حادثة طارئة محددة
    Task<IEnumerable<EmergencyEmployeeSafetyRecord>> GetRecordsByIncidentIdAsync(long emergencyIncidentId, CancellationToken cancellationToken = default);
    
    // جلب سجل سلامة موظف معين أثناء الحادثة
    Task<EmergencyEmployeeSafetyRecord?> GetRecordByEmployeeAndIncidentAsync(long employeeId, long emergencyIncidentId, CancellationToken cancellationToken = default);
}
