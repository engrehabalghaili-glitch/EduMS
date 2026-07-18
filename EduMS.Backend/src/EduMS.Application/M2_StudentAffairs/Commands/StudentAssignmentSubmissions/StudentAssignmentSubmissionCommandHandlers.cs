using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAssignmentSubmissions;

public class StudentAssignmentSubmissionCommandHandlers : 
    IRequestHandler<CreateStudentAssignmentSubmissionCommand, long>,
    IRequestHandler<UpdateStudentAssignmentSubmissionCommand, bool>,
    IRequestHandler<DeleteStudentAssignmentSubmissionCommand, bool>
{
    private readonly IGenericRepository<StudentAssignmentSubmission> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentAssignmentSubmissionCommandHandlers(IGenericRepository<StudentAssignmentSubmission> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentAssignmentSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentAssignmentSubmission>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentAssignmentSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAssignmentSubmission not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentAssignmentSubmissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAssignmentSubmission not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}