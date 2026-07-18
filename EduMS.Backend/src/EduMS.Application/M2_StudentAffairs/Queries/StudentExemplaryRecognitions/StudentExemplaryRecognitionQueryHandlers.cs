using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemplaryRecognitions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExemplaryRecognitions;

public class StudentExemplaryRecognitionQueryHandlers : 
    IRequestHandler<GetStudentExemplaryRecognitionByIdQuery, StudentExemplaryRecognitionDto>,
    IRequestHandler<GetAllStudentExemplaryRecognitionsQuery, IEnumerable<StudentExemplaryRecognitionDto>>
{
    private readonly IGenericRepository<StudentExemplaryRecognition> _repository;
    private readonly IMapper _mapper;

    public StudentExemplaryRecognitionQueryHandlers(IGenericRepository<StudentExemplaryRecognition> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentExemplaryRecognitionDto> Handle(GetStudentExemplaryRecognitionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExemplaryRecognition not found.");
        return _mapper.Map<StudentExemplaryRecognitionDto>(entity);
    }

    public async Task<IEnumerable<StudentExemplaryRecognitionDto>> Handle(GetAllStudentExemplaryRecognitionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentExemplaryRecognitionDto>>(entities);
    }
}