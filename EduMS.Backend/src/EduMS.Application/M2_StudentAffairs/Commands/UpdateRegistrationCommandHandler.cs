using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities.M2_StudentAffairs;
using EduMS.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace EduMS.Application.Registrations.Commands;

public class UpdateRegistrationCommandHandler(IRepository<Registration> registrationRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateRegistrationCommand, bool>
{
    public async Task<bool> HandleAsync(UpdateRegistrationCommand request, CancellationToken cancellationToken)
    {
        var registrations = await registrationRepository.FindAsync(r => r.Id == request.Id, cancellationToken);
        var registration = registrations.FirstOrDefault();
        
        if (registration == null)
        {
            return false;
        }

        registration.ParentId = request.ParentId;
        registration.SchoolId = request.SchoolId;
        registration.FirstNameAr = request.FirstNameAr;
        registration.FatherNameAr = request.FatherNameAr;
        registration.GrandfatherNameAr = request.GrandfatherNameAr;
        registration.FamilyNameAr = request.FamilyNameAr;
        registration.FirstNameEn = request.FirstNameEn;
        registration.FatherNameEn = request.FatherNameEn;
        registration.GrandfatherNameEn = request.GrandfatherNameEn;
        registration.FamilyNameEn = request.FamilyNameEn;
        registration.BirthDate = request.BirthDate;
        registration.BirthPlace = request.BirthPlace;
        registration.CountryOfBirth = request.CountryOfBirth;
        registration.Gender = request.Gender;
        registration.Nationality = request.Nationality;
        registration.Address = request.Address;
        registration.MotherName = request.MotherName;
        registration.MotherNationality = request.MotherNationality;
        registration.MotherPhone = request.MotherPhone;
        registration.BirthCertificate = request.BirthCertificate;
        registration.PersonalPhoto = request.PersonalPhoto;
        registration.IDCardImage = request.IDCardImage;
        registration.PreviousSchool = request.PreviousSchool;
        registration.PreviousGrade = request.PreviousGrade;
        registration.RequestedGradeLevelId = request.RequestedGradeLevelId;
        registration.AcademicYearId = request.AcademicYearId;
        registration.HasSpecialNeeds = request.HasSpecialNeeds;
        registration.SpecialNeedsDetails = request.SpecialNeedsDetails;
        registration.MedicalNotes = request.MedicalNotes;
        registration.SiblingInSchool = request.SiblingInSchool;
        registration.SiblingNames = request.SiblingNames;
        registration.ReferralSource = request.ReferralSource;
        registration.EmergencyContactName = request.EmergencyContactName;
        registration.EmergencyContactPhone = request.EmergencyContactPhone;
        registration.EmergencyContactRelation = request.EmergencyContactRelation;
        registration.RequestStatus = request.RequestStatus;
        registration.ReviewedByUserId = request.ReviewedByUserId;
        registration.ReviewDate = request.ReviewDate;
        registration.RejectionReason = request.RejectionReason;
        registration.ApprovalDate = request.ApprovalDate;
        registration.ConvertedToStudentId = request.ConvertedToStudentId;

        registrationRepository.Update(registration);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
