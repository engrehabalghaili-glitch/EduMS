using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMeetings;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeMeetings;

public class EmployeeMeetingQueryHandlers : 
    IRequestHandler<GetEmployeeMeetingByIdQuery, EmployeeMeetingDto>,
    IRequestHandler<GetAllEmployeeMeetingsQuery, IEnumerable<EmployeeMeetingDto>>
{
    private readonly IGenericRepository<EmployeeMeeting> _repository;
    private readonly IMapper _mapper;

    public EmployeeMeetingQueryHandlers(IGenericRepository<EmployeeMeeting> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeMeetingDto> Handle(GetEmployeeMeetingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeMeeting not found.");
        return _mapper.Map<EmployeeMeetingDto>(entity);
    }

    public async Task<IEnumerable<EmployeeMeetingDto>> Handle(GetAllEmployeeMeetingsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeMeetingDto>>(entities);
    }
}