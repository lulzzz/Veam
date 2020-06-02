using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AttendanceC",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Work_Date = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Time_In = table.Column<string>(unicode: false, maxLength: 19, nullable: false),
                    Time_Out = table.Column<string>(unicode: false, maxLength: 19, nullable: true),
                    Pass_Code = table.Column<string>(type: "char(1)", nullable: false),
                    Work_Shift = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Work_Day = table.Column<decimal>(type: "decimal(2, 1)", nullable: false, defaultValueSql: "((0))"),
                    OT_15 = table.Column<byte>(nullable: false, defaultValueSql: "((0))"),
                    OT_3 = table.Column<byte>(nullable: false, defaultValueSql: "((0))"),
                    Late_Min = table.Column<short>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceC", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    GlobalID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    CardID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 5, nullable: false),
                    TitleThai = table.Column<string>(maxLength: 15, nullable: false),
                    EmployeeType = table.Column<string>(type: "nchar(2)", nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FirstNameThai = table.Column<string>(maxLength: 50, nullable: false),
                    LastNameThai = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nchar(1)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Hand = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    HireType = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    AvailableFlag = table.Column<bool>(nullable: true, defaultValueSql: "('1')"),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "MasterAccount",
                schema: "dbo",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAccount", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "MasterAuthority",
                schema: "dbo",
                columns: table => new
                {
                    AuthorityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorityName = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAuthority", x => x.AuthorityID);
                });

            migrationBuilder.CreateTable(
                name: "MasterDepartment",
                schema: "dbo",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DepartmentCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    DepartmentGroup = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDepartment", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "MasterEducationDegree",
                schema: "dbo",
                columns: table => new
                {
                    DegreeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DegreeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DegreeNameThai = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterEducationDegree", x => x.DegreeID);
                });

            migrationBuilder.CreateTable(
                name: "MasterJobPosition",
                schema: "dbo",
                columns: table => new
                {
                    PositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionName = table.Column<string>(maxLength: 50, nullable: false),
                    PositionCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterJobPosition", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "MasterLevel",
                schema: "dbo",
                columns: table => new
                {
                    LevelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    LevelCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLevel", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "MasterLocationGroup",
                schema: "dbo",
                columns: table => new
                {
                    LocationGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationGroupName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLocationGroup", x => x.LocationGroupID);
                });

            migrationBuilder.CreateTable(
                name: "MasterRoute",
                schema: "dbo",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteName = table.Column<string>(maxLength: 100, nullable: false),
                    RouteCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterRoute", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "MasterShift",
                schema: "dbo",
                columns: table => new
                {
                    ShiftID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShiftName = table.Column<string>(maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterShift", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "MasterSkillGroup",
                schema: "dbo",
                columns: table => new
                {
                    SkillGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillGroupName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSkillGroup", x => x.SkillGroupID);
                });

            migrationBuilder.CreateTable(
                name: "MasterSkillType",
                schema: "dbo",
                columns: table => new
                {
                    SkillTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSkillType", x => x.SkillTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    HomeAddress = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => x.EmployeeAddressID);
                    table.ForeignKey(
                        name: "FK_EmployeeAdress_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeImage",
                schema: "dbo",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Images = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeImage", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_EmployeeImage_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAccount",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAccount", x => new { x.EmployeeID, x.AccountID });
                    table.ForeignKey(
                        name: "FK_EmployeeUser_MasterUser_UserID",
                        column: x => x.AccountID,
                        principalSchema: "dbo",
                        principalTable: "MasterAccount",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeUser_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterAccountAuthority",
                schema: "dbo",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false),
                    AuthorityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAccountAuthority", x => new { x.AccountID, x.AuthorityID });
                    table.ForeignKey(
                        name: "FK_MasterAccountAuthority_MasterAccount_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "dbo",
                        principalTable: "MasterAccount",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterUserAuthority_MasterAuthority_AuthorityID",
                        column: x => x.AuthorityID,
                        principalSchema: "dbo",
                        principalTable: "MasterAuthority",
                        principalColumn: "AuthorityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterSection",
                schema: "dbo",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentID = table.Column<int>(nullable: false),
                    SectionName = table.Column<string>(maxLength: 50, nullable: false),
                    SectionCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSection", x => x.SectionID);
                    table.ForeignKey(
                        name: "FK_MasterSection_MasterDepartment_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "dbo",
                        principalTable: "MasterDepartment",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterEducationMajor",
                schema: "dbo",
                columns: table => new
                {
                    MajorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DegreeID = table.Column<int>(nullable: false),
                    MarjorName = table.Column<string>(maxLength: 50, nullable: false),
                    MajorNameThai = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterEducationMajor", x => x.MajorID);
                    table.ForeignKey(
                        name: "FK_MasterEducationMajor_MasterEducationDegree_DegreeID",
                        column: x => x.DegreeID,
                        principalSchema: "dbo",
                        principalTable: "MasterEducationDegree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterLocation",
                schema: "dbo",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationGroupID = table.Column<int>(nullable: false),
                    LocationName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLocation", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_MasterLocation_MasterLocationGroup_LocationGroupID",
                        column: x => x.LocationGroupID,
                        principalSchema: "dbo",
                        principalTable: "MasterLocationGroup",
                        principalColumn: "LocationGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterBusStation",
                schema: "dbo",
                columns: table => new
                {
                    BusStationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteID = table.Column<int>(nullable: false),
                    BusStationName = table.Column<string>(maxLength: 100, nullable: false),
                    BusStationCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TimeInDay = table.Column<TimeSpan>(nullable: false),
                    TimeInNight = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBusStation", x => x.BusStationID);
                    table.ForeignKey(
                        name: "FK_MasterBusStation_MasterRoute_RouteID",
                        column: x => x.RouteID,
                        principalSchema: "dbo",
                        principalTable: "MasterRoute",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterShiftCalendar",
                schema: "dbo",
                columns: table => new
                {
                    WorkDate = table.Column<DateTime>(type: "date", nullable: false),
                    WorkType = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    ShiftID = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterShiftCalendar", x => x.WorkDate);
                    table.ForeignKey(
                        name: "FK_WorkCalendar_MasterShift_ShiftID",
                        column: x => x.ShiftID,
                        principalSchema: "dbo",
                        principalTable: "MasterShift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterSkill",
                schema: "dbo",
                columns: table => new
                {
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillGroupID = table.Column<int>(nullable: false),
                    SkillTypeID = table.Column<int>(nullable: false),
                    SkillName = table.Column<string>(maxLength: 100, nullable: false),
                    SkillDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSkill", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_MasterSkill_MasterSkillGroup_SkillGroupID",
                        column: x => x.SkillGroupID,
                        principalSchema: "dbo",
                        principalTable: "MasterSkillGroup",
                        principalColumn: "SkillGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterSkill_MasterSkillType_SkillTypeID",
                        column: x => x.SkillTypeID,
                        principalSchema: "dbo",
                        principalTable: "MasterSkillType",
                        principalColumn: "SkillTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterJobFunction",
                schema: "dbo",
                columns: table => new
                {
                    JobFunctionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionID = table.Column<int>(nullable: false),
                    FunctionName = table.Column<string>(maxLength: 100, nullable: false),
                    FunctionCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterJobFunction", x => x.JobFunctionID);
                    table.ForeignKey(
                        name: "FK_MasterJobFunction_MasterSection_SectionID",
                        column: x => x.SectionID,
                        principalSchema: "dbo",
                        principalTable: "MasterSection",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducation",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeEducationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MajorID = table.Column<int>(nullable: false),
                    LastEducation = table.Column<bool>(nullable: true, defaultValueSql: "('1')"),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducation", x => x.EmployeeEducationID);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEducation_MasterEducationMajor_MajorID",
                        column: x => x.MajorID,
                        principalSchema: "dbo",
                        principalTable: "MasterEducationMajor",
                        principalColumn: "MajorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLocation",
                schema: "dbo",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLocation", x => new { x.LocationID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_EmployeeLocation_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLocation_MasterLocation_LocationID",
                        column: x => x.LocationID,
                        principalSchema: "dbo",
                        principalTable: "MasterLocation",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeSkills",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    SkillID = table.Column<int>(nullable: false),
                    SkillLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeSkills", x => new { x.EmployeeID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_MasterSkill_SkillID",
                        column: x => x.SkillID,
                        principalSchema: "dbo",
                        principalTable: "MasterSkill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeState",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PositionID = table.Column<int>(nullable: false),
                    JobFunctionID = table.Column<int>(nullable: false),
                    ShiftID = table.Column<byte>(nullable: false),
                    LevelID = table.Column<int>(nullable: false),
                    BusStationID = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeState", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_EmployeeState_MasterBusStation_BusStationID",
                        column: x => x.BusStationID,
                        principalSchema: "dbo",
                        principalTable: "MasterBusStation",
                        principalColumn: "BusStationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeState_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeState_MasterJobFunction_JobFunctionID",
                        column: x => x.JobFunctionID,
                        principalSchema: "dbo",
                        principalTable: "MasterJobFunction",
                        principalColumn: "JobFunctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeState_MasterLevel_LevelID",
                        column: x => x.LevelID,
                        principalSchema: "dbo",
                        principalTable: "MasterLevel",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeState_MasterJobPosition_PositionID",
                        column: x => x.PositionID,
                        principalSchema: "dbo",
                        principalTable: "MasterJobPosition",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeState_MasterShift_ShiftID",
                        column: x => x.ShiftID,
                        principalSchema: "dbo",
                        principalTable: "MasterShift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx1_AttendanceC",
                schema: "dbo",
                table: "AttendanceC",
                columns: new[] { "EmployeeID", "Work_Date" });

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__A50E8993D0F46EBD",
                schema: "dbo",
                table: "Employee",
                column: "GlobalID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccount_AccountID",
                schema: "dbo",
                table: "EmployeeAccount",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_EmployeeID",
                schema: "dbo",
                table: "EmployeeAddress",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_EmployeeID",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducation_MajorID",
                schema: "dbo",
                table: "EmployeeEducation",
                column: "MajorID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeImage_EmployeeID",
                schema: "dbo",
                table: "EmployeeImage",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLocation_EmployeeID",
                schema: "dbo",
                table: "EmployeeLocation",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeState_BusStationID",
                schema: "dbo",
                table: "EmployeeState",
                column: "BusStationID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeState_JobFunctionID",
                schema: "dbo",
                table: "EmployeeState",
                column: "JobFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeState_LevelID",
                schema: "dbo",
                table: "EmployeeState",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeState_PositionID",
                schema: "dbo",
                table: "EmployeeState",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeState_ShiftID",
                schema: "dbo",
                table: "EmployeeState",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeSkills_SkillID",
                schema: "dbo",
                table: "EmployeSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "UQ__MasterAc__C9F28456EC943ACC",
                schema: "dbo",
                table: "MasterAccount",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterAccountAuthority_AuthorityID",
                schema: "dbo",
                table: "MasterAccountAuthority",
                column: "AuthorityID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterBusStation_RouteID",
                schema: "dbo",
                table: "MasterBusStation",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "UQ_MasterEducationDegree_DegreeName",
                schema: "dbo",
                table: "MasterEducationDegree",
                column: "DegreeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterEducationMajor_DegreeID",
                schema: "dbo",
                table: "MasterEducationMajor",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterJobFunction_SectionID",
                schema: "dbo",
                table: "MasterJobFunction",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLocation_LocationGroupID",
                schema: "dbo",
                table: "MasterLocation",
                column: "LocationGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSection_DepartmentID",
                schema: "dbo",
                table: "MasterSection",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterShiftCalendar_ShiftID",
                schema: "dbo",
                table: "MasterShiftCalendar",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSkill_SkillGroupID",
                schema: "dbo",
                table: "MasterSkill",
                column: "SkillGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSkill_SkillTypeID",
                schema: "dbo",
                table: "MasterSkill",
                column: "SkillTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceC",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeAccount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeEducation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeImage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeState",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeSkills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterAccountAuthority",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterShiftCalendar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterEducationMajor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterBusStation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterJobFunction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterLevel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterJobPosition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterSkill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterAccount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterAuthority",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterShift",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterEducationDegree",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterLocationGroup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterRoute",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterSection",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterSkillGroup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterSkillType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterDepartment",
                schema: "dbo");
        }
    }
}
