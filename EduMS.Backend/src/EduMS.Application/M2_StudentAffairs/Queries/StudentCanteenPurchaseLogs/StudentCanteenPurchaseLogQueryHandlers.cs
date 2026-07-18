using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentCanteenPurchaseLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentCanteenPurchaseLogs;

public class StudentCanteenPurchaseLogQueryHandlers : 
    IRequestHandler<GetStudentCanteenPurchaseLogByIdQuery, StudentCanteenPurchaseLogDto>,
    IRequestHandler<GetAllStudentCanteenPurchaseLogsQuery, IEnumerable<StudentCanteenPurchaseLogDto>>
{
    private readonly IGenericRepository<StudentCanteenPurchaseLog> _repository;
    private readonly IMapper _mapper;

    public StudentCanteenPurchaseLogQueryHandlers(IGenericRepository<StudentCanteenPurchaseLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentCanteenPurchaseLogDto> Handle(GetStudentCanteenPurchaseLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentCanteenPurchaseLog not found.");
        return _mapper.Map<StudentCanteenPurchaseLogDto>(entity);
    }

    public async Task<IEnumerable<StudentCanteenPurchaseLogDto>> Handle(GetAllStudentCanteenPurchaseLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentCanteenPurchaseLogDto>>(entities);
    }
}