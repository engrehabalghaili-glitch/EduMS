using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.AttendanceDetails;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.AttendanceDetails;

public class AttendanceDetailQueryHandlers : 
    IRequestHandler<GetAttendanceDetailByIdQuery, AttendanceDetailDto>,
    IRequestHandler<GetAllAttendanceDetailsQuery, IEnumerable<AttendanceDetailDto>>
{
    private readonly IGenericRepository<AttendanceDetail> _repository;
    private readonly IMapper _mapper;

    public AttendanceDetailQueryHandlers(IGenericRepository<AttendanceDetail> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AttendanceDetailDto> Handle(GetAttendanceDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AttendanceDetail not found.");
        return _mapper.Map<AttendanceDetailDto>(entity);
    }

    public async Task<IEnumerable<AttendanceDetailDto>> Handle(GetAllAttendanceDetailsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AttendanceDetailDto>>(entities);
    }
}