using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EduMS.Application.Common.CQRS;
using EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;
using EduMS.Application.M1_SchoolAdmin.DTOs.Schools;

namespace EduMS.Application.M1_SchoolAdmin.Queries;

public class GetSchoolsQueryHandler(
    ISchoolRepository schoolRepository,
    IMapper mapper
) : IQueryHandler<GetSchoolsQuery, IEnumerable<SchoolDto>>
{
    private readonly ISchoolRepository _schoolRepository = schoolRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<SchoolDto>> HandleAsync(GetSchoolsQuery query, CancellationToken cancellationToken)
    {
        var schools = query.OnlyActive
            ? await _schoolRepository.GetActiveSchoolsAsync(cancellationToken)
            : await _schoolRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<SchoolDto>>(schools);
    }
}
