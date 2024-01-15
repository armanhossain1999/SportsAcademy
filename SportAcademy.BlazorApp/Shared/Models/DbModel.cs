using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAcademy.BlazorApp.Shared.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        [Required, StringLength(100)]
        public string ManagerName { get; set; } = "";

        [Required, Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; } = default!;

        [Required, StringLength(100)]
        public string Email { get; set; } = "";

        [Required, StringLength(100)]
        public string Phone { get; set; } = "";

        [Required, StringLength(100)]
        public string Address { get; set; } = "";
        [Required, StringLength(50)]
        public string? Picture { get; set; } = default!;
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }

    public class Coach
    {
        public int CoachId { get; set; }

        [Required, StringLength(100)]
        public string CoachName { get; set; } = "";

        [Required, Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; } = default !;

        [Required, StringLength(100)]
        public string Email { get; set; } = "";

        [Required, StringLength(100)]
        public string Phone { get; set; } = "";

        [Required, StringLength(100)]
        public string Address { get; set; } = "";
        [Required, StringLength(50)]
        public string? Picture { get; set; } = default!;
        [ForeignKey("CoachType")]
        public int CoachTypeId { get; set; }
        public CoachType? CoachType { get; set; }
        public ICollection<CoachSport> CoachSports { get; set; } = new List<CoachSport>();
        public ICollection<CoachTeam> CoachTeams { get; set; } = new List<CoachTeam>();
        public ICollection<CoachSpecialization> CoachSpecializations { get; set; } = new List<CoachSpecialization>();
        public ICollection<SelectionPanel> SelectionPanels { get; set; } = new List<SelectionPanel>();

    }


    public class CoachType
    {
        public int CoachTypeId { get; set; }

        [Required, StringLength(100)]
        public string CoachTypeName { get; set; } = "";

        public ICollection<Coach> Coaches { get; set; } = new List<Coach>();
    }

    public class MedicalAdvisor
    {
        public int MedicalAdvisorId { get; set; }

        [Required, StringLength(100)]
        public string MedicalAdvisorName { get; set; } = "";

        [Required, StringLength(100)]
        public string Designation { get; set; } = "";

        [Required, Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; } = default!;

        [Required, StringLength(100)]
        public string Email { get; set; } = "";

        [Required, StringLength(100)]
        public string Phone { get; set; } = "";

        [Required, StringLength(100)]
        public string Address { get; set; } = "";
        [Required, StringLength(50)]
        public string? Picture { get; set; } = default!;
        public ICollection<MedicalAdvisorSpecialization> MedicalAdvisorSpecializations { get; set; } = new List<MedicalAdvisorSpecialization>();
    }

    public class AdvisorSpecialization
    {
        public int AdvisorSpecializationId { get; set; }

        [Required, StringLength(100)]
        public string AdvisorSpecializedIn { get; set; } = "";

        public ICollection<MedicalAdvisorSpecialization> MedicalAdvisorSpecializations { get; set; } = new List<MedicalAdvisorSpecialization>();
    }

    public class MedicalAdvisorSpecialization
    {
        public int MedicalAdvisorId { get; set; }
        public MedicalAdvisor? MedicalAdvisor { get; set; }

        public int AdvisorSpecializationId { get; set; }
        public AdvisorSpecialization? AdvisorSpecialization { get; set; }
    }

    public class SelectionPanel
    {
        [Key]
        public int SelectionPanelId { get; set; }
        public string SelectionPanelName { get; set; } = "";

        [ForeignKey("Coach")]
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }

        [ForeignKey("MedicalAdvisor")]
        public int MedicalAdvisorId { get; set; }
        public MedicalAdvisor? MedicalAdvisor { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }

    public class Sport
    {
        [Key]
        public int SportId { get; set; }

        [Required, StringLength(100)]
        public string SportsName { get; set; } = default!;
        public ICollection<Team> Teams { get; set; } = new List<Team>();
        public ICollection<CoachSport> CoachSports { get; set; } = new List<CoachSport>();
        public ICollection<PlayerSport> PlayerSports { get; set; } = new List<PlayerSport>();

    }

    public class CoachSport
    {
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
    }

    public class CricketFormat
    {
        [Key]
        public int CricketFormatId { get; set; }

        [Required, StringLength(100)]
        public string FormatName { get; set; } = "";

        [Required, ForeignKey("Sport")]
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
    }

    public class CoachSpecialization
    {
        public int CoachSpecializationId { get; set; }

        [Required, StringLength(100)]
        public string SpecializedIn { get; set; } = "";

        [ForeignKey("Coach")]
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        [Required, StringLength(50)]
        public string? Picture { get; set; } = default!;

        [ForeignKey("SelectionPanel")]
        public int SelectionPanelId { get; set; }
        public SelectionPanel? SelectionPanel { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }
    }

    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required, StringLength(100)]
        public string TeamName { get; set; } = "";

        [Required, StringLength(100)]
        public string Captain { get; set; } = "";
        [Required, StringLength(50)]
        public string? TeamLogo { get; set; } = default!;
        [Required, ForeignKey("Sport")]
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
        public ICollection<CoachTeam> CoachTeams { get; set; } = new List<CoachTeam>();
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }

    public class CoachTeam
    {
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }

    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public int RegistrationNumber { get; set; }

        [Required, StringLength(100)]
        public string PlayerName { get; set; } = default!;

        [Required, Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Required, StringLength(100)]
        public string Phone { get; set; } = default!;

        [Required, EmailAddress]
        public string Email { get; set; } = default!;

        [Required, StringLength(100)]
        public string Address { get; set; } = default!;
        [Required, StringLength(50)]
        public string? Picture { get; set; } = default!;

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();
        public ICollection<PlayerExam> PlayerExams { get; set; } = new List<PlayerExam>();
        public ICollection<PlayerRolePlayer> PlayerRolePlayers { get; set; } = new List<PlayerRolePlayer>();
        public ICollection<PlayerCourse> PlayerCourses { get; set; } = new List<PlayerCourse>();
        public ICollection<PlayerCoach> PlayerCoaches { get; set; } = new List<PlayerCoach>();
        public ICollection<PlayerSport> PlayerSports { get; set; } = new List<PlayerSport>();

    }

    public class PlayerCoach
    {
        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public int CoachId { get; set; }
        public Coach? Coach { get; set; }
    }

    public class PlayerRole
    {
        [Key]
        public int PlayerRoleId { get; set; }

        [Required, StringLength(100)]
        public string RoleName { get; set; } = "";
        public ICollection<PlayerRolePlayer> PlayerRolePlayers { get; set; } = new List<PlayerRolePlayer>();
    }

    public class PlayerRolePlayer
    {
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int PlayerRoleId { get; set; }
        public PlayerRole? PlayerRole { get; set; }
    }

    public class PlayerSport
    {
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string CategoryName { get; set; } = "";
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }

    public class PlayerStatistic
    {
        [Key]
        public int PlayerStatisticId { get; set; }
        public int? Matches { get; set; }
        public int? Innings { get; set; }
        public int? Runs { get; set; }
        public int? Balls { get; set; }
        public double? Average { get; set; }
        public int? Fifty { get; set; }
        public int? Hundred { get; set; }
        public int? Sixs { get; set; }
        public int? Fours { get; set; }
        public int? Highest { get; set; }
        public int? Ducks { get; set; }
        public int? Wicket { get; set; }
        public int? Maidens { get; set; }
        public double? Economy { get; set; }

        [Required, ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public ICollection<PlayerStateDetail> PlayerStateDetails { get; set; } = new List<PlayerStateDetail>();
    }

    public class PlayerStateDetail
    {
        [Key]
        public int PlayerStateDetailId { get; set; }
        public int? Matches { get; set; }
        public int? Innings { get; set; }
        public int? Runs { get; set; }
        public int? Balls { get; set; }
        public double? Average { get; set; }
        public int? Fifty { get; set; }
        public int? Hundred { get; set; }
        public int? Sixs { get; set; }
        public int? Fours { get; set; }
        public int? Highest { get; set; }
        public int? Ducks { get; set; }
        public int? Wicket { get; set; }
        public int? Maidens { get; set; }
        public double? Economy { get; set; }
        public int? Marks { get; set; }

        [Required, StringLength(100)]
        public string? Grade { get; set; }

        [Required, StringLength(100)]
        public string? Comment { get; set; }

        [Required, ForeignKey("TrainingSession")]
        public int TrainingSessionId { get; set; }
        public TrainingSession? TrainingSession { get; set; }

        public ICollection<ExamResult> ExamResult { get; set; } = new List<ExamResult>();
    }
    public class TrainingSession
    {
        [Key]
        public int TrainingSessionId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = default!;

        [Required, StringLength(100)]
        public string Description { get; set; } = default!;

        [Required, Column(TypeName = "date")]
        public DateTime? SessionTime { get; set; } = default!;

        public int CoachId { get; set; }
        public Coach? Coach { get; set; } = default!;

        public ICollection<PlayerTrainingSession> PlayerTrainingSessions { get; set; } = new List<PlayerTrainingSession>();
        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<PlayerStateDetail> StatDetails { get; set; } = new List<PlayerStateDetail>();
    }

    public class PlayerTrainingSession
    {
        [Key]
        public int PlayerTrainingSessionId { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; } = default!;

        public int TrainingSessionId { get; set; }
        public TrainingSession? TrainingSession { get; set; } = default!;
    }

    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public bool IsPresent { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Required]
        public int TrainingSessionId { get; set; }
        public TrainingSession? TrainingSession { get; set; } = default!;
    }

    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; } = default!;

        [Required, StringLength(100)]
        public string Semester { get; set; } = default!;

        [Required, Column(TypeName = "date")]
        public DateTime? StartDate { get; set; } = default!;

        [Required, Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; } = default!;

        public ICollection<PlayerCourse> PlayerCourses { get; set; } = new List<PlayerCourse>();
    }

    public class PlayerCourse
    {
        [Key]
        public int PlayerCourseId { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; } = default!;

        public int CourseId { get; set; }
        public Course? Course { get; set; } = default!;
    }

    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required, StringLength(100)]
        public string ExamName { get; set; } = default!;

        [Required, Column(TypeName = "date")]
        public DateTime? ExamDate { get; set; } = default!;
        public double? Result { get; set; }

        [Required]
        public int ExamResultId { get; set; }
        public ExamResult? ExamResult { get; set; } = default!;
        public ICollection<PlayerExam> PlayerExams { get; set; } = new List<PlayerExam>();
        public ICollection<ExamTypeExam> ExamTypeExams { get; set; } = new List<ExamTypeExam>();
    }

    public class PlayerExam
    {
        [Key]
        public int PlayerExamId { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; } = default!;

        public int ExamId { get; set; }
        public Exam? Exam { get; set; } = default!;
    }

    public class ExamType
    {
        [Key]
        public int ExamTypeId { get; set; }

        [Required, StringLength(100)]
        public string TypeName { get; set; } = default!;

        public ICollection<ExamTypeExam> ExamTypeExams { get; set; } = new List<ExamTypeExam>();
    }

    public class ExamTypeExam
    {
        [Key]
        public int ExamTypeExamId { get; set; }

        public int ExamId { get; set; }
        public Exam? Exam { get; set; } = default!;

        public int ExamTypeId { get; set; }
        public ExamType? ExamType { get; set; } = default!;
    }

    public class ExamResult
    {
        [Key]
        public int ExamResultId { get; set; }

        [Required, StringLength(100)]
        public string ExamTitle { get; set; } = default!;
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }

    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required, StringLength(100)]
        public string EquipmentName { get; set; } = default!;
        [Required]
        public int TrainingSessionId { get; set; }
        public TrainingSession? TrainingSession { get; set; }
    }

    public class SportsEdgeDbContext : DbContext
    {
        public SportsEdgeDbContext(DbContextOptions<SportsEdgeDbContext> options) : base(options) { }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<CoachType> CoachTypes { get; set; }
        public DbSet<MedicalAdvisor> MedicalAdvisors { get; set; }
        public DbSet<AdvisorSpecialization> AdvisorSpecializations { get; set; }
        public DbSet<MedicalAdvisorSpecialization> MedicalAdvisorSpecializations { get; set; }
        public DbSet<SelectionPanel> SelectionPanels { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<CoachSport> CoachSports { get; set; }
        public DbSet<CricketFormat> CricketFormats { get; set; }
        public DbSet<CoachSpecialization> CoachSpecializations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<CoachTeam> CoachTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerCoach> PlayerCoaches { get; set; }
        public DbSet<PlayerRole> PlayerRoles { get; set; }
        public DbSet<PlayerRolePlayer> PlayerRolePlayers { get; set; }
        public DbSet<PlayerSport> PlayerSports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<PlayerStateDetail> PlayerStateDetails { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<PlayerTrainingSession> PlayerTrainingSessions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PlayerCourse> PlayerCourses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<PlayerExam> PlayerExams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<ExamTypeExam> ExamTypeExams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure primary keys
            modelBuilder.Entity<Manager>().HasKey(m => m.ManagerId);
            modelBuilder.Entity<Coach>().HasKey(c => c.CoachId);
            modelBuilder.Entity<CoachType>().HasKey(ct => ct.CoachTypeId);
            modelBuilder.Entity<MedicalAdvisor>().HasKey(ma => ma.MedicalAdvisorId);
            modelBuilder.Entity<AdvisorSpecialization>().HasKey(ads => ads.AdvisorSpecializationId);
            modelBuilder.Entity<MedicalAdvisorSpecialization>().HasKey(mas => new { mas.MedicalAdvisorId, mas.AdvisorSpecializationId });
            modelBuilder.Entity<SelectionPanel>().HasKey(sp => sp.SelectionPanelId);
            modelBuilder.Entity<Sport>().HasKey(s => s.SportId);
            modelBuilder.Entity<CoachSport>().HasKey(cs => new { cs.CoachId, cs.SportId });
            modelBuilder.Entity<CricketFormat>().HasKey(cf => cf.CricketFormatId);
            modelBuilder.Entity<CoachSpecialization>().HasKey(cs => cs.CoachSpecializationId);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Team>().HasKey(t => t.TeamId);
            modelBuilder.Entity<CoachTeam>().HasKey(ct => new { ct.CoachId, ct.TeamId });
            modelBuilder.Entity<Player>().HasKey(p => p.PlayerId);
            modelBuilder.Entity<PlayerCoach>().HasKey(pc => new { pc.PlayerId, pc.CoachId });
            modelBuilder.Entity<PlayerRole>().HasKey(pr => pr.PlayerRoleId);
            modelBuilder.Entity<PlayerRolePlayer>().HasKey(prp => new { prp.PlayerId, prp.PlayerRoleId });
            modelBuilder.Entity<PlayerSport>().HasKey(ps => new { ps.PlayerId, ps.SportId });
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<PlayerStatistic>().HasKey(ps => ps.PlayerStatisticId);
            modelBuilder.Entity<PlayerStateDetail>().HasKey(psd => psd.PlayerStateDetailId);
            modelBuilder.Entity<TrainingSession>().HasKey(ts => ts.TrainingSessionId);
            modelBuilder.Entity<PlayerTrainingSession>().HasKey(pts => pts.PlayerTrainingSessionId);
            modelBuilder.Entity<Attendance>().HasKey(a => a.AttendanceId);
            modelBuilder.Entity<Course>().HasKey(c => c.CourseId);
            modelBuilder.Entity<PlayerCourse>().HasKey(pc => pc.PlayerCourseId);
            modelBuilder.Entity<Exam>().HasKey(e => e.ExamId);
            modelBuilder.Entity<PlayerExam>().HasKey(pe => pe.PlayerExamId);
            modelBuilder.Entity<ExamType>().HasKey(et => et.ExamTypeId);
            modelBuilder.Entity<ExamTypeExam>().HasKey(et => new { et.ExamId, et.ExamTypeId });
            modelBuilder.Entity<ExamResult>().HasKey(er => er.ExamResultId);
            modelBuilder.Entity<Equipment>().HasKey(eq => eq.EquipmentId);

            //...

            // Many-to-Many: Coach and Sport
            modelBuilder.Entity<CoachSport>().HasKey(cs => new { cs.CoachId, cs.SportId });
            modelBuilder.Entity<CoachSport>().HasOne(cs => cs.Coach).WithMany(c => c.CoachSports).HasForeignKey(cs => cs.CoachId);
            modelBuilder.Entity<CoachSport>().HasOne(cs => cs.Sport).WithMany(s => s.CoachSports).HasForeignKey(cs => cs.SportId);

            // Many-to-Many: Coach and Team
            modelBuilder.Entity<CoachTeam>().HasKey(ct => new { ct.CoachId, ct.TeamId });
            modelBuilder.Entity<CoachTeam>().HasOne(ct => ct.Coach).WithMany(c => c.CoachTeams).HasForeignKey(ct => ct.CoachId);
            modelBuilder.Entity<CoachTeam>().HasOne(ct => ct.Team).WithMany(t => t.CoachTeams).HasForeignKey(ct => ct.TeamId);

            // Many-to-Many: Player and Coach
            modelBuilder.Entity<PlayerCoach>().HasKey(pc => new { pc.PlayerId, pc.CoachId });
            modelBuilder.Entity<PlayerCoach>().HasOne(pc => pc.Player).WithMany(p => p.PlayerCoaches).HasForeignKey(pc => pc.PlayerId);            
         

            // Many-to-Many: Player and Role
            modelBuilder.Entity<PlayerRolePlayer>().HasKey(prp => new { prp.PlayerId, prp.PlayerRoleId });
            modelBuilder.Entity<PlayerRolePlayer>().HasOne(prp => prp.Player).WithMany(p => p.PlayerRolePlayers).HasForeignKey(prp => prp.PlayerId);
            modelBuilder.Entity<PlayerRolePlayer>().HasOne(prp => prp.PlayerRole).WithMany(pr => pr.PlayerRolePlayers).HasForeignKey(prp => prp.PlayerRoleId);

            // Many-to-Many: Player and Sport
            modelBuilder.Entity<PlayerSport>().HasKey(ps => new { ps.PlayerId, ps.SportId });
            modelBuilder.Entity<PlayerSport>()
            .HasKey(ps => new { ps.PlayerId, ps.SportId });
       

            // Many-to-Many: Exam and ExamType
            modelBuilder.Entity<ExamTypeExam>().HasKey(ete => new { ete.ExamId, ete.ExamTypeId });
            modelBuilder.Entity<ExamTypeExam>().HasOne(ete => ete.Exam).WithMany(e => e.ExamTypeExams).HasForeignKey(ete => ete.ExamId);
            modelBuilder.Entity<ExamTypeExam>().HasOne(ete => ete.ExamType).WithMany(et => et.ExamTypeExams).HasForeignKey(ete => ete.ExamTypeId);

            //...
            modelBuilder.Entity<PlayerSport>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerSports)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade, depending on your requirements

            modelBuilder.Entity<PlayerSport>()
                .HasOne(ps => ps.Sport)
                .WithMany(s => s.PlayerSports)
                .HasForeignKey(ps => ps.SportId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade, depending on your requirements

            // Manager
            modelBuilder.Entity<Manager>().HasData(
                new Manager { ManagerId = 1, ManagerName = "John Manager", JoinDate = DateTime.Now, Email = "john.manager@example.com", Phone = "123-456-7890", Address = "123 Main Street", Picture="manager1.jpg" },
                new Manager { ManagerId = 2, ManagerName = "Alice Administrator", JoinDate = DateTime.Now, Email = "alice.admin@example.com", Phone = "987-654-3210", Address = "456 Broad Avenue", Picture = "manager2.jpg" },
                new Manager { ManagerId = 3, ManagerName = "Bob Team Lead", JoinDate = DateTime.Now, Email = "bob.lead@example.com", Phone = "555-123-4567", Address = "789 Pine Lane", Picture = "manager3.jpg" },
                new Manager { ManagerId = 4, ManagerName = "Eva Coordinator", JoinDate = DateTime.Now, Email = "eva.coordinator@example.com", Phone = "111-222-3333", Address = "890 Oak Street", Picture = "manager4.jpg" },
                new Manager { ManagerId = 5, ManagerName = "Chris Supervisor", JoinDate = DateTime.Now, Email = "chris.supervisor@example.com", Phone = "444-555-6666", Address = "567 Elm Road", Picture = "manager5.jpg" }
            );


            // CoachType
            modelBuilder.Entity<CoachType>().HasData(
                new CoachType { CoachTypeId = 1, CoachTypeName = "Head Coach" },
                new CoachType { CoachTypeId = 2, CoachTypeName = "Assistant Coach" },
                new CoachType { CoachTypeId = 3, CoachTypeName = "Trainer" },
                new CoachType { CoachTypeId = 4, CoachTypeName = "Specialist" },
                new CoachType { CoachTypeId = 5, CoachTypeName = "Analyst" }
            );

            // Coach
            modelBuilder.Entity<Coach>().HasData(
                new Coach{CoachId = 1,CoachName = "Coach Smith",JoinDate = DateTime.Now,Email = "coach.smith@example.com",Phone = "987-654-3210",Address = "456 Oak Avenue",CoachTypeId = 1, Picture = "coach1.jpg" },
                new Coach{CoachId = 2,CoachName = "Coach Johnson",JoinDate = DateTime.Now,Email = "coach.johnson@example.com",Phone = "123-456-7890",Address = "789 Maple Street",CoachTypeId = 2, Picture = "coach2.jpg" },
                new Coach{CoachId = 3,CoachName = "Coach Davis",JoinDate = DateTime.Now,Email = "coach.davis@example.com",Phone = "555-222-3333",Address = "234 Birch Lane",CoachTypeId = 3, Picture = "coach3.jpg" },
                new Coach{CoachId = 4,CoachName = "Coach Miller",JoinDate = DateTime.Now,Email = "coach.miller@example.com",Phone = "111-999-7777",Address = "567 Pine Road",CoachTypeId = 4, Picture = "coach4.jpg" },
                new Coach{CoachId = 5,CoachName = "Coach Wilson",JoinDate = DateTime.Now,Email = "coach.wilson@example.com",Phone = "444-888-6666",Address = "890 Elm Avenue",CoachTypeId = 5, Picture = "coach5.jpg" }
            );

            // Sport
            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportId = 1, SportsName = "Cricket" },
                new Sport { SportId = 2, SportsName = "Football" },
                new Sport { SportId = 3, SportsName = "Basketball" },
                new Sport { SportId = 4, SportsName = "Volleyball" },
                new Sport { SportId = 5, SportsName = "Tennis" }
            );

            // CoachSport
            modelBuilder.Entity<CoachSport>().HasData(
                new CoachSport { CoachId = 1, SportId = 1 },
                new CoachSport { CoachId = 2, SportId = 2 },
                new CoachSport { CoachId = 3, SportId = 3 },
                new CoachSport { CoachId = 4, SportId = 4 },
                new CoachSport { CoachId = 5, SportId = 5 }
            );


            // MedicalAdvisor
            modelBuilder.Entity<MedicalAdvisor>().HasData(
                new MedicalAdvisor{MedicalAdvisorId = 1,MedicalAdvisorName = "Dr. Johnson",Designation = "Team Doctor",JoinDate = DateTime.Now,Email = "dr.johnson@example.com",Phone = "555-123-4567",Address = "789 Elm Street", Picture = "advisor1.jpg" },
                new MedicalAdvisor{MedicalAdvisorId = 2,MedicalAdvisorName = "Dr. Smith",Designation = "Sports Physio",JoinDate = DateTime.Now,Email = "dr.smith@example.com",Phone = "555-987-6543",Address = "456 Maple Avenue",Picture = "advisor2.jpg" },
                new MedicalAdvisor{MedicalAdvisorId = 3,MedicalAdvisorName = "Dr. Anderson",Designation = "Nutritionist",JoinDate = DateTime.Now,Email = "dr.anderson@example.com",Phone = "555-345-6789",Address = "123 Oak Street",Picture = "advisor3.jpg" },
                new MedicalAdvisor{MedicalAdvisorId = 4, MedicalAdvisorName = "Dr. Williams", Designation = "Psychologist",JoinDate = DateTime.Now, Email = "dr.williams@example.com", Phone = "555-678-9012",Address = "789 Pine Avenue", Picture = "advisor4.jpg" },
                new MedicalAdvisor{MedicalAdvisorId = 5,MedicalAdvisorName = "Dr. Davis",Designation = "Rehab Specialist",JoinDate = DateTime.Now,Email = "dr.davis@example.com",Phone = "555-234-5678",Address = "101 Cedar Lane", Picture = "advisor5.jpg" }
            );


            // AdvisorSpecialization
            modelBuilder.Entity<AdvisorSpecialization>().HasData(
                new AdvisorSpecialization{AdvisorSpecializationId = 2,AdvisorSpecializedIn = "Orthopedics"},
                new AdvisorSpecialization{AdvisorSpecializationId = 3,AdvisorSpecializedIn = "Nutrition"},
                new AdvisorSpecialization{AdvisorSpecializationId = 4,AdvisorSpecializedIn = "Rehabilitation"},
                new AdvisorSpecialization{AdvisorSpecializationId = 5,AdvisorSpecializedIn = "Sports Psychology"}
            );

            // MedicalAdvisorSpecialization
            modelBuilder.Entity<MedicalAdvisorSpecialization>().HasData(
                new MedicalAdvisorSpecialization{MedicalAdvisorId = 1,AdvisorSpecializationId = 2},
                new MedicalAdvisorSpecialization{MedicalAdvisorId = 1,AdvisorSpecializationId = 3},
                new MedicalAdvisorSpecialization{MedicalAdvisorId = 1,AdvisorSpecializationId = 4},
                new MedicalAdvisorSpecialization{MedicalAdvisorId = 1,AdvisorSpecializationId = 5}
            );

            // SelectionPanel
            modelBuilder.Entity<SelectionPanel>().HasData(
                new SelectionPanel{SelectionPanelId = 1, SelectionPanelName = "Selection Committee 1",CoachId = 1, MedicalAdvisorId = 1},
                new SelectionPanel{SelectionPanelId = 2, SelectionPanelName = "Selection Committee 2",CoachId = 2,MedicalAdvisorId = 2},
                new SelectionPanel{SelectionPanelId = 3, SelectionPanelName = "Selection Committee 3",CoachId = 3,MedicalAdvisorId = 3},           
                new SelectionPanel{SelectionPanelId = 4, SelectionPanelName = "Selection Committee 4",CoachId = 4,MedicalAdvisorId = 4},             
                new SelectionPanel{SelectionPanelId = 5, SelectionPanelName = "Selection Committee 5",CoachId = 5,MedicalAdvisorId = 5}
            );

            // Team
            modelBuilder.Entity<Team>().HasData(
                new Team{TeamId = 2,TeamName = "Team B",Captain = "Player Captain 2",SportId = 2, TeamLogo = "TeamLogo1.jpg" },
                new Team{TeamId = 3,TeamName = "Team C",Captain = "Player Captain 3",SportId = 3, TeamLogo = "TeamLogo2.jpg" },
                new Team{TeamId = 4,TeamName = "Team D",Captain = "Player Captain 4",SportId = 4, TeamLogo = "TeamLogo3.jpg" },
                new Team{TeamId = 5,TeamName = "Team E",Captain = "Player Captain 5",SportId = 5, TeamLogo = "TeamLogo4.jpg" },
                new Team{TeamId = 6,TeamName = "Team F",Captain = "Player Captain 6",SportId = 1,TeamLogo = "TeamLogo5.jpg" }
            );

            // CoachTeams
            modelBuilder.Entity<CoachTeam>().HasData(
                new CoachTeam
                {
        
                    CoachId = 1,
                    TeamId = 2
                },
                new CoachTeam
                {
        
                    CoachId = 2,
                    TeamId = 3
                },
                new CoachTeam
                {
        
                    CoachId = 3,
                    TeamId = 4
                },
                new CoachTeam
                {
        
                    CoachId = 4,
                    TeamId = 5
                },
                new CoachTeam
                {
        
                    CoachId = 5,
                    TeamId = 6
                }
            );


            // Player
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    PlayerId = 1,
                    RegistrationNumber = 1001,
                    PlayerName = "Player One",
                    BirthDate = DateTime.Parse("1992-03-15"),
                    Phone = "888-777-6666",
                    Email = "player.one@example.com",
                    Address = "456 Player Street",
                    TeamId = 2,
                    CategoryId = 2,
                    Picture= "player1.jpg"
                },
                new Player
                {
                    PlayerId = 2,
                    RegistrationNumber = 1002,
                    PlayerName = "Player Two",
                    BirthDate = DateTime.Parse("1992-03-15"),
                    Phone = "888-777-6666",
                    Email = "player.two@example.com",
                    Address = "456 Player Street",
                    TeamId = 2,
                    CategoryId = 2,
                    Picture = "player2.jpg"
                },
                new Player
                {
                    PlayerId = 3,
                    RegistrationNumber = 1003,
                    PlayerName = "Player Three",
                    BirthDate = DateTime.Parse("1995-07-20"),
                    Phone = "777-666-5555",
                    Email = "player.three@example.com",
                    Address = "789 Player Lane",
                    TeamId = 3,
                    CategoryId = 3,
                    Picture = "player3.jpg"
                },
                new Player
                {
                    PlayerId = 4,
                    RegistrationNumber = 1004,
                    PlayerName = "Player Four",
                    BirthDate = DateTime.Parse("1988-12-10"),
                    Phone = "666-555-4444",
                    Email = "player.four@example.com",
                    Address = "101 Player Avenue",
                    TeamId = 4,
                    CategoryId = 4,
                    Picture = "player4.jpg"
                },
                new Player
                {
                    PlayerId = 5,
                    RegistrationNumber = 1005,
                    PlayerName = "Player Five",
                    BirthDate = DateTime.Parse("1993-05-25"),
                    Phone = "555-444-3333",
                    Email = "player.five@example.com",
                    Address = "202 Player Road",
                    TeamId = 5,
                    CategoryId = 5,
                    Picture = "player5.jpg"
                }
            );


            // PlayerSport
            modelBuilder.Entity<PlayerSport>().HasData(
                new PlayerSport
                {
                    PlayerId = 1,
                    SportId = 1
                },
                new PlayerSport
                {
                    PlayerId = 1,
                    SportId = 2
                },
                new PlayerSport
                {
                    PlayerId = 2,
                    SportId = 1
                },
                new PlayerSport
                {
                    PlayerId = 2,
                    SportId = 2
                },
                new PlayerSport
                {
                    PlayerId = 3,
                    SportId = 1
                }
            );

            // PlayerRole
            modelBuilder.Entity<PlayerRole>().HasData(
                new PlayerRole
                {
                    PlayerRoleId = 1,
                    RoleName = "Team Player"
                },
                new PlayerRole
                {
                    PlayerRoleId = 2,
                    RoleName = "Captain"
                },
                new PlayerRole
                {
                    PlayerRoleId = 3,
                    RoleName = "All-Rounder"
                },
                new PlayerRole
                {
                    PlayerRoleId = 4,
                    RoleName = "Batsman"
                },
                new PlayerRole
                {
                    PlayerRoleId = 5,
                    RoleName = "Bowler"
                }
            );

            // PlayerRolePlayer
            modelBuilder.Entity<PlayerRolePlayer>().HasData(
                new PlayerRolePlayer
                {
                    PlayerId = 1,
                    PlayerRoleId = 1
                },
                new PlayerRolePlayer
                {
                    PlayerId = 2,
                    PlayerRoleId = 2
                },
                new PlayerRolePlayer
                {
                    PlayerId = 3,
                    PlayerRoleId = 3
                },
                new PlayerRolePlayer
                {
                    PlayerId = 4,
                    PlayerRoleId = 4
                },
                new PlayerRolePlayer
                {
                    PlayerId = 5,
                    PlayerRoleId = 5
                }
            );

            // Category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Professional"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Amateur"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Youth"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Senior"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Junior"
                }
            );

            // CricketFormat
            modelBuilder.Entity<CricketFormat>().HasData(
                new CricketFormat
                {
                    CricketFormatId = 1,
                    FormatName = "T20",
                    SportId = 2
                },
                new CricketFormat
                {
                    CricketFormatId = 2,
                    FormatName = "ODI",
                    SportId = 2
                },
                new CricketFormat
                {
                    CricketFormatId = 3,
                    FormatName = "Test",
                    SportId = 2
                },
                new CricketFormat
                {
                    CricketFormatId = 4,
                    FormatName = "T10",
                    SportId = 1
                },
                new CricketFormat
                {
                    CricketFormatId = 5,
                    FormatName = "One-Hour",
                    SportId = 1
                }
            );

            // CoachSpecialization
            modelBuilder.Entity<CoachSpecialization>().HasData(
                new CoachSpecialization
                {
                    CoachSpecializationId = 1,
                    SpecializedIn = "Strategic Planning",
                    CoachId = 1
                },
                new CoachSpecialization
                {
                    CoachSpecializationId = 2,
                    SpecializedIn = "Player Development",
                    CoachId = 1
                },
                new CoachSpecialization
                {
                    CoachSpecializationId = 3,
                    SpecializedIn = "Tactics and Analysis",
                    CoachId = 2
                },
                new CoachSpecialization
                {
                    CoachSpecializationId = 4,
                    SpecializedIn = "Fitness Training",
                    CoachId = 3
                },
                new CoachSpecialization
                {
                    CoachSpecializationId = 5,
                    SpecializedIn = "Injury Rehabilitation",
                    CoachId = 4
                }
            );


            // Event
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    EventName = "Training Camp",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Description = "Intensive training for the upcoming season",
                    Location = "Sports Complex",
                    SelectionPanelId = 1,
                    ManagerId = 1,
                    Picture = "Fortuna Sittard.jpg"
                },
                new Event
                {
                    EventId = 2,
                    EventName = "Team Building Workshop",
                    StartDate = DateTime.Now.AddMonths(1),
                    EndDate = DateTime.Now.AddMonths(1).AddDays(2),
                    Description = "Building team cohesion and communication",
                    Location = "Conference Center",
                    SelectionPanelId = 1,
                    ManagerId = 1,
                    Picture = "JMS CRICKET ACADEMY.jpg"
                },
                new Event
                {
                    EventId = 3,
                    EventName = "Scrimmage Match",
                    StartDate = DateTime.Now.AddMonths(2),
                    EndDate = DateTime.Now.AddMonths(2).AddDays(1),
                    Description = "Friendly match to assess team performance",
                    Location = "Stadium",
                    SelectionPanelId = 1,
                    ManagerId = 1,
                    Picture = "Cricket Ground Equipment.jpg"
                },
                new Event
                {
                    EventId = 4,
                    EventName = "Injury Prevention Workshop",
                    StartDate = DateTime.Now.AddMonths(3),
                    EndDate = DateTime.Now.AddMonths(3).AddDays(2),
                    Description = "Educating players on injury prevention techniques",
                    Location = "Training Facility",
                    SelectionPanelId = 1,
                    ManagerId = 1,
                    Picture = "Cricket Ground Equipment.jpg"
                },
                new Event
                {
                    EventId = 5,
                    EventName = "Team Strategy Session",
                    StartDate = DateTime.Now.AddMonths(4),
                    EndDate = DateTime.Now.AddMonths(4).AddDays(1),
                    Description = "Planning team strategies for the upcoming matches",
                    Location = "Team Meeting Room",
                    SelectionPanelId = 1,
                    ManagerId = 1,
                    Picture = "Cricket Ground Equipment.jpg"
                }
            );

            // Equipment
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    EquipmentId = 1,
                    EquipmentName = "Training Cones",
                    TrainingSessionId = 1,
                },
                new Equipment
                {
                    EquipmentId = 2,
                    EquipmentName = "Agility Ladders",
                    TrainingSessionId = 1,
                },
                new Equipment
                {
                    EquipmentId = 3,
                    EquipmentName = "Medicine Balls",
                    TrainingSessionId = 2,
                },
                new Equipment
                {
                    EquipmentId = 4,
                    EquipmentName = "Speed Hurdles",
                    TrainingSessionId = 3,
                },
                new Equipment
                {
                    EquipmentId = 5,
                    EquipmentName = "Resistance Bands",
                    TrainingSessionId = 4,
                }
            );

            // TrainingSession
            modelBuilder.Entity<TrainingSession>().HasData(
                new TrainingSession
                {
                    TrainingSessionId = 1,
                    Title = "Pre-Season Training",
                    Description = "Training session to prepare for the season",
                    SessionTime = DateTime.Now.AddHours(14),
                    CoachId = 1
                },
                new TrainingSession
                {
                    TrainingSessionId = 2,
                    Title = "Agility and Conditioning",
                    Description = "Focus on agility and overall conditioning",
                    SessionTime = DateTime.Now.AddMonths(1).AddHours(16),
                    CoachId = 2
                },
                new TrainingSession
                {
                    TrainingSessionId = 3,
                    Title = "Tactical Drills",
                    Description = "Drills to improve tactical understanding",
                    SessionTime = DateTime.Now.AddMonths(2).AddHours(15),
                    CoachId = 3
                },
                new TrainingSession
                {
                    TrainingSessionId = 4,
                    Title = "Speed and Power Training",
                    Description = "Specialized training for speed and power",
                    SessionTime = DateTime.Now.AddMonths(3).AddHours(14),
                    CoachId = 4
                },
                new TrainingSession
                {
                    TrainingSessionId = 5,
                    Title = "Recovery Session",
                    Description = "Focus on player recovery and injury prevention",
                    SessionTime = DateTime.Now.AddMonths(4).AddHours(17),
                    CoachId = 1
                }
            );

            // PlayerTrainingSession
            modelBuilder.Entity<PlayerTrainingSession>().HasData(
                new PlayerTrainingSession
                {
                    PlayerTrainingSessionId = 1,
                    PlayerId = 1,
                    TrainingSessionId = 1
                },
                new PlayerTrainingSession
                {
                    PlayerTrainingSessionId = 2,
                    PlayerId = 2,
                    TrainingSessionId = 2
                },
                new PlayerTrainingSession
                {
                    PlayerTrainingSessionId = 3,
                    PlayerId = 3,
                    TrainingSessionId = 3
                },
                new PlayerTrainingSession
                {
                    PlayerTrainingSessionId = 4,
                    PlayerId = 4,
                    TrainingSessionId = 4
                },
                new PlayerTrainingSession
                {
                    PlayerTrainingSessionId = 5,
                    PlayerId = 5,
                    TrainingSessionId = 5
                }
            );

            // Attendance
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance
                {
                    AttendanceId = 1,
                    IsPresent = true,
                    Date = DateTime.Now.Date,
                    TrainingSessionId = 1
                },
                new Attendance
                {
                    AttendanceId = 2,
                    IsPresent = true,
                    Date = DateTime.Now.AddMonths(1).Date,
                    TrainingSessionId = 2
                },
                new Attendance
                {
                    AttendanceId = 3,
                    IsPresent = true,
                    Date = DateTime.Now.AddMonths(2).Date,
                    TrainingSessionId = 3
                },
                new Attendance
                {
                    AttendanceId = 4,
                    IsPresent = true,
                    Date = DateTime.Now.AddMonths(3).Date,
                    TrainingSessionId = 4
                },
                new Attendance
                {
                    AttendanceId = 5,
                    IsPresent = true,
                    Date = DateTime.Now.AddMonths(4).Date,
                    TrainingSessionId = 5
                }
            );

            // Course
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Sports Management",
                    Semester = "Fall 2023",
                    StartDate = DateTime.Now.AddMonths(-1),
                    EndDate = DateTime.Now.AddMonths(5),
                    Description = "Advanced course in sports management"
                },
                new Course
                {
                    CourseId = 2,
                    CourseName = "Sports Nutrition",
                    Semester = "Fall 2023",
                    StartDate = DateTime.Now.AddMonths(1),
                    EndDate = DateTime.Now.AddMonths(6),
                    Description = "Understanding nutrition for athletic performance"
                },
                new Course
                {
                    CourseId = 3,
                    CourseName = "Sports Psychology",
                    Semester = "Fall 2023",
                    StartDate = DateTime.Now.AddMonths(2),
                    EndDate = DateTime.Now.AddMonths(7),
                    Description = "Psychological aspects of sports and performance"
                },
                new Course
                {
                    CourseId = 4,
                    CourseName = "Sports Medicine",
                    Semester = "Fall 2023",
                    StartDate = DateTime.Now.AddMonths(3),
                    EndDate = DateTime.Now.AddMonths(8),
                    Description = "Medical aspects of sports and athlete care"
                },
                new Course
                {
                    CourseId = 5,
                    CourseName = "Coaching Strategies",
                    Semester = "Fall 2023",
                    StartDate = DateTime.Now.AddMonths(4),
                    EndDate = DateTime.Now.AddMonths(9),
                    Description = "Strategies for effective coaching in sports"
                }
            );

            // PlayerCourse
            modelBuilder.Entity<PlayerCourse>().HasData(
                new PlayerCourse
                {
                    PlayerCourseId = 1,
                    PlayerId = 1,
                    CourseId = 1
                },
                new PlayerCourse
                {
                    PlayerCourseId = 2,
                    PlayerId = 2,
                    CourseId = 2
                },
                new PlayerCourse
                {
                    PlayerCourseId = 3,
                    PlayerId = 3,
                    CourseId = 3
                },
                new PlayerCourse
                {
                    PlayerCourseId = 4,
                    PlayerId = 4,
                    CourseId = 4
                },
                new PlayerCourse
                {
                    PlayerCourseId = 5,
                    PlayerId = 5,
                    CourseId = 5
                }
            );
            // PlayerCoach
            modelBuilder.Entity<PlayerCoach>().HasData(
                new PlayerCoach
                {
                    PlayerId = 1,
                    CoachId = 1
                },
                new PlayerCoach
                {
                    PlayerId = 2,
                    CoachId = 2
                },
                new PlayerCoach
                {
                    PlayerId = 3,
                    CoachId = 3
                },
                new PlayerCoach
                {
                    PlayerId = 4,
                    CoachId = 4
                },
                new PlayerCoach
                {
                    PlayerId = 5,
                    CoachId = 5
                }
            );
            // PlayerStatistic
            modelBuilder.Entity<PlayerStatistic>().HasData(
                new PlayerStatistic
                {
                    PlayerStatisticId = 1,
                    Matches = 20,
                    Innings = 18,
                    Runs = 500,
                    Balls = 400,
                    Average = 27,
                    Fifty = 2,
                    Hundred = 1,
                    Sixs = 15,
                    Fours = 60,
                    Highest = 120,
                    Ducks = 2,
                    Wicket = 10,
                    Maidens = 2,
                    Economy = 4,
                    PlayerId = 1
                },
                new PlayerStatistic
                {
                    PlayerStatisticId = 2,
                    Matches = 25,
                    Innings = 22,
                    Runs = 600,
                    Balls = 450,
                    Average = 30,
                    Fifty = 3,
                    Hundred = 2,
                    Sixs = 20,
                    Fours = 75,
                    Highest = 150,
                    Ducks = 1,
                    Wicket = 15,
                    Maidens = 3,
                    Economy = 4,
                    PlayerId = 2
                },
                new PlayerStatistic
                {
                    PlayerStatisticId = 3,
                    Matches = 15,
                    Innings = 12,
                    Runs = 300,
                    Balls = 250,
                    Average = 25,
                    Fifty = 1,
                    Hundred = 0,
                    Sixs = 10,
                    Fours = 40,
                    Highest = 100,
                    Ducks = 3,
                    Wicket = 5,
                    Maidens = 1,
                    Economy = 3.5,
                    PlayerId = 3
                },
                new PlayerStatistic
                {
                    PlayerStatisticId = 4,
                    Matches = 30,
                    Innings = 28,
                    Runs = 800,
                    Balls = 600,
                    Average = 32,
                    Fifty = 4,
                    Hundred = 3,
                    Sixs = 25,
                    Fours = 90,
                    Highest = 180,
                    Ducks = 0,
                    Wicket = 20,
                    Maidens = 4,
                    Economy = 4.5,
                    PlayerId = 4
                },
                new PlayerStatistic
                {
                    PlayerStatisticId = 5,
                    Matches = 18,
                    Innings = 16,
                    Runs = 450,
                    Balls = 350,
                    Average = 28,
                    Fifty = 2,
                    Hundred = 1,
                    Sixs = 18,
                    Fours = 70,
                    Highest = 130,
                    Ducks = 1,
                    Wicket = 12,
                    Maidens = 2,
                    Economy = 4.2,
                    PlayerId = 5
                }
            );

            // PlayerStateDetail
            modelBuilder.Entity<PlayerStateDetail>().HasData(
                new PlayerStateDetail
                {
                    PlayerStateDetailId = 1,
                    Matches = 10,
                    Innings = 8,
                    Runs = 250,
                    Balls = 200,
                    Average = 28,
                    Fifty = 1,
                    Hundred = 0,
                    Sixs = 10,
                    Fours = 40,
                    Highest = 80,
                    Ducks = 1,
                    Wicket = 5,
                    Maidens = 1,
                    Economy = 3,
                    Marks = 85,
                    Grade = "A",
                    Comment = "Excellent performance in the training session",
                    TrainingSessionId = 1
                },
                new PlayerStateDetail
                {
                    PlayerStateDetailId = 2,
                    Matches = 12,
                    Innings = 10,
                    Runs = 300,
                    Balls = 250,
                    Average = 30,
                    Fifty = 2,
                    Hundred = 1,
                    Sixs = 12,
                    Fours = 50,
                    Highest = 100,
                    Ducks = 0,
                    Wicket = 8,
                    Maidens = 2,
                    Economy = 3.5,
                    Marks = 90,
                    Grade = "A+",
                    Comment = "Outstanding performance in the training session",
                    TrainingSessionId = 2
                },
                new PlayerStateDetail
                {
                    PlayerStateDetailId = 3,
                    Matches = 8,
                    Innings = 6,
                    Runs = 180,
                    Balls = 150,
                    Average = 30,
                    Fifty = 1,
                    Hundred = 0,
                    Sixs = 8,
                    Fours = 30,
                    Highest = 90,
                    Ducks = 2,
                    Wicket = 4,
                    Maidens = 0,
                    Economy = 3.2,
                    Marks = 78,
                    Grade = "B+",
                    Comment = "Good effort in the training session",
                    TrainingSessionId = 3
                },
                new PlayerStateDetail
                {
                    PlayerStateDetailId = 4,
                    Matches = 15,
                    Innings = 14,
                    Runs = 400,
                    Balls = 300,
                    Average = 32,
                    Fifty = 3,
                    Hundred = 1,
                    Sixs = 20,
                    Fours = 60,
                    Highest = 120,
                    Ducks = 1,
                    Wicket = 10,
                    Maidens = 1,
                    Economy = 3.8,
                    Marks = 88,
                    Grade = "A",
                    Comment = "Consistent performance in the training session",
                    TrainingSessionId = 4
                },
                new PlayerStateDetail
                {
                    PlayerStateDetailId = 5,
                    Matches = 12,
                    Innings = 10,
                    Runs = 300,
                    Balls = 200,
                    Average = 40,
                    Fifty = 2,
                    Hundred = 0,
                    Sixs = 15,
                    Fours = 40,
                    Highest = 110,
                    Ducks = 0,
                    Wicket = 6,
                    Maidens = 2,
                    Economy = 4,
                    Marks = 92,
                    Grade = "A+",
                    Comment = "Impressive performance in the training session",
                    TrainingSessionId = 5
                }
            );

            // ExamResult
            modelBuilder.Entity<ExamResult>().HasData(
                new ExamResult
                {
                    ExamResultId = 1,
                    ExamTitle = "Midterm Exam"
                },
                new ExamResult
                {
                    ExamResultId = 2,
                    ExamTitle = "Final Exam"
                },
                new ExamResult
                {
                    ExamResultId = 3,
                    ExamTitle = "Practical Assessment"
                },
                new ExamResult
                {
                    ExamResultId = 4,
                    ExamTitle = "Research Project"
                },
                new ExamResult
                {
                    ExamResultId = 5,
                    ExamTitle = "Case Study Presentation"
                }
            );

            // Exam
            modelBuilder.Entity<Exam>().HasData(
                new Exam
                {
                    ExamId = 1,
                    ExamName = "Sports Science",
                    ExamDate = DateTime.Now.AddMonths(1),
                    Result = 85.5,
                    ExamResultId = 1
                },
                new Exam
                {
                    ExamId = 2,
                    ExamName = "Nutrition Fundamentals",
                    ExamDate = DateTime.Now.AddMonths(2),
                    Result = 92.3,
                    ExamResultId = 2
                },
                new Exam
                {
                    ExamId = 3,
                    ExamName = "Psychological Assessment",
                    ExamDate = DateTime.Now.AddMonths(3),
                    Result = 78.9,
                    ExamResultId = 3
                },
                new Exam
                {
                    ExamId = 4,
                    ExamName = "Sports Injury Management",
                    ExamDate = DateTime.Now.AddMonths(4),
                    Result = 89.1,
                    ExamResultId = 4
                },
                new Exam
                {
                    ExamId = 5,
                    ExamName = "Coaching Philosophies",
                    ExamDate = DateTime.Now.AddMonths(5),
                    Result = 94.7,
                    ExamResultId = 5
                }
            );

            // PlayerExam
            modelBuilder.Entity<PlayerExam>().HasData(
                new PlayerExam
                {
                    PlayerExamId = 1,
                    PlayerId = 1,
                    ExamId = 1
                },
                new PlayerExam
                {
                    PlayerExamId = 2,
                    PlayerId = 2,
                    ExamId = 2
                },
                new PlayerExam
                {
                    PlayerExamId = 3,
                    PlayerId = 3,
                    ExamId = 3
                },
                new PlayerExam
                {
                    PlayerExamId = 4,
                    PlayerId = 4,
                    ExamId = 4
                },
                new PlayerExam
                {
                    PlayerExamId = 5,
                    PlayerId = 5,
                    ExamId = 5
                }
            );

            // ExamType
            modelBuilder.Entity<ExamType>().HasData(
                new ExamType
                {
                    ExamTypeId = 1,
                    TypeName = "Theory"
                },
                new ExamType
                {
                    ExamTypeId = 2,
                    TypeName = "Practical"
                },
                new ExamType
                {
                    ExamTypeId = 3,
                    TypeName = "Project"
                },
                new ExamType
                {
                    ExamTypeId = 4,
                    TypeName = "Presentation"
                },
                new ExamType
                {
                    ExamTypeId = 5,
                    TypeName = "Case Study"
                }
            );

            // ExamTypeExam
            modelBuilder.Entity<ExamTypeExam>().HasData(
                new ExamTypeExam
                {
                    ExamTypeExamId = 1,
                    ExamId = 1,
                    ExamTypeId = 1
                },
                new ExamTypeExam
                {
                    ExamTypeExamId = 2,
                    ExamId = 2,
                    ExamTypeId = 2
                },
                new ExamTypeExam
                {
                    ExamTypeExamId = 3,
                    ExamId = 3,
                    ExamTypeId = 3
                },
                new ExamTypeExam
                {
                    ExamTypeExamId = 4,
                    ExamId = 4,
                    ExamTypeId = 4
                },
                new ExamTypeExam
                {
                    ExamTypeExamId = 5,
                    ExamId = 5,
                    ExamTypeId = 5
                }
            );

        }
    }
}
