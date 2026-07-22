using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentComplaintLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentComplaintLogs;

public class StudentComplaintLogQueryHandlers : 
    IRequestHandler<GetStudentComplaintLogByIdQuery, StudentComplaintLogDto>,
    IRequestHandler<GetAllStudentComplaintLogsQuery, IEnumerable<StudentComplaintLogDto>>
{
    private readonly IGenericRepository<StudentComplaintLog> _repository;
    private readonly IMapper _mapper;

    public StudentComplaintLogQueryHandlers(IGenericRepository<StudentComplaintLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentComplaintLogDto> Handle(GetStudentComplaintLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentComplaintLog not found.");
        return _mapper.Map<StudentComplaintLogDto>(entity);
    }

    public async Task<IEnumerable<StudentComplaintLogDto>> Handle(GetAllStudentComplaintLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentComplaintLogDto>>(entities);
    }
}