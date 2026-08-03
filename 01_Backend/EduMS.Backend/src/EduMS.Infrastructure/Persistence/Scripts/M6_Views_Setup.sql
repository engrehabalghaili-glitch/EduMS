-- =====================================================================================
-- EduMS - M6 (Statistics & Reports) Oracle 19c Views and Materialized Views Setup
-- =====================================================================================

-- 1. Standard View: Gap Analysis
CREATE OR REPLACE VIEW gap_analysis_report_view AS
SELECT 
    1 AS "Id",
    s."SCHOOL_ID" AS "SchoolId",
    'GAP-' || s."SCHOOL_ID" || '-' || TO_CHAR(SYSDATE, 'YYYYMMDD') AS "AnalysisNumber",
    'Students-Teachers' AS "AnalysisType",
    NULL AS "AssetCategoryId",
    NULL AS "GradeCapacityId",
    NULL AS "DepartmentId",
    (SELECT COUNT(*) FROM "student_enrollment" se WHERE se."SchoolId" = s."SCHOOL_ID" AND se."IsDeleted" = 0) / 25 AS "RequiredQuantity",
    (SELECT COUNT(*) FROM "employee" e WHERE e."SCHOOL_ID" = s."SCHOOL_ID" AND e."EmploymentStatus" = 1) AS "AvailableQuantity",
    0 AS "GapValue",
    0 AS "GapPercentage",
    'Match' AS "GapType",
    'Review Required' AS "Recommendation",
    2 AS "Priority",
    0 AS "EstimatedCost",
    SYSDATE AS "AnalysisDate",
    NULL AS "AnalyzedByUserId",
    NULL AS "FilePath",
    1 AS "AnalysisStatus",
    NULL AS "ApprovedByUserId",
    NULL AS "ApprovalDate",
    'Generated automatically via Oracle View' AS "Notes",
    SYSDATE AS "CreatedAt",
    NULL AS "CreatedByUserId",
    NULL AS "ModifiedAt",
    NULL AS "ModifiedByUserId",
    0 AS "IsDeleted",
    NULL AS "DeletedAt",
    NULL AS "DeletedByUserId",
    RAWTOHEX(SYS_GUID()) AS "VersionToken",
    0 AS "SyncStatus"
FROM "school" s
WHERE s."IS_DELETED" = 0;

-- 2. Standard View: Financial Summary
CREATE OR REPLACE VIEW school_financial_summary_report_view AS
SELECT 
    s."SCHOOL_ID" AS "Id",
    s."SCHOOL_ID" AS "SchoolId",
    TO_CHAR(SYSDATE, 'YYYY') AS "FiscalYear",
    SYSDATE AS "ReportDate",
    1 AS "ReportType",
    0 AS "TotalBookValue",
    0 AS "TotalDepreciation",
    0 AS "TotalAssetsCount",
    0 AS "TotalAcquisitionCost",
    0 AS "TotalRevaluationGains",
    0 AS "TotalImpairmentLosses",
    0 AS "TotalRevenue",
    0 AS "TotalExpenses",
    0 AS "NetIncome",
    'Pending' AS "AuditStatus",
    NULL AS "AuditFirmName",
    NULL AS "AuditDate",
    1 AS "ApprovalStatus",
    NULL AS "ApprovedByUserId",
    NULL AS "ApprovalDate",
    NULL AS "FilePath",
    'Generated automatically via Oracle View' AS "Notes",
    SYSDATE AS "CreatedAt",
    NULL AS "CreatedByUserId",
    NULL AS "ModifiedAt",
    NULL AS "ModifiedByUserId",
    0 AS "IsDeleted",
    NULL AS "DeletedAt",
    NULL AS "DeletedByUserId",
    RAWTOHEX(SYS_GUID()) AS "VersionToken",
    0 AS "SyncStatus"
FROM "school" s
WHERE s."IS_DELETED" = 0;

-- =====================================================================================
-- DIRECTORATE LEVEL: MATERIALIZED VIEWS
-- =====================================================================================

-- 3. Materialized View: Directorate School Stats
CREATE MATERIALIZED VIEW directorate_school_stats_mv
BUILD IMMEDIATE
REFRESH COMPLETE ON DEMAND
AS
SELECT
    d."Id" AS "DirectorateId",
    COUNT(DISTINCT s."SCHOOL_ID") AS "TotalSchools",
    COUNT(DISTINCT se."Id") AS "TotalStudents",
    COUNT(DISTINCT e."PERSON_ID") AS "TotalEmployees",
    0 AS "TotalTeachers",
    0 AS "DropoutRate",
    0 AS "AvgPassRate",
    0 AS "AvgAttendanceRate",
    0 AS "OvercrowdedSchoolsCount",
    0 AS "StaffShortageSchoolsCount",
    SYSDATE AS "MaterializedViewLastRefresh"
FROM "directorate" d
LEFT JOIN "school" s ON s."DirectorateId" = d."Id" AND s."IS_DELETED" = 0
LEFT JOIN "student_enrollment" se ON se."SchoolId" = s."SCHOOL_ID" AND se."IsDeleted" = 0
LEFT JOIN "employee" e ON e."SCHOOL_ID" = s."SCHOOL_ID"
WHERE d."IsDeleted" = 0
GROUP BY d."Id";

-- =====================================================================================
-- JOB: REFRESH MATERIALIZED VIEWS (Runs Nightly)
-- =====================================================================================
BEGIN
    DBMS_SCHEDULER.CREATE_JOB (
       job_name        => 'REFRESH_M6_MATERIALIZED_VIEWS',
       job_type        => 'PLSQL_BLOCK',
       job_action      => 'BEGIN DBMS_MVIEW.REFRESH(''directorate_school_stats_mv'',''C''); END;',
       start_date      => SYSTIMESTAMP,
       repeat_interval => 'FREQ=DAILY; BYHOUR=2; BYMINUTE=0; BYSECOND=0',
       enabled         => TRUE,
       comments        => 'Nightly refresh of M6 Statistics Materialized Views'
    );
END;
/

EXIT;
