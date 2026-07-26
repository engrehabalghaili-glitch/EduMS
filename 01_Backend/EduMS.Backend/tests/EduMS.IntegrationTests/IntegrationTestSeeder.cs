using System;
using System.Linq;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;

namespace EduMS.IntegrationTests
{
    public static class IntegrationTestSeeder
    {
        public static void Seed(EduMSDbContext context)
        {
            // Fetch or create School
            var school = context.Set<School>().FirstOrDefault();
            if (school == null)
            {
                school = new School
                {
                    SchoolNameAr = "مدرسة تجريبية",
                    SchoolNameEn = "Test School",
                    SchoolCode = "TS-001",
                    Directorate = "Directorate A",
                    Governorate = "Governorate B",
                    IsActive = true
                };
                context.Set<School>().Add(school);
                context.SaveChanges();
            }

            // Seed initial Academic Year if missing
            if (!context.Set<SchoolAcademicYear>().Any())
            {
                var academicYear = new SchoolAcademicYear
                {
                    SchoolId = school.Id,
                    YearCode = "2026/2027",
                    YearNameAr = "العام الدراسي ٢٠٢٦-٢٠٢٧",
                    StartDate = new DateTime(2026, 9, 1),
                    EndDate = new DateTime(2027, 6, 30),
                    RegistrationStartDate = new DateTime(2026, 8, 1),
                    RegistrationEndDate = new DateTime(2026, 8, 30)
                };
                context.Set<SchoolAcademicYear>().Add(academicYear);
                context.SaveChanges();
            }

            // Roles are usually seeded by EduMSDbInitializer, but ensure they exist
            if (!context.Set<SystemRole>().Any(r => r.RoleCode == "SYSTEM_ADMIN"))
            {
                var systemRole = new SystemRole
                {
                    RoleCode = "SYSTEM_ADMIN",
                    RoleNameAr = "مدير النظام",
                    DescriptionAr = "System Administrator Role",
                    IsActive = true
                };
                context.Set<SystemRole>().Add(systemRole);
                context.SaveChanges();
            }

            if (!context.Set<SystemRole>().Any(r => r.RoleCode == "TEACHER"))
            {
                var teacherRole = new SystemRole
                {
                    RoleCode = "TEACHER",
                    RoleNameAr = "مدرس",
                    DescriptionAr = "Standard Teacher Role",
                    IsActive = true
                };
                context.Set<SystemRole>().Add(teacherRole);
                context.SaveChanges();
            }
            
            // Seed a Department (M3 Foundation)
            if (!context.Set<Department>().Any())
            {
                var department = new Department
                {
                    SchoolId = school.Id,
                    DepartmentCode = "DEP-001",
                    DepartmentNameAr = "قسم تقنية المعلومات",
                    DepartmentNameEn = "IT Department",
                    DepartmentType = 2, // Administrative
                    AnnualBudget = 10000m,
                    IsActive = true
                };
                context.Set<Department>().Add(department);
                context.SaveChanges();
            }

            // Seed a Guardian (M2 Foundation)
            if (!context.Set<Guardian>().Any())
            {
                System.Console.WriteLine("SEEDING GUARDIAN...");
                var guardian = new Guardian
                {
                    FullNameAr = "ولي الأمر الاول",
                    FullNameEn = "First Guardian",
                    NationalId = "G-123456789",
                    Gender = EduMS.Domain.Enums.Gender.Male,
                    FamilyNumber = "FAM-001",
                    RelationshipType = "Father",
                    EmailAddress = "guardian@test.com", // Required for M7 testing
                    IsActivePerson = true
                };
                context.Set<Guardian>().Add(guardian);
                context.SaveChanges();
                System.Console.WriteLine($"GUARDIAN SEEDED WITH ID: {guardian.Id}");
            }
            else
            {
                System.Console.WriteLine("GUARDIAN ALREADY EXISTS!");
            }

            var guardianRecord = context.Set<Guardian>().First();

            // Seed a Student (M2/M5 Foundation)
            if (!context.Set<Student>().Any())
            {
                var student = new Student
                {
                    FullNameAr = "طالب تجريبي",
                    FullNameEn = "Test Student",
                    NationalId = "S-123456789",
                    Gender = EduMS.Domain.Enums.Gender.Male,
                    SchoolId = school.Id,
                    GuardianId = guardianRecord.Id,
                    EnrollmentNumber = "STU-001",
                    IsActivePerson = true
                };
                context.Set<Student>().Add(student);
                context.SaveChanges();
            }

            // Seed Communication Template (M7)
            if (!context.Set<CommunicationTemplate>().Any(t => t.TemplateCode == "PAYMENT_RECEIPT"))
            {
                var template = new CommunicationTemplate
                {
                    TemplateCode = "PAYMENT_RECEIPT",
                    TemplateName = "Payment Receipt Notification",
                    SubjectTemplate = "Payment Received for {StudentName}",
                    BodyTemplate = "Dear Guardian,\nWe have received a payment of {Amount} on {Date} for {StudentName}.\nThank you.",
                    Type = "Email"
                };
                context.Set<CommunicationTemplate>().Add(template);
                context.SaveChanges();
            }
        }
    }
}
