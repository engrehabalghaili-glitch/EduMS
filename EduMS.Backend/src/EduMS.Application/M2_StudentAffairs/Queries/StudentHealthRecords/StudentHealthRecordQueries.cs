using EduMS.Application.M2_StudentAffairs.DTOs.StudentHealthRecords;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentHealthRecords;

public class GetStudentHealthRecordByIdQuery : IRequest<StudentHealthRecordDto>
{
    public long Id { get; set; }
}

public class GetAllStudentHealthRecordsQuery : IRequest<IEnumerable<StudentHealthRecordDto>>
{
}