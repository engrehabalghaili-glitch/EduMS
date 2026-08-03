using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.DashboardKpiConfigurations;

public class DashboardKpiConfigurationCommandHandlers : 
    IRequestHandler<CreateDashboardKpiConfigurationCommand, long>,
    IRequestHandler<UpdateDashboardKpiConfigurationCommand, bool>,
    IRequestHandler<DeleteDashboardKpiConfigurationCommand, bool>
{
    private readonly IGenericRepository<DashboardKpiConfiguration> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DashboardKpiConfigurationCommandHandlers(IGenericRepository<DashboardKpiConfiguration> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateDashboardKpiConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<DashboardKpiConfiguration>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateDashboardKpiConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DashboardKpiConfiguration not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteDashboardKpiConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DashboardKpiConfiguration not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}