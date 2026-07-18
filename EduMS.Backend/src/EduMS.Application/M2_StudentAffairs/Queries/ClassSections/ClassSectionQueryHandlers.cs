using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.ClassSections;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.ClassSections;

public class ClassSectionQueryHandlers : 
    IRequestHandler<GetClassSectionByIdQuery, ClassSectionDto>,
    IRequestHandler<GetAllClassSectionsQuery, IEnumerable<ClassSectionDto>>
{
    private readonly IGenericRepository<ClassSection> _repository;
    private readonly IMapper _mapper;

    public ClassSectionQueryHandlers(IGenericRepository<ClassSection> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClassSectionDto> Handle(GetClassSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassSection not found.");
        return _mapper.Map<ClassSectionDto>(entity);
    }

    public async Task<IEnumerable<ClassSectionDto>> Handle(GetAllClassSectionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ClassSectionDto>>(entities);
    }
}