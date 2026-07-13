using EduMS.Application.Common.CQRS;
using EduMS.Application.Registrations.DTOs;
using EduMS.Domain.Entities.M2_StudentAffairs;
using EduMS.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace EduMS.Application.Registrations.Queries;

public class GetRegistrationByIdQueryHandler(IRepository<Registration> registrationRepository) 
    : IQueryHandler<GetRegistrationByIdQuery, RegistrationDto?>
{
    public async Task<RegistrationDto?> HandleAsync(GetRegistrationByIdQuery request, CancellationToken cancellationToken)
    {
        var registrations = await registrationRepository.FindAsync(r => r.Id == request.Id, cancellationToken);
        var registration = registrations.FirstOrDefault();
        
        if (registration == null)
        {
            return null;
        }

        return new RegistrationDto
        {
            Id = registration.Id,
            ParentId = registration.ParentId,
            SchoolId = registration.SchoolId,
            FirstNameAr = registration.FirstNameAr,
            FatherNameAr = registration.FatherNameAr,
            GrandfatherNameAr = registration.GrandfatherNameAr,
            FamilyNameAr = registration.FamilyNameAr,
            FirstNameEn = registration.FirstNameEn,
            FatherNameEn = registration.FatherNameEn,
            GrandfatherNameEn = registration.GrandfatherNameEn,
            FamilyNameEn = registration.FamilyNameEn,
            BirthDate = registration.BirthDate,
            BirthPlace = registration.BirthPlace,
            CountryOfBirth = registration.CountryOfBirth,
            Gender = registration.Gender,
            Nationality = registration.Nationality,
            Address = registration.Address,
            MotherName = registration.MotherName,
            MotherNationality = registration.MotherNationality,
            MotherPhone = registration.MotherPhone,
            BirthCertificate = registration.BirthCertificate,
            PersonalPhoto = registration.PersonalPhoto,
            IDCardImage = registration.IDCardImage,
            PreviousSchool = registration.PreviousSchool,
            PreviousGrade = registration.PreviousGrade,
            RequestedGradeLevelId = registration.RequestedGradeLevelId,
            AcademicYearId = registration.AcademicYearId,
            HasSpecialNeeds = registration.HasSpecialNeeds,
            SpecialNeedsDetails = registration.SpecialNeedsDetails,
            MedicalNotes = registration.MedicalNotes,
            SiblingInSchool = registration.SiblingInSchool,
            SiblingNames = registration.SiblingNames,
            ReferralSource = registration.ReferralSource,
            EmergencyContactName = registration.EmergencyContactName,
            EmergencyContactPhone = registration.EmergencyContactPhone,
            EmergencyContactRelation = registration.EmergencyContactRelation,
            RequestStatus = registration.RequestStatus,
            SubmissionDate = registration.SubmissionDate,
            ReviewedByUserId = registration.ReviewedByUserId,
            ReviewDate = registration.ReviewDate,
            RejectionReason = registration.RejectionReason,
            ApprovalDate = registration.ApprovalDate,
            ConvertedToStudentId = registration.ConvertedToStudentId
        };
    }
}
