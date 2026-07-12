using EduMS.Application.Common.CQRS;
using System;

namespace EduMS.Application.Registrations.Commands;

public record CreateRegistrationCommand(
    long ParentId,
    long SchoolId,
    string FirstNameAr,
    string FatherNameAr,
    string GrandfatherNameAr,
    string FamilyNameAr,
    string FirstNameEn,
    string FatherNameEn,
    string GrandfatherNameEn,
    string FamilyNameEn,
    DateTime BirthDate,
    string BirthPlace,
    string CountryOfBirth,
    EduMS.Domain.Enums.Gender Gender,
    string Nationality,
    string Address,
    string MotherName,
    string MotherNationality,
    string MotherPhone,
    string? BirthCertificate,
    string? PersonalPhoto,
    string? IDCardImage,
    string? PreviousSchool,
    string? PreviousGrade,
    long RequestedGradeLevelId,
    long AcademicYearId,
    bool HasSpecialNeeds,
    string? SpecialNeedsDetails,
    string? MedicalNotes,
    bool SiblingInSchool,
    string? SiblingNames,
    string? ReferralSource,
    string EmergencyContactName,
    string EmergencyContactPhone,
    string EmergencyContactRelation
) : ICommand<long>;
