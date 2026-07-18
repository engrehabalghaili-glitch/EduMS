using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentAdmissionApplications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAdmissionApplications;

public class StudentAdmissionApplicationQueryHandlers : 
    IRequestHandler<GetStudentAdmissionApplicationByIdQuery, StudentAdmissionApplicationDto>,
    IRequestHandler<GetAllStudentAdmissionApplicationsQuery, IEnumerable<StudentAdmissionApplicationDto>>
{
    private readonly IGenericRepository<StudentAdmissionApplication> _repository;
    private readonly IMapper _mapper;

    public StudentAdmissionApplicationQueryHandlers(IGenericRepository<StudentAdmissionApplication> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentAdmissionApplicationDto> Handle(GetStudentAdmissionApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentAdmissionApplication not found.");
        return _mapper.Map<StudentAdmissionApplicationDto>(entity);
    }

    public async Task<IEnumerable<StudentAdmissionApplicationDto>> Handle(GetAllStudentAdmissionApplicationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentAdmissionApplicationDto>>(entities);
    }
}