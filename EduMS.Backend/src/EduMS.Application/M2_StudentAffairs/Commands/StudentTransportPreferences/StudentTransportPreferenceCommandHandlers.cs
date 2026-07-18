using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransportPreferences;

public class StudentTransportPreferenceCommandHandlers : 
    IRequestHandler<CreateStudentTransportPreferenceCommand, long>,
    IRequestHandler<UpdateStudentTransportPreferenceCommand, bool>,
    IRequestHandler<DeleteStudentTransportPreferenceCommand, bool>
{
    private readonly IGenericRepository<StudentTransportPreference> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentTransportPreferenceCommandHandlers(IGenericRepository<StudentTransportPreference> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentTransportPreferenceCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentTransportPreference>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentTransportPreferenceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentTransportPreference not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentTransportPreferenceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentTransportPreference not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}