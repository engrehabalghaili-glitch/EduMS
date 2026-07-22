using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.Persons;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.Persons;

public class PersonQueryHandlers : 
    IRequestHandler<GetPersonByIdQuery, PersonDto>,
    IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
{
    private readonly IGenericRepository<Person> _repository;
    private readonly IMapper _mapper;

    public PersonQueryHandlers(IGenericRepository<Person> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Person not found.");
        return _mapper.Map<PersonDto>(entity);
    }

    public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PersonDto>>(entities);
    }
}