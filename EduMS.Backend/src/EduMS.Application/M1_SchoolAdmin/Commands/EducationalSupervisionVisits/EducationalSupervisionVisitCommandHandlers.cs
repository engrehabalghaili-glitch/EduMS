using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalSupervisionVisits;

public class EducationalSupervisionVisitCommandHandlers : 
    IRequestHandler<CreateEducationalSupervisionVisitCommand, long>,
    IRequestHandler<UpdateEducationalSupervisionVisitCommand, bool>,
    IRequestHandler<DeleteEducationalSupervisionVisitCommand, bool>
{
    private readonly IGenericRepository<EducationalSupervisionVisit> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EducationalSupervisionVisitCommandHandlers(IGenericRepository<EducationalSupervisionVisit> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateEducationalSupervisionVisitCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<EducationalSupervisionVisit>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateEducationalSupervisionVisitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalSupervisionVisit not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteEducationalSupervisionVisitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalSupervisionVisit not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}