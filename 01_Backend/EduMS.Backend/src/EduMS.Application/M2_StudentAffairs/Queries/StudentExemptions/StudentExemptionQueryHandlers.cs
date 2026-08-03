using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemptions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExemptions;

public class StudentExemptionQueryHandlers : 
    IRequestHandler<GetStudentExemptionByIdQuery, StudentExemptionDto>,
    IRequestHandler<GetAllStudentExemptionsQuery, IEnumerable<StudentExemptionDto>>
{
    private readonly IGenericRepository<StudentExemption> _repository;
    private readonly IMapper _mapper;

    public StudentExemptionQueryHandlers(IGenericRepository<StudentExemption> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentExemptionDto> Handle(GetStudentExemptionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExemption not found.");
        return _mapper.Map<StudentExemptionDto>(entity);
    }

    public async Task<IEnumerable<StudentExemptionDto>> Handle(GetAllStudentExemptionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentExemptionDto>>(entities);
    }
}