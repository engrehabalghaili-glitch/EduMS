using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemplaryRecognitions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExemplaryRecognitions;

public class GetStudentExemplaryRecognitionByIdQuery : IRequest<StudentExemplaryRecognitionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentExemplaryRecognitionsQuery : IRequest<IEnumerable<StudentExemplaryRecognitionDto>>
{
}