using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.StudentExtracurricularAchievements;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExtracurricularAchievements;

public class StudentExtracurricularAchievementQueryHandlers : 
    IRequestHandler<GetStudentExtracurricularAchievementByIdQuery, StudentExtracurricularAchievementDto>,
    IRequestHandler<GetAllStudentExtracurricularAchievementsQuery, IEnumerable<StudentExtracurricularAchievementDto>>
{
    private readonly IGenericRepository<StudentExtracurricularAchievement> _repository;
    private readonly IMapper _mapper;

    public StudentExtracurricularAchievementQueryHandlers(IGenericRepository<StudentExtracurricularAchievement> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentExtracurricularAchievementDto> Handle(GetStudentExtracurricularAchievementByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"StudentExtracurricularAchievement not found.");
        return _mapper.Map<StudentExtracurricularAchievementDto>(entity);
    }

    public async Task<IEnumerable<StudentExtracurricularAchievementDto>> Handle(GetAllStudentExtracurricularAchievementsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<StudentExtracurricularAchievementDto>>(entities);
    }
}