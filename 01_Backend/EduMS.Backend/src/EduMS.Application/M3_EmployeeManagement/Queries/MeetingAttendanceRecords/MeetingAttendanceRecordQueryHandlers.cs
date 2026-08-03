using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.MeetingAttendanceRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.MeetingAttendanceRecords;

public class MeetingAttendanceRecordQueryHandlers : 
    IRequestHandler<GetMeetingAttendanceRecordByIdQuery, MeetingAttendanceRecordDto>,
    IRequestHandler<GetAllMeetingAttendanceRecordsQuery, IEnumerable<MeetingAttendanceRecordDto>>
{
    private readonly IGenericRepository<MeetingAttendanceRecord> _repository;
    private readonly IMapper _mapper;

    public MeetingAttendanceRecordQueryHandlers(IGenericRepository<MeetingAttendanceRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MeetingAttendanceRecordDto> Handle(GetMeetingAttendanceRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"MeetingAttendanceRecord not found.");
        return _mapper.Map<MeetingAttendanceRecordDto>(entity);
    }

    public async Task<IEnumerable<MeetingAttendanceRecordDto>> Handle(GetAllMeetingAttendanceRecordsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MeetingAttendanceRecordDto>>(entities);
    }
}