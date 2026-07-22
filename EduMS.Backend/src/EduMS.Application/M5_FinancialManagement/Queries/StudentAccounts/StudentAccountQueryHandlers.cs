using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.StudentAccounts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.StudentAccounts;

public class StudentAccountQueryHandlers : 
    IRequestHandler<GetStudentAccountByIdQuery, StudentAccountDto>,
    IRequestHandler<GetAllStudentAccountsQuery, IEnumerable<StudentAccountDto>>
{
    private readonly IGenericRepository<StudentAccount> _repository;
    private readonly IMapper _mapper;

    public StudentAccountQueryHandlers(IGenericRepository<StudentAccount> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAccountDto> Handle(GetStudentAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAccount not found.");
        return _mapper.Map<StudentAccountDto>(entity);
    }

    public async Task<IEnumerable<StudentAccountDto>> Handle(GetAllStudentAccountsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAccountDto>>(entities);
    }
}