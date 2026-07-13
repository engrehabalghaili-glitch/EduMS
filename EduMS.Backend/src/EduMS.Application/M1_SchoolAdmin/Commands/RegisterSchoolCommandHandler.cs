using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities;
using EduMS.Domain.Interfaces;

namespace EduMS.Application.Schools.Commands;

public class RegisterSchoolCommandHandler(
    IRepository<School> schoolRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<RegisterSchoolCommand, long>
{
    private readonly IRepository<School> _schoolRepository = schoolRepository;
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
