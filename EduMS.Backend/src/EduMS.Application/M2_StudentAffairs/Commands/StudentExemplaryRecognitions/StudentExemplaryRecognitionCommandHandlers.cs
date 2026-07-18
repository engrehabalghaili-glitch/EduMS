using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExemplaryRecognitions;

public class StudentExemplaryRecognitionCommandHandlers : 
    IRequestHandler<CreateStudentExemplaryRecognitionCommand, long>,
    IRequestHandler<UpdateStudentExemplaryRecognitionCommand, bool>,
    IRequestHandler<DeleteStudentExemplaryRecognitionCommand, bool>
{
    private readonly IGenericRepository<StudentExemplaryRecognition> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentExemplaryRecognitionCommandHandlers(IGenericRepository<StudentExemplaryRecognition> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentExemplaryRecognitionCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentExemplaryRecognition>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentExemplaryRecognitionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExemplaryRecognition not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentExemplaryRecognitionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExemplaryRecognition not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}