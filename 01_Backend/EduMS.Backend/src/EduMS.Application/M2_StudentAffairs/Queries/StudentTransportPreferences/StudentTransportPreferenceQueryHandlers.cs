using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportPreferences;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentTransportPreferences;

public class StudentTransportPreferenceQueryHandlers : 
    IRequestHandler<GetStudentTransportPreferenceByIdQuery, StudentTransportPreferenceDto>,
    IRequestHandler<GetAllStudentTransportPreferencesQuery, IEnumerable<StudentTransportPreferenceDto>>
{
    private readonly IGenericRepository<StudentTransportPreference> _repository;
    private readonly IMapper _mapper;

    public StudentTransportPreferenceQueryHandlers(IGenericRepository<StudentTransportPreference> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentTransportPreferenceDto> Handle(GetStudentTransportPreferenceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentTransportPreference not found.");
        return _mapper.Map<StudentTransportPreferenceDto>(entity);
    }

    public async Task<IEnumerable<StudentTransportPreferenceDto>> Handle(GetAllStudentTransportPreferencesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentTransportPreferenceDto>>(entities);
    }
}