using System;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Common.Security;
using MediatR;
using FluentValidation;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Application.Interfaces.CrossModule;
using EduMS.Domain.Entities;
using ValidationException = EduMS.Application.Common.Validation.ValidationException;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicYears
{
    [AuthorizeRole("SYSTEM_ADMIN")]
    public class CloseAcademicYearCommand : IRequest<bool>
    {
        public long AcademicYearId { get; set; }
    }

    public class CloseAcademicYearCommandHandler : IRequestHandler<CloseAcademicYearCommand, bool>
    {
        private readonly IGenericRepository<SchoolAcademicYear> _academicYearRepository;
        private readonly IAcademicIntegrityChecker _integrityChecker;
        private readonly IUnitOfWork _unitOfWork;

        public CloseAcademicYearCommandHandler(
            IGenericRepository<SchoolAcademicYear> academicYearRepository,
            IAcademicIntegrityChecker integrityChecker,
            IUnitOfWork unitOfWork)
        {
            _academicYearRepository = academicYearRepository;
            _integrityChecker = integrityChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CloseAcademicYearCommand request, CancellationToken cancellationToken)
        {
            var academicYear = await _academicYearRepository.GetByIdAsync(request.AcademicYearId, cancellationToken);
            if (academicYear == null)
                throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("AcademicYearId", "Academic Year not found.") });

            if (academicYear.YearStatus == 3) // 3 = Closed
                throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("YearStatus", "Academic Year is already closed.") });

            // Check M2 (Academics) Integrity
            bool hasIncompleteGrades = await _integrityChecker.HasIncompleteGradesAsync(request.AcademicYearId, cancellationToken);
            if (hasIncompleteGrades)
            {
                throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Integrity", "Cannot close year: There are incomplete grades in M2 (Student Affairs).") });
            }

            // Check M5 (Financials) Integrity
            bool hasOutstandingDues = await _integrityChecker.HasOutstandingDuesAsync(request.AcademicYearId, cancellationToken);
            if (hasOutstandingDues)
            {
                throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Integrity", "Cannot close year: There are outstanding fee invoices in M5 (Financials).") });
            }

            academicYear.YearStatus = 3; // Closed
            await _academicYearRepository.UpdateAsync(academicYear, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
