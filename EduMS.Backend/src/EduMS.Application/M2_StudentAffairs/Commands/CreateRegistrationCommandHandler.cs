using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities.M2_StudentAffairs;
using EduMS.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.Registrations.Commands;

public class CreateRegistrationCommandHandler(IRepository<Registration> registrationRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateRegistrationCommand, long>
{
    public async Task<long> HandleAsync(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        var registration = new Registration
        {
            ParentId = request.ParentId,
            SchoolId = request.SchoolId,
            FirstNameAr = request.FirstNameAr,
            FatherNameAr = request.FatherNameAr,
            GrandfatherNameAr = request.GrandfatherNameAr,
            FamilyNameAr = request.FamilyNameAr,
            FirstNameEn = request.FirstNameEn,
            FatherNameEn = request.FatherNameEn,
            GrandfatherNameEn = request.GrandfatherNameEn,
            FamilyNameEn = request.FamilyNameEn,
            BirthDate = request.BirthDate,
            BirthPlace = request.BirthPlace,
            CountryOfBirth = request.CountryOfBirth,
            Gender = request.Gender,
            Nationality = request.Nationality,
            Address = request.Address,
            MotherName = request.MotherName,
            MotherNationality = request.MotherNationality,
            MotherPhone = request.MotherPhone,
            BirthCertificate = request.BirthCertificate,
            PersonalPhoto = request.PersonalPhoto,
            IDCardImage = request.IDCardImage,
            PreviousSchool = request.PreviousSchool,
            PreviousGrade = request.PreviousGrade,
            RequestedGradeLevelId = request.RequestedGradeLevelId,
            AcademicYearId = request.AcademicYearId,
            HasSpecialNeeds = request.HasSpecialNeeds,
            SpecialNeedsDetails = request.SpecialNeedsDetails,
            MedicalNotes = request.MedicalNotes,
            SiblingInSchool = request.SiblingInSchool,
            SiblingNames = request.SiblingNames,
            ReferralSource = request.ReferralSource,
            EmergencyContactName = request.EmergencyContactName,
            EmergencyContactPhone = request.EmergencyContactPhone,
            EmergencyContactRelation = request.EmergencyContactRelation,
            SubmissionDate = DateTime.UtcNow,
            RequestStatus = EduMS.Domain.Enums.RegistrationStatus.Pending
        };

        await registrationRepository.AddAsync(registration, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return registration.Id;
    }
}
