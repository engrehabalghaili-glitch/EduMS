using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentSkillAndTalentRecords;

public class StudentSkillAndTalentRecordCommandHandlers : 
    IRequestHandler<CreateStudentSkillAndTalentRecordCommand, long>,
    IRequestHandler<UpdateStudentSkillAndTalentRecordCommand, bool>,
    IRequestHandler<DeleteStudentSkillAndTalentRecordCommand, bool>
{
    private readonly IGenericRepository<StudentSkillAndTalentRecord> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentSkillAndTalentRecordCommandHandlers(IGenericRepository<StudentSkillAndTalentRecord> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentSkillAndTalentRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentSkillAndTalentRecord>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentSkillAndTalentRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentSkillAndTalentRecord not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentSkillAndTalentRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentSkillAndTalentRecord not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}