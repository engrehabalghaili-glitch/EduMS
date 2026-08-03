using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeDocuments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeDocuments;

public class EmployeeDocumentQueryHandlers : 
    IRequestHandler<GetEmployeeDocumentByIdQuery, EmployeeDocumentDto>,
    IRequestHandler<GetAllEmployeeDocumentsQuery, IEnumerable<EmployeeDocumentDto>>
{
    private readonly IGenericRepository<EmployeeDocument> _repository;
    private readonly IMapper _mapper;

    public EmployeeDocumentQueryHandlers(IGenericRepository<EmployeeDocument> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeDocumentDto> Handle(GetEmployeeDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmployeeDocument not found.");
        return _mapper.Map<EmployeeDocumentDto>(entity);
    }

    public async Task<IEnumerable<EmployeeDocumentDto>> Handle(GetAllEmployeeDocumentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeDocumentDto>>(entities);
    }
}