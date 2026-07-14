using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;

public class CreateClassroomDto
{
    public long SchoolId { get; set; }
    public string ClassroomCode { get; set; } = string.Empty;
    public string ClassroomNameAr { get; set; } = string.Empty;
    public string ClassroomNameEn { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public int Capacity { get; set; } = 30;
    public string? RoomNumber { get; set; }
    public int FloorLevel { get; set; }
    public string? BuildingSection { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public bool IsSmartClassroom { get; set; }
    public bool IsActive { get; set; } = true;
}
