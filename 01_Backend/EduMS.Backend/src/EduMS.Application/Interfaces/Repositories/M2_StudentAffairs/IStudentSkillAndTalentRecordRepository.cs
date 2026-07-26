using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentSkillAndTalentRecordRepository : IGenericRepository<StudentSkillAndTalentRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المواهب بناءً على الفئة (علمي، فني، رياضي، الخ)
    Task<IEnumerable<StudentSkillAndTalentRecord>> GetTalentsByCategoryAsync(int talentCategory, CancellationToken cancellationToken = default);
    
    // جلب المواهب بناءً على مستوى الإتقان أو الاحتراف
    Task<IEnumerable<StudentSkillAndTalentRecord>> GetTalentsByProficiencyLevelAsync(int proficiencyLevel, CancellationToken cancellationToken = default);
    
    // جلب الطلاب الموهوبين المسجلين في برامج الموهوبين الخاصة
    Task<IEnumerable<StudentSkillAndTalentRecord>> GetStudentsInGiftedProgramsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة سجلات المواهب الخاصة بطالب محدد
    Task<IEnumerable<StudentSkillAndTalentRecord>> GetTalentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب المواهب التي يشرف عليها أو يرعاها موظف/معلم محدد
    Task<IEnumerable<StudentSkillAndTalentRecord>> GetTalentsByMentorAsync(long mentorEmployeeId, CancellationToken cancellationToken = default);
}
