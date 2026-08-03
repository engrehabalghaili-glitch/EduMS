using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;

public class UpdateClassroomDto
{
    public long Id { get; set; }
    public string ClassroomCode { get; set; }
    public string ClassroomNameAr { get; set; }
    public string ClassroomNameEn { get; set; }
    public int GradeLevel { get; set; }
    public int Capacity { get; set; }
    public string? RoomNumber { get; set; }
    public int FloorLevel { get; set; }
    public string? BuildingSection { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public bool IsSmartClassroom { get; set; }
}
