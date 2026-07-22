using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExtracurricularAchievements;

public class StudentExtracurricularAchievementCommandHandlers : 
    IRequestHandler<CreateStudentExtracurricularAchievementCommand, long>,
    IRequestHandler<UpdateStudentExtracurricularAchievementCommand, bool>,
    IRequestHandler<DeleteStudentExtracurricularAchievementCommand, bool>
{
    private readonly IGenericRepository<StudentExtracurricularAchievement> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentExtracurricularAchievementCommandHandlers(IGenericRepository<StudentExtracurricularAchievement> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentExtracurricularAchievementCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentExtracurricularAchievement>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentExtracurricularAchievementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExtracurricularAchievement not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentExtracurricularAchievementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExtracurricularAchievement not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}