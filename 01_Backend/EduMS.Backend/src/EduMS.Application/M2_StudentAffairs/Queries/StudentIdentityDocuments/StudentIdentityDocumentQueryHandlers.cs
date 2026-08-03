using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentIdentityDocuments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentIdentityDocuments;

public class StudentIdentityDocumentQueryHandlers : 
    IRequestHandler<GetStudentIdentityDocumentByIdQuery, StudentIdentityDocumentDto>,
    IRequestHandler<GetAllStudentIdentityDocumentsQuery, IEnumerable<StudentIdentityDocumentDto>>
{
    private readonly IGenericRepository<StudentIdentityDocument> _repository;
    private readonly IMapper _mapper;

    public StudentIdentityDocumentQueryHandlers(IGenericRepository<StudentIdentityDocument> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentIdentityDocumentDto> Handle(GetStudentIdentityDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentIdentityDocument not found.");
        return _mapper.Map<StudentIdentityDocumentDto>(entity);
    }

    public async Task<IEnumerable<StudentIdentityDocumentDto>> Handle(GetAllStudentIdentityDocumentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentIdentityDocumentDto>>(entities);
    }
}