using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAttachments;

public class StudentAttachmentQueryHandlers : 
    IRequestHandler<GetStudentAttachmentByIdQuery, StudentAttachmentDto>,
    IRequestHandler<GetAllStudentAttachmentsQuery, IEnumerable<StudentAttachmentDto>>
{
    private readonly IGenericRepository<StudentAttachment> _repository;
    private readonly IMapper _mapper;

    public StudentAttachmentQueryHandlers(IGenericRepository<StudentAttachment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAttachmentDto> Handle(GetStudentAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAttachment not found.");
        return _mapper.Map<StudentAttachmentDto>(entity);
    }

    public async Task<IEnumerable<StudentAttachmentDto>> Handle(GetAllStudentAttachmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAttachmentDto>>(entities);
    }
}