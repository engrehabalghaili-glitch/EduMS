using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentPsychologicalCounselingLogs;

public class StudentPsychologicalCounselingLogCommandHandlers : 
    IRequestHandler<CreateStudentPsychologicalCounselingLogCommand, long>,
    IRequestHandler<UpdateStudentPsychologicalCounselingLogCommand, bool>,
    IRequestHandler<DeleteStudentPsychologicalCounselingLogCommand, bool>
{
    private readonly IGenericRepository<StudentPsychologicalCounselingLog> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentPsychologicalCounselingLogCommandHandlers(IGenericRepository<StudentPsychologicalCounselingLog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentPsychologicalCounselingLogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentPsychologicalCounselingLog>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentPsychologicalCounselingLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentPsychologicalCounselingLog not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentPsychologicalCounselingLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentPsychologicalCounselingLog not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}