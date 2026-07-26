using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.JobApplicants;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.JobApplicants;

public class JobApplicantQueryHandlers : 
    IRequestHandler<GetJobApplicantByIdQuery, JobApplicantDto>,
    IRequestHandler<GetAllJobApplicantsQuery, IEnumerable<JobApplicantDto>>
{
    private readonly IGenericRepository<JobApplicant> _repository;
    private readonly IMapper _mapper;

    public JobApplicantQueryHandlers(IGenericRepository<JobApplicant> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JobApplicantDto> Handle(GetJobApplicantByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"JobApplicant not found.");
        return _mapper.Map<JobApplicantDto>(entity);
    }

    public async Task<IEnumerable<JobApplicantDto>> Handle(GetAllJobApplicantsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<JobApplicantDto>>(entities);
    }
}