using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentInventoryCustodies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentInventoryCustodies;

public class StudentInventoryCustodyQueryHandlers : 
    IRequestHandler<GetStudentInventoryCustodyByIdQuery, StudentInventoryCustodyDto>,
    IRequestHandler<GetAllStudentInventoryCustodiesQuery, IEnumerable<StudentInventoryCustodyDto>>
{
    private readonly IGenericRepository<StudentInventoryCustody> _repository;
    private readonly IMapper _mapper;

    public StudentInventoryCustodyQueryHandlers(IGenericRepository<StudentInventoryCustody> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentInventoryCustodyDto> Handle(GetStudentInventoryCustodyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentInventoryCustody not found.");
        return _mapper.Map<StudentInventoryCustodyDto>(entity);
    }

    public async Task<IEnumerable<StudentInventoryCustodyDto>> Handle(GetAllStudentInventoryCustodiesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentInventoryCustodyDto>>(entities);
    }
}