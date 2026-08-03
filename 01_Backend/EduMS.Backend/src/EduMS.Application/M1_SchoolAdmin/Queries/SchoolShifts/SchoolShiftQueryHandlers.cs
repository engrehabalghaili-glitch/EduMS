using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolShifts;

public class SchoolShiftQueryHandlers : 
    IRequestHandler<GetSchoolShiftByIdQuery, SchoolShiftDto>,
    IRequestHandler<GetAllSchoolShiftsQuery, IEnumerable<SchoolShiftDto>>
{
    private readonly IGenericRepository<SchoolShift> _repository;
    private readonly IMapper _mapper;

    public SchoolShiftQueryHandlers(IGenericRepository<SchoolShift> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolShiftDto> Handle(GetSchoolShiftByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolShift not found.");
        return _mapper.Map<SchoolShiftDto>(entity);
    }

    public async Task<IEnumerable<SchoolShiftDto>> Handle(GetAllSchoolShiftsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolShiftDto>>(entities);
    }
}