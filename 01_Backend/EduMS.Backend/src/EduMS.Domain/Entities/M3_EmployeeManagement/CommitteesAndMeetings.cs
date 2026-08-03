using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// لجان الموظفين والاجتماعات - Employee committees and meetings extracted from ZIP ERD EmployeeCommittees, CommitteeMembers, EmployeeMeetings, MeetingAttendance tables.
/// </summary>
public class EmployeeCommittee : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string CommitteeNameAr { get; set; } = string.Empty;
    public string? CommitteeNameEn { get; set; }
    public string CommitteeCode { get; set; } = string.Empty;
    public int CommitteeType { get; set; } // 1=Disciplinary, 2=Academic, 3=Procurement, 4=Event, 5=General
    public DateTime FormationDate { get; set; }
    public DateTime? DissolutionDate { get; set; }
    public string? Objectives { get; set; }
    public long? ChairmanEmployeeId { get; set; }
    public int CommitteeStatus { get; set; } = 1; // 1=Active, 2=Dissolved, 3=Suspended
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}

/// <summary>
/// عضوية الموظف في اللجنة - extracted from ZIP ERD CommitteeMembers table.
/// </summary>
public class CommitteeMember : BaseAuditableEntity
{
    public long CommitteeId { get; set; }
    public long EmployeeId { get; set; }
    public int MemberRole { get; set; } // 1=Chairman, 2=Secretary, 3=Member
    public DateTime JoinDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    public virtual EmployeeCommittee? Committee { get; set; }
    public virtual Employee? Employee { get; set; }
}

/// <summary>
/// اجتماعات الموظفين - extracted from ZIP ERD EmployeeMeetings table.
/// </summary>
public class EmployeeMeeting : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? CommitteeId { get; set; }
    public string MeetingTitleAr { get; set; } = string.Empty;
    public DateTime MeetingDateTime { get; set; }
    public string MeetingLocation { get; set; } = string.Empty;
    public int MeetingType { get; set; } // 1=Regular, 2=Emergency, 3=Committee, 4=Training
    public string? AgendaJson { get; set; }
    public string? MinutesText { get; set; }
    public string? DecisionsJson { get; set; }
    public int MeetingStatus { get; set; } = 1; // 1=Scheduled, 2=Held, 3=Cancelled, 4=Postponed
    public long? ChairmanEmployeeId { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}

/// <summary>
/// حضور الموظف في الاجتماع - extracted from ZIP ERD MeetingAttendance table.
/// </summary>
public class MeetingAttendanceRecord : BaseAuditableEntity
{
    public long MeetingId { get; set; }
    public long EmployeeId { get; set; }
    public bool IsAttended { get; set; }
    public string? AttendanceMethod { get; set; } // Physical, Remote, Proxy
    public string? AbsenceReason { get; set; }
    public bool IsExcused { get; set; }
    public string? Notes { get; set; }

    public virtual EmployeeMeeting? Meeting { get; set; }
    public virtual Employee? Employee { get; set; }
}
