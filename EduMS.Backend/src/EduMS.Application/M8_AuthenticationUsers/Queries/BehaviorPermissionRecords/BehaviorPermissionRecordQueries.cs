using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionRecords;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissionRecords;

public class GetBehaviorPermissionRecordByIdQuery : IRequest<BehaviorPermissionRecordDto>
{
    public long Id { get; set; }
}

public class GetAllBehaviorPermissionRecordsQuery : IRequest<IEnumerable<BehaviorPermissionRecordDto>>
{
}