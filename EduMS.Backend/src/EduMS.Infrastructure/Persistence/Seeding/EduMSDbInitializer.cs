using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EduMS.Infrastructure.Persistence.Seeding;

/// <summary>
/// خدمة بذر وإعداد البيانات الأساسية الموحدة في نظام EduMS (Enterprise Master Data Seeder).
/// تنفذ عمليات البذر بشكل آمن ومقاوم للتكرار (Idempotent) وتراعي متطلبات الدقة وأنواع بيانات Oracle 19c.
/// </summary>
public class EduMSDbInitializer(EduMSDbContext context, ILogger<EduMSDbInitializer> logger) : IEduMSDbInitializer
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("بدء عملية فحص وبذر البيانات الأساسية (Master Data Seeding) لقاعدة بيانات EduMS على Oracle 19c...");

        await SeedSecurityAndRbacAsync(cancellationToken);
        await SeedSchoolAdminAsync(cancellationToken);
        await SeedFinanceFeeTypesAsync(cancellationToken);

        logger.LogInformation("تم إتمام كافة عمليات بذر البيانات الأساسية بنجاح تام وبدون تعارضات.");
    }

    private async Task SeedSecurityAndRbacAsync(CancellationToken cancellationToken)
    {
        // 1. Seed Roles
        var rolesSet = context.Set<SystemRole>();
        if (!await rolesSet.AnyAsync(cancellationToken))
        {
            logger.LogInformation("بذر الأدوار الأساسية في النظام (Module 8 - Roles)...");
            var roles = new List<SystemRole>
            {
                new() { RoleCode = "SUPER_ADMIN", RoleNameAr = "مدير النظام العام", RoleNameEn = "Super Administrator", RoleType = 1, HierarchyLevel = 1, IsSystem = true, IsInheritable = true, IsAssignable = true, IsActive = true, DescriptionAr = "الصلاحية العليا لإدارة وحوكمة كافة أجزاء النظام والبيانات الهيكلية" },
                new() { RoleCode = "SCHOOL_ADMIN", RoleNameAr = "مدير المدرسة", RoleNameEn = "School Administrator", RoleType = 2, HierarchyLevel = 2, IsSystem = true, IsInheritable = true, IsAssignable = true, IsActive = true, DescriptionAr = "إدارة العمليات المدرسية والشؤون الإدارية والأكاديمية والتشغيلية للمدرسة" },
                new() { RoleCode = "REGISTRAR", RoleNameAr = "مسؤول التسجيل والقبول", RoleNameEn = "Registrar Officer", RoleType = 2, HierarchyLevel = 3, IsSystem = true, IsInheritable = true, IsAssignable = true, IsActive = true, DescriptionAr = "إدارة طلبات التسجيل والقبول وملفات الطلاب وعمليات التحويل والانسحاب" },
                new() { RoleCode = "ACCOUNTANT", RoleNameAr = "المحاسب المالي", RoleNameEn = "Financial Accountant", RoleType = 2, HierarchyLevel = 3, IsSystem = true, IsInheritable = true, IsAssignable = true, IsActive = true, DescriptionAr = "إدارة الرسوم الدراسية والفواتير وسندات الصرف والقبض والتقارير المالية" },
                new() { RoleCode = "TEACHER", RoleNameAr = "المعلم / المدرس", RoleNameEn = "Teacher", RoleType = 2, HierarchyLevel = 4, IsSystem = true, IsInheritable = false, IsAssignable = true, IsActive = true, DescriptionAr = "إدارة الجداول الدراسية ورصد الدرجات والغياب والتقييمات وإدارة الفصول" },
                new() { RoleCode = "STUDENT", RoleNameAr = "الطالب", RoleNameEn = "Student", RoleType = 2, HierarchyLevel = 5, IsSystem = true, IsInheritable = false, IsAssignable = true, IsActive = true, DescriptionAr = "الوصول إلى البوابة الطلابية ومتابعة الواجبات والنتائج والحضور والجداول" },
                new() { RoleCode = "GUARDIAN", RoleNameAr = "ولي الأمر", RoleNameEn = "Guardian", RoleType = 2, HierarchyLevel = 5, IsSystem = true, IsInheritable = false, IsAssignable = true, IsActive = true, DescriptionAr = "متابعة الأبناء والرسوم الدراسية والتواصل الفعال مع إدارة المدرسة والمعلمين" }
            };

            await rolesSet.AddRangeAsync(roles, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        // 2. Seed Permissions
        var permissionsSet = context.Set<SystemPermission>();
        if (!await permissionsSet.AnyAsync(cancellationToken))
        {
            logger.LogInformation("بذر قائمة الصلاحيات القياسية في النظام (Module 8 - Permissions)...");
            var permissions = new List<SystemPermission>
            {
                new() { PermissionKey = "users.view", Module = "Security", SubModule = "Users", ActionType = "view", NameAr = "عرض حسابات المستخدمين", NameEn = "View Users", IsActive = true, RequiresLogging = true },
                new() { PermissionKey = "users.manage", Module = "Security", SubModule = "Users", ActionType = "manage", NameAr = "إدارة وإنشاء وتعديل المستخدمين", NameEn = "Manage Users", IsActive = true, RequiresLogging = true, IsSensitive = true },
                new() { PermissionKey = "roles.manage", Module = "Security", SubModule = "Roles", ActionType = "manage", NameAr = "إدارة الأدوار والصلاحيات وتعيينها", NameEn = "Manage Roles & Permissions", IsActive = true, RequiresLogging = true, IsSensitive = true },
                new() { PermissionKey = "school.manage", Module = "SchoolAdmin", SubModule = "Settings", ActionType = "manage", NameAr = "إدارة الإعدادات والبيانات الأساسية للمدرسة", NameEn = "Manage School Configuration", IsActive = true, RequiresLogging = true },
                new() { PermissionKey = "students.view", Module = "StudentAffairs", SubModule = "Students", ActionType = "view", NameAr = "عرض ملفات الطلاب والبيانات الشخصية", NameEn = "View Students", IsActive = true, RequiresLogging = true },
                new() { PermissionKey = "students.manage", Module = "StudentAffairs", SubModule = "Students", ActionType = "manage", NameAr = "إدارة شؤون الطلاب والقبول والتسجيل والتحويل", NameEn = "Manage Students & Enrollment", IsActive = true, RequiresLogging = true },
                new() { PermissionKey = "finance.manage", Module = "Finance", SubModule = "Invoices", ActionType = "manage", NameAr = "إدارة الرسوم الدراسية والفواتير وسندات القبض والصرف", NameEn = "Manage Financials & Invoices", IsActive = true, RequiresLogging = true, IsSensitive = true },
                new() { PermissionKey = "academic.manage", Module = "Academic", SubModule = "Classes", ActionType = "manage", NameAr = "إدارة الجداول والصفوف ورصد الدرجات والغياب", NameEn = "Manage Academic & Classes", IsActive = true, RequiresLogging = true },
                new() { PermissionKey = "portal.access", Module = "Portal", SubModule = "General", ActionType = "view", NameAr = "الوصول إلى البوابات الإلكترونية والخدمات الذاتية", NameEn = "Access Portal", IsActive = true, RequiresLogging = false }
            };

            await permissionsSet.AddRangeAsync(permissions, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            // Grant all permissions to SUPER_ADMIN
            var superAdminRole = await rolesSet.FirstOrDefaultAsync(r => r.RoleCode == "SUPER_ADMIN", cancellationToken);
            if (superAdminRole != null)
            {
                var rolePermissions = permissions.Select(p => new RolePermission
                {
                    RoleId = superAdminRole.Id,
                    PermissionId = p.Id,
                    IsInherited = false,
                    IsActive = true,
                    GrantedAt = DateTime.UtcNow
                }).ToList();

                await context.Set<RolePermission>().AddRangeAsync(rolePermissions, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        // 3. Seed Default SuperAdmin User
        var usersSet = context.Set<SystemUser>();
        var adminUser = await usersSet.FirstOrDefaultAsync(u => u.Username == "admin", cancellationToken);
        if (adminUser == null)
        {
            logger.LogInformation("بذر حساب مدير النظام الافتراضي (Default SuperAdmin User)...");
            const string rawPassword = "Admin@EduMS2026!";
            
            // PBKDF2 Implementation inline
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var iterations = 100000;
            using var pbkdf2 = new Rfc2898DeriveBytes(rawPassword, salt, iterations, HashAlgorithmName.SHA256);
            var hashBytes = pbkdf2.GetBytes(32);
            var passwordHash = $"{iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hashBytes)}";

            adminUser = new SystemUser
            {
                Username = "admin",
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(salt),
                FullNameAr = "مدير النظام العام",
                FullNameEn = "System Super Administrator",
                Email = "admin@edums.edu.sa",
                EmailVerified = true,
                EmailVerifiedAt = DateTime.UtcNow,
                NationalId = "1000000001",
                UserType = 1, // SysAdmin
                IsActive = true,
                MustChangePassword = false,
                PreferredLanguage = "ar",
                Theme = "dark"
            };

            await usersSet.AddAsync(adminUser, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            var superAdminRole = await rolesSet.FirstOrDefaultAsync(r => r.RoleCode == "SUPER_ADMIN", cancellationToken);
            if (superAdminRole != null)
            {
                var assignment = new UserRoleAssignment
                {
                    UserId = adminUser.Id,
                    RoleId = superAdminRole.Id,
                    IsPrimary = true,
                    IsActive = true,
                    AssignedAt = DateTime.UtcNow
                };

                await context.Set<UserRoleAssignment>().AddAsync(assignment, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
        else
        {
            logger.LogInformation("تحديث حساب مدير النظام إلى PBKDF2...");
            const string rawPassword = "Admin@EduMS2026!";
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) { rng.GetBytes(salt); }
            var iterations = 100000;
            using var pbkdf2 = new Rfc2898DeriveBytes(rawPassword, salt, iterations, HashAlgorithmName.SHA256);
            var hashBytes = pbkdf2.GetBytes(32);
            adminUser.PasswordHash = $"{iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hashBytes)}";
            adminUser.PasswordSalt = Convert.ToBase64String(salt);
            
            context.Set<SystemUser>().Update(adminUser);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    private async Task SeedSchoolAdminAsync(CancellationToken cancellationToken)
    {
        // 1. Seed Default School
        var schoolSet = context.Set<School>();
        School? defaultSchool = await schoolSet.FirstOrDefaultAsync(s => s.SchoolCode == "SCH-001", cancellationToken);
        if (defaultSchool == null)
        {
            logger.LogInformation("بذر بيانات المدرسة الرئيسية النموذجية (Module 1 - School)...");
            defaultSchool = new School
            {
                SchoolCode = "SCH-001",
                SchoolNameAr = "مدرسة النخبة النموذجية",
                SchoolNameEn = "Elite Model School",
                Directorate = "إدارة تعليم الرياض",
                Governorate = "الرياض",
                EstablishmentDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ContactPhone = "0112345678",
                ContactEmail = "info@elitemodelschool.edu.sa",
                WebsiteUrl = "https://www.elitemodelschool.edu.sa",
                MaxStudentCapacity = 1200,
                IsAccredited = true,
                IsActive = true
            };

            await schoolSet.AddAsync(defaultSchool, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        // 2. Seed Educational Stages
        var stagesSet = context.Set<EducationalStage>();
        if (!await stagesSet.AnyAsync(cancellationToken))
        {
            logger.LogInformation("بذر المراحل الدراسية الرئيسية (Module 1 - EducationalStages)...");
            var stages = new List<EducationalStage>
            {
                new() { StageCode = "KG", StageNameAr = "رياض الأطفال", StageNameEn = "Kindergarten", MinAge = 3, MaxAge = 5, DefaultDurationYears = 2, DisplayOrder = 1, RequiresGraduationCertificate = false, IsActive = true },
                new() { StageCode = "PRI", StageNameAr = "المرحلة الابتدائية", StageNameEn = "Primary Stage", MinAge = 6, MaxAge = 11, DefaultDurationYears = 6, DisplayOrder = 2, RequiresGraduationCertificate = true, IsActive = true },
                new() { StageCode = "INT", StageNameAr = "المرحلة المتوسطة", StageNameEn = "Intermediate Stage", MinAge = 12, MaxAge = 14, DefaultDurationYears = 3, DisplayOrder = 3, RequiresGraduationCertificate = true, IsActive = true },
                new() { StageCode = "SEC", StageNameAr = "المرحلة الثانوية", StageNameEn = "Secondary Stage", MinAge = 15, MaxAge = 17, DefaultDurationYears = 3, DisplayOrder = 4, RequiresGraduationCertificate = true, IsActive = true }
            };

            await stagesSet.AddRangeAsync(stages, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        // 3. Seed School Levels
        var levelsSet = context.Set<SchoolLevel>();
        if (!await levelsSet.AnyAsync(cancellationToken))
        {
            logger.LogInformation("بذر الصفوف والمستويات الدراسية للمدرسة (Module 1 - SchoolLevels)...");
            var levels = new List<SchoolLevel>
            {
                new() { SchoolId = defaultSchool.Id, LevelNameAr = "الصف الأول الابتدائي", LevelNameEn = "First Grade Primary", LevelOrder = 1, StartGrade = "G1", EndGrade = "G1", AcademicTrack = "General", MinAgeYears = 6, MaxAgeYears = 7, IsActive = true },
                new() { SchoolId = defaultSchool.Id, LevelNameAr = "الصف الأول المتوسط", LevelNameEn = "First Grade Intermediate", LevelOrder = 7, StartGrade = "G7", EndGrade = "G7", AcademicTrack = "General", MinAgeYears = 12, MaxAgeYears = 13, IsActive = true },
                new() { SchoolId = defaultSchool.Id, LevelNameAr = "الصف الأول الثانوي", LevelNameEn = "First Grade Secondary", LevelOrder = 10, StartGrade = "G10", EndGrade = "G10", AcademicTrack = "General Track", MinAgeYears = 15, MaxAgeYears = 16, IsActive = true }
            };

            await levelsSet.AddRangeAsync(levels, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        // 4. Seed Default Classrooms and capacities
        var classroomsSet = context.Set<Classroom>();
        if (!await classroomsSet.AnyAsync(cancellationToken))
        {
            logger.LogInformation("بذر القاعات الدراسية والطاقات الاستيعابية الافتراضية (Module 1 - Classrooms)...");
            var classrooms = new List<Classroom>
            {
                new() { SchoolId = defaultSchool.Id, ClassroomCode = "KG2-A", ClassroomNameAr = "قاعة روضة 2 - أ", ClassroomNameEn = "KG2 Section A", GradeLevel = 0, Capacity = 25, RoomNumber = "101", FloorLevel = 1, BuildingSection = "المبنى الرئيسي - الروضة", IsSmartClassroom = false, IsActive = true },
                new() { SchoolId = defaultSchool.Id, ClassroomCode = "PRI1-A", ClassroomNameAr = "الأول الابتدائي - أ", ClassroomNameEn = "Grade 1 Section A", GradeLevel = 1, Capacity = 30, RoomNumber = "102", FloorLevel = 1, BuildingSection = "المبنى الأكاديمي الشمالي", IsSmartClassroom = true, IsActive = true },
                new() { SchoolId = defaultSchool.Id, ClassroomCode = "PRI1-B", ClassroomNameAr = "الأول الابتدائي - ب", ClassroomNameEn = "Grade 1 Section B", GradeLevel = 1, Capacity = 30, RoomNumber = "103", FloorLevel = 1, BuildingSection = "المبنى الأكاديمي الشمالي", IsSmartClassroom = true, IsActive = true },
                new() { SchoolId = defaultSchool.Id, ClassroomCode = "INT1-A", ClassroomNameAr = "الأول المتوسط - أ", ClassroomNameEn = "Grade 7 Section A", GradeLevel = 7, Capacity = 32, RoomNumber = "201", FloorLevel = 2, BuildingSection = "المبنى الأكاديمي الأوسط", IsSmartClassroom = true, IsActive = true },
                new() { SchoolId = defaultSchool.Id, ClassroomCode = "SEC1-A", ClassroomNameAr = "الأول الثانوي - أ", ClassroomNameEn = "Grade 10 Section A", GradeLevel = 10, Capacity = 35, RoomNumber = "301", FloorLevel = 3, BuildingSection = "المبنى الأكاديمي الجنوبي", IsSmartClassroom = true, IsActive = true }
            };

            await classroomsSet.AddRangeAsync(classrooms, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    private async Task SeedFinanceFeeTypesAsync(CancellationToken cancellationToken)
    {
        var feeTypesSet = context.Set<FeeType>();
        if (!await feeTypesSet.AnyAsync(cancellationToken))
        {
            logger.LogInformation("بذر أنواع الرسوم الدراسية الإلزامية والاختيارية (Module 5 - FeeTypes)...");

            var school = await context.Set<School>().FirstOrDefaultAsync(s => s.SchoolCode == "SCH-001", cancellationToken);
            long schoolId = school?.Id ?? 1L;

            var feeTypes = new List<FeeType>
            {
                new()
                {
                    SchoolId = schoolId,
                    FeeCode = "FEE-TUI-01",
                    FeeNameAr = "الرسوم الدراسية السنوية (إلزامي)",
                    FeeNameEn = "Annual Tuition Fees",
                    FeeCategory = 1, // Tuition
                    Amount = 15000.00m,
                    Currency = "SAR",
                    BillingFrequency = "Annual",
                    IsTaxable = false,
                    TaxPercentage = 0.00m,
                    IsMandatory = true,
                    IsOptional = false,
                    IsActive = true
                },
                new()
                {
                    SchoolId = schoolId,
                    FeeCode = "FEE-REG-01",
                    FeeNameAr = "رسوم التسجيل والقبول (إلزامي - يدفع لمرة واحدة)",
                    FeeNameEn = "Registration & Admission Fees",
                    FeeCategory = 2, // Registration
                    Amount = 1000.00m,
                    Currency = "SAR",
                    BillingFrequency = "OneTime",
                    IsTaxable = true,
                    TaxPercentage = 15.00m,
                    IsMandatory = true,
                    IsOptional = false,
                    IsActive = true
                },
                new()
                {
                    SchoolId = schoolId,
                    FeeCode = "FEE-BKS-01",
                    FeeNameAr = "باقة الكتب والمقررات والزي المدرسي (إلزامي)",
                    FeeNameEn = "Books & Uniform Package",
                    FeeCategory = 5, // Books
                    Amount = 1200.00m,
                    Currency = "SAR",
                    BillingFrequency = "Annual",
                    IsTaxable = true,
                    TaxPercentage = 15.00m,
                    IsMandatory = true,
                    IsOptional = false,
                    IsActive = true
                },
                new()
                {
                    SchoolId = schoolId,
                    FeeCode = "FEE-TRN-01",
                    FeeNameAr = "رسوم النقل والباص المدرسي (اختياري)",
                    FeeNameEn = "School Bus Transportation (Optional)",
                    FeeCategory = 3, // Bus
                    Amount = 3500.00m,
                    Currency = "SAR",
                    BillingFrequency = "Annual",
                    IsTaxable = true,
                    TaxPercentage = 15.00m,
                    IsMandatory = false,
                    IsOptional = true,
                    IsActive = true
                }
            };

            await feeTypesSet.AddRangeAsync(feeTypes, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
