using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTrainings;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeTrainings;

public class EmployeeTrainingQueryHandlers : 
    IRequestHandler<GetEmployeeTrainingByIdQuery, EmployeeTrainingDto>,
    IRequestHandler<GetAllEmployeeTrainingsQuery, IEnumerable<EmployeeTrainingDto>>
{
    private readonly IGenericRepository<EmployeeTraining> _repository;
    private readonly IMapper _mapper;

    public EmployeeTrainingQueryHandlers(IGenericRepository<EmployeeTraining> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeTrainingDto> Handle(GetEmployeeTrainingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeTraining not found.");
        return _mapper.Map<EmployeeTrainingDto>(entity);
    }

    public async Task<IEnumerable<EmployeeTrainingDto>> Handle(GetAllEmployeeTrainingsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeTrainingDto>>(entities);
    }
}