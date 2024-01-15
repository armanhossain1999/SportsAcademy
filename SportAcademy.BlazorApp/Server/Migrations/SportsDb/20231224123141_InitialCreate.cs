using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportAcademy.BlazorApp.Server.migrations.SportsDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvisorSpecializations",
                columns: table => new
                {
                    AdvisorSpecializationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorSpecializedIn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorSpecializations", x => x.AdvisorSpecializationId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CoachTypes",
                columns: table => new
                {
                    CoachTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTypes", x => x.CoachTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "ExamTypes",
                columns: table => new
                {
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTypes", x => x.ExamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAdvisors",
                columns: table => new
                {
                    MedicalAdvisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalAdvisorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAdvisors", x => x.MedicalAdvisorId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoles",
                columns: table => new
                {
                    PlayerRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoles", x => x.PlayerRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CoachTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachId);
                    table.ForeignKey(
                        name: "FK_Coaches_CoachTypes_CoachTypeId",
                        column: x => x.CoachTypeId,
                        principalTable: "CoachTypes",
                        principalColumn: "CoachTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAdvisorSpecializations",
                columns: table => new
                {
                    MedicalAdvisorId = table.Column<int>(type: "int", nullable: false),
                    AdvisorSpecializationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAdvisorSpecializations", x => new { x.MedicalAdvisorId, x.AdvisorSpecializationId });
                    table.ForeignKey(
                        name: "FK_MedicalAdvisorSpecializations_AdvisorSpecializations_AdvisorSpecializationId",
                        column: x => x.AdvisorSpecializationId,
                        principalTable: "AdvisorSpecializations",
                        principalColumn: "AdvisorSpecializationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalAdvisorSpecializations_MedicalAdvisors_MedicalAdvisorId",
                        column: x => x.MedicalAdvisorId,
                        principalTable: "MedicalAdvisors",
                        principalColumn: "MedicalAdvisorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CricketFormats",
                columns: table => new
                {
                    CricketFormatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CricketFormats", x => x.CricketFormatId);
                    table.ForeignKey(
                        name: "FK_CricketFormats_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Captain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamLogo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachSpecializations",
                columns: table => new
                {
                    CoachSpecializationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializedIn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachSpecializations", x => x.CoachSpecializationId);
                    table.ForeignKey(
                        name: "FK_CoachSpecializations_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachSports",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachSports", x => new { x.CoachId, x.SportId });
                    table.ForeignKey(
                        name: "FK_CoachSports_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachSports_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectionPanels",
                columns: table => new
                {
                    SelectionPanelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectionPanelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    MedicalAdvisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionPanels", x => x.SelectionPanelId);
                    table.ForeignKey(
                        name: "FK_SelectionPanels_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectionPanels_MedicalAdvisors_MedicalAdvisorId",
                        column: x => x.MedicalAdvisorId,
                        principalTable: "MedicalAdvisors",
                        principalColumn: "MedicalAdvisorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSessions",
                columns: table => new
                {
                    TrainingSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionTime = table.Column<DateTime>(type: "date", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSessions", x => x.TrainingSessionId);
                    table.ForeignKey(
                        name: "FK_TrainingSessions_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachTeams",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTeams", x => new { x.CoachId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_CoachTeams_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SelectionPanelId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_SelectionPanels_SelectionPanelId",
                        column: x => x.SelectionPanelId,
                        principalTable: "SelectionPanels",
                        principalColumn: "SelectionPanelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TrainingSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "TrainingSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrainingSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "TrainingSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCoaches",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCoaches", x => new { x.PlayerId, x.CoachId });
                    table.ForeignKey(
                        name: "FK_PlayerCoaches_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCoaches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCourses",
                columns: table => new
                {
                    PlayerCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCourses", x => x.PlayerCourseId);
                    table.ForeignKey(
                        name: "FK_PlayerCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCourses_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRolePlayers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PlayerRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRolePlayers", x => new { x.PlayerId, x.PlayerRoleId });
                    table.ForeignKey(
                        name: "FK_PlayerRolePlayers_PlayerRoles_PlayerRoleId",
                        column: x => x.PlayerRoleId,
                        principalTable: "PlayerRoles",
                        principalColumn: "PlayerRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRolePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSports",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSports", x => new { x.PlayerId, x.SportId });
                    table.ForeignKey(
                        name: "FK_PlayerSports_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSports_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatistics",
                columns: table => new
                {
                    PlayerStatisticId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matches = table.Column<int>(type: "int", nullable: true),
                    Innings = table.Column<int>(type: "int", nullable: true),
                    Runs = table.Column<int>(type: "int", nullable: true),
                    Balls = table.Column<int>(type: "int", nullable: true),
                    Average = table.Column<double>(type: "float", nullable: true),
                    Fifty = table.Column<int>(type: "int", nullable: true),
                    Hundred = table.Column<int>(type: "int", nullable: true),
                    Sixs = table.Column<int>(type: "int", nullable: true),
                    Fours = table.Column<int>(type: "int", nullable: true),
                    Highest = table.Column<int>(type: "int", nullable: true),
                    Ducks = table.Column<int>(type: "int", nullable: true),
                    Wicket = table.Column<int>(type: "int", nullable: true),
                    Maidens = table.Column<int>(type: "int", nullable: true),
                    Economy = table.Column<double>(type: "float", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.PlayerStatisticId);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTrainingSessions",
                columns: table => new
                {
                    PlayerTrainingSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TrainingSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTrainingSessions", x => x.PlayerTrainingSessionId);
                    table.ForeignKey(
                        name: "FK_PlayerTrainingSessions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTrainingSessions_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "TrainingSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStateDetails",
                columns: table => new
                {
                    PlayerStateDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matches = table.Column<int>(type: "int", nullable: true),
                    Innings = table.Column<int>(type: "int", nullable: true),
                    Runs = table.Column<int>(type: "int", nullable: true),
                    Balls = table.Column<int>(type: "int", nullable: true),
                    Average = table.Column<double>(type: "float", nullable: true),
                    Fifty = table.Column<int>(type: "int", nullable: true),
                    Hundred = table.Column<int>(type: "int", nullable: true),
                    Sixs = table.Column<int>(type: "int", nullable: true),
                    Fours = table.Column<int>(type: "int", nullable: true),
                    Highest = table.Column<int>(type: "int", nullable: true),
                    Ducks = table.Column<int>(type: "int", nullable: true),
                    Wicket = table.Column<int>(type: "int", nullable: true),
                    Maidens = table.Column<int>(type: "int", nullable: true),
                    Economy = table.Column<double>(type: "float", nullable: true),
                    Marks = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrainingSessionId = table.Column<int>(type: "int", nullable: false),
                    PlayerStatisticId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStateDetails", x => x.PlayerStateDetailId);
                    table.ForeignKey(
                        name: "FK_PlayerStateDetails_PlayerStatistics_PlayerStatisticId",
                        column: x => x.PlayerStatisticId,
                        principalTable: "PlayerStatistics",
                        principalColumn: "PlayerStatisticId");
                    table.ForeignKey(
                        name: "FK_PlayerStateDetails_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "TrainingSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    ExamResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlayerStateDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.ExamResultId);
                    table.ForeignKey(
                        name: "FK_ExamResults_PlayerStateDetails_PlayerStateDetailId",
                        column: x => x.PlayerStateDetailId,
                        principalTable: "PlayerStateDetails",
                        principalColumn: "PlayerStateDetailId");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: true),
                    ExamResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_ExamResults_ExamResultId",
                        column: x => x.ExamResultId,
                        principalTable: "ExamResults",
                        principalColumn: "ExamResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTypeExams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTypeExams", x => new { x.ExamId, x.ExamTypeId });
                    table.ForeignKey(
                        name: "FK_ExamTypeExams_ExamTypes_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "ExamTypes",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamTypeExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerExams",
                columns: table => new
                {
                    PlayerExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerExams", x => x.PlayerExamId);
                    table.ForeignKey(
                        name: "FK_PlayerExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerExams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdvisorSpecializations",
                columns: new[] { "AdvisorSpecializationId", "AdvisorSpecializedIn" },
                values: new object[,]
                {
                    { 2, "Orthopedics" },
                    { 3, "Nutrition" },
                    { 4, "Rehabilitation" },
                    { 5, "Sports Psychology" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Professional" },
                    { 2, "Amateur" },
                    { 3, "Youth" },
                    { 4, "Senior" },
                    { 5, "Junior" }
                });

            migrationBuilder.InsertData(
                table: "CoachTypes",
                columns: new[] { "CoachTypeId", "CoachTypeName" },
                values: new object[,]
                {
                    { 1, "Head Coach" },
                    { 2, "Assistant Coach" },
                    { 3, "Trainer" },
                    { 4, "Specialist" },
                    { 5, "Analyst" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description", "EndDate", "Semester", "StartDate" },
                values: new object[,]
                {
                    { 1, "Sports Management", "Advanced course in sports management", new DateTime(2024, 5, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8374), "Fall 2023", new DateTime(2023, 11, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8372) },
                    { 2, "Sports Nutrition", "Understanding nutrition for athletic performance", new DateTime(2024, 6, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8376), "Fall 2023", new DateTime(2024, 1, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8375) },
                    { 3, "Sports Psychology", "Psychological aspects of sports and performance", new DateTime(2024, 7, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8378), "Fall 2023", new DateTime(2024, 2, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8377) },
                    { 4, "Sports Medicine", "Medical aspects of sports and athlete care", new DateTime(2024, 8, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8380), "Fall 2023", new DateTime(2024, 3, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8379) },
                    { 5, "Coaching Strategies", "Strategies for effective coaching in sports", new DateTime(2024, 9, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8382), "Fall 2023", new DateTime(2024, 4, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8381) }
                });

            migrationBuilder.InsertData(
                table: "ExamResults",
                columns: new[] { "ExamResultId", "ExamTitle", "PlayerStateDetailId" },
                values: new object[,]
                {
                    { 1, "Midterm Exam", null },
                    { 2, "Final Exam", null },
                    { 3, "Practical Assessment", null },
                    { 4, "Research Project", null },
                    { 5, "Case Study Presentation", null }
                });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "ExamTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Theory" },
                    { 2, "Practical" },
                    { 3, "Project" },
                    { 4, "Presentation" },
                    { 5, "Case Study" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "Address", "Email", "JoinDate", "ManagerName", "Phone", "Picture" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "john.manager@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7566), "John Manager", "123-456-7890", "manager1.jpg" },
                    { 2, "456 Broad Avenue", "alice.admin@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7586), "Alice Administrator", "987-654-3210", "manager2.jpg" },
                    { 3, "789 Pine Lane", "bob.lead@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7587), "Bob Team Lead", "555-123-4567", "manager3.jpg" },
                    { 4, "890 Oak Street", "eva.coordinator@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7589), "Eva Coordinator", "111-222-3333", "manager4.jpg" },
                    { 5, "567 Elm Road", "chris.supervisor@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7590), "Chris Supervisor", "444-555-6666", "manager5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "MedicalAdvisors",
                columns: new[] { "MedicalAdvisorId", "Address", "Designation", "Email", "JoinDate", "MedicalAdvisorName", "Phone", "Picture" },
                values: new object[,]
                {
                    { 1, "789 Elm Street", "Team Doctor", "dr.johnson@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7843), "Dr. Johnson", "555-123-4567", "advisor1.jpg" },
                    { 2, "456 Maple Avenue", "Sports Physio", "dr.smith@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7847), "Dr. Smith", "555-987-6543", "advisor2.jpg" },
                    { 3, "123 Oak Street", "Nutritionist", "dr.anderson@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7849), "Dr. Anderson", "555-345-6789", "advisor3.jpg" },
                    { 4, "789 Pine Avenue", "Psychologist", "dr.williams@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7854), "Dr. Williams", "555-678-9012", "advisor4.jpg" },
                    { 5, "101 Cedar Lane", "Rehab Specialist", "dr.davis@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7855), "Dr. Davis", "555-234-5678", "advisor5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PlayerRoles",
                columns: new[] { "PlayerRoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Team Player" },
                    { 2, "Captain" },
                    { 3, "All-Rounder" },
                    { 4, "Batsman" },
                    { 5, "Bowler" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "SportsName" },
                values: new object[,]
                {
                    { 1, "Cricket" },
                    { 2, "Football" },
                    { 3, "Basketball" },
                    { 4, "Volleyball" },
                    { 5, "Tennis" }
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "CoachId", "Address", "CoachName", "CoachTypeId", "Email", "JoinDate", "Phone", "Picture" },
                values: new object[,]
                {
                    { 1, "456 Oak Avenue", "Coach Smith", 1, "coach.smith@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7740), "987-654-3210", "coach1.jpg" },
                    { 2, "789 Maple Street", "Coach Johnson", 2, "coach.johnson@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7744), "123-456-7890", "coach2.jpg" },
                    { 3, "234 Birch Lane", "Coach Davis", 3, "coach.davis@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7786), "555-222-3333", "coach3.jpg" },
                    { 4, "567 Pine Road", "Coach Miller", 4, "coach.miller@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7788), "111-999-7777", "coach4.jpg" },
                    { 5, "890 Elm Avenue", "Coach Wilson", 5, "coach.wilson@example.com", new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(7790), "444-888-6666", "coach5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "CricketFormats",
                columns: new[] { "CricketFormatId", "FormatName", "SportId" },
                values: new object[,]
                {
                    { 1, "T20", 2 },
                    { 2, "ODI", 2 },
                    { 3, "Test", 2 },
                    { 4, "T10", 1 },
                    { 5, "One-Hour", 1 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "ExamDate", "ExamName", "ExamResultId", "Result" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8561), "Sports Science", 1, 85.5 },
                    { 2, new DateTime(2024, 2, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8565), "Nutrition Fundamentals", 2, 92.299999999999997 },
                    { 3, new DateTime(2024, 3, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8566), "Psychological Assessment", 3, 78.900000000000006 },
                    { 4, new DateTime(2024, 4, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8568), "Sports Injury Management", 4, 89.099999999999994 },
                    { 5, new DateTime(2024, 5, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8569), "Coaching Philosophies", 5, 94.700000000000003 }
                });

            migrationBuilder.InsertData(
                table: "MedicalAdvisorSpecializations",
                columns: new[] { "AdvisorSpecializationId", "MedicalAdvisorId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Captain", "SportId", "TeamLogo", "TeamName" },
                values: new object[,]
                {
                    { 2, "Player Captain 2", 2, "TeamLogo1.jpg", "Team B" },
                    { 3, "Player Captain 3", 3, "TeamLogo2.jpg", "Team C" },
                    { 4, "Player Captain 4", 4, "TeamLogo3.jpg", "Team D" },
                    { 5, "Player Captain 5", 5, "TeamLogo4.jpg", "Team E" },
                    { 6, "Player Captain 6", 1, "TeamLogo5.jpg", "Team F" }
                });

            migrationBuilder.InsertData(
                table: "CoachSpecializations",
                columns: new[] { "CoachSpecializationId", "CoachId", "SpecializedIn" },
                values: new object[,]
                {
                    { 1, 1, "Strategic Planning" },
                    { 2, 1, "Player Development" },
                    { 3, 2, "Tactics and Analysis" },
                    { 4, 3, "Fitness Training" },
                    { 5, 4, "Injury Rehabilitation" }
                });

            migrationBuilder.InsertData(
                table: "CoachSports",
                columns: new[] { "CoachId", "SportId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "CoachTeams",
                columns: new[] { "CoachId", "TeamId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "ExamTypeExams",
                columns: new[] { "ExamId", "ExamTypeId", "ExamTypeExamId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Address", "BirthDate", "CategoryId", "Email", "Phone", "Picture", "PlayerName", "RegistrationNumber", "TeamId" },
                values: new object[,]
                {
                    { 1, "456 Player Street", new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "player.one@example.com", "888-777-6666", "player1.jpg", "Player One", 1001, 2 },
                    { 2, "456 Player Street", new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "player.two@example.com", "888-777-6666", "player2.jpg", "Player Two", 1002, 2 },
                    { 3, "789 Player Lane", new DateTime(1995, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "player.three@example.com", "777-666-5555", "player3.jpg", "Player Three", 1003, 3 },
                    { 4, "101 Player Avenue", new DateTime(1988, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "player.four@example.com", "666-555-4444", "player4.jpg", "Player Four", 1004, 4 },
                    { 5, "202 Player Road", new DateTime(1993, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "player.five@example.com", "555-444-3333", "player5.jpg", "Player Five", 1005, 5 }
                });

            migrationBuilder.InsertData(
                table: "SelectionPanels",
                columns: new[] { "SelectionPanelId", "CoachId", "MedicalAdvisorId", "SelectionPanelName" },
                values: new object[,]
                {
                    { 1, 1, 1, "Selection Committee 1" },
                    { 2, 2, 2, "Selection Committee 2" },
                    { 3, 3, 3, "Selection Committee 3" },
                    { 4, 4, 4, "Selection Committee 4" },
                    { 5, 5, 5, "Selection Committee 5" }
                });

            migrationBuilder.InsertData(
                table: "TrainingSessions",
                columns: new[] { "TrainingSessionId", "CoachId", "Description", "SessionTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Training session to prepare for the season", new DateTime(2023, 12, 25, 8, 31, 41, 38, DateTimeKind.Local).AddTicks(8263), "Pre-Season Training" },
                    { 2, 2, "Focus on agility and overall conditioning", new DateTime(2024, 1, 25, 10, 31, 41, 38, DateTimeKind.Local).AddTicks(8266), "Agility and Conditioning" },
                    { 3, 3, "Drills to improve tactical understanding", new DateTime(2024, 2, 25, 9, 31, 41, 38, DateTimeKind.Local).AddTicks(8316), "Tactical Drills" },
                    { 4, 4, "Specialized training for speed and power", new DateTime(2024, 3, 25, 8, 31, 41, 38, DateTimeKind.Local).AddTicks(8318), "Speed and Power Training" },
                    { 5, 1, "Focus on player recovery and injury prevention", new DateTime(2024, 4, 25, 11, 31, 41, 38, DateTimeKind.Local).AddTicks(8320), "Recovery Session" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceId", "Date", "IsPresent", "TrainingSessionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), true, 1 },
                    { 2, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Local), true, 2 },
                    { 3, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Local), true, 3 },
                    { 4, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), true, 4 },
                    { 5, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Local), true, 5 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "EquipmentName", "TrainingSessionId" },
                values: new object[,]
                {
                    { 1, "Training Cones", 1 },
                    { 2, "Agility Ladders", 1 },
                    { 3, "Medicine Balls", 2 },
                    { 4, "Speed Hurdles", 3 },
                    { 5, "Resistance Bands", 4 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "EndDate", "EventName", "Location", "ManagerId", "Picture", "SelectionPanelId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Intensive training for the upcoming season", new DateTime(2023, 12, 31, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8209), "Training Camp", "Sports Complex", 1, "Fortuna Sittard.jpg", 1, new DateTime(2023, 12, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8207) },
                    { 2, "Building team cohesion and communication", new DateTime(2024, 1, 26, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8221), "Team Building Workshop", "Conference Center", 1, "JMS CRICKET ACADEMY.jpg", 1, new DateTime(2024, 1, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8218) },
                    { 3, "Friendly match to assess team performance", new DateTime(2024, 2, 25, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8223), "Scrimmage Match", "Stadium", 1, "Cricket Ground Equipment.jpg", 1, new DateTime(2024, 2, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8223) },
                    { 4, "Educating players on injury prevention techniques", new DateTime(2024, 3, 26, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8226), "Injury Prevention Workshop", "Training Facility", 1, "Cricket Ground Equipment.jpg", 1, new DateTime(2024, 3, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8225) },
                    { 5, "Planning team strategies for the upcoming matches", new DateTime(2024, 4, 25, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8228), "Team Strategy Session", "Team Meeting Room", 1, "Cricket Ground Equipment.jpg", 1, new DateTime(2024, 4, 24, 18, 31, 41, 38, DateTimeKind.Local).AddTicks(8227) }
                });

            migrationBuilder.InsertData(
                table: "PlayerCoaches",
                columns: new[] { "CoachId", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PlayerCourses",
                columns: new[] { "PlayerCourseId", "CourseId", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PlayerExams",
                columns: new[] { "PlayerExamId", "ExamId", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PlayerRolePlayers",
                columns: new[] { "PlayerId", "PlayerRoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PlayerSports",
                columns: new[] { "PlayerId", "SportId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStateDetails",
                columns: new[] { "PlayerStateDetailId", "Average", "Balls", "Comment", "Ducks", "Economy", "Fifty", "Fours", "Grade", "Highest", "Hundred", "Innings", "Maidens", "Marks", "Matches", "PlayerStatisticId", "Runs", "Sixs", "TrainingSessionId", "Wicket" },
                values: new object[,]
                {
                    { 1, 28.0, 200, "Excellent performance in the training session", 1, 3.0, 1, 40, "A", 80, 0, 8, 1, 85, 10, null, 250, 10, 1, 5 },
                    { 2, 30.0, 250, "Outstanding performance in the training session", 0, 3.5, 2, 50, "A+", 100, 1, 10, 2, 90, 12, null, 300, 12, 2, 8 },
                    { 3, 30.0, 150, "Good effort in the training session", 2, 3.2000000000000002, 1, 30, "B+", 90, 0, 6, 0, 78, 8, null, 180, 8, 3, 4 },
                    { 4, 32.0, 300, "Consistent performance in the training session", 1, 3.7999999999999998, 3, 60, "A", 120, 1, 14, 1, 88, 15, null, 400, 20, 4, 10 },
                    { 5, 40.0, 200, "Impressive performance in the training session", 0, 4.0, 2, 40, "A+", 110, 0, 10, 2, 92, 12, null, 300, 15, 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatistics",
                columns: new[] { "PlayerStatisticId", "Average", "Balls", "Ducks", "Economy", "Fifty", "Fours", "Highest", "Hundred", "Innings", "Maidens", "Matches", "PlayerId", "Runs", "Sixs", "Wicket" },
                values: new object[,]
                {
                    { 1, 27.0, 400, 2, 4.0, 2, 60, 120, 1, 18, 2, 20, 1, 500, 15, 10 },
                    { 2, 30.0, 450, 1, 4.0, 3, 75, 150, 2, 22, 3, 25, 2, 600, 20, 15 },
                    { 3, 25.0, 250, 3, 3.5, 1, 40, 100, 0, 12, 1, 15, 3, 300, 10, 5 },
                    { 4, 32.0, 600, 0, 4.5, 4, 90, 180, 3, 28, 4, 30, 4, 800, 25, 20 },
                    { 5, 28.0, 350, 1, 4.2000000000000002, 2, 70, 130, 1, 16, 2, 18, 5, 450, 18, 12 }
                });

            migrationBuilder.InsertData(
                table: "PlayerTrainingSessions",
                columns: new[] { "PlayerTrainingSessionId", "PlayerId", "TrainingSessionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TrainingSessionId",
                table: "Attendances",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CoachTypeId",
                table: "Coaches",
                column: "CoachTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachSpecializations_CoachId",
                table: "CoachSpecializations",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachSports_SportId",
                table: "CoachSports",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachTeams_TeamId",
                table: "CoachTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CricketFormats_SportId",
                table: "CricketFormats",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_TrainingSessionId",
                table: "Equipments",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ManagerId",
                table: "Events",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SelectionPanelId",
                table: "Events",
                column: "SelectionPanelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_PlayerStateDetailId",
                table: "ExamResults",
                column: "PlayerStateDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamResultId",
                table: "Exams",
                column: "ExamResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTypeExams_ExamTypeId",
                table: "ExamTypeExams",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAdvisorSpecializations_AdvisorSpecializationId",
                table: "MedicalAdvisorSpecializations",
                column: "AdvisorSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCoaches_CoachId",
                table: "PlayerCoaches",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCourses_CourseId",
                table: "PlayerCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCourses_PlayerId",
                table: "PlayerCourses",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerExams_ExamId",
                table: "PlayerExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerExams_PlayerId",
                table: "PlayerExams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRolePlayers_PlayerRoleId",
                table: "PlayerRolePlayers",
                column: "PlayerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CategoryId",
                table: "Players",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSports_SportId",
                table: "PlayerSports",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStateDetails_PlayerStatisticId",
                table: "PlayerStateDetails",
                column: "PlayerStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStateDetails_TrainingSessionId",
                table: "PlayerStateDetails",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_PlayerId",
                table: "PlayerStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTrainingSessions_PlayerId",
                table: "PlayerTrainingSessions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTrainingSessions_TrainingSessionId",
                table: "PlayerTrainingSessions",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectionPanels_CoachId",
                table: "SelectionPanels",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectionPanels_MedicalAdvisorId",
                table: "SelectionPanels",
                column: "MedicalAdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessions_CoachId",
                table: "TrainingSessions",
                column: "CoachId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "CoachSpecializations");

            migrationBuilder.DropTable(
                name: "CoachSports");

            migrationBuilder.DropTable(
                name: "CoachTeams");

            migrationBuilder.DropTable(
                name: "CricketFormats");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ExamTypeExams");

            migrationBuilder.DropTable(
                name: "MedicalAdvisorSpecializations");

            migrationBuilder.DropTable(
                name: "PlayerCoaches");

            migrationBuilder.DropTable(
                name: "PlayerCourses");

            migrationBuilder.DropTable(
                name: "PlayerExams");

            migrationBuilder.DropTable(
                name: "PlayerRolePlayers");

            migrationBuilder.DropTable(
                name: "PlayerSports");

            migrationBuilder.DropTable(
                name: "PlayerTrainingSessions");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "SelectionPanels");

            migrationBuilder.DropTable(
                name: "ExamTypes");

            migrationBuilder.DropTable(
                name: "AdvisorSpecializations");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "PlayerRoles");

            migrationBuilder.DropTable(
                name: "MedicalAdvisors");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "PlayerStateDetails");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");

            migrationBuilder.DropTable(
                name: "TrainingSessions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "CoachTypes");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
