using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EduMS.Application.Common.CQRS;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;
using EduMS.Domain.Entities;

namespace EduMS.Application.M1_SchoolAdmin.Commands;

public class CreateSchoolCommandHandler(
    ISchoolRepository schoolRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : ICommandHandler<CreateSchoolCommand, long>
{
    private readonly ISchoolRepository _schoolRepository = schoolRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<long> HandleAsync(CreateSchoolCommand command, CancellationToken cancellationToken)
    {
        // Check uniqueness of school code
        var cleanCode = command.SchoolDto.SchoolCode.Trim().ToUpperInvariant();
        var isUnique = await _schoolRepository.IsSchoolCodeUniqueAsync(cleanCode, null, cancellationToken);
        if (!isUnique)
        {
            throw new InvalidOperationException($"رمز المدرسة '{cleanCode}' مسجل مسبقاً في النظام.");
        }

        var school = _mapper.Map<School>(command.SchoolDto);
        school.SchoolCode = cleanCode;
        school.IsActive = true;

        await _schoolRepository.AddAsync(school, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return school.Id;
    }
}
