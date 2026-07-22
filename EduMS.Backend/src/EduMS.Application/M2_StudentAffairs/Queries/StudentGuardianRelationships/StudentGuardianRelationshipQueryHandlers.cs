using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentGuardianRelationships;

public class StudentGuardianRelationshipQueryHandlers : 
    IRequestHandler<GetStudentGuardianRelationshipByIdQuery, StudentGuardianRelationshipDto>,
    IRequestHandler<GetAllStudentGuardianRelationshipsQuery, IEnumerable<StudentGuardianRelationshipDto>>
{
    private readonly IGenericRepository<StudentGuardianRelationship> _repository;
    private readonly IMapper _mapper;

    public StudentGuardianRelationshipQueryHandlers(IGenericRepository<StudentGuardianRelationship> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentGuardianRelationshipDto> Handle(GetStudentGuardianRelationshipByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentGuardianRelationship not found.");
        return _mapper.Map<StudentGuardianRelationshipDto>(entity);
    }

    public async Task<IEnumerable<StudentGuardianRelationshipDto>> Handle(GetAllStudentGuardianRelationshipsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentGuardianRelationshipDto>>(entities);
    }
}