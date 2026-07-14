using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Unified_EduMS_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCESS_POLICY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    POLICY_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    POLICY_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    POLICY_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    POLICY_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    POLICY_RULE_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    POLICY_EFFECT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRIORITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    APPLIES_TO_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    APPLIES_TO_IDS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    VALID_FROM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCESS_POLICY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ParentCategoryId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CategoryCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CategoryNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CategoryNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CategoryLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FullHierarchyPath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DefaultDepreciationRate = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DefaultDepreciationMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DefaultUsefulLifeYears = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsSystemCategory = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SortOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCategory_AssetCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "AssetCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssetLocationRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ParentLocationId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LocationCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LocationNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LocationNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LocationType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BuildingName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FloorNumber = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    RoomNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ResponsiblePersonId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    MapReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QrCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLocationRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLocationRecord_AssetLocationRecord_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalTable: "AssetLocationRecord",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BEHAVIOR_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    PERMISSION_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PERMISSION_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    IS_CONFIDENTIAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_SOCIAL_WORKER_ROLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALLOWED_ROLES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEHAVIOR_PERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CM_AUDITABLE_ENTITY_REGISTRY",
                columns: table => new
                {
                    REGISTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ENTITY_TYPE_KEY = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    SOURCE_MODULE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    TABLE_NAME_HINT = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    ENTITY_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    ENTITY_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    IS_SENSITIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_APPROVAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_AUDITABLE_ENTITY_REGISTRY", x => x.REGISTRY_ID);
                });

            migrationBuilder.CreateTable(
                name: "DASHBOARD_KPI_CONFIG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    KPI_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    KPI_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    KPI_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    KpiDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SOURCE_MODULE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SourceTable = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SourceField = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AggregationMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ChartType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RefreshIntervalMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TARGET_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    THRESHOLD_GREEN = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    THRESHOLD_YELLOW = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    THRESHOLD_RED = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    AlertEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AlertRecipientsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DashboardId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DASHBOARD_KPI_CONFIG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directorate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DirectorateCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DirectorateNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DirectorateNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ContactPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ContactEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DirectorName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Governorate = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RegionCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SupervisoryScopeDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnnualBudgetLimit = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalStage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StageCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StageNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StageNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MinAge = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaxAge = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DefaultDurationYears = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MinistryCurriculumCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RequiresGraduationCertificate = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalStage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OFFICE_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    OfficeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    PERMISSION_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PERMISSION_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    SCOPE_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    SCOPE_TARGET_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CAN_OVERRIDE_SCHOOL_DECISION = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_READ_ONLY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALLOWED_ROLES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFICE_PERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PAYROLL_RUN",
                columns: table => new
                {
                    PAYROLL_RUN_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RUN_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    MONTH = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    YEAR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PROCESS_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYROLL_RUN", x => x.PAYROLL_RUN_ID);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSION_BASE_MODULE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MODULE_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MODULE_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    MODULE_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    SECTION_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    SECTION_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    SECTION_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DEFAULT_PERMISSIONS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SORT_ORDER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION_BASE_MODULE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSION_TYPE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TYPE_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TYPE_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    TYPE_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    SCOPE_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    RISK_LEVEL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    REQUIRES_APPROVAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    APPROVAL_LEVEL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    DESCRIPTION_AR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_SYSTEM = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SORT_ORDER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    PERSON_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FULL_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    FULL_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    NATIONAL_ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    GENDER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CONTACT_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    MEDICAL_INFO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NationalityCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmailAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BloodGroup = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ResidentialAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PassportNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActivePerson = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.PERSON_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRIVILEGE_RULE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RULE_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    RULE_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    RULE_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    RULE_CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    APPLIES_TO_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CONDITION_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TRIGGER_ACTION = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ACTION_PARAMETERS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PRIORITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIVILEGE_RULE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_MATRIX",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ROLE_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ROLE_NAME_AR = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    ROLE_NAME_EN = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    ROLE_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PERMISSIONS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DESCRIPTION_AR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SORT_ORDER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_MATRIX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STATISTICS_UPDATE_HISTORY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StatisticsDraftId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SubmittedStatisticsId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CHANGE_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ChangeCategory = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OldValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NewValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdateReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SupportingDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ChangedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsApproved = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATISTICS_UPDATE_HISTORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_ACADEMIC_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    PERMISSION_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PERMISSION_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    IS_TIME_BOUND = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALLOWED_WINDOW_DAYS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    REQUIRES_LOCK_OVERRIDE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_SUPERVISOR_APPROVAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALLOWED_ROLES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_ACADEMIC_PERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_BASE_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    PERMISSION_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PERMISSION_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    REQUIRES_PRINCIPAL_APPROVAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_GUARDIAN_CONSENT = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_SENSITIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALLOWED_ROLES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_BASE_PERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_FINANCE_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    PERMISSION_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PERMISSION_NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    MAX_AMOUNT_LIMIT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    MAX_DISCOUNT_PCT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    REQUIRES_DIRECTOR_APPROVAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_BOARD_APPROVAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALLOWED_ROLES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_FINANCE_PERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_PERM_AUDIT_LOG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    USER_ROLE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    ENTITY_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ENTITY_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ACTION_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ACCESS_CONTEXT_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    WAS_ALLOWED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REJECTION_REASON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RISK_SCORE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    ACTION_TIMESTAMP = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_PERM_AUDIT_LOG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_ROLE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ROLE_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ROLE_NAME_AR = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    ROLE_NAME_EN = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    ROLE_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HIERARCHY_LEVEL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PARENT_ROLE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_INHERITABLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_ASSIGNABLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_SYSTEM = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DESCRIPTION_AR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_ROLE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SYSTEM_ROLE_SYSTEM_ROLE_PARENT_ROLE_ID",
                        column: x => x.PARENT_ROLE_ID,
                        principalTable: "SYSTEM_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TREND_ANALYSIS_RESULT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDY_PERIOD = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    StartYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EndYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    KpiCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HistoricalValuesJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TrendDirection = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SLOPE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    CORRELATION_COEFFICIENT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    FORECASTED_VALUE_NEXT_1_YEAR = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    FORECASTED_VALUE_NEXT_2_YEAR = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    CONFIDENCE_LEVEL = table.Column<decimal>(type: "DECIMAL(18,4)", precision: 18, scale: 4, nullable: true),
                    LOWER_BOUND = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    UPPER_BOUND = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    ForecastingMethod = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnalysisDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AnalyzedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AnalysisStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TREND_ANALYSIS_RESULT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VENDOR",
                columns: table => new
                {
                    VENDOR_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VENDOR_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TAX_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    CONTACT_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CONTACT_EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CONTACT_PHONE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDOR", x => x.VENDOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE",
                columns: table => new
                {
                    WAREHOUSE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    WAREHOUSE_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    OWNER_TYPE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    OWNER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LOCATION_ADDRESS = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSE", x => x.WAREHOUSE_ID);
                });

            migrationBuilder.CreateTable(
                name: "KPI_METRIC_RECORD",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    KpiConfigId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PeriodType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodValue = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ACTUAL_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TARGET_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    PREVIOUS_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: true),
                    CHANGE_PERCENTAGE = table.Column<decimal>(type: "DECIMAL(18,4)", precision: 18, scale: 4, nullable: false),
                    StatusColor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CalculationMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CalculationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CalculatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsVerified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    VerifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPI_METRIC_RECORD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KPI_METRIC_RECORD_DASHBOARD_KPI_CONFIG_KpiConfigId",
                        column: x => x.KpiConfigId,
                        principalTable: "DASHBOARD_KPI_CONFIG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EducationalStageId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SCHOOL_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    SCHOOL_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    SCHOOL_CODE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DIRECTORATE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    GOVERNORATE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ContactPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ContactEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PostalAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TaxRegistrationNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CommercialLicenseNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MaxStudentCapacity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsAccredited = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL", x => x.SCHOOL_ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SCHOOL_EducationalStage_EducationalStageId",
                        column: x => x.EducationalStageId,
                        principalTable: "EducationalStage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    MODULE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SUB_MODULE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ACTION_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    PERMISSION_TYPE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DEFAULT_SCOPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    NAME_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    DESCRIPTION_AR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RISK_LEVEL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    IS_SENSITIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_LOGGING = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CONDITIONS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_PERMISSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SYSTEM_PERMISSION_PERMISSION_TYPE_PERMISSION_TYPE_ID",
                        column: x => x.PERMISSION_TYPE_ID,
                        principalTable: "PERMISSION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUARDIAN",
                columns: table => new
                {
                    PERSON_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FAMILY_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    RELATIONSHIP_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    JOB_TITLE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    EmployerName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    WorkPhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmergencyContactPriority = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsAuthorizedPickup = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnnualIncomeRange = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUARDIAN", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "FK_GUARDIAN_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSON",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BEHAVIOR_PERMISSION_MATRIX",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RoleId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    BEHAVIOR_LEVEL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CAN_RECORD = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CAN_INVESTIGATE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CAN_DECIDE_PENALTY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CAN_EXECUTE_PENALTY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CAN_WAIVE_PENALTY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_COMMITTEE_DECISION = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEHAVIOR_PERMISSION_MATRIX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BEHAVIOR_PERMISSION_MATRIX_SYSTEM_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SYSTEM_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BEHAVIOR_PERMISSION_RECORD",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RoleId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SUB_CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    PERMISSION_KEY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    ALLOWED_ACTIONS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SCOPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    IS_SENSITIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REQUIRES_JUSTIFICATION = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    JUSTIFICATION_APPROVAL_REQ = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DESCRIPTION_AR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEHAVIOR_PERMISSION_RECORD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BEHAVIOR_PERMISSION_RECORD_SYSTEM_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SYSTEM_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GOVERNANCE_RBAC_RULE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TargetRoleId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TargetPermissionId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ALLOWED_ACTION = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CAN_DELEGATE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    APPROVAL_REQUIRED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    APPROVAL_ROLE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOVERNANCE_RBAC_RULE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GOVERNANCE_RBAC_RULE_SYSTEM_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SYSTEM_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicWarningPolicy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PolicyCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PolicyTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    WarningCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ThresholdValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ActionRequired = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PolicyTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConsecutiveOccurrenceLimit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AutoTriggerNotification = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EscalationPolicyId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicWarningPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicWarningPolicy_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ACCOUNT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ACCOUNT_CODE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ACCOUNT_NAME_AR = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ACCOUNT_NAME_EN = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PARENT_ACCOUNT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ACCOUNT_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LEVEL_NUMBER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CURRENT_BALANCE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ACCOUNT_ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_ACCOUNT_PARENT_ACCOUNT_ID",
                        column: x => x.PARENT_ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ACCOUNT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "AssetWarrantyContract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ContractType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ContractNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ContractName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProviderName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProviderContact = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CoverageDetailsText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ContractValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    HasRenewalOption = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RenewalTerms = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ContractStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReminderDaysBeforeExpiry = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsAlertEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LastAlertSentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetWarrantyContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetWarrantyContract_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPARATIVE_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REPORT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    COMPARISON_TITLE = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    FirstPeriodLabel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FirstPeriodStart = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FirstPeriodEnd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SecondPeriodLabel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SecondPeriodStart = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SecondPeriodEnd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ComparisonType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    KpiComparedJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ComparisonDataJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AutoInsights = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Summary = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GenerationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GeneratedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FileFormat = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ViewCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastViewedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ReportStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPARATIVE_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMPARATIVE_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMERGENCY_CLOSURE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CLOSURE_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CLOSURE_REASON = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DECISION_AUTHORITY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    AUTHORITY_DECISION_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ACTUAL_END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TOTAL_CLOSURE_DAYS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SCHOOL_DAYS_AFFECTED = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ALT_EDU_ACTIVATED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ALT_EDU_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ALT_EDU_PLATFORM = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ALT_EDU_DETAILS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    WAS_COMPENSATED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    COMPENSATION_PLAN_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PARENT_NOTIFICATION_SENT = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PARENT_NOTIFICATION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PARENT_NOTIFICATION_METHOD = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    CLOSURE_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMERGENCY_CLOSURE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_CLOSURE_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMERGENCY_PLAN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PLAN_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PLAN_TITLE_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PLAN_TITLE_EN = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    EVACUATION_PROCEDURE_SUMMARY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NEXT_SCHEDULED_DRILL_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMERGENCY_PLAN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_PLAN_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_PLAN_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EXCEPTIONAL_STATISTICS_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    REPORT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TotalIncidents = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalClosureDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TOTAL_DAMAGE_COST = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TotalAwardsCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalParticipationsCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalDeficitCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalSurplusCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmergencySummaryJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClosureSummaryJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AwardSummaryJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GenerationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GeneratedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReportStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXCEPTIONAL_STATISTICS_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXCEPTIONAL_STATISTICS_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXTERNAL_COMPLIANCE_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REPORT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TARGET_ENTITY_NAME = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    EntityType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StandardType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReportType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodStart = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PeriodEnd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GenerationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GeneratedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SubmissionMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReceiptReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SubmissionStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsFinal = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FinalApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXTERNAL_COMPLIANCE_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXTERNAL_COMPLIANCE_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXTERNAL_PARTICIPATION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PARTICIPATION_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EVENT_NAME = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    EVENT_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ORGANIZER = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    ORGANIZER_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    LOCATION = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RESULTS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RANKING = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    PARTICIPANTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STUDENT_PARTICIPANTS_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TEACHER_PARTICIPANTS_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EXPENSES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FUNDING_SOURCE = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    ATTACHMENTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LESSONS_LEARNED = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RECOMMENDATIONS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXTERNAL_PARTICIPATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXTERNAL_PARTICIPATION_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeeStructure",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FeeCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FeeNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FeeNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GradeLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    AcademicYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeStructure_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GAP_ANALYSIS_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ANALYSIS_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AnalysisType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssetCategoryId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GradeCapacityId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DepartmentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GAP_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    GAP_PERCENTAGE = table.Column<decimal>(type: "DECIMAL(18,4)", precision: 18, scale: 4, nullable: false),
                    GapType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Recommendation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Priority = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ESTIMATED_COST = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    AnalysisDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AnalyzedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnalysisStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GAP_ANALYSIS_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GAP_ANALYSIS_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradingScaleBound",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ScaleName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LetterCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MinPercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    MaxPercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    GradePointValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ScaleCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsPassingGrade = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingScaleBound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradingScaleBound_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JOURNAL_ENTRY",
                columns: table => new
                {
                    JOURNAL_ENTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ENTRY_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ENTRY_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOURNAL_ENTRY", x => x.JOURNAL_ENTRY_ID);
                    table.ForeignKey(
                        name: "FK_JOURNAL_ENTRY_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PoNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PoDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RequirementRequestId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SupplierName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SupplierContact = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PaymentTerms = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DeliveryDeadline = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PoStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BudgetAllocationId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_AWARD",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AWARD_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AWARD_NAME = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    AWARD_CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    AWARD_LEVEL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ISSUING_BODY = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    ISSUING_BODY_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    AWARD_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AWARD_PLACE = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    RANKING = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    PARTICIPANTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STUDENT_PARTICIPANTS_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TEACHER_PARTICIPANTS_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AWARD_DETAILS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CERTIFICATE_PATH = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    PHOTOS_PATH_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VIDEO_PATH = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    IMPACT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_AWARD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHOOL_AWARD_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_DEFICIT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DEFICIT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DEFICIT_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DEFICIT_CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    DEFICIT_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    REQUIRED_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    AVAILABLE_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    DEFICIT_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EDUCATIONAL_IMPACT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IMPACT_LEVEL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DETECTION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DETECTED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DEFICIT_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    STATUS_UPDATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PROPOSED_SOLUTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ESTIMATED_RESOLUTION_COST = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    ESTIMATED_RESOLUTION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ACTUAL_RESOLUTION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RESOLVED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RESOLUTION_NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RELATED_PLAN_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ATTACHMENTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_DEFICIT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHOOL_DEFICIT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_FINANCIAL_SUMMARY_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FISCAL_YEAR = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ReportDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReportType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TOTAL_BOOK_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_DEPRECIATION = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TotalAssetsCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TOTAL_ACQUISITION_COST = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_REVALUATION_GAINS = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_IMPAIRMENT_LOSSES = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_REVENUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_EXPENSES = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NET_INCOME = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    AuditStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AuditFirmName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_FINANCIAL_SUMMARY_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHOOL_FINANCIAL_SUMMARY_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_MERGER",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MERGER_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    MERGER_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SOURCE_SCHOOL_IDS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TARGET_SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MERGER_REASON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DECISION_AUTHORITY = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    DECISION_DOCUMENT_PATH = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    STUDENTS_TRANSFER_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EMPLOYEES_TRANSFER_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ASSETS_TRANSFER_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MERGER_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    COMPLETION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    COMPLETION_NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_MERGER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHOOL_MERGER_SCHOOL_TARGET_SCHOOL_ID",
                        column: x => x.TARGET_SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_STATISTICS_DRAFT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolSemesterId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PeriodType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodValue = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DRAFT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DraftVersion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StudentDataJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StaffDataJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FinancialSummaryJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AssetSummaryJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    COMPLETENESS_PERCENTAGE = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    DraftStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsLocked = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LockedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LastSavedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SavedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_STATISTICS_DRAFT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHOOL_STATISTICS_DRAFT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_SURPLUS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SURPLUS_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SURPLUS_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SURPLUS_CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    SURPLUS_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    AVAILABLE_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    REQUIRED_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    SURPLUS_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UTILIZATION_PLAN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UTILIZATION_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    POTENTIAL_BENEFICIARY = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    DISCOVERY_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DISCOVERED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SURPLUS_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    STATUS_UPDATE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UTILIZATION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ACTUAL_UTILIZATION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UTILIZED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    UTILIZATION_NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RELATED_PLAN_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ATTACHMENTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_SURPLUS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SCHOOL_SURPLUS_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAccreditationLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AccreditationBody = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LicenseType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AccreditationGrade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CertificateAttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RenewalSubmittedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAccreditationLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAccreditationLog_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolOperationalBudgetLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FiscalYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BudgetCategoryCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CategoryNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AllocatedAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ConsumedAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CategoryNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QuarterNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByDirectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LastTransactionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NotesDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolOperationalBudgetLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolOperationalBudgetLog_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolOperationalBudgetLog_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "SchoolShift",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ShiftNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ShiftNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StartTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EndTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ShiftCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalPeriodsCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodDurationMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BreakDurationMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolShift_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STATISTICS_REPORTS_ARCHIVE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SOURCE_REPORT_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SourceReportId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ArchivedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RetentionPeriodYears = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RetentionEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FileSizeBytes = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DisposalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DisposalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DisposalMethod = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATISTICS_REPORTS_ARCHIVE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STATISTICS_REPORTS_ARCHIVE_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubjectCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SubjectNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SubjectNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Specialization = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    WeeklyHours = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GradeLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TextbookTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalMarks = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PassingMarks = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CreditHours = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IsCoreSubject = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REPORT_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ReportSubType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    REPORT_TITLE = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    ReportFrequency = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodStart = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PeriodEnd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GenerationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GenerationMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GeneratedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FileFormat = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FileSizeBytes = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ReportStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsPublished = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PublishedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ViewCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastViewedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SYSTEM_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCourseOffering",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CourseCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CourseTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TrainerName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TotalHours = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaxParticipants = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CostPerParticipant = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CourseTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TrainingLocation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TargetSpecialization = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EnrolledParticipantsCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CertificateTemplateUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourseOffering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCourseOffering_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCourseOffering_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "ROLE_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PermissionId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCOPE_OVERRIDE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    IS_INHERITED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    INHERITED_FROM_ROLE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    GRANTED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GRANTED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSION_SYSTEM_PERMISSION_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "SYSTEM_PERMISSION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSION_SYSTEM_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SYSTEM_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT_VOUCHER",
                columns: table => new
                {
                    PAYMENT_VOUCHER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    VendorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VOUCHER_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    VOUCHER_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    PAYMENT_METHOD = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    ACCOUNT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_VOUCHER", x => x.PAYMENT_VOUCHER_ID);
                    table.ForeignKey(
                        name: "FK_PAYMENT_VOUCHER_ACCOUNT_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ACCOUNT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PAYMENT_VOUCHER_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAYMENT_VOUCHER_VENDOR_VendorId",
                        column: x => x.VendorId,
                        principalTable: "VENDOR",
                        principalColumn: "VENDOR_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_KPI_FINANCIAL_PERIOD",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    KPI_METRIC_RECORD_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PAYROLL_RUN_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JOURNAL_ENTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERIOD_LABEL = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    KpiMetricRecordId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PayrollRunId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JournalEntryId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_KPI_FINANCIAL_PERIOD", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_JOURNAL_ENTRY_JOURNAL_ENTRY_ID",
                        column: x => x.JOURNAL_ENTRY_ID,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID");
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_JOURNAL_ENTRY_JournalEntryId1",
                        column: x => x.JournalEntryId1,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID");
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_KPI_METRIC_RECORD_KPI_METRIC_RECORD_ID",
                        column: x => x.KPI_METRIC_RECORD_ID,
                        principalTable: "KPI_METRIC_RECORD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_KPI_METRIC_RECORD_KpiMetricRecordId1",
                        column: x => x.KpiMetricRecordId1,
                        principalTable: "KPI_METRIC_RECORD",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_PAYROLL_RUN_PAYROLL_RUN_ID",
                        column: x => x.PAYROLL_RUN_ID,
                        principalTable: "PAYROLL_RUN",
                        principalColumn: "PAYROLL_RUN_ID");
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_PAYROLL_RUN_PayrollRunId1",
                        column: x => x.PayrollRunId1,
                        principalTable: "PAYROLL_RUN",
                        principalColumn: "PAYROLL_RUN_ID");
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_KPI_FINANCIAL_PERIOD_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "JOURNAL_ENTRY_LINE",
                columns: table => new
                {
                    ENTRY_LINE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    JOURNAL_ENTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ACCOUNT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DEBIT_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    CREDIT_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOURNAL_ENTRY_LINE", x => x.ENTRY_LINE_ID);
                    table.ForeignKey(
                        name: "FK_JOURNAL_ENTRY_LINE_ACCOUNT_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ACCOUNT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JOURNAL_ENTRY_LINE_JOURNAL_ENTRY_JOURNAL_ENTRY_ID",
                        column: x => x.JOURNAL_ENTRY_ID,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUBMITTED_STATISTICS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StatisticsDraftId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SUBMISSION_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SubmissionTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SubmissionMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubmittedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DirectorSignatureHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DirectorSignatureDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    StudentDataSnapshotJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StaffDataSnapshotJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FinancialSummarySnapshotJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReviewerNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ReviewedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsFinal = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsArchived = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBMITTED_STATISTICS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUBMITTED_STATISTICS_SCHOOL_STATISTICS_DRAFT_StatisticsDraftId",
                        column: x => x.StatisticsDraftId,
                        principalTable: "SCHOOL_STATISTICS_DRAFT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumTextbookDistribution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TextbookCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TextbookTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TextbookTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EditionYear = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuantityAllocated = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuantityDistributed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DistributionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TargetGradeLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UnitCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalValueAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    WarehouseLocationCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumTextbookDistribution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumTextbookDistribution_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumTextbookDistribution_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REPORT_APPROVAL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SystemReportId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SubmittedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReviewerId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Comments = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DigitalSignatureHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CertificateNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CertificatePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsFinal = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORT_APPROVAL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REPORT_APPROVAL_SYSTEM_REPORT_SystemReportId",
                        column: x => x.SystemReportId,
                        principalTable: "SYSTEM_REPORT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CM_ASSET_PROCUREMENT_PAYMENT",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PURCHASE_ORDER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PAYMENT_VOUCHER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PAID_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    PurchaseOrderId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PaymentVoucherId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_ASSET_PROCUREMENT_PAYMENT", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_PROCUREMENT_PAYMENT_PAYMENT_VOUCHER_PAYMENT_VOUCHER_ID",
                        column: x => x.PAYMENT_VOUCHER_ID,
                        principalTable: "PAYMENT_VOUCHER",
                        principalColumn: "PAYMENT_VOUCHER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_PROCUREMENT_PAYMENT_PAYMENT_VOUCHER_PaymentVoucherId1",
                        column: x => x.PaymentVoucherId1,
                        principalTable: "PAYMENT_VOUCHER",
                        principalColumn: "PAYMENT_VOUCHER_ID");
                    table.ForeignKey(
                        name: "FK_CM_ASSET_PROCUREMENT_PAYMENT_PurchaseOrder_PURCHASE_ORDER_ID",
                        column: x => x.PURCHASE_ORDER_ID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_PROCUREMENT_PAYMENT_PurchaseOrder_PurchaseOrderId1",
                        column: x => x.PurchaseOrderId1,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_ASSET_PROCUREMENT_PAYMENT_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_PROCUREMENT_PAYMENT_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "STATISTICS_ARCHIVE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SubmittedStatisticsId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ARCHIVED_YEAR = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    PeriodType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ArchivedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FinalDataSnapshotJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StudentSnapshotJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StaffSnapshotJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RetentionPeriodYears = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RetentionEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATISTICS_ARCHIVE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STATISTICS_ARCHIVE_SUBMITTED_STATISTICS_SubmittedStatisticsId",
                        column: x => x.SubmittedStatisticsId,
                        principalTable: "SUBMITTED_STATISTICS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACADEMIC_LOCK_PERIOD",
                columns: table => new
                {
                    LOCK_PERIOD_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    OFFICE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PERIOD_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LOCK_GRADE_ROSTERS = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LOCK_ENROLLMENT_SNAPSHOTS = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LOCK_PERIOD_STATS_REPORTS = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockAttendanceLogs = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockBehavioralRecords = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockFinancialFeeAssessments = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UnlockReasonDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    InitiatedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACADEMIC_LOCK_PERIOD", x => x.LOCK_PERIOD_ID);
                    table.ForeignKey(
                        name: "FK_ACADEMIC_LOCK_PERIOD_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STATISTICAL_REPORT_SNAPSHOT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AcademicLockPeriodId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    REPORT_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    REPORT_NAME_AR = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    REPORT_CATEGORY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SNAPSHOT_PAYLOAD_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SNAPSHOT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IS_VERIFIED_BY_OFFICE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AcademicLockPeriodId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATISTICAL_REPORT_SNAPSHOT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STATISTICAL_REPORT_SNAPSHOT_ACADEMIC_LOCK_PERIOD_AcademicLockPeriodId",
                        column: x => x.AcademicLockPeriodId,
                        principalTable: "ACADEMIC_LOCK_PERIOD",
                        principalColumn: "LOCK_PERIOD_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STATISTICAL_REPORT_SNAPSHOT_ACADEMIC_LOCK_PERIOD_AcademicLockPeriodId1",
                        column: x => x.AcademicLockPeriodId1,
                        principalTable: "ACADEMIC_LOCK_PERIOD",
                        principalColumn: "LOCK_PERIOD_ID");
                    table.ForeignKey(
                        name: "FK_STATISTICAL_REPORT_SNAPSHOT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STATISTICAL_REPORT_SNAPSHOT_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_REPORT_SNAPSHOT_SOURCE",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    REPORT_SNAPSHOT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SOURCE_MODULE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    SOURCE_ENTITY_TYPE = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    SOURCE_ENTITY_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ACADEMIC_YEAR_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AGGREGATION_DESC = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    StatisticalReportSnapshotId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_REPORT_SNAPSHOT_SOURCE", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_REPORT_SNAPSHOT_SOURCE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_REPORT_SNAPSHOT_SOURCE_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_REPORT_SNAPSHOT_SOURCE_STATISTICAL_REPORT_SNAPSHOT_REPORT_SNAPSHOT_ID",
                        column: x => x.REPORT_SNAPSHOT_ID,
                        principalTable: "STATISTICAL_REPORT_SNAPSHOT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_REPORT_SNAPSHOT_SOURCE_STATISTICAL_REPORT_SNAPSHOT_StatisticalReportSnapshotId1",
                        column: x => x.StatisticalReportSnapshotId1,
                        principalTable: "STATISTICAL_REPORT_SNAPSHOT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademicBranchConfigLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ConfigKey = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConfigValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PreviousValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ChangeReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ConfigCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ModifiedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RequiresSupervisoryApproval = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicBranchConfigLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicBranchConfigLog_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDecision",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DecisionNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DecisionSource = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DecisionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    JobTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    JobGrade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DepartmentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmploymentType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ProbationPeriodMonths = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProbationEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SalaryAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    AllowanceDetailsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    OtherBenefits = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovedByName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovedByTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDecision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetAllocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InventoryItemId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssignedToEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AllocatedQuantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AllocationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAllocation_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetAssignment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssigneeType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssigneeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssigneeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssignerUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssignmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AssignmentReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConditionAtAssignment = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConditionNotesAtAssignment = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConditionAtReturn = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConditionNotesAtReturn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PenaltyAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PenaltyStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssignmentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsReturned = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ReturnedToUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAssignment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetInspectionLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RelatedTransactionType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RelatedTransactionId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    InspectionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InspectorUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PhysicalCondition = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DamageDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DamagePhotosJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FunctionalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MissingPartsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    InspectionResult = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecommendedAction = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EstimatedRepairCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInspectionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetLoan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    BorrowerType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BorrowerId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    BorrowerName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BorrowerContact = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LoanDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LoanPurpose = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IssuerUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ConditionAtLoan = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConditionAtReturn = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsOverdue = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    OverdueDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FineAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IsFinePaid = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FinePaidDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LoanStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetMaintenanceTicket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TicketNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ReportedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IssueType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SeverityLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IssueDescriptionText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssignedToEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Diagnosis = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    EstimatedCompletionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActualCompletionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ResolutionDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ResolutionCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TicketStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClosedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AttachmentsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenanceTicket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetMovementHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ActionType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ActionDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OldValueJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NewValueJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RelatedEntityType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RelatedEntityId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PerformedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMovementHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetSuspensionRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RequestNumber = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RequestedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Reason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReasonDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AttachmentsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ApprovalNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsRevoked = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RevokeDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RevokeReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RevokedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetSuspensionRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTransferRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RequestNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FromEntityType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FromEntityId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ToEntityType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ToEntityId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TransferType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RequestReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RequestedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TransferExecutionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExecutedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RequestStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTransferRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AttendanceStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AbsenceReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DurationMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecordedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PeriodNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CheckInTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CheckOutTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsParentNotified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ExcusalDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BehavioralLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    BehaviorCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IncidentTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ActionTaken = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RecordedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IncidentTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DemeritOrMeritPoints = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IncidentLocation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ParentNotificationStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InvestigationNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehavioralLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLASSROOM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomCode = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ClassroomNameAr = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ClassroomNameEn = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    GradeLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Capacity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoomNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FloorLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BuildingSection = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HomeroomTeacherEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsSmartClassroom = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASSROOM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CLASSROOM_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLASSROOM_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "ClassroomOperationalRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RuleCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RuleTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RuleTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MaxAllowedAbsencePercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    RequiresDailyAttendanceLog = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AllowLateArrivalMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaxAllowedConsecutiveAbsenceDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PenaltyTypeForExceedingLimit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomOperationalRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassroomOperationalRule_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomResourceAllocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ResourceNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResourceCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResourceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ConditionStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ResourceNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AssetSerialNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UnitPurchaseCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    LastInspectionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NextMaintenanceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomResourceAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassroomResourceAllocation_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    PERSON_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ENROLLMENT_NUMBER = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ENROLLMENT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GUARDIAN_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PreviousSchoolName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AdmissionGradeLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CurrentAcademicYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StudentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SpecialEducationNeeds = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BusStopLocationDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "FK_STUDENT_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_STUDENT_GUARDIAN_GUARDIAN_ID",
                        column: x => x.GUARDIAN_ID,
                        principalTable: "GUARDIAN",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_STUDENT_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSON",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STUDENT_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "FeeInvoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FeeStructureId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeInvoice_FeeStructure_FeeStructureId",
                        column: x => x.FeeStructureId,
                        principalTable: "FeeStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeeInvoice_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AccountNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TotalDebit = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BalanceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalDues = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalPaid = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TotalExemption = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    LastTransactionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastPaymentAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    AccountStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsExempt = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ExemptionPercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    ExemptionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ExemptionApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ExemptionApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExemptionDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MinimumPaymentRequired = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    IsBlockedFromRegistration = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    BlockReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UnblockDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PaymentPlan = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsEligibleForExam = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAccount_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDailyAttendanceSummary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AcademicYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SemesterNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MonthNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalPresentDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalAbsentDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalExcusedDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalLateDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalAbsencePercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IsWarningThresholdReached = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ConsecutiveAbsentDaysCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastAbsenceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsParentNotifiedOfThreshold = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CalculatedGradeLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDailyAttendanceSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDailyAttendanceSummary_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AcademicYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SemesterNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EnrollmentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsCurrentTerm = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EnrollmentType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssignedRollNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PromotionStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EnrollmentRemarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExemplaryRecognition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AcademicYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SemesterNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecognitionTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Category = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AwardDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CertificateNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RecognitionTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AwardGrantedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MeritBonusPoints = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsFeaturedInSchoolBoard = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExemplaryRecognition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExemplaryRecognition_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGuardianRelationship",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    GuardianId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RelationshipType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsPrimaryContact = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsEmergencyContact = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasFinancialResponsibility = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HasLegalCustody = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CustodyDocumentReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsAuthorizedForMedicalDecisions = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsLivingTogether = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGuardianRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGuardianRelationship_GUARDIAN_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "GUARDIAN",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGuardianRelationship_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentHealthRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExaminationDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Diagnosis = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReferralHospital = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ExaminedByNurseName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HealthStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HealthRecordCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhysicalHeightCm = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PhysicalWeightKg = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    VisionCheckResult = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HearingCheckResult = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsFitForPhysicalEducation = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NextCheckupDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHealthRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentHealthRecord_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMedicalAllergyLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AllergyOrConditionName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SeverityLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReactionSymptoms = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmergencyActionProtocol = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RequiredMedicationName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IsEpiPenRequired = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DoctorContactNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastReactionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NurseVerificationStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMedicalAllergyLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMedicalAllergyLog_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CM_PAYMENT_INVOICE_SETTLEMENT",
                columns: table => new
                {
                    SETTLEMENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PAYMENT_VOUCHER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FEE_INVOICE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ALLOCATED_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    PaymentVoucherId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FeeInvoiceId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_PAYMENT_INVOICE_SETTLEMENT", x => x.SETTLEMENT_ID);
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_FeeInvoice_FEE_INVOICE_ID",
                        column: x => x.FEE_INVOICE_ID,
                        principalTable: "FeeInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_FeeInvoice_FeeInvoiceId1",
                        column: x => x.FeeInvoiceId1,
                        principalTable: "FeeInvoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_PAYMENT_VOUCHER_PAYMENT_VOUCHER_ID",
                        column: x => x.PAYMENT_VOUCHER_ID,
                        principalTable: "PAYMENT_VOUCHER",
                        principalColumn: "PAYMENT_VOUCHER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_PAYMENT_VOUCHER_PaymentVoucherId1",
                        column: x => x.PaymentVoucherId1,
                        principalTable: "PAYMENT_VOUCHER",
                        principalColumn: "PAYMENT_VOUCHER_ID");
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_PAYMENT_INVOICE_SETTLEMENT_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_ENROLLMENT_FINANCIAL_LINK",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ENROLLMENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ACCOUNT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ACADEMIC_YEAR_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TUITION_FEE_DUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    DISCOUNT_APPLIED = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    EXEMPTION_APPLIED = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NET_PAYABLE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    IS_SETTLED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SETTLEMENT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EnrollmentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentAccountId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_ENROLLMENT_FINANCIAL_LINK", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_StudentAccount_STUDENT_ACCOUNT_ID",
                        column: x => x.STUDENT_ACCOUNT_ID,
                        principalTable: "StudentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_StudentAccount_StudentAccountId1",
                        column: x => x.StudentAccountId1,
                        principalTable: "StudentAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_StudentEnrollment_ENROLLMENT_ID",
                        column: x => x.ENROLLMENT_ID,
                        principalTable: "StudentEnrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ENROLLMENT_FINANCIAL_LINK_StudentEnrollment_EnrollmentId1",
                        column: x => x.EnrollmentId1,
                        principalTable: "StudentEnrollment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssignedEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DayOfWeek = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PeriodNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoomCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StartTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EndTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TermSemesterNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ScheduleType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CM_ASSET_FINANCIAL_JOURNAL",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ASSET_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    JOURNAL_ENTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ENTRY_TYPE = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    ENTRY_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    ENTRY_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    SchoolAssetId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JournalEntryId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_ASSET_FINANCIAL_JOURNAL", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_FINANCIAL_JOURNAL_JOURNAL_ENTRY_JOURNAL_ENTRY_ID",
                        column: x => x.JOURNAL_ENTRY_ID,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_FINANCIAL_JOURNAL_JOURNAL_ENTRY_JournalEntryId1",
                        column: x => x.JournalEntryId1,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID");
                    table.ForeignKey(
                        name: "FK_CM_ASSET_FINANCIAL_JOURNAL_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_ASSET_FINANCIAL_JOURNAL_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_EMERGENCY_ASSET_IMPACT",
                columns: table => new
                {
                    IMPACT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMERGENCY_INCIDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ASSET_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IMPACT_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EST_DAMAGE_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    DAMAGE_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    REQUIRES_MAINTENANCE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MAINTENANCE_TICKET_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EmergencyIncidentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAssetId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    MaintenanceTicketId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_EMERGENCY_ASSET_IMPACT", x => x.IMPACT_ID);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_ASSET_IMPACT_AssetMaintenanceTicket_MAINTENANCE_TICKET_ID",
                        column: x => x.MAINTENANCE_TICKET_ID,
                        principalTable: "AssetMaintenanceTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_ASSET_IMPACT_AssetMaintenanceTicket_MaintenanceTicketId1",
                        column: x => x.MaintenanceTicketId1,
                        principalTable: "AssetMaintenanceTicket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_ASSET_IMPACT_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_ASSET_IMPACT_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                columns: table => new
                {
                    SAFETY_RECORD_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMERGENCY_INCIDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SAFETY_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IS_ON_DUTY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ASSIGNED_ROLE = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EmergencyIncidentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmployeeId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_EMERGENCY_EMPLOYEE_SAFETY", x => x.SAFETY_RECORD_ID);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_EMPLOYEE_SAFETY_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_EMPLOYEE_SAFETY_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                columns: table => new
                {
                    EXPENSE_LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EMERGENCY_INCIDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EMERGENCY_HOSTING_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EMERGENCY_CLOSURE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JOURNAL_ENTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EXPENSE_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    EXPENSE_CATEGORY = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EmergencyIncidentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmergencyHostingId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmergencyClosureId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JournalEntryId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_EMERGENCY_FINANCIAL_EXPENSE", x => x.EXPENSE_LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_EMERGENCY_CLOSURE_EMERGENCY_CLOSURE_ID",
                        column: x => x.EMERGENCY_CLOSURE_ID,
                        principalTable: "EMERGENCY_CLOSURE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_EMERGENCY_CLOSURE_EmergencyClosureId1",
                        column: x => x.EmergencyClosureId1,
                        principalTable: "EMERGENCY_CLOSURE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_JOURNAL_ENTRY_JOURNAL_ENTRY_ID",
                        column: x => x.JOURNAL_ENTRY_ID,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_JOURNAL_ENTRY_JournalEntryId1",
                        column: x => x.JournalEntryId1,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID");
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMERGENCY_HOSTING_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    WAREHOUSE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SUPPLIES_USED_JSON = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    TOTAL_SUPPLY_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EmergencyHostingId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    WarehouseId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_EMERGENCY_HOSTING_WAREHOUSE", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_HOSTING_WAREHOUSE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_HOSTING_WAREHOUSE_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_HOSTING_WAREHOUSE_WAREHOUSE_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "WAREHOUSE",
                        principalColumn: "WAREHOUSE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_HOSTING_WAREHOUSE_WAREHOUSE_WarehouseId1",
                        column: x => x.WarehouseId1,
                        principalTable: "WAREHOUSE",
                        principalColumn: "WAREHOUSE_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_EMERGENCY_STUDENT_SAFETY",
                columns: table => new
                {
                    SAFETY_RECORD_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMERGENCY_INCIDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SAFETY_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PARENT_NOTIFIED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PARENT_NOTIFICATION_TIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LOCATION = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EmergencyIncidentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_EMERGENCY_STUDENT_SAFETY", x => x.SAFETY_RECORD_ID);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_STUDENT_SAFETY_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_STUDENT_SAFETY_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_STUDENT_SAFETY_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMERGENCY_STUDENT_SAFETY_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_EMPLOYEE_TRAINING_COURSE",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMPLOYEE_TRAINING_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TRAINING_COURSE_OFFERING_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TRAINING_FEE_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    FUNDING_SOURCE = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: true),
                    CERTIFICATE_ISSUED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CERTIFICATE_URL = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EmployeeTrainingId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TrainingCourseOfferingId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmployeeId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_EMPLOYEE_TRAINING_COURSE", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_EMPLOYEE_TRAINING_COURSE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMPLOYEE_TRAINING_COURSE_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_EMPLOYEE_TRAINING_COURSE_TrainingCourseOffering_TRAINING_COURSE_OFFERING_ID",
                        column: x => x.TRAINING_COURSE_OFFERING_ID,
                        principalTable: "TrainingCourseOffering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_EMPLOYEE_TRAINING_COURSE_TrainingCourseOffering_TrainingCourseOfferingId1",
                        column: x => x.TrainingCourseOfferingId1,
                        principalTable: "TrainingCourseOffering",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CM_PAYROLL_JOURNAL_LINK",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PAYROLL_DETAIL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    JOURNAL_ENTRY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PAYROLL_RUN_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SALARY_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    PayrollDetailId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JournalEntryId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmployeeId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PayrollRunId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_PAYROLL_JOURNAL_LINK", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_PAYROLL_JOURNAL_LINK_JOURNAL_ENTRY_JOURNAL_ENTRY_ID",
                        column: x => x.JOURNAL_ENTRY_ID,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_PAYROLL_JOURNAL_LINK_JOURNAL_ENTRY_JournalEntryId1",
                        column: x => x.JournalEntryId1,
                        principalTable: "JOURNAL_ENTRY",
                        principalColumn: "JOURNAL_ENTRY_ID");
                    table.ForeignKey(
                        name: "FK_CM_PAYROLL_JOURNAL_LINK_PAYROLL_RUN_PAYROLL_RUN_ID",
                        column: x => x.PAYROLL_RUN_ID,
                        principalTable: "PAYROLL_RUN",
                        principalColumn: "PAYROLL_RUN_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_PAYROLL_JOURNAL_LINK_PAYROLL_RUN_PayrollRunId1",
                        column: x => x.PayrollRunId1,
                        principalTable: "PAYROLL_RUN",
                        principalColumn: "PAYROLL_RUN_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_STUDENT_CUSTODY_ASSET",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    STUDENT_INVENTORY_CUSTODY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ASSET_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    INVENTORY_ITEM_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REPLACEMENT_VALUE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    IS_RETURNED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RETURN_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CONDITION_ON_RETURN = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    StudentInventoryCustodyId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAssetId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    InventoryItemId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_STUDENT_CUSTODY_ASSET", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_CUSTODY_ASSET_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_CUSTODY_ASSET_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_CUSTODY_ASSET_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_CUSTODY_ASSET_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_STUDENT_TRANSPORT_ROUTE",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TRANSPORT_SUBSCRIPTION_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TRANSPORTATION_SERVICE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ASSIGNED_SEAT_NUMBER = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    SUBSCRIPTION_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EFFECTIVE_FROM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EFFECTIVE_TO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    StudentTransportationSubscriptionId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TransportationServiceId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_STUDENT_TRANSPORT_ROUTE", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_TRANSPORT_ROUTE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_TRANSPORT_ROUTE_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_TRANSPORT_ROUTE_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_STUDENT_TRANSPORT_ROUTE_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_USER_EMPLOYEE_IDENTITY",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SYSTEM_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DIRECTORATE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ORGANIZATIONAL_SECTOR_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LINK_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LINKED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UNLINKED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UNLINK_REASON = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true),
                    LINKED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    SystemUserId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmployeeId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_USER_EMPLOYEE_IDENTITY", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_USER_EMPLOYEE_IDENTITY_Directorate_DIRECTORATE_ID",
                        column: x => x.DIRECTORATE_ID,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_USER_EMPLOYEE_IDENTITY_Directorate_DirectorateId1",
                        column: x => x.DirectorateId1,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CM_USER_EMPLOYEE_IDENTITY_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_USER_EMPLOYEE_IDENTITY_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "CM_USER_GUARDIAN_IDENTITY",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SYSTEM_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    GUARDIAN_RELATIONSHIP_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LINK_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LINKED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UNLINKED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    SystemUserId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GuardianRelationshipId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_USER_GUARDIAN_IDENTITY", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_USER_GUARDIAN_IDENTITY_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_USER_GUARDIAN_IDENTITY_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_USER_GUARDIAN_IDENTITY_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_USER_GUARDIAN_IDENTITY_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_CM_USER_GUARDIAN_IDENTITY_StudentGuardianRelationship_GUARDIAN_RELATIONSHIP_ID",
                        column: x => x.GUARDIAN_RELATIONSHIP_ID,
                        principalTable: "StudentGuardianRelationship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_USER_GUARDIAN_IDENTITY_StudentGuardianRelationship_GuardianRelationshipId",
                        column: x => x.GuardianRelationshipId,
                        principalTable: "StudentGuardianRelationship",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CM_USER_STUDENT_IDENTITY",
                columns: table => new
                {
                    LINK_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SYSTEM_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LINK_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LINKED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UNLINKED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LINKED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    SystemUserId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CM_USER_STUDENT_IDENTITY", x => x.LINK_ID);
                    table.ForeignKey(
                        name: "FK_CM_USER_STUDENT_IDENTITY_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_USER_STUDENT_IDENTITY_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_CM_USER_STUDENT_IDENTITY_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CM_USER_STUDENT_IDENTITY_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "CommitteeMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CommitteeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MemberRole = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMMUNITY_PARTNERSHIP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PARTNERSHIP_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PARTNER_NAME = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    PARTNER_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    SUPPORT_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    AGREEMENT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IS_RENEWABLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AGREEMENT_DOC_PATH = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    SUPPORT_VALUE_AMOUNT = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    SUPPORT_VALUE_CURRENCY = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    SUPPORT_IN_KIND_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IMPACT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IMPACT_RATING = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RESPONSIBLE_EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PARTNER_CONTACT_PERSON = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    PARTNER_CONTACT_EMAIL = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    PARTNER_CONTACT_PHONE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    PARTNERSHIP_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMUNITY_PARTNERSHIP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMMUNITY_PARTNERSHIP_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DepartmentCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DepartmentNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DepartmentNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DepartmentType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Responsibilities = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnnualBudget = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HeadOfDepartmentEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    WorkingHoursDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    HeadOfDepartmentEmployeeId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Department_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "DetailedAcademicWarningLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    WarningDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    WarningCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    WarningLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TriggerDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GuardianAcknowledgedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IssuedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RemedialPlanDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TargetResolutionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsEscalatedToDirector = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedAcademicWarningLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedAcademicWarningLog_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedAcademicWarningLog_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationalSupervisionVisit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SupervisorName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    VisitPurpose = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EvaluationScore = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: true),
                    Recommendations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SupervisorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VisitedTeacherEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TargetDepartmentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FollowUpRequiredDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActionItemsDetail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DirectorateId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalSupervisionVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalSupervisionVisit_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalSupervisionVisit_Directorate_DirectorateId1",
                        column: x => x.DirectorateId1,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EducationalSupervisionVisit_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalSupervisionVisit_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EMERGENCY_HOSTING",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    HOSTING_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    HOSTING_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    HOSTING_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EXPECTED_END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ACTUAL_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MAX_CAPACITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UTILIZATION_PERCENTAGE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    REASON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SOURCE_LOCATION = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    SUPPORT_ORGANIZATION = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    SUPPORT_ORG_CONTACT = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    FACILITIES_USED_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RESOURCES_PROVIDED_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RESOURCES_RECEIVED_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EXPENSES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TOTAL_EXPENSES = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    HOSTING_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLOSURE_NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LESSONS_LEARNED = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    REPORTED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ATTACHMENTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMERGENCY_HOSTING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_HOSTING_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMERGENCY_INCIDENT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    INCIDENT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    INCIDENT_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    INCIDENT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    INCIDENT_TIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SEVERITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LOCATION_TEXT = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    REPORTED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    REPORTED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IS_PLAN_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EMERGENCY_PLAN_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AFFECTED_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    STUDENTS_AFFECTED = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EMPLOYEES_AFFECTED = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    INJURIES_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SEVERE_INJURIES_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FATALITIES_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PROPERTY_DAMAGE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    PROPERTY_DAMAGE_DESC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EMERGENCY_RESPONSE_ACTIONS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EXTERNAL_AGENCIES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EXTERNAL_RESPONSE_TIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    INCIDENT_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLOSURE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CLOSURE_NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    INVESTIGATION_REPORT_URL = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    LESSONS_LEARNED = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RECOMMENDATIONS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ATTACHMENTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMERGENCY_INCIDENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_INCIDENT_EMERGENCY_PLAN_EMERGENCY_PLAN_ID",
                        column: x => x.EMERGENCY_PLAN_ID,
                        principalTable: "EMERGENCY_PLAN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_INCIDENT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMERGENCY_INCIDENT_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    PERSON_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    WorkLocationType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EMPLOYEE_CODE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    NationalIdNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NationalIdType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NationalIdExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PassportExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ResidenceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ResidenceExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ResidenceSponsorName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FirstNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FatherNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GrandfatherNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FamilyNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FirstNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FamilyNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Nationality = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MaritalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumberOfDependents = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BloodType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HasSpecialNeeds = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PhonePrimary = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneSecondary = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PersonalEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    OfficialEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FullAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ProfilePhotoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CONTRACT_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmployeeType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DepartmentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    JOB_TITLE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    JobGrade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Specialization = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AcademicQualification = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QualificationSource = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ExperienceYears = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HIRE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EmploymentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CanLogin = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PortalUsername = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PortalPasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    BankName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BankIban = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VerificationStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DirectorateId1 = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_Directorate_DirectorateId1",
                        column: x => x.DirectorateId1,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSON",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DocumentType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DocumentSubType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DocumentName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IssuedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsExpiryRequired = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ExpiryReminderSent = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FileSize = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FileType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ThumbnailPath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsRequired = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsVerified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    VerifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    VerificationNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DocumentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsConfidential = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsArchived = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDocument_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY_ITEM",
                columns: table => new
                {
                    INVENTORY_ITEM_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    WAREHOUSE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ITEM_NAME = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    ITEM_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    QUANTITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UNIT_OF_MEASURE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_ITEM", x => x.INVENTORY_ITEM_ID);
                    table.ForeignKey(
                        name: "FK_INVENTORY_ITEM_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_INVENTORY_ITEM_WAREHOUSE_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "WAREHOUSE",
                        principalColumn: "WAREHOUSE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficialCircular",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CircularNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CircularType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IssuerName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TargetAudience = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ContentBody = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IssuerEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AttachmentFileUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RequiresMandatoryAcknowledgment = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AcknowledgmentDeadline = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialCircular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialCircular_EMPLOYEE_IssuerEmployeeId",
                        column: x => x.IssuerEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalSector",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SectorCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SectorNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SectorNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SectorType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParentSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CostCenterCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnnualHrBudget = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    HeadOfSectorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DirectorateId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalSector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationalSector_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationalSector_Directorate_DirectorateId1",
                        column: x => x.DirectorateId1,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationalSector_EMPLOYEE_HeadOfSectorEmployeeId",
                        column: x => x.HeadOfSectorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationalSector_OrganizationalSector_ParentSectorId",
                        column: x => x.ParentSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationalSector_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationalSector_SCHOOL_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "PAYROLL_DETAIL",
                columns: table => new
                {
                    PAYROLL_DETAIL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PAYROLL_RUN_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    BASE_SALARY = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_ALLOWANCES = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    TOTAL_DEDUCTIONS = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    NET_SALARY = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CREATED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MODIFIED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    MODIFIED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DELETED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DELETED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VERSION_TOKEN = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LAST_SYNCED_AT = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYROLL_DETAIL", x => x.PAYROLL_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_PAYROLL_DETAIL_EMPLOYEE_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PAYROLL_DETAIL_PAYROLL_RUN_PAYROLL_RUN_ID",
                        column: x => x.PAYROLL_RUN_ID,
                        principalTable: "PAYROLL_RUN",
                        principalColumn: "PAYROLL_RUN_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAnnouncementLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnnouncementContent = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TargetAudience = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsPinned = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AnnouncementPriority = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AttachmentFileUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ViewCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PublishedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAnnouncementLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAnnouncementLog_EMPLOYEE_PublishedByEmployeeId",
                        column: x => x.PublishedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_SchoolAnnouncementLog_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAsset",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssetUniqueCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssetNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssetNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AssetTag = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SerialNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ModelNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Manufacturer = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Brand = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AssetCategoryId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssetStatusId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssetLocationId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    Condition = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AcquisitionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AcquisitionCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    SupplierName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PurchaseOrderReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    WarrantyContractId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsInsured = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    InsurancePolicyNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    InsuranceExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UsefulLifeYears = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SalvageValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CurrentBookValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Barcode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QrCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RfidTag = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    HasPhysicalTag = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PhysicalTagDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Currency = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LocationId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAsset_AssetCategory_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AssetCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolAsset_AssetLocationRecord_LocationId",
                        column: x => x.LocationId,
                        principalTable: "AssetLocationRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolAsset_AssetWarrantyContract_WarrantyContractId",
                        column: x => x.WarrantyContractId,
                        principalTable: "AssetWarrantyContract",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolAsset_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_SchoolAsset_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolEventCalendar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EventTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsPublic = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    OrganizerEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TargetAudience = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LocationDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RequiresAttendanceTracking = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEventCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolEventCalendar_EMPLOYEE_OrganizerEmployeeId",
                        column: x => x.OrganizerEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_SchoolEventCalendar_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolFacility",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FacilityCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FacilityNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FacilityNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FacilityType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Capacity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssignedSupervisorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsOperational = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LocationFloor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BuildingName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SafetyInspectionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    MaintenanceStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolFacility_EMPLOYEE_AssignedSupervisorId",
                        column: x => x.AssignedSupervisorId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_SchoolFacility_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTransportationRoute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RouteCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RouteNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DriverEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    BusPlateNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalSeats = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MorningStartHour = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EveningReturnHour = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MonthlyFee = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    RouteNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BusSupervisorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    BusModelAndYear = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalSubscribedStudents = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GpsTrackingDeviceId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTransportationRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolTransportationRoute_EMPLOYEE_BusSupervisorEmployeeId",
                        column: x => x.BusSupervisorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolTransportationRoute_EMPLOYEE_DriverEmployeeId",
                        column: x => x.DriverEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolTransportationRoute_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelfServicePortalRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RequestType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RequestTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RequestDetailsText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RequestStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReviewedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfServicePortalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelfServicePortalRequest_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffCustodySummary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CustodySummaryJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalItemsCount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalEstimatedValue = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    CustodyIssuedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CustodyStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClearanceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ClearedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ClearanceNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClearanceDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCustodySummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffCustodySummary_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_TRANSFER_LOG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FromSchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ToSchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Reason = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TransferCertificateNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    MinistryApprovalReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TransferRemarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StudentId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FromSchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ToSchoolId1 = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_TRANSFER_LOG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_EMPLOYEE_ApprovedByEmployeeId",
                        column: x => x.ApprovedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_SCHOOL_FromSchoolId",
                        column: x => x.FromSchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_SCHOOL_FromSchoolId1",
                        column: x => x.FromSchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_SCHOOL_ToSchoolId",
                        column: x => x.ToSchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_SCHOOL_ToSchoolId1",
                        column: x => x.ToSchoolId1,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_TRANSFER_LOG_STUDENT_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentAbsenceExcusal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExcusalType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReasonDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MedicalReportAttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReviewStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReviewedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SubmittedByGuardianId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReviewRemarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAbsenceExcusal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAbsenceExcusal_EMPLOYEE_ReviewedByEmployeeId",
                        column: x => x.ReviewedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentAbsenceExcusal_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentActivityParticipation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ActivityNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ActivityType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SupervisorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ParticipationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AchievementDetail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ScoreBonus = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ActivityNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ParticipationRole = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalHoursLogged = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AwardLevel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentActivityParticipation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentActivityParticipation_EMPLOYEE_SupervisorEmployeeId",
                        column: x => x.SupervisorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentActivityParticipation_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentActivityParticipation_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssessmentTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssessmentCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaxScore = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ObtainedScore = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    AssessmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EvaluatedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PassingScore = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    LetterCodeResult = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GradePointResult = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Remarks = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsRetakeExam = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    OriginalAssessmentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssessment_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssessment_EMPLOYEE_EvaluatedByEmployeeId",
                        column: x => x.EvaluatedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentAssessment_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssessment_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignmentSubmission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssignmentTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SubmissionStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ScoreObtained = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    TeacherFeedback = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AttachmentFileUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MaxPossibleScore = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    SubmissionAttemptNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsGraded = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    GradedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignmentSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssignmentSubmission_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignmentSubmission_EMPLOYEE_GradedByEmployeeId",
                        column: x => x.GradedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentAssignmentSubmission_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignmentSubmission_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AttachmentTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AttachmentCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FileName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FilePathUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FileSizeKb = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AttachmentTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MimeType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsConfidential = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UploadedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAttachment_EMPLOYEE_UploadedByEmployeeId",
                        column: x => x.UploadedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentAttachment_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDisciplinaryHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    BehavioralLogId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DisciplinaryActionCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ActionTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExecutedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PenaltyDurationDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GuardianNotifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AppealStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ActionTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AppealNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReinstatementCondition = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDisciplinaryHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDisciplinaryHistory_BehavioralLog_BehavioralLogId",
                        column: x => x.BehavioralLogId,
                        principalTable: "BehavioralLog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentDisciplinaryHistory_EMPLOYEE_ExecutedByEmployeeId",
                        column: x => x.ExecutedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentDisciplinaryHistory_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExemption",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ExemptionCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ReasonDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExemptionCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SupportingDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AnnualMaxDiscountAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IsRenewable = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExemption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExemption_EMPLOYEE_ApprovedByEmployeeId",
                        column: x => x.ApprovedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentExemption_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentIdentityDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DocumentType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IssueCountry = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsVerified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IssuePlace = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VerifiedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DocumentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIdentityDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIdentityDocument_EMPLOYEE_VerifiedByEmployeeId",
                        column: x => x.VerifiedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentIdentityDocument_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPsychologicalCounselingLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CounselorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SessionCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SessionNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RecommendedIntervention = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsConfidential = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ReferralSource = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RiskAssessmentLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsParentInvolved = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CaseStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPsychologicalCounselingLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPsychologicalCounselingLog_EMPLOYEE_CounselorEmployeeId",
                        column: x => x.CounselorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPsychologicalCounselingLog_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSkillAndTalentRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TalentCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TalentTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiscoveredDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MentorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TalentTitleEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DevelopmentPlanDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PortfolioAttachmentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsEnrolledInGiftedProgram = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSkillAndTalentRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSkillAndTalentRecord_EMPLOYEE_MentorEmployeeId",
                        column: x => x.MentorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentSkillAndTalentRecord_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_USER",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OFFICE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PASSWORD_HASH = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    PasswordSalt = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PasswordExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastPasswordChangeDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    MustChangePassword = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FailedAttempts = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastFailedAttemptDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsLocked = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LockExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DeactivationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DeactivationReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FullNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FullNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NationalId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EmailVerified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EmailVerifiedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneVerified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PhoneVerifiedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    USER_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GuardianId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TwoFactorSecret = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TwoFactorBackupCodesJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastLoginIp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastLoginDevice = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastLoginUserAgent = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PreviousLoginDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PreferredLanguage = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Timezone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DateFormat = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Theme = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SignatureImageUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NotificationPreferencesJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DashboardLayoutJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SYSTEM_USER_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_SYSTEM_USER_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_SYSTEM_USER_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateTable(
                name: "VisitorEntryLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    VisitorFullName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NationalIdOrPassport = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VisitPurpose = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HostEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    VisitorBadgeNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VisitorPhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VisitorOrganization = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityGateNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityOfficerEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorEntryLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorEntryLog_EMPLOYEE_HostEmployeeId",
                        column: x => x.HostEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitorEntryLog_EMPLOYEE_SecurityOfficerEmployeeId",
                        column: x => x.SecurityOfficerEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitorEntryLog_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAdditionalTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TaskTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TaskDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TaskType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    HasFinancialCompensation = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CompensationAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    AssignedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TaskStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAdditionalTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAdditionalTask_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeAdditionalTask_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeAdditionalTask_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeAdditionalTask_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolSemesterId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AttendanceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DayOfWeek = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ShiftId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ExpectedCheckIn = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ExpectedCheckOut = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CheckInMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CheckOutMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LocationVerified = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CheckInLocationGps = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AttendanceStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LateMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EarlyDepartureMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OvertimeMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsOvertimeApproved = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TotalWorkHours = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    IsExcused = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ExcuseLeaveId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ExcuseDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsHoliday = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsWeekend = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsWorkingDay = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsOverridden = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    OverrideReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    OverriddenByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsSyncedWithPayroll = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PayrollId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCommittee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CommitteeNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CommitteeNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CommitteeCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CommitteeType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FormationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DissolutionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Objectives = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ChairmanEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CommitteeStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCommittee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCommittee_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeCommittee_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeCommittee_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExternalTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FromSchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ToSchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FromDirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ToDirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FromOrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ToOrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TransferRequestNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TransferDirection = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TransferReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    MinistryDecisionNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MinistryDecisionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DecisionDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExternalTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_Directorate_FromDirectorateId",
                        column: x => x.FromDirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_Directorate_ToDirectorateId",
                        column: x => x.ToDirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_OrganizationalSector_FromOrganizationalSectorId",
                        column: x => x.FromOrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_OrganizationalSector_ToOrganizationalSectorId",
                        column: x => x.ToOrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_SCHOOL_FromSchoolId",
                        column: x => x.FromSchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "FK_EmployeeExternalTransfer_SCHOOL_ToSchoolId",
                        column: x => x.ToSchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFinancialTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TransactionReferenceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TransactionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Module5VoucherReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFinancialTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialTransaction_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialTransaction_EMPLOYEE_ApprovedByEmployeeId",
                        column: x => x.ApprovedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialTransaction_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialTransaction_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialTransaction_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInternalTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TransferRequestNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FromDepartmentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ToDepartmentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FromJobTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ToJobTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TransferReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DecisionDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInternalTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInternalTransfer_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeInternalTransfer_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInternalTransfer_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeInternalTransfer_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLeave",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LeaveType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TotalDays = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LeaveReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SupportingDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ApprovedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsEmergency = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ReplacementEmployeeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMeeting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CommitteeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    MeetingTitleAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MeetingDateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MeetingLocation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MeetingType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AgendaJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MinutesText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DecisionsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MeetingStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ChairmanEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AttachmentsJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMentor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MentorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MenteeEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssignmentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    MentoringGoals = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMentor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMentor_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeMentor_EMPLOYEE_MenteeEmployeeId",
                        column: x => x.MenteeEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeMentor_EMPLOYEE_MentorEmployeeId",
                        column: x => x.MentorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeMentor_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeMentor_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayroll",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PayrollMonth = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PayrollYear = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    HousingAllowance = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    TransportAllowance = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    OtherAllowances = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    OvertimePay = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    GrossTotal = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    DeductionAbsence = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    DeductionInsurance = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    DeductionOther = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    NetSalary = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BankTransactionRef = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsSynced = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePayroll_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePayroll_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePayroll_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePayroll_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePerformanceReview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReviewPeriodType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReviewPeriodStart = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReviewPeriodEnd = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReviewedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OverallScore = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    PerformanceLevel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    KpiScoresJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    StrengthsText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AreasForImprovementText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DevelopmentPlanText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmployeeResponseText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsDisputed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DisputeReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisputeDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    FinalDecisionText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePerformanceReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePerformanceReview_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePerformanceReview_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePerformanceReview_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePerformanceReview_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTermination",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TerminationReferenceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TerminationType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TerminationReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastWorkingDay = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CustodyCleared = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CustodyClearanceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    FinancialCleared = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FinancialClearanceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    GratuityAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalSalarySettlement = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    DecisionDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TerminationStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTermination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTermination_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTermination_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTermination_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTermination_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTraining",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CourseName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CourseCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TrainingType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProviderName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DurationHours = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TrainingLocation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TrainingCost = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    FundingSource = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CompletionStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Score = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: true),
                    GradeLevel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CertificateUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CertificateExpiryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TrainingOutcomesSummary = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTraining_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTraining_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTraining_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTraining_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeViolation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ViolationReferenceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ViolationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ViolationCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ViolationDescriptionAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SupportingDocumentUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SanctionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PenaltyDeductionAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    ViolationStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReportedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    InvestigatingEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    InvestigationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    InvestigationNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DecisionText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsAppealed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AppealDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    AppealResult = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeViolation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeViolation_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeViolation_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeViolation_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeViolation_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "TeacherSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TeacherEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DirectorateId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SchoolSemesterId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DayOfWeek = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClassPeriodId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PeriodNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ClassSectionId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GradeCapacityId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsSubstitute = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    OriginalTeacherEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SubstituteDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SubstituteReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsCancelled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CancellationReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSchedule_Directorate_DirectorateId",
                        column: x => x.DirectorateId,
                        principalTable: "Directorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherSchedule_EMPLOYEE_TeacherEmployeeId",
                        column: x => x.TeacherEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSchedule_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherSchedule_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInventoryCustody",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ItemType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ItemNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ItemBrand = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ItemModel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ItemSerialNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ItemCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EstimatedValue = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    ConditionAtHandover = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HandoverDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HandoverNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IssuedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReceiptSignatureUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ExpectedReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ConditionAtReturn = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReturnNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsReturned = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsDamaged = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DamageDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PenaltyAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    PenaltyStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsLost = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ReplacementRequired = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CustodyStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInventoryCustody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInventoryCustody_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInventoryCustody_SchoolAsset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "SchoolAsset",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreventiveMaintenanceSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ScheduleCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    AssetCategoryId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TaskNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TaskNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MaintenanceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FrequencyUnit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FrequencyValue = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NextDueDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastServiceDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EstimatedDurationMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssignedToTeamText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    InstructionsText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ChecklistJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    MaintenanceContractId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsReminderActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ReminderDaysBefore = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ScheduleStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventiveMaintenanceSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreventiveMaintenanceSchedule_SchoolAsset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "SchoolAsset",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentInventoryCustody",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolAcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ItemType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ItemCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ItemNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ItemNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QuantityDelivered = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConditionAtDelivery = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConditionNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DeliveredByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReceivedByName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ActualReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ConditionAtReturn = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReturnNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsReturned = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsDamaged = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DamageDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DamageDiscoveredDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsLost = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LostReportedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PenaltyAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PenaltyStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PenaltyPaidDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsExemptFromPenalty = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ExemptionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReplacementRequired = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SchoolAssetId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInventoryCustody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInventoryCustody_EMPLOYEE_DeliveredByEmployeeId",
                        column: x => x.DeliveredByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentInventoryCustody_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInventoryCustody_SchoolAsset_SchoolAssetId",
                        column: x => x.SchoolAssetId,
                        principalTable: "SchoolAsset",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TRANSPORTATION_SERVICE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ROUTE_CODE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ROUTE_NAME = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    ROUTE_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BUS_ASSET_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    BUS_PLATE_NUMBER = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    BUS_CAPACITY = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    BUS_MODEL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    BUS_YEAR = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    DRIVER_EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DRIVER_LICENSE_NUMBER = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DRIVER_PHONE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    SUPERVISOR_EMPLOYEE_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SUPERVISOR_PHONE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    SHIFT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TRIP_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    START_TIME = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    END_TIME = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    ESTIMATED_DURATION_MIN = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    STOPS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SERVICE_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OPERATOR_COMPANY = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    CONTRACT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSPORTATION_SERVICE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRANSPORTATION_SERVICE_EMPLOYEE_DRIVER_EMPLOYEE_ID",
                        column: x => x.DRIVER_EMPLOYEE_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSPORTATION_SERVICE_EMPLOYEE_SUPERVISOR_EMPLOYEE_ID",
                        column: x => x.SUPERVISOR_EMPLOYEE_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSPORTATION_SERVICE_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSPORTATION_SERVICE_SchoolAsset_BUS_ASSET_ID",
                        column: x => x.BUS_ASSET_ID,
                        principalTable: "SchoolAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsageViolation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AssetId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ViolationType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ViolationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReportedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ReportedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ViolatingUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EvidenceJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PenaltyAction = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PenaltyAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PenaltyAmountCurrency = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DeductionFromSalary = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageViolation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsageViolation_SchoolAsset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "SchoolAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentParentConferenceReservation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    GuardianId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TeacherEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolEventCalendarId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReservedDateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MeetingDurationMinutes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiscussionTopic = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConferenceNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MeetingRoomOrLink = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConferenceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FollowUpActionItems = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsGuardianAttended = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParentConferenceReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentParentConferenceReservation_EMPLOYEE_TeacherEmployeeId",
                        column: x => x.TeacherEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParentConferenceReservation_GUARDIAN_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "GUARDIAN",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParentConferenceReservation_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParentConferenceReservation_SchoolEventCalendar_SchoolEventCalendarId",
                        column: x => x.SchoolEventCalendarId,
                        principalTable: "SchoolEventCalendar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExamDistributionTimetable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubjectId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ClassroomId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FacilityId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ProctorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    StartTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EndTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MaxSeatCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ExamSessionNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ExamType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TermSemesterNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssistantProctorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsSeatingChartPublished = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamDistributionTimetable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamDistributionTimetable_CLASSROOM_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "CLASSROOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamDistributionTimetable_EMPLOYEE_AssistantProctorEmployeeId",
                        column: x => x.AssistantProctorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_ExamDistributionTimetable_EMPLOYEE_ProctorEmployeeId",
                        column: x => x.ProctorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_ExamDistributionTimetable_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamDistributionTimetable_SchoolFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "SchoolFacility",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamDistributionTimetable_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolCanteenItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FacilityId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ItemCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ItemNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NutritionalCategory = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsApprovedByHealthOfficer = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ItemNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CostPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ReorderThresholdQuantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BarcodeNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DailySalesLimitPerStudent = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolCanteenItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolCanteenItem_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolCanteenItem_SchoolFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "SchoolFacility",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTransportationSubscription",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolTransportationRouteId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PickupStationAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DropoffStationAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SubscriptionStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubscriptionType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AgreedMonthlyFee = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PickupTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DropoffTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AssignedBusStopOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTransportationSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTransportationSubscription_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTransportationSubscription_SchoolTransportationRoute_SchoolTransportationRouteId",
                        column: x => x.SchoolTransportationRouteId,
                        principalTable: "SchoolTransportationRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ParentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FirstNameAr = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    FatherNameAr = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    GrandfatherNameAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FamilyNameAr = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    FirstNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FatherNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GrandfatherNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FamilyNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    BirthPlace = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CountryOfBirth = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nationality = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MotherName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MotherNationality = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MotherPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BirthCertificate = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PersonalPhoto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IDCardImage = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PreviousSchool = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PreviousGrade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RequestedGradeLevelId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    AcademicYearId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    HasSpecialNeeds = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SpecialNeedsDetails = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MedicalNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SiblingInSchool = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SiblingNames = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReferralSource = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmergencyContactPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmergencyContactRelation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RequestStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ReviewedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RejectionReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ConvertedToStudentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.CheckConstraint("CK_Registration_Gender", "\"Gender\" IN (1, 2)");
                    table.CheckConstraint("CK_Registration_Status", "\"RequestStatus\" IN (1, 2, 3, 4)");
                    table.ForeignKey(
                        name: "FK_Registrations_GUARDIAN_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GUARDIAN",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_STUDENT_ConvertedToStudentId",
                        column: x => x.ConvertedToStudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_Registrations_SYSTEM_USER_ReviewedByUserId",
                        column: x => x.ReviewedByUserId,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "REMEDIATION_PLAN",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PLAN_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PLAN_NAME = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    RELATED_DEFICIT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    RELATED_SURPLUS_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    PLAN_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SELECTED_OPTION = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    OPTION_DETAILS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    OBJECTIVES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ACTION_STEPS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PLANNED_START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PLANNED_END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ACTUAL_START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ACTUAL_END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ESTIMATED_BUDGET = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    ACTUAL_COST = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    CURRENCY = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    EXECUTION_LEAD_EMP_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    EXECUTION_TEAM_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PROGRESS_PERCENTAGE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    PLAN_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    APPROVAL_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    APPROVED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    COMPLETION_REPORT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LESSONS_LEARNED = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REMEDIATION_PLAN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REMEDIATION_PLAN_EMPLOYEE_EXECUTION_LEAD_EMP_ID",
                        column: x => x.EXECUTION_LEAD_EMP_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REMEDIATION_PLAN_SCHOOL_DEFICIT_RELATED_DEFICIT_ID",
                        column: x => x.RELATED_DEFICIT_ID,
                        principalTable: "SCHOOL_DEFICIT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REMEDIATION_PLAN_SCHOOL_SURPLUS_RELATED_SURPLUS_ID",
                        column: x => x.RELATED_SURPLUS_ID,
                        principalTable: "SCHOOL_SURPLUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REMEDIATION_PLAN_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REMEDIATION_PLAN_SYSTEM_USER_APPROVED_BY_USER_ID",
                        column: x => x.APPROVED_BY_USER_ID,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAFETY_SECURITY_REPORT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REPORT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    REPORT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    REPORT_PERIOD = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    SAFETY_LEVEL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    EXTINGUISHER_EXPIRY_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EXTINGUISHERS_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EXTINGUISHERS_LAST_INSPECTION = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EXTINGUISHERS_NEXT_INSPECTION = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ALARM_SYSTEM_STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    ALARM_LAST_TEST_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    HAS_EVACUATION_MAPS = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EMERGENCY_EXITS_STATUS = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    DRILL_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DRILL_DATES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DRILL_AVG_TIME_MIN = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DRILL_EVALUATION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SAFETY_COMMITTEE_FORMED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SAFETY_COMMITTEE_MEMBERS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SAFETY_TRAINING_HOURS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    INCIDENTS_COUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RECOMMENDATIONS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ACTION_PLAN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ATTACHMENTS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    APPROVED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    APPROVAL_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAFETY_SECURITY_REPORT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SAFETY_SECURITY_REPORT_SCHOOL_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SAFETY_SECURITY_REPORT_SYSTEM_USER_APPROVED_BY_USER_ID",
                        column: x => x.APPROVED_BY_USER_ID,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_AUDIT_LOG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    USER_ROLE_AT_EXEC = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ACTION_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ENTITY_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ENTITY_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    OLD_VALUE_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NEW_VALUE_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CHANGE_SUMMARY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TABLE_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    FIELD_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DEVICE_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    USER_AGENT = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    SESSION_ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ACCESS_CONTEXT_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SEVERITY = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    RISK_SCORE = table.Column<decimal>(type: "DECIMAL(19,4)", precision: 19, scale: 4, nullable: false),
                    IS_SUSPICIOUS = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    WAS_ALLOWED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    REJECTION_REASON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ACTION_TIMESTAMP = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_AUDIT_LOG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SYSTEM_AUDIT_LOG_SYSTEM_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_ACTIVITY_LOG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ACTIVITY_TYPE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ACTIVITY_TIMESTAMP = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ACTIVITY_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FAILURE_REASON = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DEVICE_TYPE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DEVICE_NAME = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    OPERATING_SYSTEM = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    BROWSER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    USER_AGENT = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    LOCATION_TEXT = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: true),
                    SESSION_ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ACTION_DETAILS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ACTIVITY_LOG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_ACTIVITY_LOG_SYSTEM_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_DIRECT_PERMISSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PermissionId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SCOPE_OVERRIDE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    GRANTED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    GRANTED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    REASON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_DIRECT_PERMISSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_DIRECT_PERMISSION_SYSTEM_PERMISSION_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "SYSTEM_PERMISSION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_DIRECT_PERMISSION_SYSTEM_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE_ASSIGNMENT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    RoleId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IS_PRIMARY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SCOPE_CONTEXT_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ASSIGNED_BY_USER_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ASSIGNED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NOTES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLE_ASSIGNMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ASSIGNMENT_SYSTEM_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SYSTEM_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ASSIGNMENT_SYSTEM_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "SYSTEM_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingAttendanceRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MeetingId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IsAttended = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AttendanceMethod = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AbsenceReason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsExcused = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingAttendanceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingAttendanceRecord_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingAttendanceRecord_EmployeeMeeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "EmployeeMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayrollFinancialContract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeePayrollId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    OrganizationalSectorId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FinancialTransactionReferenceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CostCenterCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BudgetLineCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TotalGrossAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalDeductionsAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    NetDisbursementAmount = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DisbursementStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DisbursementDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    BankTransferReference = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FinancialAuditorEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FinancialAuditNotes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayrollFinancialContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePayrollFinancialContract_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePayrollFinancialContract_EMPLOYEE_FinancialAuditorEmployeeId",
                        column: x => x.FinancialAuditorEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePayrollFinancialContract_EmployeePayroll_EmployeePayrollId",
                        column: x => x.EmployeePayrollId,
                        principalTable: "EmployeePayroll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePayrollFinancialContract_OrganizationalSector_OrganizationalSectorId",
                        column: x => x.OrganizationalSectorId,
                        principalTable: "OrganizationalSector",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentCanteenPurchaseLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SchoolCanteenItemId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    QuantityPurchased = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ServedByEmployeeId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TransactionReferenceNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NutritionalCalorieCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsAllergyAlertTriggered = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PaymentTransactionId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    ModifiedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    VersionToken = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SyncStatus = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastSyncedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCanteenPurchaseLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCanteenPurchaseLog_EMPLOYEE_ServedByEmployeeId",
                        column: x => x.ServedByEmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "FK_StudentCanteenPurchaseLog_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCanteenPurchaseLog_SchoolCanteenItem_SchoolCanteenItemId",
                        column: x => x.SchoolCanteenItemId,
                        principalTable: "SchoolCanteenItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACADEMIC_LOCK_PERIOD_InitiatedByEmployeeId",
                table: "ACADEMIC_LOCK_PERIOD",
                column: "InitiatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ACADEMIC_LOCK_PERIOD_SCHOOL_ID",
                table: "ACADEMIC_LOCK_PERIOD",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicBranchConfigLog_ModifiedByEmployeeId",
                table: "AcademicBranchConfigLog",
                column: "ModifiedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicBranchConfigLog_SchoolId",
                table: "AcademicBranchConfigLog",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicWarningPolicy_SchoolId",
                table: "AcademicWarningPolicy",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_ACCOUNT_CODE",
                table: "ACCOUNT",
                column: "ACCOUNT_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_PARENT_ACCOUNT_ID",
                table: "ACCOUNT",
                column: "PARENT_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_SchoolId",
                table: "ACCOUNT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDecision_EmployeeId",
                table: "AppointmentDecision",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_AssignedToEmployeeId",
                table: "AssetAllocation",
                column: "AssignedToEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_ClassroomId",
                table: "AssetAllocation",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_InventoryItemId",
                table: "AssetAllocation",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_SchoolId",
                table: "AssetAllocation",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAssignment_AssetId",
                table: "AssetAssignment",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_ParentCategoryId",
                table: "AssetCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInspectionLog_AssetId",
                table: "AssetInspectionLog",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLoan_AssetId",
                table: "AssetLoan",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLocationRecord_ParentLocationId",
                table: "AssetLocationRecord",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceTicket_AssetId",
                table: "AssetMaintenanceTicket",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovementHistory_AssetId",
                table: "AssetMovementHistory",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSuspensionRequest_AssetId",
                table: "AssetSuspensionRequest",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransferRequest_AssetId",
                table: "AssetTransferRequest",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetWarrantyContract_SchoolId",
                table: "AssetWarrantyContract",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetail_ClassroomId",
                table: "AttendanceDetail",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetail_RecordedByEmployeeId",
                table: "AttendanceDetail",
                column: "RecordedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetail_StudentId",
                table: "AttendanceDetail",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BEHAVIOR_PERMISSION_MATRIX_RoleId",
                table: "BEHAVIOR_PERMISSION_MATRIX",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BEHAVIOR_PERMISSION_RECORD_RoleId",
                table: "BEHAVIOR_PERMISSION_RECORD",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioralLog_RecordedByEmployeeId",
                table: "BehavioralLog",
                column: "RecordedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioralLog_StudentId",
                table: "BehavioralLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CLASSROOM_HomeroomTeacherEmployeeId",
                table: "CLASSROOM",
                column: "HomeroomTeacherEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CLASSROOM_SchoolId_ClassroomCode",
                table: "CLASSROOM",
                columns: new[] { "SchoolId", "ClassroomCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLASSROOM_SchoolId1",
                table: "CLASSROOM",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomOperationalRule_ClassroomId",
                table: "ClassroomOperationalRule",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomResourceAllocation_ClassroomId",
                table: "ClassroomResourceAllocation",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_AssignedEmployeeId",
                table: "ClassSchedule",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_ClassroomId",
                table: "ClassSchedule",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_SchoolId",
                table: "ClassSchedule",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_SubjectId",
                table: "ClassSchedule",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_AFJ_ASSET",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "SCHOOL_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_AFJ_JOURNAL",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "JOURNAL_ENTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_AFJ_SCHOOL_DATE",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                columns: new[] { "SCHOOL_ID", "ENTRY_DATE" });

            migrationBuilder.CreateIndex(
                name: "IX_CM_ASSET_FINANCIAL_JOURNAL_JournalEntryId1",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "JournalEntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ASSET_FINANCIAL_JOURNAL_SchoolAssetId1",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "SchoolAssetId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ASSET_FINANCIAL_JOURNAL_SchoolId1",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_APP_ORDER",
                table: "CM_ASSET_PROCUREMENT_PAYMENT",
                column: "PURCHASE_ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_APP_SCHOOL",
                table: "CM_ASSET_PROCUREMENT_PAYMENT",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_APP_VOUCHER",
                table: "CM_ASSET_PROCUREMENT_PAYMENT",
                column: "PAYMENT_VOUCHER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ASSET_PROCUREMENT_PAYMENT_PaymentVoucherId1",
                table: "CM_ASSET_PROCUREMENT_PAYMENT",
                column: "PaymentVoucherId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ASSET_PROCUREMENT_PAYMENT_PurchaseOrderId1",
                table: "CM_ASSET_PROCUREMENT_PAYMENT",
                column: "PurchaseOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ASSET_PROCUREMENT_PAYMENT_SchoolId1",
                table: "CM_ASSET_PROCUREMENT_PAYMENT",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_AER_SOURCE_MODULE",
                table: "CM_AUDITABLE_ENTITY_REGISTRY",
                column: "SOURCE_MODULE");

            migrationBuilder.CreateIndex(
                name: "UX_CM_AER_ENTITY_TYPE_KEY",
                table: "CM_AUDITABLE_ENTITY_REGISTRY",
                column: "ENTITY_TYPE_KEY",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EAIA_ASSET",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "SCHOOL_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EAIA_INCIDENT",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "EMERGENCY_INCIDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EAIA_SCHOOL",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_ASSET_IMPACT_EmergencyIncidentId1",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "EmergencyIncidentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_ASSET_IMPACT_MAINTENANCE_TICKET_ID",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "MAINTENANCE_TICKET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_ASSET_IMPACT_MaintenanceTicketId1",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "MaintenanceTicketId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_ASSET_IMPACT_SchoolAssetId1",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "SchoolAssetId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_ASSET_IMPACT_SchoolId1",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EESR_EMPLOYEE",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EESR_INCIDENT_STATUS",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                columns: new[] { "EMERGENCY_INCIDENT_ID", "SAFETY_STATUS" });

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EESR_SCHOOL",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_EMPLOYEE_SAFETY_EmergencyIncidentId1",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EmergencyIncidentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_EMPLOYEE_SAFETY_EmployeeId1",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_EMPLOYEE_SAFETY_SchoolId1",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFE_CLOSURE",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EMERGENCY_CLOSURE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFE_HOSTING",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EMERGENCY_HOSTING_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFE_INCIDENT",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EMERGENCY_INCIDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFE_JOURNAL",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "JOURNAL_ENTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFE_SCHOOL",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_FINANCIAL_EXPENSE_EmergencyClosureId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EmergencyClosureId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_FINANCIAL_EXPENSE_EmergencyHostingId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EmergencyHostingId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_FINANCIAL_EXPENSE_EmergencyIncidentId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EmergencyIncidentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_FINANCIAL_EXPENSE_JournalEntryId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "JournalEntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_FINANCIAL_EXPENSE_SchoolId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EHW_HOSTING",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "EMERGENCY_HOSTING_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EHW_SCHOOL",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EHW_WAREHOUSE",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_HOSTING_WAREHOUSE_EmergencyHostingId1",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "EmergencyHostingId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_HOSTING_WAREHOUSE_SchoolId1",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_HOSTING_WAREHOUSE_WarehouseId1",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "WarehouseId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_ESSR_INCIDENT_STATUS",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                columns: new[] { "EMERGENCY_INCIDENT_ID", "SAFETY_STATUS" });

            migrationBuilder.CreateIndex(
                name: "IDX_CM_ESSR_SCHOOL",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_ESSR_STUDENT",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_STUDENT_SAFETY_EmergencyIncidentId1",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "EmergencyIncidentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_STUDENT_SAFETY_SchoolId1",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMERGENCY_STUDENT_SAFETY_StudentId1",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_ETCL_EMPLOYEE",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_ETCL_OFFERING",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "TRAINING_COURSE_OFFERING_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_ETCL_TRAINING",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EMPLOYEE_TRAINING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMPLOYEE_TRAINING_COURSE_EmployeeId1",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMPLOYEE_TRAINING_COURSE_EmployeeTrainingId1",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EmployeeTrainingId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMPLOYEE_TRAINING_COURSE_SCHOOL_ID",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMPLOYEE_TRAINING_COURSE_SchoolId1",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_EMPLOYEE_TRAINING_COURSE_TrainingCourseOfferingId1",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "TrainingCourseOfferingId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFL_ACCOUNT",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "STUDENT_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFL_ENROLLMENT",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "ENROLLMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFL_SCHOOL",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_EFL_STUDENT",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ENROLLMENT_FINANCIAL_LINK_EnrollmentId1",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "EnrollmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ENROLLMENT_FINANCIAL_LINK_SchoolId1",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ENROLLMENT_FINANCIAL_LINK_StudentAccountId1",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "StudentAccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_ENROLLMENT_FINANCIAL_LINK_StudentId1",
                table: "CM_ENROLLMENT_FINANCIAL_LINK",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_KFPL_JOURNAL",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "JOURNAL_ENTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_KFPL_KPI",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "KPI_METRIC_RECORD_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_KFPL_PAYROLL_RUN",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "PAYROLL_RUN_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_KFPL_SCHOOL",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_KPI_FINANCIAL_PERIOD_JournalEntryId1",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "JournalEntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_KPI_FINANCIAL_PERIOD_KpiMetricRecordId1",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "KpiMetricRecordId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_KPI_FINANCIAL_PERIOD_PayrollRunId1",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "PayrollRunId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_KPI_FINANCIAL_PERIOD_SchoolId1",
                table: "CM_KPI_FINANCIAL_PERIOD",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PIS_INVOICE",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "FEE_INVOICE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PIS_STUDENT",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PIS_VOUCHER",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "PAYMENT_VOUCHER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYMENT_INVOICE_SETTLEMENT_FeeInvoiceId1",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "FeeInvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYMENT_INVOICE_SETTLEMENT_PaymentVoucherId1",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "PaymentVoucherId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYMENT_INVOICE_SETTLEMENT_SCHOOL_ID",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYMENT_INVOICE_SETTLEMENT_SchoolId1",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYMENT_INVOICE_SETTLEMENT_StudentId1",
                table: "CM_PAYMENT_INVOICE_SETTLEMENT",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PJL_DETAIL",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "PAYROLL_DETAIL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PJL_EMPLOYEE",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PJL_JOURNAL",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "JOURNAL_ENTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_PJL_RUN",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "PAYROLL_RUN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYROLL_JOURNAL_LINK_EmployeeId1",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYROLL_JOURNAL_LINK_JournalEntryId1",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "JournalEntryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYROLL_JOURNAL_LINK_PayrollDetailId1",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "PayrollDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_PAYROLL_JOURNAL_LINK_PayrollRunId1",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "PayrollRunId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_RSSL_SCHOOL_MOD",
                table: "CM_REPORT_SNAPSHOT_SOURCE",
                columns: new[] { "SCHOOL_ID", "SOURCE_MODULE" });

            migrationBuilder.CreateIndex(
                name: "IDX_CM_RSSL_SNAPSHOT",
                table: "CM_REPORT_SNAPSHOT_SOURCE",
                column: "REPORT_SNAPSHOT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_REPORT_SNAPSHOT_SOURCE_SchoolId1",
                table: "CM_REPORT_SNAPSHOT_SOURCE",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_REPORT_SNAPSHOT_SOURCE_StatisticalReportSnapshotId1",
                table: "CM_REPORT_SNAPSHOT_SOURCE",
                column: "StatisticalReportSnapshotId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_SCAL_ASSET",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "SCHOOL_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_SCAL_CUSTODY",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "STUDENT_INVENTORY_CUSTODY_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_SCAL_ITEM",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "INVENTORY_ITEM_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_SCAL_STUDENT",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_CUSTODY_ASSET_InventoryItemId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "InventoryItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_CUSTODY_ASSET_SCHOOL_ID",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_CUSTODY_ASSET_SchoolAssetId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "SchoolAssetId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_CUSTODY_ASSET_SchoolId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_CUSTODY_ASSET_StudentId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_CUSTODY_ASSET_StudentInventoryCustodyId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "StudentInventoryCustodyId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_STRL_SERVICE",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "TRANSPORTATION_SERVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_STRL_STUDENT",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_STRL_SUBSCRIPTION",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "TRANSPORT_SUBSCRIPTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_TRANSPORT_ROUTE_SCHOOL_ID",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_TRANSPORT_ROUTE_SchoolId1",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_TRANSPORT_ROUTE_StudentId1",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_TRANSPORT_ROUTE_StudentTransportationSubscriptionId1",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "StudentTransportationSubscriptionId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_STUDENT_TRANSPORT_ROUTE_TransportationServiceId1",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "TransportationServiceId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_UEIL_EMPLOYEE",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_UEIL_SCHOOL",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_UEIL_USER",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "SYSTEM_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_DIRECTORATE_ID",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "DIRECTORATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_DirectorateId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "DirectorateId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_EmployeeId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_ORGANIZATIONAL_SECTOR_ID",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "ORGANIZATIONAL_SECTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_OrganizationalSectorId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "OrganizationalSectorId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_SchoolId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_EMPLOYEE_IDENTITY_SystemUserId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "SystemUserId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_UGIL_GUARDIAN",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "GUARDIAN_RELATIONSHIP_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_UGIL_STUDENT",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_UGIL_USER",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "SYSTEM_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_GUARDIAN_IDENTITY_GuardianRelationshipId",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "GuardianRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_GUARDIAN_IDENTITY_SCHOOL_ID",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_GUARDIAN_IDENTITY_SchoolId1",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_GUARDIAN_IDENTITY_StudentId1",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_GUARDIAN_IDENTITY_SystemUserId1",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "SystemUserId1");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_USIL_SCHOOL",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_USIL_STUDENT",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_CM_USIL_USER",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "SYSTEM_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_STUDENT_IDENTITY_SchoolId1",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_STUDENT_IDENTITY_StudentId1",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CM_USER_STUDENT_IDENTITY_SystemUserId1",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "SystemUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMember_CommitteeId",
                table: "CommitteeMember",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMember_EmployeeId",
                table: "CommitteeMember",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMUNITY_PARTNERSHIP_RESPONSIBLE_EMPLOYEE_ID",
                table: "COMMUNITY_PARTNERSHIP",
                column: "RESPONSIBLE_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMMUNITY_PARTNERSHIP_SchoolId",
                table: "COMMUNITY_PARTNERSHIP",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_COMPARATIVE_REPORT_SchoolId",
                table: "COMPARATIVE_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumTextbookDistribution_SchoolId",
                table: "CurriculumTextbookDistribution",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumTextbookDistribution_SubjectId",
                table: "CurriculumTextbookDistribution",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DirectorateId",
                table: "Department",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_HeadOfDepartmentEmployeeId1",
                table: "Department",
                column: "HeadOfDepartmentEmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Department_OrganizationalSectorId",
                table: "Department",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_SchoolId",
                table: "Department",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedAcademicWarningLog_IssuedByEmployeeId",
                table: "DetailedAcademicWarningLog",
                column: "IssuedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedAcademicWarningLog_StudentId",
                table: "DetailedAcademicWarningLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedAcademicWarningLog_SubjectId",
                table: "DetailedAcademicWarningLog",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalSupervisionVisit_DirectorateId",
                table: "EducationalSupervisionVisit",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalSupervisionVisit_DirectorateId1",
                table: "EducationalSupervisionVisit",
                column: "DirectorateId1");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalSupervisionVisit_SchoolId",
                table: "EducationalSupervisionVisit",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalSupervisionVisit_SchoolId1",
                table: "EducationalSupervisionVisit",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalSupervisionVisit_SupervisorEmployeeId",
                table: "EducationalSupervisionVisit",
                column: "SupervisorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalSupervisionVisit_VisitedTeacherEmployeeId",
                table: "EducationalSupervisionVisit",
                column: "VisitedTeacherEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_CLOSURE_SchoolId",
                table: "EMERGENCY_CLOSURE",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_HOSTING_REPORTED_BY_USER_ID",
                table: "EMERGENCY_HOSTING",
                column: "REPORTED_BY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_HOSTING_SchoolId",
                table: "EMERGENCY_HOSTING",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_INCIDENT_EMERGENCY_PLAN_ID",
                table: "EMERGENCY_INCIDENT",
                column: "EMERGENCY_PLAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_INCIDENT_REPORTED_BY_USER_ID",
                table: "EMERGENCY_INCIDENT",
                column: "REPORTED_BY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_INCIDENT_SchoolId",
                table: "EMERGENCY_INCIDENT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_INCIDENT_SchoolId1",
                table: "EMERGENCY_INCIDENT",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_PLAN_SchoolId_PLAN_CODE",
                table: "EMERGENCY_PLAN",
                columns: new[] { "SchoolId", "PLAN_CODE" });

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCY_PLAN_SchoolId1",
                table: "EMERGENCY_PLAN",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DepartmentId",
                table: "EMPLOYEE",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DirectorateId",
                table: "EMPLOYEE",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DirectorateId1",
                table: "EMPLOYEE",
                column: "DirectorateId1");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_OrganizationalSectorId",
                table: "EMPLOYEE",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_SCHOOL_ID",
                table: "EMPLOYEE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAdditionalTask_DirectorateId",
                table: "EmployeeAdditionalTask",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAdditionalTask_EmployeeId",
                table: "EmployeeAdditionalTask",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAdditionalTask_OrganizationalSectorId",
                table: "EmployeeAdditionalTask",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAdditionalTask_SchoolId",
                table: "EmployeeAdditionalTask",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_DirectorateId",
                table: "EmployeeAttendance",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_EmployeeId",
                table: "EmployeeAttendance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_OrganizationalSectorId",
                table: "EmployeeAttendance",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_SchoolId",
                table: "EmployeeAttendance",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommittee_DirectorateId",
                table: "EmployeeCommittee",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommittee_OrganizationalSectorId",
                table: "EmployeeCommittee",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommittee_SchoolId",
                table: "EmployeeCommittee",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocument_EmployeeId",
                table: "EmployeeDocument",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_EmployeeId",
                table: "EmployeeExternalTransfer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_FromDirectorateId",
                table: "EmployeeExternalTransfer",
                column: "FromDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_FromOrganizationalSectorId",
                table: "EmployeeExternalTransfer",
                column: "FromOrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_FromSchoolId",
                table: "EmployeeExternalTransfer",
                column: "FromSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_ToDirectorateId",
                table: "EmployeeExternalTransfer",
                column: "ToDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_ToOrganizationalSectorId",
                table: "EmployeeExternalTransfer",
                column: "ToOrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExternalTransfer_ToSchoolId",
                table: "EmployeeExternalTransfer",
                column: "ToSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialTransaction_ApprovedByEmployeeId",
                table: "EmployeeFinancialTransaction",
                column: "ApprovedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialTransaction_DirectorateId",
                table: "EmployeeFinancialTransaction",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialTransaction_EmployeeId",
                table: "EmployeeFinancialTransaction",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialTransaction_OrganizationalSectorId",
                table: "EmployeeFinancialTransaction",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialTransaction_SchoolId",
                table: "EmployeeFinancialTransaction",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInternalTransfer_DirectorateId",
                table: "EmployeeInternalTransfer",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInternalTransfer_EmployeeId",
                table: "EmployeeInternalTransfer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInternalTransfer_OrganizationalSectorId",
                table: "EmployeeInternalTransfer",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInternalTransfer_SchoolId",
                table: "EmployeeInternalTransfer",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInventoryCustody_AssetId",
                table: "EmployeeInventoryCustody",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInventoryCustody_EmployeeId",
                table: "EmployeeInventoryCustody",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_DirectorateId",
                table: "EmployeeLeave",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_EmployeeId",
                table: "EmployeeLeave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_OrganizationalSectorId",
                table: "EmployeeLeave",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_SchoolId",
                table: "EmployeeLeave",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeeting_DirectorateId",
                table: "EmployeeMeeting",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeeting_OrganizationalSectorId",
                table: "EmployeeMeeting",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeeting_SchoolId",
                table: "EmployeeMeeting",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMentor_DirectorateId",
                table: "EmployeeMentor",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMentor_MenteeEmployeeId",
                table: "EmployeeMentor",
                column: "MenteeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMentor_MentorEmployeeId",
                table: "EmployeeMentor",
                column: "MentorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMentor_OrganizationalSectorId",
                table: "EmployeeMentor",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMentor_SchoolId",
                table: "EmployeeMentor",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayroll_DirectorateId",
                table: "EmployeePayroll",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayroll_EmployeeId",
                table: "EmployeePayroll",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayroll_OrganizationalSectorId",
                table: "EmployeePayroll",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayroll_SchoolId",
                table: "EmployeePayroll",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayrollFinancialContract_EmployeeId",
                table: "EmployeePayrollFinancialContract",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayrollFinancialContract_EmployeePayrollId",
                table: "EmployeePayrollFinancialContract",
                column: "EmployeePayrollId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayrollFinancialContract_FinancialAuditorEmployeeId",
                table: "EmployeePayrollFinancialContract",
                column: "FinancialAuditorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayrollFinancialContract_OrganizationalSectorId",
                table: "EmployeePayrollFinancialContract",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformanceReview_DirectorateId",
                table: "EmployeePerformanceReview",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformanceReview_EmployeeId",
                table: "EmployeePerformanceReview",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformanceReview_OrganizationalSectorId",
                table: "EmployeePerformanceReview",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformanceReview_SchoolId",
                table: "EmployeePerformanceReview",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTermination_DirectorateId",
                table: "EmployeeTermination",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTermination_EmployeeId",
                table: "EmployeeTermination",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTermination_OrganizationalSectorId",
                table: "EmployeeTermination",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTermination_SchoolId",
                table: "EmployeeTermination",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_DirectorateId",
                table: "EmployeeTraining",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_EmployeeId",
                table: "EmployeeTraining",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_OrganizationalSectorId",
                table: "EmployeeTraining",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTraining_SchoolId",
                table: "EmployeeTraining",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViolation_DirectorateId",
                table: "EmployeeViolation",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViolation_EmployeeId",
                table: "EmployeeViolation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViolation_OrganizationalSectorId",
                table: "EmployeeViolation",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViolation_SchoolId",
                table: "EmployeeViolation",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDistributionTimetable_AssistantProctorEmployeeId",
                table: "ExamDistributionTimetable",
                column: "AssistantProctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDistributionTimetable_ClassroomId",
                table: "ExamDistributionTimetable",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDistributionTimetable_FacilityId",
                table: "ExamDistributionTimetable",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDistributionTimetable_ProctorEmployeeId",
                table: "ExamDistributionTimetable",
                column: "ProctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDistributionTimetable_SchoolId",
                table: "ExamDistributionTimetable",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDistributionTimetable_SubjectId",
                table: "ExamDistributionTimetable",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EXCEPTIONAL_STATISTICS_REPORT_SchoolId",
                table: "EXCEPTIONAL_STATISTICS_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EXTERNAL_COMPLIANCE_REPORT_SchoolId",
                table: "EXTERNAL_COMPLIANCE_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EXTERNAL_PARTICIPATION_SchoolId",
                table: "EXTERNAL_PARTICIPATION",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeInvoice_FeeStructureId",
                table: "FeeInvoice",
                column: "FeeStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeInvoice_StudentId",
                table: "FeeInvoice",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeStructure_SchoolId",
                table: "FeeStructure",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_GAP_ANALYSIS_REPORT_SchoolId",
                table: "GAP_ANALYSIS_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_GOVERNANCE_RBAC_RULE_RoleId",
                table: "GOVERNANCE_RBAC_RULE",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingScaleBound_SchoolId",
                table: "GradingScaleBound",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_ITEM_EmployeeId",
                table: "INVENTORY_ITEM",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_ITEM_WAREHOUSE_ID",
                table: "INVENTORY_ITEM",
                column: "WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JOURNAL_ENTRY_ENTRY_NUMBER",
                table: "JOURNAL_ENTRY",
                column: "ENTRY_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JOURNAL_ENTRY_SchoolId",
                table: "JOURNAL_ENTRY",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_JOURNAL_ENTRY_LINE_ACCOUNT_ID",
                table: "JOURNAL_ENTRY_LINE",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JOURNAL_ENTRY_LINE_JOURNAL_ENTRY_ID",
                table: "JOURNAL_ENTRY_LINE",
                column: "JOURNAL_ENTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPI_METRIC_RECORD_KpiConfigId",
                table: "KPI_METRIC_RECORD",
                column: "KpiConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttendanceRecord_EmployeeId",
                table: "MeetingAttendanceRecord",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttendanceRecord_MeetingId",
                table: "MeetingAttendanceRecord",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialCircular_IssuerEmployeeId",
                table: "OfficialCircular",
                column: "IssuerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalSector_DirectorateId",
                table: "OrganizationalSector",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalSector_DirectorateId1",
                table: "OrganizationalSector",
                column: "DirectorateId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalSector_HeadOfSectorEmployeeId",
                table: "OrganizationalSector",
                column: "HeadOfSectorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalSector_ParentSectorId",
                table: "OrganizationalSector",
                column: "ParentSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalSector_SchoolId",
                table: "OrganizationalSector",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalSector_SchoolId1",
                table: "OrganizationalSector",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_VOUCHER_ACCOUNT_ID",
                table: "PAYMENT_VOUCHER",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_VOUCHER_SchoolId",
                table: "PAYMENT_VOUCHER",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_VOUCHER_VendorId",
                table: "PAYMENT_VOUCHER",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_VOUCHER_VOUCHER_NUMBER",
                table: "PAYMENT_VOUCHER",
                column: "VOUCHER_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLL_DETAIL_EMPLOYEE_ID",
                table: "PAYROLL_DETAIL",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLL_DETAIL_PAYROLL_RUN_ID",
                table: "PAYROLL_DETAIL",
                column: "PAYROLL_RUN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYROLL_RUN_RUN_NUMBER",
                table: "PAYROLL_RUN",
                column: "RUN_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSION_TYPE_TYPE_CODE",
                table: "PERMISSION_TYPE",
                column: "TYPE_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PERSON_NATIONAL_ID",
                table: "PERSON",
                column: "NATIONAL_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreventiveMaintenanceSchedule_AssetId",
                table: "PreventiveMaintenanceSchedule",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_SchoolId",
                table: "PurchaseOrder",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ConvertedToStudentId",
                table: "Registrations",
                column: "ConvertedToStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ParentId",
                table: "Registrations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ParentId_SchoolId_AcademicYearId_RequestedGradeLevelId",
                table: "Registrations",
                columns: new[] { "ParentId", "SchoolId", "AcademicYearId", "RequestedGradeLevelId" },
                unique: true,
                filter: "RequestStatus != 3");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ReviewedByUserId",
                table: "Registrations",
                column: "ReviewedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SchoolId",
                table: "Registrations",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_REMEDIATION_PLAN_APPROVED_BY_USER_ID",
                table: "REMEDIATION_PLAN",
                column: "APPROVED_BY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REMEDIATION_PLAN_EXECUTION_LEAD_EMP_ID",
                table: "REMEDIATION_PLAN",
                column: "EXECUTION_LEAD_EMP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REMEDIATION_PLAN_RELATED_DEFICIT_ID",
                table: "REMEDIATION_PLAN",
                column: "RELATED_DEFICIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REMEDIATION_PLAN_RELATED_SURPLUS_ID",
                table: "REMEDIATION_PLAN",
                column: "RELATED_SURPLUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REMEDIATION_PLAN_SchoolId",
                table: "REMEDIATION_PLAN",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_REPORT_APPROVAL_SystemReportId",
                table: "REPORT_APPROVAL",
                column: "SystemReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_MATRIX_ROLE_CODE",
                table: "ROLE_MATRIX",
                column: "ROLE_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSION_PermissionId",
                table: "ROLE_PERMISSION",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSION_RoleId_PermissionId",
                table: "ROLE_PERMISSION",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.CreateIndex(
                name: "IX_SAFETY_SECURITY_REPORT_APPROVED_BY_USER_ID",
                table: "SAFETY_SECURITY_REPORT",
                column: "APPROVED_BY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SAFETY_SECURITY_REPORT_SchoolId",
                table: "SAFETY_SECURITY_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_DirectorateId",
                table: "SCHOOL",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_EducationalStageId",
                table: "SCHOOL",
                column: "EducationalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_SCHOOL_CODE",
                table: "SCHOOL",
                column: "SCHOOL_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_AWARD_SchoolId",
                table: "SCHOOL_AWARD",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_DEFICIT_SchoolId",
                table: "SCHOOL_DEFICIT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_FINANCIAL_SUMMARY_REPORT_SchoolId",
                table: "SCHOOL_FINANCIAL_SUMMARY_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_MERGER_TARGET_SCHOOL_ID",
                table: "SCHOOL_MERGER",
                column: "TARGET_SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_STATISTICS_DRAFT_SchoolId",
                table: "SCHOOL_STATISTICS_DRAFT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_SURPLUS_SchoolId",
                table: "SCHOOL_SURPLUS",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAccreditationLog_SchoolId",
                table: "SchoolAccreditationLog",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAnnouncementLog_PublishedByEmployeeId",
                table: "SchoolAnnouncementLog",
                column: "PublishedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAnnouncementLog_SchoolId",
                table: "SchoolAnnouncementLog",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAsset_AssetCategoryId",
                table: "SchoolAsset",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAsset_EmployeeId",
                table: "SchoolAsset",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAsset_LocationId",
                table: "SchoolAsset",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAsset_SchoolId",
                table: "SchoolAsset",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAsset_WarrantyContractId",
                table: "SchoolAsset",
                column: "WarrantyContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCanteenItem_FacilityId",
                table: "SchoolCanteenItem",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCanteenItem_SchoolId",
                table: "SchoolCanteenItem",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEventCalendar_OrganizerEmployeeId",
                table: "SchoolEventCalendar",
                column: "OrganizerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEventCalendar_SchoolId",
                table: "SchoolEventCalendar",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFacility_AssignedSupervisorId",
                table: "SchoolFacility",
                column: "AssignedSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFacility_SchoolId",
                table: "SchoolFacility",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolOperationalBudgetLog_DirectorateId",
                table: "SchoolOperationalBudgetLog",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolOperationalBudgetLog_SchoolId",
                table: "SchoolOperationalBudgetLog",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolShift_SchoolId",
                table: "SchoolShift",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTransportationRoute_BusSupervisorEmployeeId",
                table: "SchoolTransportationRoute",
                column: "BusSupervisorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTransportationRoute_DriverEmployeeId",
                table: "SchoolTransportationRoute",
                column: "DriverEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTransportationRoute_SchoolId",
                table: "SchoolTransportationRoute",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfServicePortalRequest_EmployeeId",
                table: "SelfServicePortalRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCustodySummary_EmployeeId",
                table: "StaffCustodySummary",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STATISTICAL_REPORT_SNAPSHOT_AcademicLockPeriodId",
                table: "STATISTICAL_REPORT_SNAPSHOT",
                column: "AcademicLockPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_STATISTICAL_REPORT_SNAPSHOT_AcademicLockPeriodId1",
                table: "STATISTICAL_REPORT_SNAPSHOT",
                column: "AcademicLockPeriodId1");

            migrationBuilder.CreateIndex(
                name: "IX_STATISTICAL_REPORT_SNAPSHOT_SchoolId_REPORT_CODE",
                table: "STATISTICAL_REPORT_SNAPSHOT",
                columns: new[] { "SchoolId", "REPORT_CODE" });

            migrationBuilder.CreateIndex(
                name: "IX_STATISTICAL_REPORT_SNAPSHOT_SchoolId1",
                table: "STATISTICAL_REPORT_SNAPSHOT",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_STATISTICS_ARCHIVE_SubmittedStatisticsId",
                table: "STATISTICS_ARCHIVE",
                column: "SubmittedStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_STATISTICS_REPORTS_ARCHIVE_SchoolId",
                table: "STATISTICS_REPORTS_ARCHIVE",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ClassroomId",
                table: "STUDENT",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_GUARDIAN_ID",
                table: "STUDENT",
                column: "GUARDIAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_SCHOOL_ID",
                table: "STUDENT",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_ApprovedByEmployeeId",
                table: "STUDENT_TRANSFER_LOG",
                column: "ApprovedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_FromSchoolId",
                table: "STUDENT_TRANSFER_LOG",
                column: "FromSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_FromSchoolId1",
                table: "STUDENT_TRANSFER_LOG",
                column: "FromSchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_StudentId",
                table: "STUDENT_TRANSFER_LOG",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_StudentId1",
                table: "STUDENT_TRANSFER_LOG",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_ToSchoolId",
                table: "STUDENT_TRANSFER_LOG",
                column: "ToSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_ToSchoolId1",
                table: "STUDENT_TRANSFER_LOG",
                column: "ToSchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_TRANSFER_LOG_TransferDate",
                table: "STUDENT_TRANSFER_LOG",
                column: "TransferDate");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAbsenceExcusal_ReviewedByEmployeeId",
                table: "StudentAbsenceExcusal",
                column: "ReviewedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAbsenceExcusal_StudentId",
                table: "StudentAbsenceExcusal",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccount_StudentId",
                table: "StudentAccount",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityParticipation_SchoolId",
                table: "StudentActivityParticipation",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityParticipation_StudentId",
                table: "StudentActivityParticipation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityParticipation_SupervisorEmployeeId",
                table: "StudentActivityParticipation",
                column: "SupervisorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_ClassroomId",
                table: "StudentAssessment",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_EvaluatedByEmployeeId",
                table: "StudentAssessment",
                column: "EvaluatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_StudentId",
                table: "StudentAssessment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_SubjectId",
                table: "StudentAssessment",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignmentSubmission_ClassroomId",
                table: "StudentAssignmentSubmission",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignmentSubmission_GradedByEmployeeId",
                table: "StudentAssignmentSubmission",
                column: "GradedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignmentSubmission_StudentId",
                table: "StudentAssignmentSubmission",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignmentSubmission_SubjectId",
                table: "StudentAssignmentSubmission",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttachment_StudentId",
                table: "StudentAttachment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttachment_UploadedByEmployeeId",
                table: "StudentAttachment",
                column: "UploadedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCanteenPurchaseLog_SchoolCanteenItemId",
                table: "StudentCanteenPurchaseLog",
                column: "SchoolCanteenItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCanteenPurchaseLog_ServedByEmployeeId",
                table: "StudentCanteenPurchaseLog",
                column: "ServedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCanteenPurchaseLog_StudentId",
                table: "StudentCanteenPurchaseLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDailyAttendanceSummary_StudentId",
                table: "StudentDailyAttendanceSummary",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDisciplinaryHistory_BehavioralLogId",
                table: "StudentDisciplinaryHistory",
                column: "BehavioralLogId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDisciplinaryHistory_ExecutedByEmployeeId",
                table: "StudentDisciplinaryHistory",
                column: "ExecutedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDisciplinaryHistory_StudentId",
                table: "StudentDisciplinaryHistory",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_ClassroomId",
                table: "StudentEnrollment",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_SchoolId",
                table: "StudentEnrollment",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_StudentId",
                table: "StudentEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExemplaryRecognition_StudentId",
                table: "StudentExemplaryRecognition",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExemption_ApprovedByEmployeeId",
                table: "StudentExemption",
                column: "ApprovedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExemption_StudentId",
                table: "StudentExemption",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardianRelationship_GuardianId",
                table: "StudentGuardianRelationship",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardianRelationship_StudentId",
                table: "StudentGuardianRelationship",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHealthRecord_StudentId",
                table: "StudentHealthRecord",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentityDocument_StudentId",
                table: "StudentIdentityDocument",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentityDocument_VerifiedByEmployeeId",
                table: "StudentIdentityDocument",
                column: "VerifiedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInventoryCustody_DeliveredByEmployeeId",
                table: "StudentInventoryCustody",
                column: "DeliveredByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInventoryCustody_SchoolAssetId",
                table: "StudentInventoryCustody",
                column: "SchoolAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInventoryCustody_StudentId",
                table: "StudentInventoryCustody",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMedicalAllergyLog_StudentId",
                table: "StudentMedicalAllergyLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentConferenceReservation_GuardianId",
                table: "StudentParentConferenceReservation",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentConferenceReservation_SchoolEventCalendarId",
                table: "StudentParentConferenceReservation",
                column: "SchoolEventCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentConferenceReservation_StudentId",
                table: "StudentParentConferenceReservation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentConferenceReservation_TeacherEmployeeId",
                table: "StudentParentConferenceReservation",
                column: "TeacherEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPsychologicalCounselingLog_CounselorEmployeeId",
                table: "StudentPsychologicalCounselingLog",
                column: "CounselorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPsychologicalCounselingLog_StudentId",
                table: "StudentPsychologicalCounselingLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSkillAndTalentRecord_MentorEmployeeId",
                table: "StudentSkillAndTalentRecord",
                column: "MentorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSkillAndTalentRecord_StudentId",
                table: "StudentSkillAndTalentRecord",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransportationSubscription_SchoolTransportationRouteId",
                table: "StudentTransportationSubscription",
                column: "SchoolTransportationRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransportationSubscription_StudentId",
                table: "StudentTransportationSubscription",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SchoolId",
                table: "Subject",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SUBMITTED_STATISTICS_StatisticsDraftId",
                table: "SUBMITTED_STATISTICS",
                column: "StatisticsDraftId");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_AUDIT_LOG_UserId_ACTION_TIMESTAMP",
                table: "SYSTEM_AUDIT_LOG",
                columns: new[] { "UserId", "ACTION_TIMESTAMP" });

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_PERMISSION_PERMISSION_KEY",
                table: "SYSTEM_PERMISSION",
                column: "PERMISSION_KEY",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_PERMISSION_PERMISSION_TYPE_ID",
                table: "SYSTEM_PERMISSION",
                column: "PERMISSION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_REPORT_SchoolId",
                table: "SYSTEM_REPORT",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_ROLE_PARENT_ROLE_ID",
                table: "SYSTEM_ROLE",
                column: "PARENT_ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_ROLE_ROLE_CODE",
                table: "SYSTEM_ROLE",
                column: "ROLE_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_USER_EmployeeId",
                table: "SYSTEM_USER",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_USER_SCHOOL_ID",
                table: "SYSTEM_USER",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_USER_StudentId",
                table: "SYSTEM_USER",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchedule_DirectorateId",
                table: "TeacherSchedule",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchedule_OrganizationalSectorId",
                table: "TeacherSchedule",
                column: "OrganizationalSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchedule_SchoolId",
                table: "TeacherSchedule",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchedule_TeacherEmployeeId",
                table: "TeacherSchedule",
                column: "TeacherEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourseOffering_DirectorateId",
                table: "TrainingCourseOffering",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourseOffering_SchoolId",
                table: "TrainingCourseOffering",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTATION_SERVICE_BUS_ASSET_ID",
                table: "TRANSPORTATION_SERVICE",
                column: "BUS_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTATION_SERVICE_DRIVER_EMPLOYEE_ID",
                table: "TRANSPORTATION_SERVICE",
                column: "DRIVER_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTATION_SERVICE_SchoolId",
                table: "TRANSPORTATION_SERVICE",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTATION_SERVICE_SUPERVISOR_EMPLOYEE_ID",
                table: "TRANSPORTATION_SERVICE",
                column: "SUPERVISOR_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsageViolation_AssetId",
                table: "UsageViolation",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ACTIVITY_LOG_UserId_ACTIVITY_TIMESTAMP",
                table: "USER_ACTIVITY_LOG",
                columns: new[] { "UserId", "ACTIVITY_TIMESTAMP" });

            migrationBuilder.CreateIndex(
                name: "IX_USER_DIRECT_PERMISSION_PermissionId",
                table: "USER_DIRECT_PERMISSION",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_DIRECT_PERMISSION_UserId",
                table: "USER_DIRECT_PERMISSION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ASSIGNMENT_RoleId",
                table: "USER_ROLE_ASSIGNMENT",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ASSIGNMENT_UserId_RoleId",
                table: "USER_ROLE_ASSIGNMENT",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_VisitorEntryLog_HostEmployeeId",
                table: "VisitorEntryLog",
                column: "HostEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorEntryLog_SchoolId",
                table: "VisitorEntryLog",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorEntryLog_SecurityOfficerEmployeeId",
                table: "VisitorEntryLog",
                column: "SecurityOfficerEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ACADEMIC_LOCK_PERIOD_EMPLOYEE_InitiatedByEmployeeId",
                table: "ACADEMIC_LOCK_PERIOD",
                column: "InitiatedByEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicBranchConfigLog_EMPLOYEE_ModifiedByEmployeeId",
                table: "AcademicBranchConfigLog",
                column: "ModifiedByEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDecision_EMPLOYEE_EmployeeId",
                table: "AppointmentDecision",
                column: "EmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_CLASSROOM_ClassroomId",
                table: "AssetAllocation",
                column: "ClassroomId",
                principalTable: "CLASSROOM",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_EMPLOYEE_AssignedToEmployeeId",
                table: "AssetAllocation",
                column: "AssignedToEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_INVENTORY_ITEM_InventoryItemId",
                table: "AssetAllocation",
                column: "InventoryItemId",
                principalTable: "INVENTORY_ITEM",
                principalColumn: "INVENTORY_ITEM_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAssignment_SchoolAsset_AssetId",
                table: "AssetAssignment",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInspectionLog_SchoolAsset_AssetId",
                table: "AssetInspectionLog",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLoan_SchoolAsset_AssetId",
                table: "AssetLoan",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMaintenanceTicket_SchoolAsset_AssetId",
                table: "AssetMaintenanceTicket",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovementHistory_SchoolAsset_AssetId",
                table: "AssetMovementHistory",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetSuspensionRequest_SchoolAsset_AssetId",
                table: "AssetSuspensionRequest",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTransferRequest_SchoolAsset_AssetId",
                table: "AssetTransferRequest",
                column: "AssetId",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceDetail_CLASSROOM_ClassroomId",
                table: "AttendanceDetail",
                column: "ClassroomId",
                principalTable: "CLASSROOM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceDetail_EMPLOYEE_RecordedByEmployeeId",
                table: "AttendanceDetail",
                column: "RecordedByEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceDetail_STUDENT_StudentId",
                table: "AttendanceDetail",
                column: "StudentId",
                principalTable: "STUDENT",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BehavioralLog_EMPLOYEE_RecordedByEmployeeId",
                table: "BehavioralLog",
                column: "RecordedByEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BehavioralLog_STUDENT_StudentId",
                table: "BehavioralLog",
                column: "StudentId",
                principalTable: "STUDENT",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CLASSROOM_EMPLOYEE_HomeroomTeacherEmployeeId",
                table: "CLASSROOM",
                column: "HomeroomTeacherEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedule_EMPLOYEE_AssignedEmployeeId",
                table: "ClassSchedule",
                column: "AssignedEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_ASSET_FINANCIAL_JOURNAL_SchoolAsset_SCHOOL_ASSET_ID",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "SCHOOL_ASSET_ID",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_ASSET_FINANCIAL_JOURNAL_SchoolAsset_SchoolAssetId1",
                table: "CM_ASSET_FINANCIAL_JOURNAL",
                column: "SchoolAssetId1",
                principalTable: "SchoolAsset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_ASSET_IMPACT_EMERGENCY_INCIDENT_EMERGENCY_INCIDENT_ID",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "EMERGENCY_INCIDENT_ID",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_ASSET_IMPACT_EMERGENCY_INCIDENT_EmergencyIncidentId1",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "EmergencyIncidentId1",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_ASSET_IMPACT_SchoolAsset_SCHOOL_ASSET_ID",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "SCHOOL_ASSET_ID",
                principalTable: "SchoolAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_ASSET_IMPACT_SchoolAsset_SchoolAssetId1",
                table: "CM_EMERGENCY_ASSET_IMPACT",
                column: "SchoolAssetId1",
                principalTable: "SchoolAsset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_EMPLOYEE_SAFETY_EMERGENCY_INCIDENT_EMERGENCY_INCIDENT_ID",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EMERGENCY_INCIDENT_ID",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_EMPLOYEE_SAFETY_EMERGENCY_INCIDENT_EmergencyIncidentId1",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EmergencyIncidentId1",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_EMPLOYEE_SAFETY_EMPLOYEE_EMPLOYEE_ID",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EMPLOYEE_ID",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_EMPLOYEE_SAFETY_EMPLOYEE_EmployeeId1",
                table: "CM_EMERGENCY_EMPLOYEE_SAFETY",
                column: "EmployeeId1",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_EMERGENCY_HOSTING_EMERGENCY_HOSTING_ID",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EMERGENCY_HOSTING_ID",
                principalTable: "EMERGENCY_HOSTING",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_EMERGENCY_HOSTING_EmergencyHostingId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EmergencyHostingId1",
                principalTable: "EMERGENCY_HOSTING",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_EMERGENCY_INCIDENT_EMERGENCY_INCIDENT_ID",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EMERGENCY_INCIDENT_ID",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_FINANCIAL_EXPENSE_EMERGENCY_INCIDENT_EmergencyIncidentId1",
                table: "CM_EMERGENCY_FINANCIAL_EXPENSE",
                column: "EmergencyIncidentId1",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_HOSTING_WAREHOUSE_EMERGENCY_HOSTING_EMERGENCY_HOSTING_ID",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "EMERGENCY_HOSTING_ID",
                principalTable: "EMERGENCY_HOSTING",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_HOSTING_WAREHOUSE_EMERGENCY_HOSTING_EmergencyHostingId1",
                table: "CM_EMERGENCY_HOSTING_WAREHOUSE",
                column: "EmergencyHostingId1",
                principalTable: "EMERGENCY_HOSTING",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_STUDENT_SAFETY_EMERGENCY_INCIDENT_EMERGENCY_INCIDENT_ID",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "EMERGENCY_INCIDENT_ID",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMERGENCY_STUDENT_SAFETY_EMERGENCY_INCIDENT_EmergencyIncidentId1",
                table: "CM_EMERGENCY_STUDENT_SAFETY",
                column: "EmergencyIncidentId1",
                principalTable: "EMERGENCY_INCIDENT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMPLOYEE_TRAINING_COURSE_EMPLOYEE_EMPLOYEE_ID",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EMPLOYEE_ID",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMPLOYEE_TRAINING_COURSE_EMPLOYEE_EmployeeId1",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EmployeeId1",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMPLOYEE_TRAINING_COURSE_EmployeeTraining_EMPLOYEE_TRAINING_ID",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EMPLOYEE_TRAINING_ID",
                principalTable: "EmployeeTraining",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_EMPLOYEE_TRAINING_COURSE_EmployeeTraining_EmployeeTrainingId1",
                table: "CM_EMPLOYEE_TRAINING_COURSE",
                column: "EmployeeTrainingId1",
                principalTable: "EmployeeTraining",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_PAYROLL_JOURNAL_LINK_EMPLOYEE_EMPLOYEE_ID",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "EMPLOYEE_ID",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_PAYROLL_JOURNAL_LINK_EMPLOYEE_EmployeeId1",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "EmployeeId1",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_PAYROLL_JOURNAL_LINK_PAYROLL_DETAIL_PAYROLL_DETAIL_ID",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "PAYROLL_DETAIL_ID",
                principalTable: "PAYROLL_DETAIL",
                principalColumn: "PAYROLL_DETAIL_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_PAYROLL_JOURNAL_LINK_PAYROLL_DETAIL_PayrollDetailId1",
                table: "CM_PAYROLL_JOURNAL_LINK",
                column: "PayrollDetailId1",
                principalTable: "PAYROLL_DETAIL",
                principalColumn: "PAYROLL_DETAIL_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_CUSTODY_ASSET_INVENTORY_ITEM_INVENTORY_ITEM_ID",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "INVENTORY_ITEM_ID",
                principalTable: "INVENTORY_ITEM",
                principalColumn: "INVENTORY_ITEM_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_CUSTODY_ASSET_INVENTORY_ITEM_InventoryItemId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "InventoryItemId1",
                principalTable: "INVENTORY_ITEM",
                principalColumn: "INVENTORY_ITEM_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_CUSTODY_ASSET_SchoolAsset_SCHOOL_ASSET_ID",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "SCHOOL_ASSET_ID",
                principalTable: "SchoolAsset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_CUSTODY_ASSET_SchoolAsset_SchoolAssetId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "SchoolAssetId1",
                principalTable: "SchoolAsset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_CUSTODY_ASSET_StudentInventoryCustody_STUDENT_INVENTORY_CUSTODY_ID",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "STUDENT_INVENTORY_CUSTODY_ID",
                principalTable: "StudentInventoryCustody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_CUSTODY_ASSET_StudentInventoryCustody_StudentInventoryCustodyId1",
                table: "CM_STUDENT_CUSTODY_ASSET",
                column: "StudentInventoryCustodyId1",
                principalTable: "StudentInventoryCustody",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_TRANSPORT_ROUTE_StudentTransportationSubscription_StudentTransportationSubscriptionId1",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "StudentTransportationSubscriptionId1",
                principalTable: "StudentTransportationSubscription",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_TRANSPORT_ROUTE_StudentTransportationSubscription_TRANSPORT_SUBSCRIPTION_ID",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "TRANSPORT_SUBSCRIPTION_ID",
                principalTable: "StudentTransportationSubscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_TRANSPORT_ROUTE_TRANSPORTATION_SERVICE_TRANSPORTATION_SERVICE_ID",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "TRANSPORTATION_SERVICE_ID",
                principalTable: "TRANSPORTATION_SERVICE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_STUDENT_TRANSPORT_ROUTE_TRANSPORTATION_SERVICE_TransportationServiceId1",
                table: "CM_STUDENT_TRANSPORT_ROUTE",
                column: "TransportationServiceId1",
                principalTable: "TRANSPORTATION_SERVICE",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_EMPLOYEE_IDENTITY_EMPLOYEE_EMPLOYEE_ID",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "EMPLOYEE_ID",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_EMPLOYEE_IDENTITY_EMPLOYEE_EmployeeId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "EmployeeId1",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_EMPLOYEE_IDENTITY_OrganizationalSector_ORGANIZATIONAL_SECTOR_ID",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "ORGANIZATIONAL_SECTOR_ID",
                principalTable: "OrganizationalSector",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_EMPLOYEE_IDENTITY_OrganizationalSector_OrganizationalSectorId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "OrganizationalSectorId1",
                principalTable: "OrganizationalSector",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_EMPLOYEE_IDENTITY_SYSTEM_USER_SYSTEM_USER_ID",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "SYSTEM_USER_ID",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_EMPLOYEE_IDENTITY_SYSTEM_USER_SystemUserId1",
                table: "CM_USER_EMPLOYEE_IDENTITY",
                column: "SystemUserId1",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_GUARDIAN_IDENTITY_SYSTEM_USER_SYSTEM_USER_ID",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "SYSTEM_USER_ID",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_GUARDIAN_IDENTITY_SYSTEM_USER_SystemUserId1",
                table: "CM_USER_GUARDIAN_IDENTITY",
                column: "SystemUserId1",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_STUDENT_IDENTITY_SYSTEM_USER_SYSTEM_USER_ID",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "SYSTEM_USER_ID",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CM_USER_STUDENT_IDENTITY_SYSTEM_USER_SystemUserId1",
                table: "CM_USER_STUDENT_IDENTITY",
                column: "SystemUserId1",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeMember_EMPLOYEE_EmployeeId",
                table: "CommitteeMember",
                column: "EmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeMember_EmployeeCommittee_CommitteeId",
                table: "CommitteeMember",
                column: "CommitteeId",
                principalTable: "EmployeeCommittee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COMMUNITY_PARTNERSHIP_EMPLOYEE_RESPONSIBLE_EMPLOYEE_ID",
                table: "COMMUNITY_PARTNERSHIP",
                column: "RESPONSIBLE_EMPLOYEE_ID",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_EMPLOYEE_HeadOfDepartmentEmployeeId1",
                table: "Department",
                column: "HeadOfDepartmentEmployeeId1",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_OrganizationalSector_OrganizationalSectorId",
                table: "Department",
                column: "OrganizationalSectorId",
                principalTable: "OrganizationalSector",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailedAcademicWarningLog_EMPLOYEE_IssuedByEmployeeId",
                table: "DetailedAcademicWarningLog",
                column: "IssuedByEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalSupervisionVisit_EMPLOYEE_SupervisorEmployeeId",
                table: "EducationalSupervisionVisit",
                column: "SupervisorEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalSupervisionVisit_EMPLOYEE_VisitedTeacherEmployeeId",
                table: "EducationalSupervisionVisit",
                column: "VisitedTeacherEmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "PERSON_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMERGENCY_HOSTING_SYSTEM_USER_REPORTED_BY_USER_ID",
                table: "EMERGENCY_HOSTING",
                column: "REPORTED_BY_USER_ID",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMERGENCY_INCIDENT_SYSTEM_USER_REPORTED_BY_USER_ID",
                table: "EMERGENCY_INCIDENT",
                column: "REPORTED_BY_USER_ID",
                principalTable: "SYSTEM_USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEE_OrganizationalSector_OrganizationalSectorId",
                table: "EMPLOYEE",
                column: "OrganizationalSectorId",
                principalTable: "OrganizationalSector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_EMPLOYEE_HeadOfDepartmentEmployeeId1",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalSector_EMPLOYEE_HeadOfSectorEmployeeId",
                table: "OrganizationalSector");

            migrationBuilder.DropTable(
                name: "AcademicBranchConfigLog");

            migrationBuilder.DropTable(
                name: "AcademicWarningPolicy");

            migrationBuilder.DropTable(
                name: "ACCESS_POLICY");

            migrationBuilder.DropTable(
                name: "AppointmentDecision");

            migrationBuilder.DropTable(
                name: "AssetAllocation");

            migrationBuilder.DropTable(
                name: "AssetAssignment");

            migrationBuilder.DropTable(
                name: "AssetInspectionLog");

            migrationBuilder.DropTable(
                name: "AssetLoan");

            migrationBuilder.DropTable(
                name: "AssetMovementHistory");

            migrationBuilder.DropTable(
                name: "AssetSuspensionRequest");

            migrationBuilder.DropTable(
                name: "AssetTransferRequest");

            migrationBuilder.DropTable(
                name: "AttendanceDetail");

            migrationBuilder.DropTable(
                name: "BEHAVIOR_PERMISSION");

            migrationBuilder.DropTable(
                name: "BEHAVIOR_PERMISSION_MATRIX");

            migrationBuilder.DropTable(
                name: "BEHAVIOR_PERMISSION_RECORD");

            migrationBuilder.DropTable(
                name: "ClassroomOperationalRule");

            migrationBuilder.DropTable(
                name: "ClassroomResourceAllocation");

            migrationBuilder.DropTable(
                name: "ClassSchedule");

            migrationBuilder.DropTable(
                name: "CM_ASSET_FINANCIAL_JOURNAL");

            migrationBuilder.DropTable(
                name: "CM_ASSET_PROCUREMENT_PAYMENT");

            migrationBuilder.DropTable(
                name: "CM_AUDITABLE_ENTITY_REGISTRY");

            migrationBuilder.DropTable(
                name: "CM_EMERGENCY_ASSET_IMPACT");

            migrationBuilder.DropTable(
                name: "CM_EMERGENCY_EMPLOYEE_SAFETY");

            migrationBuilder.DropTable(
                name: "CM_EMERGENCY_FINANCIAL_EXPENSE");

            migrationBuilder.DropTable(
                name: "CM_EMERGENCY_HOSTING_WAREHOUSE");

            migrationBuilder.DropTable(
                name: "CM_EMERGENCY_STUDENT_SAFETY");

            migrationBuilder.DropTable(
                name: "CM_EMPLOYEE_TRAINING_COURSE");

            migrationBuilder.DropTable(
                name: "CM_ENROLLMENT_FINANCIAL_LINK");

            migrationBuilder.DropTable(
                name: "CM_KPI_FINANCIAL_PERIOD");

            migrationBuilder.DropTable(
                name: "CM_PAYMENT_INVOICE_SETTLEMENT");

            migrationBuilder.DropTable(
                name: "CM_PAYROLL_JOURNAL_LINK");

            migrationBuilder.DropTable(
                name: "CM_REPORT_SNAPSHOT_SOURCE");

            migrationBuilder.DropTable(
                name: "CM_STUDENT_CUSTODY_ASSET");

            migrationBuilder.DropTable(
                name: "CM_STUDENT_TRANSPORT_ROUTE");

            migrationBuilder.DropTable(
                name: "CM_USER_EMPLOYEE_IDENTITY");

            migrationBuilder.DropTable(
                name: "CM_USER_GUARDIAN_IDENTITY");

            migrationBuilder.DropTable(
                name: "CM_USER_STUDENT_IDENTITY");

            migrationBuilder.DropTable(
                name: "CommitteeMember");

            migrationBuilder.DropTable(
                name: "COMMUNITY_PARTNERSHIP");

            migrationBuilder.DropTable(
                name: "COMPARATIVE_REPORT");

            migrationBuilder.DropTable(
                name: "CurriculumTextbookDistribution");

            migrationBuilder.DropTable(
                name: "DetailedAcademicWarningLog");

            migrationBuilder.DropTable(
                name: "EducationalSupervisionVisit");

            migrationBuilder.DropTable(
                name: "EmployeeAdditionalTask");

            migrationBuilder.DropTable(
                name: "EmployeeAttendance");

            migrationBuilder.DropTable(
                name: "EmployeeDocument");

            migrationBuilder.DropTable(
                name: "EmployeeExternalTransfer");

            migrationBuilder.DropTable(
                name: "EmployeeFinancialTransaction");

            migrationBuilder.DropTable(
                name: "EmployeeInternalTransfer");

            migrationBuilder.DropTable(
                name: "EmployeeInventoryCustody");

            migrationBuilder.DropTable(
                name: "EmployeeLeave");

            migrationBuilder.DropTable(
                name: "EmployeeMentor");

            migrationBuilder.DropTable(
                name: "EmployeePayrollFinancialContract");

            migrationBuilder.DropTable(
                name: "EmployeePerformanceReview");

            migrationBuilder.DropTable(
                name: "EmployeeTermination");

            migrationBuilder.DropTable(
                name: "EmployeeViolation");

            migrationBuilder.DropTable(
                name: "ExamDistributionTimetable");

            migrationBuilder.DropTable(
                name: "EXCEPTIONAL_STATISTICS_REPORT");

            migrationBuilder.DropTable(
                name: "EXTERNAL_COMPLIANCE_REPORT");

            migrationBuilder.DropTable(
                name: "EXTERNAL_PARTICIPATION");

            migrationBuilder.DropTable(
                name: "GAP_ANALYSIS_REPORT");

            migrationBuilder.DropTable(
                name: "GOVERNANCE_RBAC_RULE");

            migrationBuilder.DropTable(
                name: "GradingScaleBound");

            migrationBuilder.DropTable(
                name: "JOURNAL_ENTRY_LINE");

            migrationBuilder.DropTable(
                name: "MeetingAttendanceRecord");

            migrationBuilder.DropTable(
                name: "OFFICE_PERMISSION");

            migrationBuilder.DropTable(
                name: "OfficialCircular");

            migrationBuilder.DropTable(
                name: "PERMISSION_BASE_MODULE");

            migrationBuilder.DropTable(
                name: "PreventiveMaintenanceSchedule");

            migrationBuilder.DropTable(
                name: "PRIVILEGE_RULE");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "REMEDIATION_PLAN");

            migrationBuilder.DropTable(
                name: "REPORT_APPROVAL");

            migrationBuilder.DropTable(
                name: "ROLE_MATRIX");

            migrationBuilder.DropTable(
                name: "ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "SAFETY_SECURITY_REPORT");

            migrationBuilder.DropTable(
                name: "SCHOOL_AWARD");

            migrationBuilder.DropTable(
                name: "SCHOOL_FINANCIAL_SUMMARY_REPORT");

            migrationBuilder.DropTable(
                name: "SCHOOL_MERGER");

            migrationBuilder.DropTable(
                name: "SchoolAccreditationLog");

            migrationBuilder.DropTable(
                name: "SchoolAnnouncementLog");

            migrationBuilder.DropTable(
                name: "SchoolOperationalBudgetLog");

            migrationBuilder.DropTable(
                name: "SchoolShift");

            migrationBuilder.DropTable(
                name: "SelfServicePortalRequest");

            migrationBuilder.DropTable(
                name: "StaffCustodySummary");

            migrationBuilder.DropTable(
                name: "STATISTICS_ARCHIVE");

            migrationBuilder.DropTable(
                name: "STATISTICS_REPORTS_ARCHIVE");

            migrationBuilder.DropTable(
                name: "STATISTICS_UPDATE_HISTORY");

            migrationBuilder.DropTable(
                name: "STUDENT_ACADEMIC_PERMISSION");

            migrationBuilder.DropTable(
                name: "STUDENT_BASE_PERMISSION");

            migrationBuilder.DropTable(
                name: "STUDENT_FINANCE_PERMISSION");

            migrationBuilder.DropTable(
                name: "STUDENT_PERM_AUDIT_LOG");

            migrationBuilder.DropTable(
                name: "STUDENT_TRANSFER_LOG");

            migrationBuilder.DropTable(
                name: "StudentAbsenceExcusal");

            migrationBuilder.DropTable(
                name: "StudentActivityParticipation");

            migrationBuilder.DropTable(
                name: "StudentAssessment");

            migrationBuilder.DropTable(
                name: "StudentAssignmentSubmission");

            migrationBuilder.DropTable(
                name: "StudentAttachment");

            migrationBuilder.DropTable(
                name: "StudentCanteenPurchaseLog");

            migrationBuilder.DropTable(
                name: "StudentDailyAttendanceSummary");

            migrationBuilder.DropTable(
                name: "StudentDisciplinaryHistory");

            migrationBuilder.DropTable(
                name: "StudentExemplaryRecognition");

            migrationBuilder.DropTable(
                name: "StudentExemption");

            migrationBuilder.DropTable(
                name: "StudentHealthRecord");

            migrationBuilder.DropTable(
                name: "StudentIdentityDocument");

            migrationBuilder.DropTable(
                name: "StudentMedicalAllergyLog");

            migrationBuilder.DropTable(
                name: "StudentParentConferenceReservation");

            migrationBuilder.DropTable(
                name: "StudentPsychologicalCounselingLog");

            migrationBuilder.DropTable(
                name: "StudentSkillAndTalentRecord");

            migrationBuilder.DropTable(
                name: "SYSTEM_AUDIT_LOG");

            migrationBuilder.DropTable(
                name: "TeacherSchedule");

            migrationBuilder.DropTable(
                name: "TREND_ANALYSIS_RESULT");

            migrationBuilder.DropTable(
                name: "UsageViolation");

            migrationBuilder.DropTable(
                name: "USER_ACTIVITY_LOG");

            migrationBuilder.DropTable(
                name: "USER_DIRECT_PERMISSION");

            migrationBuilder.DropTable(
                name: "USER_ROLE_ASSIGNMENT");

            migrationBuilder.DropTable(
                name: "VisitorEntryLog");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "AssetMaintenanceTicket");

            migrationBuilder.DropTable(
                name: "EMERGENCY_CLOSURE");

            migrationBuilder.DropTable(
                name: "EMERGENCY_HOSTING");

            migrationBuilder.DropTable(
                name: "EMERGENCY_INCIDENT");

            migrationBuilder.DropTable(
                name: "EmployeeTraining");

            migrationBuilder.DropTable(
                name: "TrainingCourseOffering");

            migrationBuilder.DropTable(
                name: "StudentAccount");

            migrationBuilder.DropTable(
                name: "StudentEnrollment");

            migrationBuilder.DropTable(
                name: "KPI_METRIC_RECORD");

            migrationBuilder.DropTable(
                name: "FeeInvoice");

            migrationBuilder.DropTable(
                name: "PAYMENT_VOUCHER");

            migrationBuilder.DropTable(
                name: "PAYROLL_DETAIL");

            migrationBuilder.DropTable(
                name: "STATISTICAL_REPORT_SNAPSHOT");

            migrationBuilder.DropTable(
                name: "INVENTORY_ITEM");

            migrationBuilder.DropTable(
                name: "StudentInventoryCustody");

            migrationBuilder.DropTable(
                name: "StudentTransportationSubscription");

            migrationBuilder.DropTable(
                name: "TRANSPORTATION_SERVICE");

            migrationBuilder.DropTable(
                name: "StudentGuardianRelationship");

            migrationBuilder.DropTable(
                name: "EmployeeCommittee");

            migrationBuilder.DropTable(
                name: "EmployeePayroll");

            migrationBuilder.DropTable(
                name: "JOURNAL_ENTRY");

            migrationBuilder.DropTable(
                name: "EmployeeMeeting");

            migrationBuilder.DropTable(
                name: "SCHOOL_DEFICIT");

            migrationBuilder.DropTable(
                name: "SCHOOL_SURPLUS");

            migrationBuilder.DropTable(
                name: "SYSTEM_REPORT");

            migrationBuilder.DropTable(
                name: "SUBMITTED_STATISTICS");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "SchoolCanteenItem");

            migrationBuilder.DropTable(
                name: "BehavioralLog");

            migrationBuilder.DropTable(
                name: "SchoolEventCalendar");

            migrationBuilder.DropTable(
                name: "SYSTEM_PERMISSION");

            migrationBuilder.DropTable(
                name: "SYSTEM_ROLE");

            migrationBuilder.DropTable(
                name: "EMERGENCY_PLAN");

            migrationBuilder.DropTable(
                name: "SYSTEM_USER");

            migrationBuilder.DropTable(
                name: "DASHBOARD_KPI_CONFIG");

            migrationBuilder.DropTable(
                name: "FeeStructure");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "VENDOR");

            migrationBuilder.DropTable(
                name: "PAYROLL_RUN");

            migrationBuilder.DropTable(
                name: "ACADEMIC_LOCK_PERIOD");

            migrationBuilder.DropTable(
                name: "WAREHOUSE");

            migrationBuilder.DropTable(
                name: "SchoolTransportationRoute");

            migrationBuilder.DropTable(
                name: "SchoolAsset");

            migrationBuilder.DropTable(
                name: "SCHOOL_STATISTICS_DRAFT");

            migrationBuilder.DropTable(
                name: "SchoolFacility");

            migrationBuilder.DropTable(
                name: "PERMISSION_TYPE");

            migrationBuilder.DropTable(
                name: "STUDENT");

            migrationBuilder.DropTable(
                name: "AssetCategory");

            migrationBuilder.DropTable(
                name: "AssetLocationRecord");

            migrationBuilder.DropTable(
                name: "AssetWarrantyContract");

            migrationBuilder.DropTable(
                name: "CLASSROOM");

            migrationBuilder.DropTable(
                name: "GUARDIAN");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "PERSON");

            migrationBuilder.DropTable(
                name: "OrganizationalSector");

            migrationBuilder.DropTable(
                name: "SCHOOL");

            migrationBuilder.DropTable(
                name: "Directorate");

            migrationBuilder.DropTable(
                name: "EducationalStage");
        }
    }
}
