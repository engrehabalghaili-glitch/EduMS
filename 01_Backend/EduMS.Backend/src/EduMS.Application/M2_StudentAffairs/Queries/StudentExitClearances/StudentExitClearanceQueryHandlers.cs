using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExitClearances;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExitClearances;

public class StudentExitClearanceQueryHandlers : 
    IRequestHandler<GetStudentExitClearanceByIdQuery, StudentExitClearanceDto>,
    IRequestHandler<GetAllStudentExitClearancesQuery, IEnumerable<StudentExitClearanceDto>>
{
    private readonly IGenericRepository<StudentExitClearance> _repository;
    private readonly IMapper _mapper;

    public StudentExitClearanceQueryHandlers(IGenericRepository<StudentExitClearance> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentExitClearanceDto> Handle(GetStudentExitClearanceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExitClearance not found.");
        return _mapper.Map<StudentExitClearanceDto>(entity);
    }

    public async Task<IEnumerable<StudentExitClearanceDto>> Handle(GetAllStudentExitClearancesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentExitClearanceDto>>(entities);
    }
}