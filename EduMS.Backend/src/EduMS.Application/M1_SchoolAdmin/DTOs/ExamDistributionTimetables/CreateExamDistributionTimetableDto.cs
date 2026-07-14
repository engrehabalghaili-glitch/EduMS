using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;

public class CreateExamDistributionTimetableDto
{
    public long SchoolId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public long? FacilityId { get; set; }
    public long? ProctorEmployeeId { get; set; }
    public DateTime ExamDate { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public int MaxSeatCount { get; set; }
    public int Status { get; set; }
    public string? ExamSessionNameAr { get; set; }
    public int ExamType { get; set; } = 1;
    public int TermSemesterNumber { get; set; } = 1;
    public long? AssistantProctorEmployeeId { get; set; }
    public bool IsSeatingChartPublished { get; set; }
}
