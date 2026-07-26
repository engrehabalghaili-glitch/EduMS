using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentFinancialAidApplications;

public class StudentFinancialAidApplicationQueryHandlers : 
    IRequestHandler<GetStudentFinancialAidApplicationByIdQuery, StudentFinancialAidApplicationDto>,
    IRequestHandler<GetAllStudentFinancialAidApplicationsQuery, IEnumerable<StudentFinancialAidApplicationDto>>
{
    private readonly IGenericRepository<StudentFinancialAidApplication> _repository;
    private readonly IMapper _mapper;

    public StudentFinancialAidApplicationQueryHandlers(IGenericRepository<StudentFinancialAidApplication> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentFinancialAidApplicationDto> Handle(GetStudentFinancialAidApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentFinancialAidApplication not found.");
        return _mapper.Map<StudentFinancialAidApplicationDto>(entity);
    }

    public async Task<IEnumerable<StudentFinancialAidApplicationDto>> Handle(GetAllStudentFinancialAidApplicationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentFinancialAidApplicationDto>>(entities);
    }
}