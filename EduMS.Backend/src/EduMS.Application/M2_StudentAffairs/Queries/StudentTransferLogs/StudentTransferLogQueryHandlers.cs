using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransferLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentTransferLogs;

public class StudentTransferLogQueryHandlers : 
    IRequestHandler<GetStudentTransferLogByIdQuery, StudentTransferLogDto>,
    IRequestHandler<GetAllStudentTransferLogsQuery, IEnumerable<StudentTransferLogDto>>
{
    private readonly IGenericRepository<StudentTransferLog> _repository;
    private readonly IMapper _mapper;

    public StudentTransferLogQueryHandlers(IGenericRepository<StudentTransferLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentTransferLogDto> Handle(GetStudentTransferLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentTransferLog not found.");
        return _mapper.Map<StudentTransferLogDto>(entity);
    }

    public async Task<IEnumerable<StudentTransferLogDto>> Handle(GetAllStudentTransferLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentTransferLogDto>>(entities);
    }
}