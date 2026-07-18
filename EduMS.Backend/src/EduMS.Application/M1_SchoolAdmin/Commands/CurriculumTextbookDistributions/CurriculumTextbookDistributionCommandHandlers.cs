using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.CurriculumTextbookDistributions;

public class CurriculumTextbookDistributionCommandHandlers : 
    IRequestHandler<CreateCurriculumTextbookDistributionCommand, long>,
    IRequestHandler<UpdateCurriculumTextbookDistributionCommand, bool>,
    IRequestHandler<DeleteCurriculumTextbookDistributionCommand, bool>
{
    private readonly IGenericRepository<CurriculumTextbookDistribution> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CurriculumTextbookDistributionCommandHandlers(IGenericRepository<CurriculumTextbookDistribution> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateCurriculumTextbookDistributionCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CurriculumTextbookDistribution>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateCurriculumTextbookDistributionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"CurriculumTextbookDistribution not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteCurriculumTextbookDistributionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"CurriculumTextbookDistribution not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}