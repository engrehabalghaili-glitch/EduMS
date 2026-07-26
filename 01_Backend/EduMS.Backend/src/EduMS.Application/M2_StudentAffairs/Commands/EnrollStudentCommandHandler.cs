using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities;
using EduMS.Domain.Interfaces;

namespace EduMS.Application.Students.Commands;

public class EnrollStudentCommandHandler(
    IRepository<Student> studentRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<EnrollStudentCommand, long>
{
    private readonly IRepository<Student> _studentRepository = studentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<long> HandleAsync(EnrollStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            FullNameAr = request.FullNameAr,
            FullNameEn = request.FullNameEn,
            NationalId = request.NationalId,
            Gender = (EduMS.Domain.Enums.Gender)request.Gender,
            EnrollmentNumber = request.EnrollmentNumber.Trim().ToUpperInvariant(),
            EnrollmentDate = request.EnrollmentDate,
            SchoolId = request.SchoolId,
            GuardianId = request.GuardianId,
            IsActive = true
        };

        await _studentRepository.AddAsync(student, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}
