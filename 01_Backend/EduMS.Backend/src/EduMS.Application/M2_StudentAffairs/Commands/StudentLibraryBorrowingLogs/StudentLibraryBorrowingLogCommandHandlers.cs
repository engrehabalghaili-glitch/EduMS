using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentLibraryBorrowingLogs;

public class StudentLibraryBorrowingLogCommandHandlers : 
    IRequestHandler<CreateStudentLibraryBorrowingLogCommand, long>,
    IRequestHandler<UpdateStudentLibraryBorrowingLogCommand, bool>,
    IRequestHandler<DeleteStudentLibraryBorrowingLogCommand, bool>
{
    private readonly IGenericRepository<StudentLibraryBorrowingLog> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentLibraryBorrowingLogCommandHandlers(IGenericRepository<StudentLibraryBorrowingLog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStudentLibraryBorrowingLogCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StudentLibraryBorrowingLog>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateStudentLibraryBorrowingLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentLibraryBorrowingLog not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteStudentLibraryBorrowingLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentLibraryBorrowingLog not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}