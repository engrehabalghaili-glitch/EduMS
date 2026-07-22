using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicBranchConfigLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.AcademicBranchConfigLogs;

public class AcademicBranchConfigLogQueryHandlers : 
    IRequestHandler<GetAcademicBranchConfigLogByIdQuery, AcademicBranchConfigLogDto>,
    IRequestHandler<GetAllAcademicBranchConfigLogsQuery, IEnumerable<AcademicBranchConfigLogDto>>
{
    private readonly IGenericRepository<AcademicBranchConfigLog> _repository;
    private readonly IMapper _mapper;

    public AcademicBranchConfigLogQueryHandlers(IGenericRepository<AcademicBranchConfigLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AcademicBranchConfigLogDto> Handle(GetAcademicBranchConfigLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AcademicBranchConfigLog not found.");
        return _mapper.Map<AcademicBranchConfigLogDto>(entity);
    }

    public async Task<IEnumerable<AcademicBranchConfigLogDto>> Handle(GetAllAcademicBranchConfigLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AcademicBranchConfigLogDto>>(entities);
    }
}