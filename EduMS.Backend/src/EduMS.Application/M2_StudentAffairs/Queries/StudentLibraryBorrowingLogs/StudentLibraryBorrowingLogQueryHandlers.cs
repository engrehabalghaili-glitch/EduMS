using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentLibraryBorrowingLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentLibraryBorrowingLogs;

public class StudentLibraryBorrowingLogQueryHandlers : 
    IRequestHandler<GetStudentLibraryBorrowingLogByIdQuery, StudentLibraryBorrowingLogDto>,
    IRequestHandler<GetAllStudentLibraryBorrowingLogsQuery, IEnumerable<StudentLibraryBorrowingLogDto>>
{
    private readonly IGenericRepository<StudentLibraryBorrowingLog> _repository;
    private readonly IMapper _mapper;

    public StudentLibraryBorrowingLogQueryHandlers(IGenericRepository<StudentLibraryBorrowingLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentLibraryBorrowingLogDto> Handle(GetStudentLibraryBorrowingLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentLibraryBorrowingLog not found.");
        return _mapper.Map<StudentLibraryBorrowingLogDto>(entity);
    }

    public async Task<IEnumerable<StudentLibraryBorrowingLogDto>> Handle(GetAllStudentLibraryBorrowingLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentLibraryBorrowingLogDto>>(entities);
    }
}