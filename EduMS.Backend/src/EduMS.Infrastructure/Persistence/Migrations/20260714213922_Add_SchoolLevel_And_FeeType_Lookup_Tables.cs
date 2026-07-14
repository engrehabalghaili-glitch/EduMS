using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_SchoolLevel_And_FeeType_Lookup_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "UsageViolation",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPerParticipant",
                table: "TrainingCourseOffering",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalMarks",
                table: "Subject",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PassingMarks",
                table: "Subject",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditHours",
                table: "Subject",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AgreedMonthlyFee",
                table: "StudentTransportationSubscription",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "StudentInventoryCustody",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalWeightKg",
                table: "StudentHealthRecord",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalHeightCm",
                table: "StudentHealthRecord",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercentage",
                table: "StudentExemption",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualMaxDiscountAmount",
                table: "StudentExemption",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAbsencePercentage",
                table: "StudentDailyAttendanceSummary",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "StudentCanteenPurchaseLog",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ScoreObtained",
                table: "StudentAssignmentSubmission",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPossibleScore",
                table: "StudentAssignmentSubmission",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PassingScore",
                table: "StudentAssessment",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ObtainedScore",
                table: "StudentAssessment",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxScore",
                table: "StudentAssessment",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GradePointResult",
                table: "StudentAssessment",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ScoreBonus",
                table: "StudentActivityParticipation",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPaid",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalExemption",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDues",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebit",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCredit",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OutstandingBalance",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumPaymentRequired",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LastPaymentAmount",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExemptionPercentage",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBalance",
                table: "StudentAccount",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RemainingAmount",
                table: "SchoolOperationalBudgetLog",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ConsumedAmount",
                table: "SchoolOperationalBudgetLog",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AllocatedAmount",
                table: "SchoolOperationalBudgetLog",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "SchoolCanteenItem",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPrice",
                table: "SchoolCanteenItem",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalvageValue",
                table: "SchoolAsset",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBookValue",
                table: "SchoolAsset",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AcquisitionCost",
                table: "SchoolAsset",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "PurchaseOrder",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                table: "PurchaseOrder",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FrequencyValue",
                table: "PreventiveMaintenanceSchedule",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedCost",
                table: "PreventiveMaintenanceSchedule",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinPercentage",
                table: "GradingScaleBound",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPercentage",
                table: "GradingScaleBound",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GradePointValue",
                table: "GradingScaleBound",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "FeeStructure",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "FeeInvoice",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "FeeInvoice",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualBudgetLimit",
                table: "Directorate",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualBudget",
                table: "Department",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "CurriculumTextbookDistribution",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalValueAmount",
                table: "CurriculumTextbookDistribution",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPurchaseCost",
                table: "ClassroomResourceAllocation",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxAllowedAbsencePercentage",
                table: "ClassroomOperationalRule",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ContractValue",
                table: "AssetWarrantyContract",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ResolutionCost",
                table: "AssetMaintenanceTicket",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedCost",
                table: "AssetMaintenanceTicket",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FineAmount",
                table: "AssetLoan",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedRepairCost",
                table: "AssetInspectionLog",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DefaultDepreciationRate",
                table: "AssetCategory",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "AssetAssignment",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ThresholdValue",
                table: "AcademicWarningPolicy",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "FEE_TYPE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    GRADE_CAPACITY_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FEE_CODE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    FEE_NAME_AR = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    FEE_NAME_EN = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    FEE_CATEGORY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "NUMBER(18,4)", nullable: false),
                    CURRENCY = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    BILLING_FREQUENCY = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    IS_TAXABLE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TAX_PERCENTAGE = table.Column<decimal>(type: "NUMBER(10,4)", nullable: false),
                    IS_MANDATORY = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IS_OPTIONAL = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsDiscountable = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DiscountPercentageAllowed = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    IsRefundable = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RefundPercentage = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    RefundCutoffDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsRecurring = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    RecurrenceType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AppliesToGradesJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AppliesToNationalitiesJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AppliesToStudentTypesJson = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
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
                    table.PrimaryKey("PK_FEE_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FEE_TYPE_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_LEVEL",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LEVEL_NAME_AR = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    LEVEL_NAME_EN = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    LEVEL_ORDER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    START_GRADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    END_GRADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ACADEMIC_TRACK = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    MIN_AGE_YEARS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MAX_AGE_YEARS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DEFAULT_SHIFT_ID = table.Column<long>(type: "NUMBER(19)", nullable: true),
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
                    table.PrimaryKey("PK_SCHOOL_LEVEL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHOOL_LEVEL_SCHOOL_SCHOOL_ID",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FEE_TYPE_SCHOOL_ID",
                table: "FEE_TYPE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOL_LEVEL_SCHOOL_ID",
                table: "SCHOOL_LEVEL",
                column: "SCHOOL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FEE_TYPE");

            migrationBuilder.DropTable(
                name: "SCHOOL_LEVEL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "UsageViolation",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPerParticipant",
                table: "TrainingCourseOffering",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalMarks",
                table: "Subject",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PassingMarks",
                table: "Subject",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditHours",
                table: "Subject",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AgreedMonthlyFee",
                table: "StudentTransportationSubscription",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "StudentInventoryCustody",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalWeightKg",
                table: "StudentHealthRecord",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalHeightCm",
                table: "StudentHealthRecord",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercentage",
                table: "StudentExemption",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualMaxDiscountAmount",
                table: "StudentExemption",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAbsencePercentage",
                table: "StudentDailyAttendanceSummary",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "StudentCanteenPurchaseLog",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ScoreObtained",
                table: "StudentAssignmentSubmission",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPossibleScore",
                table: "StudentAssignmentSubmission",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PassingScore",
                table: "StudentAssessment",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ObtainedScore",
                table: "StudentAssessment",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxScore",
                table: "StudentAssessment",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GradePointResult",
                table: "StudentAssessment",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ScoreBonus",
                table: "StudentActivityParticipation",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPaid",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalExemption",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDues",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebit",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCredit",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OutstandingBalance",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumPaymentRequired",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LastPaymentAmount",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExemptionPercentage",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBalance",
                table: "StudentAccount",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RemainingAmount",
                table: "SchoolOperationalBudgetLog",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ConsumedAmount",
                table: "SchoolOperationalBudgetLog",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AllocatedAmount",
                table: "SchoolOperationalBudgetLog",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "SchoolCanteenItem",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPrice",
                table: "SchoolCanteenItem",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalvageValue",
                table: "SchoolAsset",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBookValue",
                table: "SchoolAsset",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AcquisitionCost",
                table: "SchoolAsset",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "PurchaseOrder",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                table: "PurchaseOrder",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FrequencyValue",
                table: "PreventiveMaintenanceSchedule",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedCost",
                table: "PreventiveMaintenanceSchedule",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinPercentage",
                table: "GradingScaleBound",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPercentage",
                table: "GradingScaleBound",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GradePointValue",
                table: "GradingScaleBound",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "FeeStructure",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "FeeInvoice",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "FeeInvoice",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualBudgetLimit",
                table: "Directorate",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualBudget",
                table: "Department",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "CurriculumTextbookDistribution",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalValueAmount",
                table: "CurriculumTextbookDistribution",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPurchaseCost",
                table: "ClassroomResourceAllocation",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxAllowedAbsencePercentage",
                table: "ClassroomOperationalRule",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ContractValue",
                table: "AssetWarrantyContract",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ResolutionCost",
                table: "AssetMaintenanceTicket",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedCost",
                table: "AssetMaintenanceTicket",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FineAmount",
                table: "AssetLoan",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "EstimatedRepairCost",
                table: "AssetInspectionLog",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DefaultDepreciationRate",
                table: "AssetCategory",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PenaltyAmount",
                table: "AssetAssignment",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ThresholdValue",
                table: "AcademicWarningPolicy",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
