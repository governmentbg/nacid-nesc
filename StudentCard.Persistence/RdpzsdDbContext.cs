using Microsoft.EntityFrameworkCore;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using StudentCard.Data.Rdpzsd.Nomenclatures.Others;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Rdpzsd.Students.Parts.History;
using StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Persistence
{
    public class RdpzsdDbContext : DbContext, IRdpzsdDbContext
    {
        public RdpzsdDbContext(DbContextOptions<RdpzsdDbContext> options)
            : base(options)
        {
        }

        #region Rdpzsd
        public DbSet<PersonLot> PersonLots { get; set; }
        public DbSet<PersonLotAction> PersonLotActions { get; set; }
        public DbSet<PersonBasic> PersonBasics { get; set; }
        public DbSet<PersonBasicInfo> PersonBasicInfos { get; set; }
        public DbSet<PersonImage> PersonImages { get; set; }
        public DbSet<PassportCopy> PassportCopies { get; set; }

        public DbSet<PersonSecondary> PersonSecondaries { get; set; }
        public DbSet<PersonSecondaryInfo> PersonSecondaryInfos { get; set; }

        public DbSet<PersonBasicHistory> PersonBasicHistories { get; set; }
        public DbSet<PersonBasicHistoryInfo> PersonBasicHistoryInfos { get; set; }
        public DbSet<PersonImageHistory> PersonImageHistories { get; set; }
        public DbSet<PassportCopyHistory> PassportCopyHistories { get; set; }


        public DbSet<PersonStudent> PersonStudents { get; set; }
        public DbSet<PersonStudentInfo> PersonStudentInfos { get; set; }
        public DbSet<PersonStudentSemester> PersonStudentSemesters { get; set; }
        public DbSet<PersonStudentDiploma> PersonStudentDiplomas { get; set; }
        public DbSet<PersonStudentDiplomaFile> PersonStudentDiplomaFile { get; set; }
        public DbSet<PersonStudentProtocol> PersonStudentProtocols { get; set; }
        public DbSet<PersonStudentDuplicateDiploma> PersonStudentDuplicateDiplomas { get; set; }
        public DbSet<PersonStudentSemesterRelocatedFile> PersonStudentSemesterRelocatedFiles { get; set; }


        public DbSet<PersonDoctoral> PersonDoctorals { get; set; }
        public DbSet<PersonDoctoralInfo> PersonDoctoralInfos { get; set; }
        public DbSet<PersonDoctoralSemester> PersonDoctoralSemesters { get; set; }
        public DbSet<PersonDoctoralSemesterRelocatedFile> PersonDoctoralSemesterRelocatedFiles { get; set; }
        #endregion

        #region Nomenclatures
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionSpeciality> InstitutionSpecialities { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<ResearchArea> ResearchAreas { get; set; }
        public DbSet<EducationalForm> EducationalForms { get; set; }
        public DbSet<EducationalQualification> EducationalQualifications { get; set; }

        public DbSet<Period> Periods { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<AdmissionReason> AdmissionReasons { get; set; }
        public DbSet<EducationFeeType> EducationFeeTypes { get; set; }
        public DbSet<AdmissionReasonEducationFee> AdmissionReasonEducationFees { get; set; }

        public DbSet<StudentStatus> StudentStatuses { get; set; }
        public DbSet<StudentEvent> StudentEvents { get; set; }
        public DbSet<StudentEventQualification> StudentEventQualifications { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfigurations(modelBuilder);
            DisableCascadeDelete(modelBuilder);
            ConfigurePgSqlNameMappings(modelBuilder);
        }

        protected void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                   .Where(t => t.GetInterfaces().Any(gi =>
                       gi.IsGenericType
                       && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)) && t.Namespace == "StudentCard.Persistence.Configurations.Rdpzsd")
                   .ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        protected void DisableCascadeDelete(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership
                    && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(e => e.DeleteBehavior = DeleteBehavior.Restrict);
        }

        protected void ConfigurePgSqlNameMappings(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Configure pgsql table names convention.
                entity.SetTableName(entity.ClrType.Name.ToLower());

                // Configure pgsql column names convention.
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.Name.ToLower());
            }
        }
    }
}
