using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAcademicYears;

public class SchoolAcademicYearQueryHandlers : 
    IRequestHandler<GetSchoolAcademicYearByIdQuery, SchoolAcademicYearDto>,
    IRequestHandler<GetAllSchoolAcademicYearsQuery, IEnumerable<SchoolAcademicYearDto>>
{
    private readonly IGenericRepository<SchoolAcademicYear> _repository;
    private readonly IMapper _mapper;

    public SchoolAcademicYearQueryHandlers(IGenericRepository<SchoolAcademicYear> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolAcademicYearDto> Handle(GetSchoolAcademicYearByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolAcademicYear not found.");
        return _mapper.Map<SchoolAcademicYearDto>(entity);
    }

    public async Task<IEnumerable<SchoolAcademicYearDto>> Handle(GetAllSchoolAcademicYearsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolAcademicYearDto>>(entities);
    }
}