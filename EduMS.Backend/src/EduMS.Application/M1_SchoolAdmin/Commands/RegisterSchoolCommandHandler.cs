using EduMS.Application.Common.CQRS;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;
using EduMS.Domain.Entities;

namespace EduMS.Application.Schools.Commands;

public class RegisterSchoolCommandHandler(
    ISchoolRepository schoolRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<RegisterSchoolCommand, long>
{
    private readonly ISchoolRepository _schoolRepository = schoolRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    public async Task<long> HandleAsync(RegisterSchoolCommand request, CancellationToken cancellationToken)
    {
        var school = new School
        {
            SchoolNameAr = request.SchoolNameAr,
            SchoolNameEn = request.SchoolNameEn,
            SchoolCode = request.SchoolCode.Trim().ToUpperInvariant(),
            Directorate = request.Directorate,
            Governorate = request.Governorate,
            IsActive = true
        };

        await _schoolRepository.AddAsync(school, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return school.Id;
    }
}
