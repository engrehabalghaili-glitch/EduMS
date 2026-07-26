using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassroomOperationalRules;

public class ClassroomOperationalRuleCommandHandlers : 
    IRequestHandler<CreateClassroomOperationalRuleCommand, long>,
    IRequestHandler<UpdateClassroomOperationalRuleCommand, bool>,
    IRequestHandler<DeleteClassroomOperationalRuleCommand, bool>
{
    private readonly IGenericRepository<ClassroomOperationalRule> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassroomOperationalRuleCommandHandlers(IGenericRepository<ClassroomOperationalRule> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateClassroomOperationalRuleCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ClassroomOperationalRule>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateClassroomOperationalRuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassroomOperationalRule not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteClassroomOperationalRuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassroomOperationalRule not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}