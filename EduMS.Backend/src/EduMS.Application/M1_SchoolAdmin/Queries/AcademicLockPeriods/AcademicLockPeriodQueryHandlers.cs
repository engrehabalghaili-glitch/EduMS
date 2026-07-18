using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.AcademicLockPeriods;

public class AcademicLockPeriodQueryHandlers : 
    IRequestHandler<GetAcademicLockPeriodByIdQuery, AcademicLockPeriodDto>,
    IRequestHandler<GetAllAcademicLockPeriodsQuery, IEnumerable<AcademicLockPeriodDto>>
{
    private readonly IGenericRepository<AcademicLockPeriod> _repository;
    private readonly IMapper _mapper;

    public AcademicLockPeriodQueryHandlers(IGenericRepository<AcademicLockPeriod> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AcademicLockPeriodDto> Handle(GetAcademicLockPeriodByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AcademicLockPeriod not found.");
        return _mapper.Map<AcademicLockPeriodDto>(entity);
    }

    public async Task<IEnumerable<AcademicLockPeriodDto>> Handle(GetAllAcademicLockPeriodsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AcademicLockPeriodDto>>(entities);
    }
}