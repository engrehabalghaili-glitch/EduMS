using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticalReportSnapshots;

public class StatisticalReportSnapshotCommandHandlers : 
    IRequestHandler<CreateStatisticalReportSnapshotCommand, long>
{
    private readonly IGenericRepository<StatisticalReportSnapshot> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StatisticalReportSnapshotCommandHandlers(IGenericRepository<StatisticalReportSnapshot> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateStatisticalReportSnapshotCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<StatisticalReportSnapshot>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}