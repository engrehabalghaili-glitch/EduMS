using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.Students;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.Students;

public class StudentQueryHandlers : 
    IRequestHandler<GetStudentByIdQuery, StudentDto>,
    IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
{
    private readonly IGenericRepository<Student> _repository;
    private readonly IMapper _mapper;

    public StudentQueryHandlers(IGenericRepository<Student> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Student not found.");
        return _mapper.Map<StudentDto>(entity);
    }

    public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentDto>>(entities);
    }
}