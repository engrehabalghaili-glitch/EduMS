using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M7_EmergencyManagement.Configurations;

public class EmergencyPlanConfiguration : IEntityTypeConfiguration<EmergencyPlan>
{
    public void Configure(EntityTypeBuilder<EmergencyPlan> builder)
    {
        builder.ToTable("EMERGENCY_PLAN");

        builder.Property(e => e.PlanCode)
            .HasColumnName("PLAN_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.PlanTitleAr)
            .HasColumnName("PLAN_TITLE_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PlanTitleEn)
            .HasColumnName("PLAN_TITLE_EN")
            .HasMaxLength(250);

        builder.Property(e => e.EvacuationProcedureSummary)
            .HasColumnName("EVACUATION_PROCEDURE_SUMMARY");

        builder.Property(e => e.NextScheduledDrillDate)
            .HasColumnName("NEXT_SCHEDULED_DRILL_DATE");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.SchoolId, e.PlanCode });
    }
}



public class EmergencyHostingConfiguration : IEntityTypeConfiguration<EmergencyHosting>
{
    public void Configure(EntityTypeBuilder<EmergencyHosting> builder)
    {
        builder.ToTable("EMERGENCY_HOSTING");

        builder.Property(e => e.HostingNumber)
            .HasColumnName("HOSTING_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.HostingType)
            .HasColumnName("HOSTING_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.HostingDate)
            .HasColumnName("HOSTING_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.ExpectedEndDate)
            .HasColumnName("EXPECTED_END_DATE");

        builder.Property(e => e.ActualCount)
            .HasColumnName("ACTUAL_COUNT");

        builder.Property(e => e.MaxCapacity)
            .HasColumnName("MAX_CAPACITY");

        builder.Property(e => e.UtilizationPercentage)
            .HasColumnName("UTILIZATION_PERCENTAGE")
            .HasPrecision(19, 4);

        builder.Property(e => e.Reason)
            .HasColumnName("REASON");

        builder.Property(e => e.SourceLocation)
            .HasColumnName("SOURCE_LOCATION")
            .HasMaxLength(250);

        builder.Property(e => e.SupportOrganization)
            .HasColumnName("SUPPORT_ORGANIZATION")
            .HasMaxLength(250);

        builder.Property(e => e.SupportOrgContact)
            .HasColumnName("SUPPORT_ORG_CONTACT")
            .HasMaxLength(150);

        builder.Property(e => e.FacilitiesUsedJson)
            .HasColumnName("FACILITIES_USED_JSON");

        builder.Property(e => e.ResourcesProvidedJson)
            .HasColumnName("RESOURCES_PROVIDED_JSON");

        builder.Property(e => e.ResourcesReceivedJson)
            .HasColumnName("RESOURCES_RECEIVED_JSON");

        builder.Property(e => e.ExpensesJson)
            .HasColumnName("EXPENSES_JSON");

        builder.Property(e => e.TotalExpenses)
            .HasColumnName("TOTAL_EXPENSES")
            .HasPrecision(19, 4);

        builder.Property(e => e.HostingStatus)
            .HasColumnName("HOSTING_STATUS");

        builder.Property(e => e.ClosureNotes)
            .HasColumnName("CLOSURE_NOTES");

        builder.Property(e => e.LessonsLearned)
            .HasColumnName("LESSONS_LEARNED");

        builder.Property(e => e.ReportedByUserId)
            .HasColumnName("REPORTED_BY_USER_ID");

        builder.Property(e => e.AttachmentsJson)
            .HasColumnName("ATTACHMENTS_JSON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ReportedByUser)
            .WithMany()
            .HasForeignKey(e => e.ReportedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmergencyIncidentConfiguration : IEntityTypeConfiguration<EmergencyIncident>
{
    public void Configure(EntityTypeBuilder<EmergencyIncident> builder)
    {
        builder.ToTable("EMERGENCY_INCIDENT");

        builder.Property(e => e.IncidentNumber)
            .HasColumnName("INCIDENT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.IncidentType)
            .HasColumnName("INCIDENT_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.IncidentDate)
            .HasColumnName("INCIDENT_DATE");

        builder.Property(e => e.IncidentTime)
            .HasColumnName("INCIDENT_TIME");

        builder.Property(e => e.Severity)
            .HasColumnName("SEVERITY");

        builder.Property(e => e.Description)
            .HasColumnName("DESCRIPTION");

        builder.Property(e => e.LocationText)
            .HasColumnName("LOCATION_TEXT")
            .HasMaxLength(250);

        builder.Property(e => e.ReportedByUserId)
            .HasColumnName("REPORTED_BY_USER_ID");

        builder.Property(e => e.ReportedAt)
            .HasColumnName("REPORTED_AT");

        builder.Property(e => e.IsPlanActive)
            .HasColumnName("IS_PLAN_ACTIVE");

        builder.Property(e => e.EmergencyPlanId)
            .HasColumnName("EMERGENCY_PLAN_ID");

        builder.Property(e => e.AffectedCount)
            .HasColumnName("AFFECTED_COUNT");

        builder.Property(e => e.StudentsAffected)
            .HasColumnName("STUDENTS_AFFECTED");

        builder.Property(e => e.EmployeesAffected)
            .HasColumnName("EMPLOYEES_AFFECTED");

        builder.Property(e => e.InjuriesCount)
            .HasColumnName("INJURIES_COUNT");

        builder.Property(e => e.SevereInjuriesCount)
            .HasColumnName("SEVERE_INJURIES_COUNT");

        builder.Property(e => e.FatalitiesCount)
            .HasColumnName("FATALITIES_COUNT");

        builder.Property(e => e.PropertyDamage)
            .HasColumnName("PROPERTY_DAMAGE")
            .HasPrecision(19, 4);

        builder.Property(e => e.PropertyDamageDescription)
            .HasColumnName("PROPERTY_DAMAGE_DESC");

        builder.Property(e => e.EmergencyResponseActions)
            .HasColumnName("EMERGENCY_RESPONSE_ACTIONS");

        builder.Property(e => e.ExternalAgenciesJson)
            .HasColumnName("EXTERNAL_AGENCIES_JSON");

        builder.Property(e => e.ExternalResponseTime)
            .HasColumnName("EXTERNAL_RESPONSE_TIME");

        builder.Property(e => e.IncidentStatus)
            .HasColumnName("INCIDENT_STATUS");

        builder.Property(e => e.ClosureDate)
            .HasColumnName("CLOSURE_DATE");

        builder.Property(e => e.ClosureNotes)
            .HasColumnName("CLOSURE_NOTES");

        builder.Property(e => e.InvestigationReportUrl)
            .HasColumnName("INVESTIGATION_REPORT_URL")
            .HasMaxLength(500);

        builder.Property(e => e.LessonsLearned)
            .HasColumnName("LESSONS_LEARNED");

        builder.Property(e => e.Recommendations)
            .HasColumnName("RECOMMENDATIONS");

        builder.Property(e => e.AttachmentsJson)
            .HasColumnName("ATTACHMENTS_JSON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ReportedByUser)
            .WithMany()
            .HasForeignKey(e => e.ReportedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.EmergencyPlan)
            .WithMany(p => p.Incidents)
            .HasForeignKey(e => e.EmergencyPlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmergencyClosureConfiguration : IEntityTypeConfiguration<EmergencyClosure>
{
    public void Configure(EntityTypeBuilder<EmergencyClosure> builder)
    {
        builder.ToTable("EMERGENCY_CLOSURE");

        builder.Property(e => e.ClosureNumber)
            .HasColumnName("CLOSURE_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ClosureReason)
            .HasColumnName("CLOSURE_REASON")
            .HasMaxLength(100);

        builder.Property(e => e.DecisionAuthority)
            .HasColumnName("DECISION_AUTHORITY")
            .HasMaxLength(150);

        builder.Property(e => e.AuthorityDecisionNumber)
            .HasColumnName("AUTHORITY_DECISION_NUMBER")
            .HasMaxLength(100);

        builder.Property(e => e.StartDate)
            .HasColumnName("START_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.ActualEndDate)
            .HasColumnName("ACTUAL_END_DATE");

        builder.Property(e => e.TotalClosureDays)
            .HasColumnName("TOTAL_CLOSURE_DAYS");

        builder.Property(e => e.SchoolDaysAffected)
            .HasColumnName("SCHOOL_DAYS_AFFECTED");

        builder.Property(e => e.AlternativeEducationActivated)
            .HasColumnName("ALT_EDU_ACTIVATED");

        builder.Property(e => e.AlternativeEducationType)
            .HasColumnName("ALT_EDU_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.AltEducationPlatform)
            .HasColumnName("ALT_EDU_PLATFORM")
            .HasMaxLength(100);

        builder.Property(e => e.AltEducationDetails)
            .HasColumnName("ALT_EDU_DETAILS");

        builder.Property(e => e.WasCompensated)
            .HasColumnName("WAS_COMPENSATED");

        builder.Property(e => e.CompensationRemediationPlanId)
            .HasColumnName("COMPENSATION_PLAN_ID");

        builder.Property(e => e.ParentNotificationSent)
            .HasColumnName("PARENT_NOTIFICATION_SENT");

        builder.Property(e => e.ParentNotificationDate)
            .HasColumnName("PARENT_NOTIFICATION_DATE");

        builder.Property(e => e.ParentNotificationMethod)
            .HasColumnName("PARENT_NOTIFICATION_METHOD")
            .HasMaxLength(50);

        builder.Property(e => e.ClosureStatus)
            .HasColumnName("CLOSURE_STATUS");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class TransportationServiceConfiguration : IEntityTypeConfiguration<TransportationService>
{
    public void Configure(EntityTypeBuilder<TransportationService> builder)
    {
        builder.ToTable("TRANSPORTATION_SERVICE");

        builder.Property(e => e.RouteCode)
            .HasColumnName("ROUTE_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.RouteName)
            .HasColumnName("ROUTE_NAME")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.RouteDescription)
            .HasColumnName("ROUTE_DESCRIPTION");

        builder.Property(e => e.BusAssetId)
            .HasColumnName("BUS_ASSET_ID");

        builder.Property(e => e.BusPlateNumber)
            .HasColumnName("BUS_PLATE_NUMBER")
            .HasMaxLength(50);

        builder.Property(e => e.BusCapacity)
            .HasColumnName("BUS_CAPACITY");

        builder.Property(e => e.BusModel)
            .HasColumnName("BUS_MODEL")
            .HasMaxLength(100);

        builder.Property(e => e.BusYear)
            .HasColumnName("BUS_YEAR")
            .HasMaxLength(20);

        builder.Property(e => e.DriverEmployeeId)
            .HasColumnName("DRIVER_EMPLOYEE_ID");

        builder.Property(e => e.DriverLicenseNumber)
            .HasColumnName("DRIVER_LICENSE_NUMBER")
            .HasMaxLength(50);

        builder.Property(e => e.DriverPhone)
            .HasColumnName("DRIVER_PHONE")
            .HasMaxLength(30);

        builder.Property(e => e.SupervisorEmployeeId)
            .HasColumnName("SUPERVISOR_EMPLOYEE_ID");

        builder.Property(e => e.SupervisorPhone)
            .HasColumnName("SUPERVISOR_PHONE")
            .HasMaxLength(30);

        builder.Property(e => e.ShiftId)
            .HasColumnName("SHIFT_ID");

        builder.Property(e => e.TripType)
            .HasColumnName("TRIP_TYPE");

        builder.Property(e => e.StartTime)
            .HasColumnName("START_TIME")
            .HasMaxLength(20);

        builder.Property(e => e.EndTime)
            .HasColumnName("END_TIME")
            .HasMaxLength(20);

        builder.Property(e => e.EstimatedDurationMinutes)
            .HasColumnName("ESTIMATED_DURATION_MIN")
            .HasMaxLength(50);

        builder.Property(e => e.StopsJson)
            .HasColumnName("STOPS_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.ServiceStatus)
            .HasColumnName("SERVICE_STATUS");

        builder.Property(e => e.OperatorCompany)
            .HasColumnName("OPERATOR_COMPANY")
            .HasMaxLength(250);

        builder.Property(e => e.ContractId)
            .HasColumnName("CONTRACT_ID");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BusAsset)
            .WithMany()
            .HasForeignKey(e => e.BusAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DriverEmployee)
            .WithMany()
            .HasForeignKey(e => e.DriverEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SupervisorEmployee)
            .WithMany()
            .HasForeignKey(e => e.SupervisorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SchoolMergerConfiguration : IEntityTypeConfiguration<SchoolMerger>
{
    public void Configure(EntityTypeBuilder<SchoolMerger> builder)
    {
        builder.ToTable("SCHOOL_MERGER");

        builder.Property(e => e.MergerNumber)
            .HasColumnName("MERGER_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.MergerDate)
            .HasColumnName("MERGER_DATE");

        builder.Property(e => e.EffectiveDate)
            .HasColumnName("EFFECTIVE_DATE");

        builder.Property(e => e.SourceSchoolIdsJson)
            .HasColumnName("SOURCE_SCHOOL_IDS_JSON");

        builder.Property(e => e.TargetSchoolId)
            .HasColumnName("TARGET_SCHOOL_ID");

        builder.Property(e => e.MergerReason)
            .HasColumnName("MERGER_REASON");

        builder.Property(e => e.DecisionAuthority)
            .HasColumnName("DECISION_AUTHORITY")
            .HasMaxLength(150);

        builder.Property(e => e.DecisionDocumentPath)
            .HasColumnName("DECISION_DOCUMENT_PATH")
            .HasMaxLength(500);

        builder.Property(e => e.StudentsTransferStatus)
            .HasColumnName("STUDENTS_TRANSFER_STATUS");

        builder.Property(e => e.EmployeesTransferStatus)
            .HasColumnName("EMPLOYEES_TRANSFER_STATUS");

        builder.Property(e => e.AssetsTransferStatus)
            .HasColumnName("ASSETS_TRANSFER_STATUS");

        builder.Property(e => e.MergerStatus)
            .HasColumnName("MERGER_STATUS");

        builder.Property(e => e.CompletionDate)
            .HasColumnName("COMPLETION_DATE");

        builder.Property(e => e.CompletionNotes)
            .HasColumnName("COMPLETION_NOTES");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.TargetSchool)
            .WithMany()
            .HasForeignKey(e => e.TargetSchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SchoolAwardConfiguration : IEntityTypeConfiguration<SchoolAward>
{
    public void Configure(EntityTypeBuilder<SchoolAward> builder)
    {
        builder.ToTable("SCHOOL_AWARD");

        builder.Property(e => e.AwardNumber)
            .HasColumnName("AWARD_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.AwardName)
            .HasColumnName("AWARD_NAME")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.AwardCategory)
            .HasColumnName("AWARD_CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.AwardLevel)
            .HasColumnName("AWARD_LEVEL");

        builder.Property(e => e.IssuingBody)
            .HasColumnName("ISSUING_BODY")
            .HasMaxLength(250);

        builder.Property(e => e.IssuingBodyType)
            .HasColumnName("ISSUING_BODY_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.AwardDate)
            .HasColumnName("AWARD_DATE");

        builder.Property(e => e.AwardPlace)
            .HasColumnName("AWARD_PLACE")
            .HasMaxLength(250);

        builder.Property(e => e.Ranking)
            .HasColumnName("RANKING")
            .HasMaxLength(100);

        builder.Property(e => e.ParticipantsJson)
            .HasColumnName("PARTICIPANTS_JSON");

        builder.Property(e => e.StudentParticipantsCount)
            .HasColumnName("STUDENT_PARTICIPANTS_COUNT");

        builder.Property(e => e.TeacherParticipantsCount)
            .HasColumnName("TEACHER_PARTICIPANTS_COUNT");

        builder.Property(e => e.AwardDetails)
            .HasColumnName("AWARD_DETAILS");

        builder.Property(e => e.CertificatePath)
            .HasColumnName("CERTIFICATE_PATH")
            .HasMaxLength(500);

        builder.Property(e => e.PhotosPathJson)
            .HasColumnName("PHOTOS_PATH_JSON");

        builder.Property(e => e.VideoPath)
            .HasColumnName("VIDEO_PATH")
            .HasMaxLength(500);

        builder.Property(e => e.Impact)
            .HasColumnName("IMPACT");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ExternalParticipationConfiguration : IEntityTypeConfiguration<ExternalParticipation>
{
    public void Configure(EntityTypeBuilder<ExternalParticipation> builder)
    {
        builder.ToTable("EXTERNAL_PARTICIPATION");

        builder.Property(e => e.ParticipationNumber)
            .HasColumnName("PARTICIPATION_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.EventName)
            .HasColumnName("EVENT_NAME")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.EventType)
            .HasColumnName("EVENT_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.Organizer)
            .HasColumnName("ORGANIZER")
            .HasMaxLength(250);

        builder.Property(e => e.OrganizerType)
            .HasColumnName("ORGANIZER_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.Location)
            .HasColumnName("LOCATION")
            .HasMaxLength(250);

        builder.Property(e => e.StartDate)
            .HasColumnName("START_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.Results)
            .HasColumnName("RESULTS");

        builder.Property(e => e.Ranking)
            .HasColumnName("RANKING")
            .HasMaxLength(100);

        builder.Property(e => e.ParticipantsJson)
            .HasColumnName("PARTICIPANTS_JSON");

        builder.Property(e => e.StudentParticipantsCount)
            .HasColumnName("STUDENT_PARTICIPANTS_COUNT");

        builder.Property(e => e.TeacherParticipantsCount)
            .HasColumnName("TEACHER_PARTICIPANTS_COUNT");

        builder.Property(e => e.ExpensesJson)
            .HasColumnName("EXPENSES_JSON");

        builder.Property(e => e.FundingSource)
            .HasColumnName("FUNDING_SOURCE")
            .HasMaxLength(250);

        builder.Property(e => e.AttachmentsJson)
            .HasColumnName("ATTACHMENTS_JSON");

        builder.Property(e => e.LessonsLearned)
            .HasColumnName("LESSONS_LEARNED");

        builder.Property(e => e.Recommendations)
            .HasColumnName("RECOMMENDATIONS");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class CommunityPartnershipConfiguration : IEntityTypeConfiguration<CommunityPartnership>
{
    public void Configure(EntityTypeBuilder<CommunityPartnership> builder)
    {
        builder.ToTable("COMMUNITY_PARTNERSHIP");

        builder.Property(e => e.PartnershipNumber)
            .HasColumnName("PARTNERSHIP_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.PartnerName)
            .HasColumnName("PARTNER_NAME")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PartnerType)
            .HasColumnName("PARTNER_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.SupportType)
            .HasColumnName("SUPPORT_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.AgreementDate)
            .HasColumnName("AGREEMENT_DATE");

        builder.Property(e => e.StartDate)
            .HasColumnName("START_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.IsRenewable)
            .HasColumnName("IS_RENEWABLE");

        builder.Property(e => e.AgreementDocumentPath)
            .HasColumnName("AGREEMENT_DOC_PATH")
            .HasMaxLength(500);

        builder.Property(e => e.SupportValueAmount)
            .HasColumnName("SUPPORT_VALUE_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.SupportValueCurrency)
            .HasColumnName("SUPPORT_VALUE_CURRENCY")
            .HasMaxLength(10);

        builder.Property(e => e.SupportInKindJson)
            .HasColumnName("SUPPORT_IN_KIND_JSON");

        builder.Property(e => e.Impact)
            .HasColumnName("IMPACT");

        builder.Property(e => e.ImpactRating)
            .HasColumnName("IMPACT_RATING");

        builder.Property(e => e.ResponsibleEmployeeId)
            .HasColumnName("RESPONSIBLE_EMPLOYEE_ID");

        builder.Property(e => e.PartnerContactPerson)
            .HasColumnName("PARTNER_CONTACT_PERSON")
            .HasMaxLength(150);

        builder.Property(e => e.PartnerContactEmail)
            .HasColumnName("PARTNER_CONTACT_EMAIL")
            .HasMaxLength(150);

        builder.Property(e => e.PartnerContactPhone)
            .HasColumnName("PARTNER_CONTACT_PHONE")
            .HasMaxLength(30);

        builder.Property(e => e.PartnershipStatus)
            .HasColumnName("PARTNERSHIP_STATUS");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ResponsibleEmployee)
            .WithMany()
            .HasForeignKey(e => e.ResponsibleEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SafetySecurityReportConfiguration : IEntityTypeConfiguration<SafetySecurityReport>
{
    public void Configure(EntityTypeBuilder<SafetySecurityReport> builder)
    {
        builder.ToTable("SAFETY_SECURITY_REPORT");

        builder.Property(e => e.ReportNumber)
            .HasColumnName("REPORT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ReportDate)
            .HasColumnName("REPORT_DATE");

        builder.Property(e => e.ReportPeriod)
            .HasColumnName("REPORT_PERIOD")
            .HasMaxLength(50);

        builder.Property(e => e.SafetyLevel)
            .HasColumnName("SAFETY_LEVEL")
            .HasMaxLength(50);

        builder.Property(e => e.ExtinguisherExpiryDate)
            .HasColumnName("EXTINGUISHER_EXPIRY_DATE");

        builder.Property(e => e.ExtinguishersCount)
            .HasColumnName("EXTINGUISHERS_COUNT");

        builder.Property(e => e.ExtinguishersLastInspection)
            .HasColumnName("EXTINGUISHERS_LAST_INSPECTION");

        builder.Property(e => e.ExtinguishersNextInspection)
            .HasColumnName("EXTINGUISHERS_NEXT_INSPECTION");

        builder.Property(e => e.AlarmSystemStatus)
            .HasColumnName("ALARM_SYSTEM_STATUS")
            .HasMaxLength(50);

        builder.Property(e => e.AlarmLastTestDate)
            .HasColumnName("ALARM_LAST_TEST_DATE");

        builder.Property(e => e.HasEvacuationMaps)
            .HasColumnName("HAS_EVACUATION_MAPS");

        builder.Property(e => e.EmergencyExitsStatus)
            .HasColumnName("EMERGENCY_EXITS_STATUS")
            .HasMaxLength(100);

        builder.Property(e => e.DrillCount)
            .HasColumnName("DRILL_COUNT");

        builder.Property(e => e.DrillDatesJson)
            .HasColumnName("DRILL_DATES_JSON");

        builder.Property(e => e.DrillAverageTimeMinutes)
            .HasColumnName("DRILL_AVG_TIME_MIN");

        builder.Property(e => e.DrillEvaluation)
            .HasColumnName("DRILL_EVALUATION");

        builder.Property(e => e.SafetyCommitteeFormed)
            .HasColumnName("SAFETY_COMMITTEE_FORMED");

        builder.Property(e => e.SafetyCommitteeMembersJson)
            .HasColumnName("SAFETY_COMMITTEE_MEMBERS_JSON");

        builder.Property(e => e.SafetyTrainingHours)
            .HasColumnName("SAFETY_TRAINING_HOURS");

        builder.Property(e => e.IncidentsCount)
            .HasColumnName("INCIDENTS_COUNT");

        builder.Property(e => e.Recommendations)
            .HasColumnName("RECOMMENDATIONS");

        builder.Property(e => e.ActionPlan)
            .HasColumnName("ACTION_PLAN");

        builder.Property(e => e.AttachmentsJson)
            .HasColumnName("ATTACHMENTS_JSON");

        builder.Property(e => e.ApprovedByUserId)
            .HasColumnName("APPROVED_BY_USER_ID");

        builder.Property(e => e.ApprovalDate)
            .HasColumnName("APPROVAL_DATE");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SchoolDeficitConfiguration : IEntityTypeConfiguration<SchoolDeficit>
{
    public void Configure(EntityTypeBuilder<SchoolDeficit> builder)
    {
        builder.ToTable("SCHOOL_DEFICIT");

        builder.Property(e => e.DeficitNumber)
            .HasColumnName("DEFICIT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DeficitType)
            .HasColumnName("DEFICIT_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DeficitCategory)
            .HasColumnName("DEFICIT_CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.DeficitAmount)
            .HasColumnName("DEFICIT_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.RequiredAmount)
            .HasColumnName("REQUIRED_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.AvailableAmount)
            .HasColumnName("AVAILABLE_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.DeficitDescription)
            .HasColumnName("DEFICIT_DESCRIPTION");

        builder.Property(e => e.EducationalImpact)
            .HasColumnName("EDUCATIONAL_IMPACT");

        builder.Property(e => e.ImpactLevel)
            .HasColumnName("IMPACT_LEVEL");

        builder.Property(e => e.DetectionDate)
            .HasColumnName("DETECTION_DATE");

        builder.Property(e => e.DetectedByUserId)
            .HasColumnName("DETECTED_BY_USER_ID");

        builder.Property(e => e.DeficitStatus)
            .HasColumnName("DEFICIT_STATUS");

        builder.Property(e => e.StatusUpdateDate)
            .HasColumnName("STATUS_UPDATE_DATE");

        builder.Property(e => e.ProposedSolution)
            .HasColumnName("PROPOSED_SOLUTION");

        builder.Property(e => e.EstimatedResolutionCost)
            .HasColumnName("ESTIMATED_RESOLUTION_COST")
            .HasPrecision(19, 4);

        builder.Property(e => e.EstimatedResolutionDate)
            .HasColumnName("ESTIMATED_RESOLUTION_DATE");

        builder.Property(e => e.ActualResolutionDate)
            .HasColumnName("ACTUAL_RESOLUTION_DATE");

        builder.Property(e => e.ResolvedByUserId)
            .HasColumnName("RESOLVED_BY_USER_ID");

        builder.Property(e => e.ResolutionNotes)
            .HasColumnName("RESOLUTION_NOTES");

        builder.Property(e => e.RelatedRemediationPlanId)
            .HasColumnName("RELATED_PLAN_ID");

        builder.Property(e => e.AttachmentsJson)
            .HasColumnName("ATTACHMENTS_JSON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SchoolSurplusConfiguration : IEntityTypeConfiguration<SchoolSurplus>
{
    public void Configure(EntityTypeBuilder<SchoolSurplus> builder)
    {
        builder.ToTable("SCHOOL_SURPLUS");

        builder.Property(e => e.SurplusNumber)
            .HasColumnName("SURPLUS_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.SurplusType)
            .HasColumnName("SURPLUS_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.SurplusCategory)
            .HasColumnName("SURPLUS_CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.SurplusAmount)
            .HasColumnName("SURPLUS_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.AvailableAmount)
            .HasColumnName("AVAILABLE_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.RequiredAmount)
            .HasColumnName("REQUIRED_AMOUNT")
            .HasPrecision(19, 4);

        builder.Property(e => e.SurplusDescription)
            .HasColumnName("SURPLUS_DESCRIPTION");

        builder.Property(e => e.UtilizationPlan)
            .HasColumnName("UTILIZATION_PLAN");

        builder.Property(e => e.UtilizationType)
            .HasColumnName("UTILIZATION_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.PotentialBeneficiary)
            .HasColumnName("POTENTIAL_BENEFICIARY")
            .HasMaxLength(250);

        builder.Property(e => e.DiscoveryDate)
            .HasColumnName("DISCOVERY_DATE");

        builder.Property(e => e.DiscoveredByUserId)
            .HasColumnName("DISCOVERED_BY_USER_ID");

        builder.Property(e => e.SurplusStatus)
            .HasColumnName("SURPLUS_STATUS");

        builder.Property(e => e.StatusUpdateDate)
            .HasColumnName("STATUS_UPDATE_DATE");

        builder.Property(e => e.UtilizationDate)
            .HasColumnName("UTILIZATION_DATE");

        builder.Property(e => e.ActualUtilizationDate)
            .HasColumnName("ACTUAL_UTILIZATION_DATE");

        builder.Property(e => e.UtilizedByUserId)
            .HasColumnName("UTILIZED_BY_USER_ID");

        builder.Property(e => e.UtilizationNotes)
            .HasColumnName("UTILIZATION_NOTES");

        builder.Property(e => e.RelatedRemediationPlanId)
            .HasColumnName("RELATED_PLAN_ID");

        builder.Property(e => e.AttachmentsJson)
            .HasColumnName("ATTACHMENTS_JSON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RemediationPlanConfiguration : IEntityTypeConfiguration<RemediationPlan>
{
    public void Configure(EntityTypeBuilder<RemediationPlan> builder)
    {
        builder.ToTable("REMEDIATION_PLAN");

        builder.Property(e => e.PlanNumber)
            .HasColumnName("PLAN_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.PlanName)
            .HasColumnName("PLAN_NAME")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.RelatedDeficitId)
            .HasColumnName("RELATED_DEFICIT_ID");

        builder.Property(e => e.RelatedSurplusId)
            .HasColumnName("RELATED_SURPLUS_ID");

        builder.Property(e => e.PlanType)
            .HasColumnName("PLAN_TYPE");

        builder.Property(e => e.SelectedOption)
            .HasColumnName("SELECTED_OPTION")
            .HasMaxLength(100);

        builder.Property(e => e.OptionDetails)
            .HasColumnName("OPTION_DETAILS");

        builder.Property(e => e.Objectives)
            .HasColumnName("OBJECTIVES");

        builder.Property(e => e.ActionStepsJson)
            .HasColumnName("ACTION_STEPS_JSON");

        builder.Property(e => e.PlannedStartDate)
            .HasColumnName("PLANNED_START_DATE");

        builder.Property(e => e.PlannedEndDate)
            .HasColumnName("PLANNED_END_DATE");

        builder.Property(e => e.ActualStartDate)
            .HasColumnName("ACTUAL_START_DATE");

        builder.Property(e => e.ActualEndDate)
            .HasColumnName("ACTUAL_END_DATE");

        builder.Property(e => e.EstimatedBudget)
            .HasColumnName("ESTIMATED_BUDGET")
            .HasPrecision(19, 4);

        builder.Property(e => e.ActualCost)
            .HasColumnName("ACTUAL_COST")
            .HasPrecision(19, 4);

        builder.Property(e => e.Currency)
            .HasColumnName("CURRENCY")
            .HasMaxLength(10);

        builder.Property(e => e.ExecutionLeadEmployeeId)
            .HasColumnName("EXECUTION_LEAD_EMP_ID");

        builder.Property(e => e.ExecutionTeamJson)
            .HasColumnName("EXECUTION_TEAM_JSON");

        builder.Property(e => e.ProgressPercentage)
            .HasColumnName("PROGRESS_PERCENTAGE")
            .HasPrecision(19, 4);

        builder.Property(e => e.PlanStatus)
            .HasColumnName("PLAN_STATUS");

        builder.Property(e => e.ApprovalDate)
            .HasColumnName("APPROVAL_DATE");

        builder.Property(e => e.ApprovedByUserId)
            .HasColumnName("APPROVED_BY_USER_ID");

        builder.Property(e => e.CompletionReport)
            .HasColumnName("COMPLETION_REPORT");

        builder.Property(e => e.LessonsLearned)
            .HasColumnName("LESSONS_LEARNED");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SchoolDeficit)
            .WithMany()
            .HasForeignKey(e => e.RelatedDeficitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SchoolSurplus)
            .WithMany()
            .HasForeignKey(e => e.RelatedSurplusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ExecutionLeadEmployee)
            .WithMany()
            .HasForeignKey(e => e.ExecutionLeadEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
