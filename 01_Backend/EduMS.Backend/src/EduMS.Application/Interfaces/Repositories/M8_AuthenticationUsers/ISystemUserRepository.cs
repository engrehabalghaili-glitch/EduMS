using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface ISystemUserRepository : IGenericRepository<SystemUser>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المستخدمين الفعالين
    Task<IEnumerable<SystemUser>> GetActiveUsersAsync(CancellationToken cancellationToken = default);
    
    // جلب المستخدمين بناءً على نوع المستخدم (مدير نظام، مدير مدرسة، معلم، طالب، ولي أمر، الخ)
    Task<IEnumerable<SystemUser>> GetUsersByTypeAsync(int userType, CancellationToken cancellationToken = default);
    
    // جلب المستخدمين الذين تم إقفال حساباتهم (Locked)
    Task<IEnumerable<SystemUser>> GetLockedUsersAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهوية (Foreign Keys and Identity)
    // جلب مستخدم بناءً على اسم المستخدم (Username)
    Task<SystemUser?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    
    // جلب مستخدم بناءً على البريد الإلكتروني
    Task<SystemUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    
    // جلب مستخدم بناءً على رقم الهوية الوطنية
    Task<SystemUser?> GetUserByNationalIdAsync(string nationalId, CancellationToken cancellationToken = default);
    
    // جلب مستخدمي مدرسة محددة
    Task<IEnumerable<SystemUser>> GetUsersBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
