using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMentors;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeMentors;

public class EmployeeMentorQueryHandlers : 
    IRequestHandler<GetEmployeeMentorByIdQuery, EmployeeMentorDto>,
    IRequestHandler<GetAllEmployeeMentorsQuery, IEnumerable<EmployeeMentorDto>>
{
    private readonly IGenericRepository<EmployeeMentor> _repository;
    private readonly IMapper _mapper;

    public EmployeeMentorQueryHandlers(IGenericRepository<EmployeeMentor> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeMentorDto> Handle(GetEmployeeMentorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeMentor not found.");
        return _mapper.Map<EmployeeMentorDto>(entity);
    }

    public async Task<IEnumerable<EmployeeMentorDto>> Handle(GetAllEmployeeMentorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeMentorDto>>(entities);
    }
}